using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Figaro.Models;
using Figaro.Services;
using System.Runtime.CompilerServices;

namespace Figaro.ViewModels
{
    class TipoCocinaViewModel : INotifyPropertyChanged
    {
        private List<TipoCocina> listaTipoCocina;
        private bool isBusy;
        private string statusMessage;
        private TipoCocina tipoCocinaSeleccionado;

        public event PropertyChangedEventHandler PropertyChanged;

        /*-----PROPERTIES-----*/

        public TipoCocina TipoCocinaSeleccionado
        {
            get { return tipoCocinaSeleccionado; }
            set
            {
                tipoCocinaSeleccionado = value;
                OnPropertyChanged();
            }
        }

        public List<TipoCocina> ListaTipoCocina
        {
            get
            {
                return listaTipoCocina;
            }
            set
            {
                listaTipoCocina = value;
                OnPropertyChanged();
            }
        }

        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged();
            }
        }
        /*-----FUNCTIONS-----*/
        TipoCocinaViewModel()
        {
            InitializeDataAsync();
        }

        private async Task InitializeDataAsync()
        {
            IsBusy = true;

            var tipoCocinaServices = new TipoCocinaServices();
            ListaTipoCocina = await tipoCocinaServices.GetTipoCocinaAsync();

            IsBusy = false;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
