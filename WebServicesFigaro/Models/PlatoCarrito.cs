using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebServicesFigaro.Models
{
    public class PlatoCarrito
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DisplayName("Usuario")]
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        [DisplayName("Plato")]
        [ForeignKey("Plato")]
        public int PlatoId { get; set; }
        public int Cantidad { get; set; }

        public Plato Plato { get; set; }
        public Usuario Usuario { get; set; }

    }
}
