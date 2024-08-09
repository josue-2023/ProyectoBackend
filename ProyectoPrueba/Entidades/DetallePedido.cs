using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPrueba.Entidades
{
    public class DetallePedido
    {
        public int Id { get; set; }
        public int OrdenId { get; set; }
        public Orden? Orden { get; set; }
        public int ProductoId { get; set; }
        public Producto? Producto { get; set; }
        public int Cantidad { get; set; }
        public double Subtotal { get; set; }
        public double Total { get; set; }
        public string Estado { get; set; } = null!;
    }
}
