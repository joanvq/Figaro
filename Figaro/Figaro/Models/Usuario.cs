using Figaro.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Figaro.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string Imagen { get; set; }
        public string Password { get; set; }
        public int ZonaId { get; set; }
        public Zona Zona { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        public string Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string genero { get; set; }
        public string NombreApellidos { get; set; }

    }
}