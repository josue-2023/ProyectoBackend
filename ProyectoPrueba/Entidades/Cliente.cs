using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProyectoPrueba.Entidades
{
    public class Cliente
    {
        public int Id { get; set; }

        public string Cedula { get; set; } = null!;
        public string Nombre { get; set; } = null!;

        public string Apellido { get; set; } = null!;

        public string Correo { get; set; } = null!;

        public int Estado { get; set; }

        [JsonIgnore]
        public List<Orden>? Ordens { get; set; }
    }
}
