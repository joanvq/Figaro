using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Figaro.Models
{
    public class PlatoPedido
    {
        public int Id { get; set; }
        public Pedido Pedido { get; set; }
        public int PedidoId { get; set; }
        public string TituloPlato { get; set; }
        public decimal PrecioPlato { get; set; }
        public int TiempoCocinado { get; set; }
        public string Ingredientes { get; set; }
        public string Utensilios { get; set; }
        public int Cantidad { get; set; }
        
    }
}