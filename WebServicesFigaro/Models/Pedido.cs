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
        [DisplayName("Identificador pedido")]
        public string NPedido { get; set; }
        [DisplayName("Nombre y apellidos")]
        public string NombreApellidos { get; set; }
        [DisplayName("Dirección")]
        public string Direccion { get; set; }
        public string CP { get; set; }
        [DisplayName("Estado")]
        public string Estado { get; set; }
        [DisplayName("Usuario")]
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        [DisplayName("Zona")]
        [ForeignKey("Zona")]
        public int ZonaId { get; set; }
        [DisplayName("Precio")]
        public Decimal PrecioTotal { get; set; }
        public string Comentario { get; set; }
        public DateTime FechaPedido { get; set; }
        [DisplayName("Nombre Chef")]
        public string NombreChef { get; set; }
        [DisplayName("Tipo Cocina")]
        public string TipoCocina { get; set; }

        public Usuario Usuario { get; set; }
        public Zona Zona { get; set; }
    }
}