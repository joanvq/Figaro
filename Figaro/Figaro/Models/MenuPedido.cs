using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Figaro.Models
{
    public class MenuPedido
    {

        public int Id { get; set; }
        public Pedido Pedido { get; set; }
        public string TituloMenu { get; set; }
        public Decimal PrecioMenu { get; set; }
        public string Entrante { get; set; }
        public string Primero { get; set; }
        public string Segundo { get; set; }
        public string Guarnicion { get; set; }
        public string Postre { get; set; }
        public int TiempoCocinado { get; set; }
        public string Ingredientes { get; set; }
        public string Utensilios { get; set; }
        public int Cantidad { get; set; }

    }
}