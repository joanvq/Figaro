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
        public string Imagen { get; set; }
        public int TiempoCocinado { get; set; }
        public string TipoPlato { get; set; }
        public Decimal Precio { get; set; }
        public double Valoracion { get; set; }
        public TipoCocina TipoCocina { get; set; }
        public string Categoria { get; set; }
        public string Ingredientes { get; set; }
        public string Utensilios { get; set; }

        public double ImageSize { get; set; }


    }
}
