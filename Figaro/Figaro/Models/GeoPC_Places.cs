using System;
using System.Collections.Generic;
using System.Linq;

namespace Figaro.Models
{
    public class GeoPC_Places
    {
        public string ISO { get; set; }
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