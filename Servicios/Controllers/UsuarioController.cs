using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoPrueba.Entidades;
using ProyectoPrueba.Repositorios;

namespace Servicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IRepositorioUsuarios _repositorioUsuarios;

        public UsuarioController(IRepositorioUsuarios repositorioUsuarios)
        {
            this._repositorioUsuarios = repositorioUsuarios;
        }

        [HttpPost("autentificacion")]

        public async Task<IActionResult> Autentificacion(Usuario usuario)
        {
            if (usuario == null)
                return BadRequest(new { Message = "El usuario no puede ser nulo." });

            try
            {
                // Autenticación del usuario
                var usuarioAutenticado = await _repositorioUsuarios.Autentificacion(usuario);

                if (usuarioAutenticado == null)
                {
                    return NotFound(new { Message = "Usuario no encontrado" });
                }
                else
                {
                    return Ok(new { Id = usuarioAutenticado.Id, Message = "Login exitoso" });
                }

                
            }
            catch (Exception ex)
            {
                // Manejo de excepciones: puedes registrar el error en tus logs
                return StatusCode(500, new { Message = "Ocurrió un error en el servidor." });
            }
        }


        [HttpPost("Registar")]
        public async Task<IActionResult> Post(Usuario usuario)
        {
            if (usuario == null)
                return BadRequest();
            try
            {
                var id = await _repositorioUsuarios.Agregar(usuario);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetId(int id)
        {
            try
            {
                var producto = await _repositorioUsuarios.ConsultarPorId(id);
                return Ok(producto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

    }
}
