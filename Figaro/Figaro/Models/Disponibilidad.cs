using Figaro.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Figaro.Models
{
    public class Disponibilidad
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public bool EstaDisponible { get; set; }
        public int ChefId { get; set; }
        public Chef Chef { get; set; }

    }
}