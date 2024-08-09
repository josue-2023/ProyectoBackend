
using Microsoft.EntityFrameworkCore;
using ProyectoPrueba.Entidades;
using ProyectoPrueba.Repositorios;

namespace Servicios
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //add Cors
            builder.Services.AddCors(options => options.AddPolicy("AllowWebApp",
                                builder => builder.AllowAnyOrigin()
                                .AllowAnyHeader()
                                .AllowAnyMethod()));

            //agregar conexion
            builder.Services.AddDbContext<ApplicationDbContext>(opciones =>
            opciones.UseSqlServer("name=DefaultConnection"));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            //alcance
            builder.Services.AddScoped<IRepositorioCategorias, RepositorioCategorias>();
            builder.Services.AddScoped<IRepositorioClientes, RepositorioClientes>();
            builder.Services.AddScoped<IRepositorioProductos, RepositorioProductos>();
            builder.Services.AddScoped<IRepositorioOrdens, RepositorioOrdens>();
            builder.Services.AddScoped<IRepositorioDetallePedidos, RepositorioDetallePedidos>();
            builder.Services.AddScoped<IRepositorioUsuarios, RepositorioUsuarios>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowWebApp");

            app.UseAuthentication();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
