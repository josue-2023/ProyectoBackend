using Microsoft.EntityFrameworkCore;
using ProyectoPrueba.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPrueba.Repositorios
{
    public class RepositorioDetallePedidos : IRepositorioDetallePedidos
    {
        private readonly ApplicationDbContext context;

        public RepositorioDetallePedidos(ApplicationDbContext dbContext)
        {
            this.context = dbContext;
        }
        public async Task<int> Agregar(DetallePedido detallePedido)
        {
            Producto producto = await context.Productos.FindAsync(detallePedido.ProductoId);
            detallePedido.Subtotal=producto.Precio*detallePedido.Cantidad;
            context.DetallesPedidos.Add(detallePedido);
            await context.SaveChangesAsync();

            double total = await CalcularTotalOrden(detallePedido.OrdenId);

            // Actualiza el total en todos los detalles del pedido de la misma orden
            await ActualizarTotalEnDetallesPedido(detallePedido.OrdenId, total);



            return detallePedido.Id;
        }

        public async Task<List<DetallePedido>> ObtenerTodos()
        {

            return await context.DetallesPedidos.Include(p => p.Orden)
                .Include(p => p.Producto)
                .ToListAsync();
        }

        public async Task<List<DetallePedido>> consultarOrdenesPorId(int id)
        {

            return await context.DetallesPedidos.Where(dtPedido => dtPedido.OrdenId == id)
                .Include(orden => orden.Orden)
                .Include(orden => orden.Orden.Cliente)
                .Include(producto => producto.Producto)
                .Include(producto => producto.Producto.Categoria)   
                .ToListAsync();
        }

        public async Task<DetallePedido?> consultarOrdenPorId(int id)
        {

            return  context.DetallesPedidos.Where(dtPedido => dtPedido.Id == id)
                .Include(orden => orden.Orden)
                .Include(orden => orden.Orden.Cliente)
                .Include(producto => producto.Producto)
                .Include(producto => producto.Producto.Categoria)
                .ToList()[0];
        }

        public async Task<DetallePedido?> ConsultarProductoPorId(int id, int productoId)
        {

            List<DetallePedido> dtPedidos = await context.DetallesPedidos.Where(dtPedido => dtPedido.OrdenId == id)
                 .Include(orden => orden.Orden)
                 .Include(orden => orden.Orden.Cliente)
                 .Include(producto => producto.Producto)
                 .Include(producto => producto.Producto.Categoria)
                 .ToListAsync();

            DetallePedido? producto = dtPedidos
         .FirstOrDefault(dtPedido => dtPedido.ProductoId == productoId);

            return producto;
            

        }



        public async  Task eliminar(int id)
        {

            DetallePedido detallePedido = await context.DetallesPedidos.FindAsync(id);
            var idOrden = detallePedido.OrdenId;

            

            context.DetallesPedidos.Remove(detallePedido);

           

            // Actualiza el total en todos los detalles del pedido de la misma orden


            await context.SaveChangesAsync();

            double total = await CalcularTotalOrden(idOrden);

            await ActualizarTotalEnDetallesPedido(detallePedido.OrdenId, total);

        }

        public async Task<int> Modificar(DetallePedido detallePedido)
        {
     
          
            Producto producto=  await context.Productos.FindAsync(detallePedido.ProductoId);
            DetallePedido dtPedido = await context.DetallesPedidos.FindAsync(detallePedido.Id);
            dtPedido.OrdenId = detallePedido.OrdenId;
            dtPedido.ProductoId = detallePedido.ProductoId;
            dtPedido.Cantidad = detallePedido.Cantidad;
            dtPedido.Subtotal = detallePedido.Cantidad*producto.Precio;
            await context.SaveChangesAsync();

            // Calcula el nuevo total de la orden
            double total = await CalcularTotalOrden(detallePedido.OrdenId);

            // Actualiza el total en todos los detalles del pedido de la misma orden
            await ActualizarTotalEnDetallesPedido(detallePedido.OrdenId, total);


            return detallePedido.Id;
        }

        private async Task<double> CalcularTotalOrden(int ordenId)
        {
            return await context.DetallesPedidos
                .Where(dp => dp.OrdenId == ordenId)
                .SumAsync(dp => dp.Subtotal);
        }

        private async Task ActualizarTotalEnDetallesPedido(int ordenId, double total)
        {
             List<DetallePedido> detallesPedidos = await context.DetallesPedidos
                .Where(dp => dp.OrdenId == ordenId)
                .ToListAsync();

            foreach (var detalle in detallesPedidos)
            {
                detalle.Total = total;
            }

            await context.SaveChangesAsync();
        }


    }
}
