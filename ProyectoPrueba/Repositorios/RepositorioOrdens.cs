using Microsoft.EntityFrameworkCore;
using ProyectoPrueba.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPrueba.Repositorios
{
    public class RepositorioOrdens:IRepositorioOrdens
    {
        private readonly ApplicationDbContext context;

        public RepositorioOrdens(ApplicationDbContext dbContext)
        {
            this.context = dbContext;
        }
        public async Task<List<Orden>> ObtenerTodos()
        {

            return await context.Ordens.Include(pedido => pedido.Cliente)
                // .Include(pedido=>pedido.Producto)
                .ToListAsync();
        }

        public async Task<int> Agregar(Orden orden)
        {
           
            context.Ordens.Add(orden);
            await context.SaveChangesAsync();
            return orden.Id;
        }

        public async Task<Orden?> consultarPorId(int id)
        {

            return context.Ordens.Where(o => o.Id == id)
                .Include(o => o.Cliente)
                // .Include(o => o.Producto.Categoria)
                .ToList()[0];
        }

        public async Task eliminar(int id)
        {
            Orden orden = await context.Ordens.FindAsync(id);
            context.Ordens.Remove(orden);
            await context.SaveChangesAsync();

        }


        public async Task<int> modificar(Orden orden)
        {
            var detallePedido = context.DetallesPedidos
            .Where(dp => dp.OrdenId == orden.Id) 
            .ToList()[0];

            Orden ordens = await context.Ordens.FindAsync(orden.Id);
            ordens.Total = detallePedido.Total;
            ordens.CantidadProducto =await CalcularTotalOrden(orden.Id);
            await context.SaveChangesAsync();
            return orden.Id;
        }

        private async Task<int> CalcularTotalOrden(int ordenId)
        {
            return await context.DetallesPedidos
                .Where(dp => dp.OrdenId == ordenId)
                .SumAsync(dp => dp.Cantidad);
        }



    }
}
