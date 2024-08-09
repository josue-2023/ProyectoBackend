using Microsoft.EntityFrameworkCore;
using ProyectoPrueba.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPrueba.Repositorios
{
    public class RepositorioProductos:IRepositorioProductos
    {
        private readonly ApplicationDbContext context;

        public RepositorioProductos(ApplicationDbContext dbContext)
        {
            this.context = dbContext;
        }
        public async Task<int> Agregar(Producto producto)
        {
            context.Productos.Add(producto);
            await context.SaveChangesAsync();
            return producto.Id;
        }
        /*
        public async Task<List<Producto>> ObtenerTodos()
        {
            return await context.Productos.ToListAsync();
        }
        */

        public async Task<List<Producto>> ObtenerProductoCategoria()
        {
            return await context.Productos.Include(categoria => categoria.Categoria)
                .ToListAsync();
        }

        public async Task<List<Producto>> obtenerProductorPorCategoriaID(int id)
        {
            return await context.Productos.Where(producto => producto.CategoriaId == id && producto.Estado==1)
                .Include(categoria => categoria.Categoria)
                .ToListAsync();
        }



        public async Task<int> Modificar(Producto producto)
        {
            Producto productos = await context.Productos.FindAsync(producto.Id);
            productos.Nombre=producto.Nombre;
            productos.Categoria=producto.Categoria;
            productos.Marca=producto.Marca;
            productos.Precio=producto.Precio;
            productos.Cantidad=producto.Cantidad;
            productos.Proveedor=producto.Proveedor;
            productos.CategoriaId=producto.CategoriaId;
            productos.Estado=producto.Estado;

            await context.SaveChangesAsync();
            return producto.Id;
        }

        public async Task<Producto?> consultarPorId(int id)
        {

            return context.Productos.Where(o => o.Id == id)
                .Include(o => o.Categoria)
                .ToList()[0];
        }

        public async Task Eliminar(int id)
        {
            Producto producto = await context.Productos.FindAsync(id);
            producto.Estado = 0;
            //context.Ordens.Remove(orden);
            await context.SaveChangesAsync();

        }




    }
}
