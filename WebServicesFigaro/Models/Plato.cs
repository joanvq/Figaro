﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
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
        [DisplayName("Es Entrante?")]
        public bool EsEntrante { get; set; }
        [DisplayName("Es Primero?")]
        public bool EsPrimero { get; set; }
        [DisplayName("Es Segundo?")]
        public bool EsSegundo { get; set; }
        [DisplayName("Es Guarnición?")]
        public bool EsGuarnicion { get; set; }
        [DisplayName("Es Postre?")]
        public bool EsPostre { get; set; }
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

        public TipoCocina TipoCocina { get; set; }
    }
}
