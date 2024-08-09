using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoPrueba.Entidades;
using ProyectoPrueba.Repositorios;

namespace Servicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IRepositorioProductos _repositorioProductos;

        public ProductoController(IRepositorioProductos repositorioProdutos)
        {
            this._repositorioProductos = repositorioProdutos;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Producto producto)
        {
            try
            {
                var id = await _repositorioProductos.Agregar(producto);
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
                var lstProducto = await _repositorioProductos.ObtenerProductoCategoria();
                return Ok(lstProducto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductoPorCategoria(int id)
        {
            try
            {
                var lstProducto = await _repositorioProductos.obtenerProductorPorCategoriaID(id);
                return Ok(lstProducto);
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
                var producto = await _repositorioProductos.consultarPorId(id);
                return Ok(producto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Producto producto)
        {
            try
            {
         
                await _repositorioProductos.Modificar(producto);
                return Ok(producto.Id);
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
                await _repositorioProductos.Eliminar(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


    }
}
