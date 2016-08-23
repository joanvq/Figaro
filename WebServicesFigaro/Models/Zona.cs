using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebServicesFigaro.Models
{
    public class Zona
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Título")]
        public string Titulo { get; set; }
    }
}