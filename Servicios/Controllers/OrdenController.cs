using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoPrueba.Entidades;
using ProyectoPrueba.Repositorios;

namespace Servicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenController : ControllerBase
    {
        private readonly IRepositorioOrdens _repositorioOrdens;

        public OrdenController(IRepositorioOrdens repositorioOrdens)
        {
            this._repositorioOrdens = repositorioOrdens;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Orden orden)
        {
            try
            {

                orden.Fecha = DateTime.Now;
                var id = await _repositorioOrdens.Agregar(orden);
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
                var listaPedidos = await _repositorioOrdens.ObtenerTodos();
                var pedidos = listaPedidos.Select(pedido => new {
                    pedido.Id,
                    pedido.ClienteId,
                    pedido.Cliente,
                    fecha = pedido.Fecha.ToString("yyyy-MM-dd"),
                    pedido.CantidadProducto,
                    pedido.Total,
                    pedido.Estado

                });

                return Ok(pedidos);

                // return Ok(listaPedidos);
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
                var orden = await _repositorioOrdens.consultarPorId(id);
                return Ok(orden);
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
                await _repositorioOrdens.eliminar(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> put(Orden orden)
        {
            try
            {
                
                await _repositorioOrdens.modificar(orden);
                return Ok(orden.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

    }
}
