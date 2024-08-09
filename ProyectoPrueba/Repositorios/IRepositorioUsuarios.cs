using ProyectoPrueba.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPrueba.Repositorios
{
    public interface IRepositorioUsuarios
    {
        Task<Usuario?> Autentificacion(Usuario usuario);

        Task<int> Agregar(Usuario usuario);

        Task<Usuario?> ConsultarPorId(int id);
    }
}
