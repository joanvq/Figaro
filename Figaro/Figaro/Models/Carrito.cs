using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figaro.Models
{
    public class Carrito
    {
        public Chef chef { get; set; }
        public List<Plato> listPlatos { get; set; }
        public List<Menu> listaMenus { get; set; }

    }
}
