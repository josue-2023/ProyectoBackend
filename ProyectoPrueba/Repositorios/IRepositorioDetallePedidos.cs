using ProyectoPrueba.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPrueba.Repositorios
{
    public interface IRepositorioDetallePedidos
    {

        Task<int> Agregar(DetallePedido detallePedido);
        Task<List<DetallePedido>> ObtenerTodos();

        Task<List<DetallePedido>> consultarOrdenesPorId(int id);

        Task<DetallePedido> ConsultarProductoPorId(int id,int productoId);

        Task<DetallePedido?> consultarOrdenPorId(int id);

        Task eliminar(int id);

        Task<int> Modificar(DetallePedido detallePedido);


    }
}
