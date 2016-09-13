using Figaro.Models;
using Figaro.Other;
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

        private TipoCocina tipoCocinaSeleccionado = null;
        private List<TipoCocina> listaTipoCocina;

        private List<Menu> listaMenus;
        private Menu menuSeleccionado = new Menu();

        private List<Chef> listaChefs;
        private Chef chefSeleccionado = new Chef();

        private List<Zona> listaZonas;
        private Zona zonaSeleccionada = null;

        private List<ComentarioChef> listaComentariosChef;

        private Usuario usuarioLogueado;
        
        private static Carrito carritoCompra = new Carrito();

        public event PropertyChangedEventHandler PropertyChanged;

        /*----Propiedades-----*/

       /* PLATO */

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

        /* TIPO COCINA */

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

        /* MENU */

        public List<Menu> ListaMenus
        {
            get
            {
                return listaMenus;
            }
            set
            {
                listaMenus = value;
                OnPropertyChanged();
            }
        }

        public Menu MenuSeleccionado
        {
            get { return menuSeleccionado; }
            set
            {
                menuSeleccionado = value;
                OnPropertyChanged();
            }
        }

        /* PLATO */

        public List<Chef> ListaChefs
        {
            get
            {
                return listaChefs;
            }
            set
            {
                listaChefs = value;
                OnPropertyChanged();
            }
        }

        public Chef ChefSeleccionado
        {
            get { return chefSeleccionado; }
            set
            {
                chefSeleccionado = value;
                OnPropertyChanged();
            }
        }

        /* ZONA */

        public List<Zona> ListaZonas
        {
            get
            {
                return listaZonas;
            }
            set
            {
                listaZonas = value;
                OnPropertyChanged();
            }
        }

        public Zona ZonaSeleccionada
        {
            get { return zonaSeleccionada; }
            set
            {
                zonaSeleccionada = value;
                OnPropertyChanged();
            }
        }

        /* COMENTARIO CHEF */

        public List<ComentarioChef> ListaComentariosChef
        {
            get { return listaComentariosChef; }
            set
            {
                listaComentariosChef = value;
                OnPropertyChanged();
            }
        }

        /* USUARIO */

        public Usuario UsuarioLogueado
        {
            get { return usuarioLogueado; }
            set
            {
                usuarioLogueado = value;
                OnPropertyChanged();
            }
        }

        /* OTROS */

        public Carrito CarritoCompra
        {
            get { return carritoCompra; }
            set
            {
                carritoCompra = value;
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

        /*Item1 = idPlato; Item2 = Cantidad*/
        public Command AnadirPlatoCesta
        {
            get
            {
                return new Command<Tuple<int, int>>(async (key) => 
                {
                    IsBusy = true;

                    var platosServices = new PlatosServices();
                    platoSeleccionado = await platosServices.GetPlatosAsync(key.Item1);
                    KeyValuePair<Plato, int> platoCant = new KeyValuePair<Plato, int>(platoSeleccionado, key.Item2);
                    carritoCompra.anadirPlato(platoCant);
                    StatusMessage = "Se han añadido " + key.Item2 + " platos de " + platoSeleccionado.Titulo + " correctamente.";

                    IsBusy = false;
                });
            }
        }

        /*Item1 = idMenu; Item2 = Cantidad*/
        public Command AnadirMenuCesta
        {
            get
            {
                return new Command<Tuple<int, int>>(async (key) =>
                {
                    IsBusy = true;

                    var menusServices = new MenusServices();
                    menuSeleccionado = await menusServices.GetMenusAsync(key.Item1);
                    KeyValuePair<Menu, int> menuCant = new KeyValuePair<Menu, int>(menuSeleccionado, key.Item2);
                    carritoCompra.anadirMenu(menuCant);
                    StatusMessage = "Se han añadido " + key.Item2 + " menus " + menuSeleccionado.Titulo + " en el carrito.";
                    
                    IsBusy = false;
                });
            }
        }

        public Command ElegirChef
        {
            get
            {
                return new Command<int>(async (key) =>
                {
                    IsBusy = true;

                    var chefServices = new ChefServices();
                    chefSeleccionado = await chefServices.GetChefsAsync(key);
                    StatusMessage = "Se ha elegido el chef " + chefSeleccionado.NombreApellidos + " correctamente.";
                    carritoCompra.chef = chefSeleccionado;

                    IsBusy = false;
                });
            }
        }

        /*-----FUNCTIONS-----*/

        public MainViewModel()
        {
            //Fatla Inizializar TipoCocina
            InitializeDataAsync();
        }

        public async Task InitializeDataAsync()
        {
            IsBusy = true;

            var tipoCocinaServices = new TipoCocinaServices();
            ListaTipoCocina = await tipoCocinaServices.GetTipoCocinaAsync();

            var platosServices = new PlatosServices();
            ListaPlatos = await platosServices.GetPlatosAsync();

            var menusServices = new MenusServices();
            ListaMenus = await menusServices.GetMenusAsync();

            var chefServices = new ChefServices();
            ListaChefs = await chefServices.GetChefsAsync();

            var zonaServices = new ZonaServices();
            ListaZonas = await zonaServices.GetZonaAsync();

            //seleccion por defecto el 2
            var usuarioServices = new UsuarioServices();
            UsuarioLogueado = await usuarioServices.GetUsuariosAsync(2);

            if(TipoCocinaSeleccionado != null)
            {
                ListaPlatos = ListaPlatos.Where(plato => plato.TipoCocina.Id == TipoCocinaSeleccionado.Id).ToList();
                ListaMenus = ListaMenus.Where(menu => menu.TipoCocina.Id == TipoCocinaSeleccionado.Id).ToList();
                ListaChefs = ListaChefs.Where(chef => chef.TipoCocina.Id == TipoCocinaSeleccionado.Id).ToList();
            }

            if(ZonaSeleccionada != null)
            {
                ListaChefs = ListaChefs.Where(chef => chef.Zona.Id == ZonaSeleccionada.Id).ToList();
            }

            IsBusy = false;
        }

        public async Task InitializeComentariosAsync(int idChef)
        {
            IsBusy = true;

            var comentarioChefServices = new ComentarioChefServices();
            ListaComentariosChef = await comentarioChefServices.GetComentariosChefAsync(idChef);

            IsBusy = false;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
