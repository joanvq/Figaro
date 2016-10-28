using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebServicesFigaro.Models
{
    public class ComentarioPlatoMenu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [DisplayName("Autor Comentario")]
        public string Autor { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        [Required]
        [DisplayName("Valoración")]
        [Range(1, 5)]
        public double Valoracion { get; set; }
        [DisplayName("Menu")]
        [ForeignKey("Menu")]
        public int? MenuId { get; set; }
        [DisplayName("Plato")]
        [ForeignKey("Plato")]
        public int? PlatoId { get; set; }

        public Plato Plato { get; set; }
        public Menu Menu { get; set; }
    }
}