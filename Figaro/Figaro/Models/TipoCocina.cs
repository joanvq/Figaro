using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;

namespace Figaro.Models
{
    public class TipoCocina
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Imagen { get; set; }
        public string Icono { get; set; }
        public bool Actual { get; set; }
        public bool NoActual { get; set; }
    }
}