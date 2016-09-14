using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebServicesFigaro.Models
{
    public class Pedido
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DisplayName("Número de pedido")]
        [Index("NPedidoIndex", IsUnique = true)]
        public int NPedido { get; set; }
        [DisplayName("Dirección")]
        public string Direccion { get; set; }
        [DisplayName("Estado")]
        public string Estado { get; set; }
        [DisplayName("Usuario")]
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        [DisplayName("Zona")]
        [ForeignKey("Zona")]
        public int ZonaId { get; set; }
        //Falta
        //Ocupación chef

        public Usuario Usuario { get; set; }
        public Zona Zona { get; set; }
    }
}