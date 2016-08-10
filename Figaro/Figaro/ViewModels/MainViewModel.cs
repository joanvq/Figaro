using Figaro.Models;
using Figaro.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Figaro.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private List<Plato> listaPlatos;
        private Plato platoSeleccionado = new Plato();

        public event PropertyChangedEventHandler PropertyChanged;

        public List<Plato> ListaPlatos {
            get
            {
                return listaPlatos;
            }
            set
            {
                listaPlatos = value;
                OnPropertyChanged();
            }
        }

        public Plato PlatoSeleccionado {
            get { return platoSeleccionado; }
            set
            {
                platoSeleccionado = value;
                OnPropertyChanged();
            }
        }

        public Command PostCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var platosServices = new PlatosServices();
                    await platosServices.PostPlatoAsync(platoSeleccionado);
                });
            }
        }

        public Command PutCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var platosServices = new PlatosServices();
                    await platosServices.PutPlatoAsync(platoSeleccionado.Id, platoSeleccionado);
                });
            }
        }

        public Command DeleteCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var platosServices = new PlatosServices();
                    await platosServices.DeletePlatoAsync(platoSeleccionado.Id);
                });
            }
        }

        public MainViewModel()
        {
            InitializeDataAsync();
        }

        private async Task InitializeDataAsync()
        {
            var platosServices = new PlatosServices();
            ListaPlatos = await platosServices.GetPlatosAsync();
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
