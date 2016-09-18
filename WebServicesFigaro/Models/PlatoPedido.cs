using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebServicesFigaro.Models
{
    public class PlatoPedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DisplayName("Pedido")]
        [ForeignKey("Pedido")]
        public int PedidoId { get; set; }
        [DisplayName("Nombre")]
        public string TituloPlato { get; set; }
        [DisplayName("Precio")]
        public string PrecioPlato { get; set; }
        [DisplayName("Tiempo de Cocinado (minutos)")]
        public string TiempoCocinado { get; set; }
        public string Ingredientes { get; set; }
        public string Utensilios { get; set; }

        public Pedido Pedido { get; set; }

    }
}