﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebServicesFigaro.Models
{
    public class TipoCocina
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DisplayName("Título")]
        public string Titulo { get; set; }
        public string Imagen { get; set; }
        public string Icono { get; set; }

        //public ICollection<Plato> Platos { get; set; }
    }
}