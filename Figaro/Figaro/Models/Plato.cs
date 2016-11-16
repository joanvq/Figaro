using Figaro.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Figaro.Models
{
    public class Plato
    {

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public int TiempoCocinado { get; set; }
        public bool EsEntrante { get; set; }
        public bool EsPrimero { get; set; }
        public bool EsSegundo { get; set; }
        public bool EsGuarnicion { get; set; }
        public bool EsPostre { get; set; }
        public Decimal Precio { get; set; }
        public double Valoracion { get; set; }
        public TipoCocina TipoCocina { get; set; }
        public string Categoria { get; set; }
        public string Ingredientes { get; set; }
        public string Utensilios { get; set; }
        public string HorasCocinado { get; set; }
        public string PrecioEuros { get; set; }
        //public bool EnCarrito { get; set; }
        //public int Cantidad
        //{
        //    get(Usuario usuarioLogueado)
        //    {
        //        var mvm = BindingContext as MainViewModel;
        //        var platoCarrito = mvm.ListaPlatoCarrito.FirstOrDefault(l => l.PlatoId == Id);
        //        if (platoCarrito == null)
        //        {
        //            return 0;
        //        }
        //        else
        //        {
        //            return platoCarrito.Cantidad;
        //        }
        //    }
        //}
        //public Decimal 

    }
}
