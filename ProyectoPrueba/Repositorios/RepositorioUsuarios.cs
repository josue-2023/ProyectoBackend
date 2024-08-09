using Microsoft.EntityFrameworkCore;
using ProyectoPrueba.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPrueba.Repositorios
{
    public class RepositorioUsuarios : IRepositorioUsuarios
    {
        private readonly ApplicationDbContext context;

        public RepositorioUsuarios(ApplicationDbContext dbContext)
        {
            this.context = dbContext;
        }
        public async Task<Usuario> Autentificacion(Usuario usuario)
        {

            var usuarios=await context.Usuarios.FirstOrDefaultAsync(x=>x.Username==usuario.Username && x.Password==usuario.Password);
            return usuarios; 
        }

        public async Task<int> Agregar(Usuario usuario)
        {
            context.Usuarios.Add(usuario);
            await context.SaveChangesAsync();
            return usuario.Id;
        }

        public async Task<Usuario?> ConsultarPorId(int id)
        {

            return context.Usuarios.Where(o => o.Id == id)
                .ToList()[0];
        }
    }
}
