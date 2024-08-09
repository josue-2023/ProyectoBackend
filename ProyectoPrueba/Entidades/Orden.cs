using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPrueba.Entidades
{
    public class Orden
    {

        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        public DateTime Fecha { get; set; }

        public int CantidadProducto { get; set; }

        public double Total { get; set; }
        public int Estado { get; set; }
    }
}
