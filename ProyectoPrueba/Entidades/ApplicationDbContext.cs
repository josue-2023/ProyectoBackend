using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPrueba.Entidades
{
    public class ApplicationDbContext:DbContext 
    {

  
          public ApplicationDbContext(DbContextOptions options):base(options)
        {

      }
   /*     
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
optionsBuilder.UseSqlServer("Data Source=DESKTOP-NAH2PP5\\SQLEXPRESS;Database=ProyectoTrinistorePruebas;Integrated Security=True;TrustServerCertificate=True;");
}*/


        public DbSet<Orden> Ordens { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Producto> Productos { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<DetallePedido> DetallesPedidos { get; set;}

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioC> UsuarioCs { get; set; }
    }

}
