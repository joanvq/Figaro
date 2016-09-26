using Figaro.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Figaro.Models
{
    public class MenuCarrito
    {
        
        public int Id { get; set; }
        public Menu Menu { get; set; }
        public Usuario Usuario { get; set; }
        public int Cantidad { get; set; }

    }
}
