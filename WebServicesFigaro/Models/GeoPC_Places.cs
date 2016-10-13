using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebServicesFigaro.Models
{
    public class GeoPC_Places
    {
        [Key]
        [Column(Order = 0)]
        public string ISO { get; set; }
        [Key]
        [Column(Order = 1)]
        public string PostCode { get; set; }
        public string PlaceName { get; set; }
        public string AdminName1 { get; set; }
        public string AdminCode1 { get; set; }
        public string AdminName2 { get; set; }
        public string AdminCode2 { get; set; }
        public string AdminName3 { get; set; }
        public string AdminCode3 { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int? Accuracy { get; set; }
        public int? ZonaId { get; set; }
    }
}