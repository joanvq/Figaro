using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebServicesFigaro.Models
{
    public class Disponibilidad
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        [DisplayName("Está disponible?")]
        public bool EstaDisponible { get; set; }
        [ForeignKey("Chef")]
        public int ChefId { get; set; }

        public Chef Chef { get; set; }

    }
}