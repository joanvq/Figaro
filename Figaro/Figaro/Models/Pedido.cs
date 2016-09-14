using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Figaro.Models
{
    public class Pedido
    {
        
        public int Id { get; set; }
        public int NPedido { get; set; }
        public string Direccion { get; set; }
        public string Estado { get; set; }
        public Usuario Usuario { get; set; }
        public Zona Zona { get; set; }
    }
}