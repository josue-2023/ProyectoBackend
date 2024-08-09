using ProyectoPrueba.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPrueba.Repositorios
{
    public interface IRepositorioCategorias
    {
        Task<int> Agregar(Categoria categoria);

        Task Eliminar(int id);
        Task<List<Categoria>> ObtenerTodos();

        Task<int> Modificar(Categoria categoria);


    }
}
