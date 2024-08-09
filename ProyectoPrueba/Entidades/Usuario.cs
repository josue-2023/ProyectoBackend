using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPrueba.Entidades
{
    public class Usuario
    {
            public int Id { get; set; }

            public string? FirstName { get; set; }

            public string? LastName { get; set; } 

            public string Username { get; set; } = null!;

            public string Password { get; set; } = null!;

            public string? Token { get; set; }

            public int? Role { get; set; }

            public string? Email { get; set; }

    }
}
