using System;
using System.Collections.Generic;
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
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        //public List<string> Imagen { get; set; }
        public int TiempoCocinado { get; set; }
        public string TipoPlato { get; set; }
        //[DataType(DataType.Currency)]
        public Decimal Precio { get; set; } 
        public Double Valoracion { get; set; }
        public int TipoCocina { get; set; }
        public string Categoria { get; set; }
        public string Ingredientes { get; set; }
        public string Utensilios { get; set; }

    }
}
