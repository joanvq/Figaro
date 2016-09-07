using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Figaro.Models
{
    public class Chef
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Imagen { get; set; }
        public string ImagenFondo { get; set; }
        public string Subtitulo { get; set; }
        public Zona Zona { get; set; }
        public TipoCocina TipoCocina { get; set; }
        public Double Valoracion { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Genero { get; set; }
        public string NombreApellidos { get; set; }
        public int Edad { get; set; }



    }
}