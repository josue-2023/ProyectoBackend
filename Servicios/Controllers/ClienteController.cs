using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoPrueba.Entidades;
using ProyectoPrueba.Repositorios;

namespace Servicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IRepositorioClientes _repositorioClientes;

        public ClienteController(IRepositorioClientes repositorioClientes)
        {
            this._repositorioClientes = repositorioClientes;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Cliente cliente)
        {
            try
            {
                var id = await _repositorioClientes.Agregar(cliente);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var lstCliente = await _repositorioClientes.ObtenerTodos();
                return Ok(lstCliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("estado")]
        public async Task<IActionResult> GetEstado()
        {
            try
            {
                var lstCliente = await _repositorioClientes.EstadoCliente();
                return Ok(lstCliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Cliente cliente)
        {
            try
            {

                await _repositorioClientes.Modificar(cliente);
                return Ok(cliente.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> delete(int id)
        {
            try
            {
                await _repositorioClientes.Eliminar(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("editar{id}")]
        public async Task<IActionResult> GetId(int id)
        {
            try
            {
                var producto = await _repositorioClientes.ConsultarPorId(id);
                return Ok(producto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }



    }
}
