using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebServicesFigaro.Models
{
    public class Chef
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Imagen { get; set; }
        [DisplayName("Imagen de Fondo")]
        public string ImagenFondo { get; set; }
        [DisplayName("Subtítulo")]
        public string Subtitulo { get; set; }
        [DisplayName("Zona")]
        [ForeignKey("Zona")]
        public int ZonaId { get; set; }
        [DisplayName("Tipo de Cocina")]
        [ForeignKey("TipoCocina")]
        public int TipoCocinaId { get; set; }
        [DisplayName("Valoración (1-5)")]
        [Range(1, 5)]
        public Double Valoracion { get; set; }
        [DisplayName("Descrpción")]
        public string Descripcion { get; set; }
        [DisplayName("Fecha de nacimiento")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaNacimiento { get; set; }
        [DisplayName("Género")]
        public string Genero { get; set; }

        public Zona Zona { get; set; }
        public TipoCocina TipoCocina { get; set; }


    }
}