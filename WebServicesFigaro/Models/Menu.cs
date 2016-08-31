using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebServicesFigaro.Models
{
    public class Menu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DisplayName("Título")]
        public string Titulo { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        [DisplayName("Entrante")]
        [ForeignKey("Entrante")]
        public int EntranteId { get; set; }
        [DisplayName("Primer Plato")]
        [ForeignKey("Primero")]
        public int PrimeroId { get; set; }
        [DisplayName("Segundo Plato")]
        [ForeignKey("Segundo")]
        public int SegundoId { get; set; }
        [DisplayName("Guarnición")]
        [ForeignKey("Guarnicion")]
        public int GuarnicionId { get; set; }
        [DisplayName("Postre")]
        [ForeignKey("Postre")]
        public int PostreId { get; set; }
        public string Imagen { get; set; }
        [DisplayName("Tiempo de Cocinado (minutos)")]
        public int TiempoCocinado { get; set; }
        [DisplayName("Precio (€)")]
        [DisplayFormat(DataFormatString = "{0:n} €")]
        public Decimal Precio { get; set; }
        [DisplayName("Valoración (1-5)")]
        [Range(1, 5)]
        public Double Valoracion { get; set; }
        [DisplayName("Tipo de Cocina")]
        [ForeignKey("TipoCocina")]
        public int TipoCocinaId { get; set; }
        public string Categoria { get; set; }
        public string Ingredientes { get; set; }
        public string Utensilios { get; set; }
        
        public Plato Entrante { get; set; }
        public Plato Primero { get; set; }
        public Plato Segundo { get; set; }
        public Plato Guarnicion { get; set; }
        public Plato Postre { get; set; }
        public TipoCocina TipoCocina { get; set; }
    }
}