using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figaro.Models
{
    public class ComentarioPlatoMenu
    {
        public int Id { get; set; }
        public string Autor { get; set; }
        public string Descripcion { get; set; }
        public double Valoracion { get; set; }
        public int? MenuId { get; set; }
        public int? PlatoId { get; set; }
        public Plato Plato { get; set; }
        public Menu Menu { get; set; }
    }
}
