using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebServicesFigaro.Models
{
    public class ComentarioChef
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        [DisplayName("Valoración")]
        [Range(1, 5)]
        public double Valoracion { get; set; }
        [DisplayName("Chef")]
        [ForeignKey("Chef")]
        public int ChefId { get; set; }
        [DisplayName("Usuario")]
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }
        public Chef Chef { get; set; }
        
    }
}