using Microsoft.EntityFrameworkCore;
using ProyectoPrueba.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPrueba.Repositorios
{
    public class RepositorioCategorias: IRepositorioCategorias
    {
        private readonly ApplicationDbContext context;

        public RepositorioCategorias(ApplicationDbContext dbContext)
        {
            this.context = dbContext;
        }
        public async Task<int> Agregar(Categoria categoria)
        {
            context.Categorias.Add(categoria);
            await context.SaveChangesAsync();
            return categoria.Id;
        }

        public async Task<List<Categoria>> ObtenerTodos()
        {
            return await context.Categorias.ToListAsync();
        }

        public async Task Eliminar(int id)
        {

            DetallePedido detallePedido = await context.DetallesPedidos.FindAsync(id);
            //detallePedido.Estado = "0";
            context.DetallesPedidos.Remove(detallePedido);
            await context.SaveChangesAsync();


        }


        public async Task<int> Modificar(Categoria categoria)
        {
            Categoria categorias = await context.Categorias.FindAsync(categoria.Id);
            categorias.Nombre = categoria.Nombre;

            await context.SaveChangesAsync();
            return categoria.Id;
        }
    }
}
