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
        private List<Plato> searchedPlatos;
        private string keywordPlato;
        private bool isBusy;
        private string statusMessage;
        private Plato platoSeleccionado = new Plato();

        
        public event PropertyChangedEventHandler PropertyChanged;

        /*----Propiedades-----*/

        public string KeywordPlato
        {
            get { return keywordPlato; }
            set
            {
                keywordPlato = value;
                OnPropertyChanged();
            }
        }

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

        public List<Plato> SearchedPlatos
        {
            get { return searchedPlatos; }
            set
            {
                searchedPlatos = value;
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

        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged();
            }
        }

        public string StatusMessage
        {
            get { return statusMessage; }
            set
            {
                statusMessage = value;
                OnPropertyChanged();
            }
        }

        /*-----COMMANDS-----*/

        public Command PostCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsBusy = true;

                    var platosServices = new PlatosServices();
                    var isSuccess = await platosServices.PostPlatoAsync(platoSeleccionado);
                    
                    if(isSuccess)
                    {
                        StatusMessage = "Se ha añadido correctamente.";
                    }
                    else
                    {
                        StatusMessage = "No se ha podido añadir.";
                    }
                    
                    IsBusy = false;
                });
            }
        }

        public Command PutCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsBusy = true;

                    var platosServices = new PlatosServices();
                    var isSuccess = await platosServices.PutPlatoAsync(platoSeleccionado.Id, platoSeleccionado);

                    if (isSuccess)
                    {
                        StatusMessage = "Se ha modificado correctamente.";
                    }
                    else
                    {
                        StatusMessage = "No se ha podido modificar.";
                    }

                    IsBusy = false;
                });
            }
        }

        public Command SearchCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsBusy = true;

                    var platosServices = new PlatosServices();
                    SearchedPlatos = await platosServices.GetPlatosByKeywordAsync(keywordPlato);

                    IsBusy = false;
                });
            }
        }

        public Command DeleteCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsBusy = true;

                    var platosServices = new PlatosServices();
                    var isSuccess = await platosServices.DeletePlatoAsync(platoSeleccionado.Id);

                    if (isSuccess)
                    {
                        StatusMessage = "Se ha borrado correctamente.";
                    }
                    else
                    {
                        StatusMessage = "No se ha podido borrar.";
                    }

                    IsBusy = false;
                });
            }
        }

        public Command Refresh
        {
            get
            {
                return new Command(async () => await InitializeDataAsync());
            }
        }

        /*-----FUNCTIONS-----*/

        public MainViewModel(string name)
        {
            InitializeDataAsync();
        }

        private async Task InitializeDataAsync()
        {
            IsBusy = true;

            var platosServices = new PlatosServices();
            ListaPlatos = await platosServices.GetPlatosAsync();

            IsBusy = false;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
