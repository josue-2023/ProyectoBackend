using ProyectoPrueba.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPrueba.Repositorios
{
    public interface IRepositorioOrdens
    {
        Task<List<Orden>> ObtenerTodos();

        Task<int> Agregar(Orden orden);

        Task eliminar(int id);

       Task<int> modificar(Orden orden);

        Task<Orden?> consultarPorId(int id);

    }
}
