using ProyectoPrueba.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPrueba.Repositorios
{
    public interface IRepositorioProductos
    {
        //Task<List<Producto>> ObtenerTodos();
        Task<int> Agregar(Producto producto);

        Task<List<Producto>> ObtenerProductoCategoria();

        Task<List<Producto>> obtenerProductorPorCategoriaID(int id);

        Task<int> Modificar(Producto producto);

        Task<Producto?> consultarPorId(int id);

        Task Eliminar(int id);

      

    }
}
