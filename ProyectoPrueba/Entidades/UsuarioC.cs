using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPrueba.Entidades
{
    public class UsuarioC
    {
        public int Id { get; set; }
        public string Correo { get; set; } = null!;
        public string Contrasena { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string NumeroCedula { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public string Genero { get; set; } = null!;
        public string Ciudad { get; set; } = null!;
        public string Pais { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string Telefono { get; set; } = null!;

    }
}
