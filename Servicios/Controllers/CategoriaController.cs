using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoPrueba.Entidades;
using ProyectoPrueba.Repositorios;

namespace Servicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly IRepositorioCategorias _repositorioCategorias;

        public CategoriaController(IRepositorioCategorias repositorioCategorias)
        {
            this._repositorioCategorias = repositorioCategorias;
        }


        [HttpGet]

        public async Task<IActionResult> Get()
        {
            try
            {
                var lstCategoria = await _repositorioCategorias.ObtenerTodos();
                return Ok(lstCategoria);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post(Categoria categoria)
        {
            try
            {
                var id = await _repositorioCategorias.Agregar(categoria);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Categoria categoria)
        {
            try
            {

                await _repositorioCategorias.Modificar(categoria);
                return Ok(categoria.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }


    }
}
