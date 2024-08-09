using Microsoft.EntityFrameworkCore;
using ProyectoPrueba.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPrueba.Repositorios
{
    public  class RepositorioClientes:IRepositorioClientes
    {
        private readonly ApplicationDbContext context;

        public RepositorioClientes(ApplicationDbContext dbContext)
        {
            this.context = dbContext;
        }
        public async Task<int> Agregar(Cliente cliente)
        {
            context.Clientes.Add(cliente);
            await context.SaveChangesAsync();
            return cliente.Id;
        }

        public async Task<List<Cliente>> ObtenerTodos()
        {
            return await context.Clientes.ToListAsync();
        }

        public async Task<List<Cliente>> EstadoCliente()
        {
            return await context.Clientes.Where(cliente => cliente.Estado == 1).ToListAsync();
        }

        public async Task Eliminar(int id)
        {
            Cliente clientes = await context.Clientes.FindAsync(id);
            clientes.Estado = 0;
            //context.Ordens.Remove(orden);
            await context.SaveChangesAsync();

        }

        public async Task<int> Modificar(Cliente cliente)
        {
            Cliente clientes = await context.Clientes.FindAsync(cliente.Id);
            clientes.Cedula = cliente.Cedula;
            clientes.Nombre = cliente.Nombre;
            clientes.Apellido = cliente.Apellido;
            clientes.Correo = cliente.Correo;
            clientes.Estado = cliente.Estado;

            await context.SaveChangesAsync();
            return cliente.Id;
        }

        public async Task<Cliente?> ConsultarPorId(int id)
        {

            return  context.Clientes.Where(o => o.Id == id)
                .ToList()[0];
        }


    }
}
