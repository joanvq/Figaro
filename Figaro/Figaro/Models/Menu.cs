using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Figaro.Models
{
    public class Menu
    {

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public Plato Entrante { get; set; }
        public Plato Primero { get; set; }
        public Plato Segundo { get; set; }
        public Plato Guarnicion { get; set; }
        public Plato Postre { get; set; }
        public string Imagen { get; set; }
        public int TiempoCocinado { get; set; }
        public Decimal Precio { get; set; }
        public double Valoracion { get; set; }
        public TipoCocina TipoCocina { get; set; }
        public string Categoria { get; set; }
        public string Ingredientes { get; set; }
        public string Utensilios { get; set; }
        public bool EstaOculto { get; set; }
        public string HorasCocinado { get; set; }
        public string PrecioEuros { get; set; }

    }
}