using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoPrueba.Entidades;
using ProyectoPrueba.Repositorios;

namespace Servicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetallePedidoController : ControllerBase
    {
        private readonly IRepositorioDetallePedidos _repositorioDetallePedidos;

        public DetallePedidoController(IRepositorioDetallePedidos repositorioDetallePedidos)
        {
            this._repositorioDetallePedidos = repositorioDetallePedidos;
        }

        [HttpPost]
        public async Task<IActionResult> Post(DetallePedido detallePedido)
        {
            try
            {
                var id = await _repositorioDetallePedidos.Agregar(detallePedido);
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
                var lstDetallePedido = await _repositorioDetallePedidos.ObtenerTodos();
                return Ok(lstDetallePedido);
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
                var orden = await _repositorioDetallePedidos.consultarOrdenesPorId(id);
                return Ok(orden);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> put(DetallePedido detallePedido)
        {
            try
            {
          
                await _repositorioDetallePedidos.Modificar(detallePedido);
                return Ok(detallePedido.Id);
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
                await _repositorioDetallePedidos.eliminar(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("detalle/{id}")]
        public async Task<IActionResult> GetIdDetalle(int id)
        {
            try
            {
                var orden = await _repositorioDetallePedidos.consultarOrdenPorId(id);
                return Ok(orden);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("producto/{id}/{productoId}")]
        public async Task<IActionResult> GetIdProducto(int id, int productoId)
        {
            try
            {
                var orden = await _repositorioDetallePedidos.ConsultarProductoPorId(id ,productoId);
                return Ok(orden);
            }
            catch (Exception ex)
            {   
                return BadRequest(ex.ToString());
            }
        }


    }
}
