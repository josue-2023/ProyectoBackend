using ProyectoPrueba.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPrueba.Repositorios
{
    public interface IRepositorioClientes
    {
        Task<int> Agregar(Cliente cliente);
        Task<List<Cliente>> ObtenerTodos();

        Task<List<Cliente>> EstadoCliente();

        Task<int> Modificar(Cliente cliente);

        Task Eliminar(int id);

        Task<Cliente?> ConsultarPorId(int id);
    }
}
