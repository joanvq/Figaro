using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figaro.Models
{
    public class Plato
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public List<string> Imagen { get; set; }
        public int TiempoCocinado { get; set; }
        public string Tipo { get; set; }
        public List<string> Ingredientes { get; set; }
        public Decimal Precio { get; set; }
        public List<string> Utensilios { get; set; }
        public double Valoracion { get; set; }

    }
}
