using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPrueba.Entidades
{
    public class Producto
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string Marca { get; set; } = null!;

        public int Cantidad { get; set; }

        public double Precio { get; set; }

        public int Estado { get; set; }

        public string Proveedor { get; set; }=null!;

        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }

    }
}
