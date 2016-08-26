﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServicesFigaro.Models
{
    public class Plato
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DisplayName("Título")]
        public string Titulo { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        [DisplayName("Tiempo de Cocinado (minutos)")]
        public int TiempoCocinado { get; set; }
        [DisplayName("Tipo de Plato")]
        public string TipoPlato { get; set; }
        [DisplayName("Precio (€)")]
        [DisplayFormat(DataFormatString = "{0:n} €")]
        public Decimal Precio { get; set; }
        [DisplayName("Valoración (1-5)")]
        [Range(1, 5)]
        public Double Valoracion { get; set; }
        [DisplayName("Tipo de Cocina")]
        public int TipoCocinaId { get; set; }
        [ForeignKey("TipoCocinaId")]
        public virtual TipoCocina TipoCocina { get; set; }
        public string Categoria { get; set; }
        public string Ingredientes { get; set; }
        public string Utensilios { get; set; }

    }
}
