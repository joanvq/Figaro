using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Figaro.Models
{
    public class ComentarioChef
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public double Valoracion { get; set; }
        public Chef Chef { get; set; }
        
    }
}