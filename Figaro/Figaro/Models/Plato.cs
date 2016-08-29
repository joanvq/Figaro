using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Figaro.Models
{
    public class Plato : INotifyPropertyChanged
    {

        private double imageSize;

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public int TiempoCocinado { get; set; }
        public string TipoPlato { get; set; }
        public Decimal Precio { get; set; }
        public double Valoracion { get; set; }
        public TipoCocina TipoCocina { get; set; }
        public string Categoria { get; set; }
        public string Ingredientes { get; set; }
        public string Utensilios { get; set; }


        public double ImageSize
        {
            get { return imageSize; }
            set
            {
                imageSize = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
