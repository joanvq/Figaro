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
        private List<Plato> allPlatos; //Lista de todos los platos que existen en la BD
        private List<Plato> listaPlatos; //Lista filtrada
        private List<Plato> searchedPlatos;
        private string keywordPlato;
        private bool isBusy;
        private string statusMessage;
        private Plato platoSeleccionado = new Plato();
        
        private List<TipoCocina> listaTipoCocina;
        private TipoCocina tipoCocinaSeleccionado = null;

        private List<Menu> allMenus;
        private List<Menu> listaMenus;
        private Menu menuSeleccionado = new Menu();

        private List<Chef> allChefs;
        private List<Chef> listaChefs;
        private Chef chefSeleccionado = new Chef();
        
        private List<Zona> listaZonas;
        private Zona zonaSeleccionada = null;

        private List<ComentarioChef> listaComentariosChef;

        private Usuario usuarioLogueado;
        
        //private static Carrito carritoCompra = new Carrito();

        private List<PlatoCarrito> listaPlatoCarrito;
        private List<MenuCarrito> listaMenuCarrito;

        private List<Pedido> listaPedidosRealizados = new List<Pedido>();
        private List<Pedido> listaPedidosActivos = new List<Pedido>();

        private DateTime fecha = DateTime.Now.AddDays(1);
        // De 0 a 47 --> 24 horas + medias horas
        private int hora = DateTime.Now.Hour*2;

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
                usuarioLogueado.NombreApellidos = usuarioLogueado.Nombre + " " + usuarioLogueado.Apellidos;
                OnPropertyChanged();
            }
        }

        public List<Pedido> ListaPedidosActivos
        {
            get { return listaPedidosActivos; }
            set
            {
                listaPedidosActivos = value;
                OnPropertyChanged();
            }
        }

        public List<Pedido> ListaPedidosRealizados
        {
            get { return listaPedidosRealizados; }
            set
            {
                listaPedidosRealizados = value;
                OnPropertyChanged();
            }
        }

        /* CARRITO */

        //public Carrito CarritoCompra
        //{
        //    get { return carritoCompra; }
        //    set
        //    {
        //        carritoCompra = value;
        //        OnPropertyChanged();
        //    }
        //}

        public List<MenuCarrito> ListaMenuCarrito
        {
            get { return listaMenuCarrito; }
            set
            {
                listaMenuCarrito = value;
                OnPropertyChanged();
            }
        }

        public List<PlatoCarrito> ListaPlatoCarrito
        {
            get { return listaPlatoCarrito; }
            set
            {
                listaPlatoCarrito = value;
                OnPropertyChanged();
            }
        }

        /* DISPONIBILIDAD */

        public DateTime Fecha
        {
            get { return fecha; }
            set
            {
                fecha = value;
                OnPropertyChanged();
            }
        }

        public int Hora
        {
            get { return hora; }
            set
            {
                hora = value;
                OnPropertyChanged();
            }
        }

        /* OTROS */

        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                if (isBusy != value)
                {
                    isBusy = value;
                    OnPropertyChanged("IsBusy");
                    OnPropertyChanged("IsIdle");
                }
            }
        }

        public bool IsIdle
        {
            get { return !IsBusy; }
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
                    var platoCarritoServices = new PlatoCarritoServices();
                    var enCarrito = ListaPlatoCarrito.Where(p => p.PlatoId == platoSeleccionado.Id).FirstOrDefault();
                    if (enCarrito != null)
                    {
                        //El plato ya existe en el carrito
                        PlatoCarrito platoCarrito = new PlatoCarrito();
                        platoCarrito.Id = enCarrito.Id;
                        platoCarrito.PlatoId = enCarrito.PlatoId;
                        platoCarrito.UsuarioId = enCarrito.UsuarioId;
                        platoCarrito.Cantidad = enCarrito.Cantidad + key.Item2;
                        var isSuccessStatusCode = await platoCarritoServices.PutPlatoCarritoAsync(platoCarrito);
                        if (isSuccessStatusCode)
                        {
                            //ListaPlatoCarrito.Where(p => p.Plato == platoSeleccionado).FirstOrDefault().Cantidad = platoCarrito.Cantidad;
                            enCarrito.Cantidad = platoCarrito.Cantidad;
                            StatusMessage = "Se han añadido " + key.Item2 + " platos de " + platoSeleccionado.Titulo
                                + " correctamente.";
                        }
                        else
                        {
                            StatusMessage = "No se ha podido añadir el plato " + platoSeleccionado.Titulo + ".";
                        }
                    }
                    else
                    {
                        //El plato no existe en el carrito -> añadir nuevo en la BD y en local
                        PlatoCarrito platoCarrito = new PlatoCarrito();
                        platoCarrito.PlatoId = platoSeleccionado.Id;
                        platoCarrito.UsuarioId = UsuarioLogueado.Id;
                        platoCarrito.Cantidad = key.Item2;
                        var isSuccessStatusCode = await platoCarritoServices.PostPlatoCarritoAsync(platoCarrito);
                        if (isSuccessStatusCode)
                        {
                            List<PlatoCarrito> newListaPlatoCarrito = await platoCarritoServices.GetPlatoCarritoByUsuarioAsync(UsuarioLogueado.Id);
                            ListaPlatoCarrito.Add(newListaPlatoCarrito.Where(p => p.PlatoId == platoCarrito.PlatoId).FirstOrDefault());
                            StatusMessage = "Se han añadido " + key.Item2 + " platos de " + platoSeleccionado.Titulo 
                                + " correctamente.";
                        }
                        else
                        {
                            StatusMessage = "No se ha podido añadir el plato " + platoSeleccionado.Titulo + ".";
                        }
                    }

                    //carritoCompra.anadirPlato(platoCant);
                    
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

                    var menuCarritoServices = new MenuCarritoServices();
                    var enCarrito = ListaMenuCarrito.Where(p => p.MenuId == menuSeleccionado.Id).FirstOrDefault();
                    if (enCarrito != null)
                    {
                        //El menu ya existe en el carrito
                        MenuCarrito menuCarrito = new MenuCarrito();
                        menuCarrito.Id = enCarrito.Id;
                        menuCarrito.MenuId =  enCarrito.MenuId;
                        menuCarrito.UsuarioId = enCarrito.UsuarioId;
                        menuCarrito.Cantidad = enCarrito.Cantidad + key.Item2;
                        var isSuccessStatusCode = await menuCarritoServices.PutMenuCarritoAsync(menuCarrito);
                        if (isSuccessStatusCode)
                        {
                            //ListaMenuCarrito.Where(m => m.MenuId == menuSeleccionado.Id).FirstOrDefault().Cantidad = menuCarrito.Cantidad;
                            enCarrito.Cantidad = menuCarrito.Cantidad;
                            StatusMessage = "Se han añadido " + key.Item2 + " menus de " + menuSeleccionado.Titulo
                                + " correctamente.";
                        }
                        else
                        {
                            StatusMessage = "No se ha podido añadir el menu " + menuSeleccionado.Titulo + ".";
                        }
                    }
                    else
                    {
                        //El menu no existe en el carrito -> añadir nuevo en la BD y en local
                        MenuCarrito menuCarrito = new MenuCarrito();
                        menuCarrito.MenuId = menuSeleccionado.Id;
                        menuCarrito.UsuarioId = UsuarioLogueado.Id;
                        menuCarrito.Cantidad = key.Item2;
                        var isSuccessStatusCode = await menuCarritoServices.PostMenuCarritoAsync(menuCarrito);
                        if (isSuccessStatusCode)
                        {
                            List<MenuCarrito> newListaMenuCarrito = await menuCarritoServices.GetMenuCarritoByUsuarioAsync(UsuarioLogueado.Id);
                            ListaMenuCarrito.Add(newListaMenuCarrito.Where(m => m.MenuId == menuCarrito.MenuId).FirstOrDefault());
                            StatusMessage = "Se han añadido " + key.Item2 + " menus de " + menuSeleccionado.Titulo
                                + " correctamente.";
                        }
                        else
                        {
                            StatusMessage = "No se ha podido añadir el menu " + menuSeleccionado.Titulo + ".";
                        }
                    }

                    //carritoCompra.anadirMenu(menuCant);

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
                    var usuarioServices = new UsuarioServices();
                    Usuario usuario = UsuarioLogueado;
                    usuario.ChefSeleccionadoId = chefSeleccionado.Id;

                    var isSuccessStatusCode = await usuarioServices.PutUsuarioAsync(usuario.Id, usuario);
                    if (isSuccessStatusCode)
                    {
                        UsuarioLogueado.ChefSeleccionado = chefSeleccionado;
                        UsuarioLogueado.ChefSeleccionadoId = chefSeleccionado.Id;
                        StatusMessage = "Se ha elegido el chef " + chefSeleccionado.NombreApellidos + " correctamente.";
                    }
                    else
                    {
                        StatusMessage = "Hubo un problema al elegir el chef " + chefSeleccionado.NombreApellidos + ".";
                    }
                    //carritoCompra.chef = chefSeleccionado;

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

            var platosServices = new PlatosServices();
            allPlatos = await platosServices.GetPlatosAsync();

            var menusServices = new MenusServices();
            allMenus = await menusServices.GetMenusAsync();

            var chefServices = new ChefServices();
            allChefs = await chefServices.GetChefsAsync();

            var tipoCocinaServices = new TipoCocinaServices();
            ListaTipoCocina = await tipoCocinaServices.GetTipoCocinaAsync();
            
            var zonaServices = new ZonaServices();
            ListaZonas = await zonaServices.GetZonaAsync();

            //seleccion por defecto el -1 - cambiar cuando se implemente el login
            var usuarioServices = new UsuarioServices();
            UsuarioLogueado = await usuarioServices.GetUsuariosAsync(-1);

            var platoCarritoServices = new PlatoCarritoServices();
            ListaPlatoCarrito = await platoCarritoServices.GetPlatoCarritoByUsuarioAsync(UsuarioLogueado.Id);
            var menuCarritoServices = new MenuCarritoServices();
            ListaMenuCarrito = await menuCarritoServices.GetMenuCarritoByUsuarioAsync(UsuarioLogueado.Id);
            ZonaSeleccionada = ListaZonas.FirstOrDefault(z => z.Id == UsuarioLogueado.ZonaId);
            TipoCocinaSeleccionado = ListaTipoCocina.FirstOrDefault(t => t.Id == UsuarioLogueado.TipoCocinaId);

            FiltrarPlatosMenus();
            IsBusy = true;

            FiltrarChefs();
            IsBusy = true;
            
            IsBusy = false;
        }

        public async Task InitializeComentariosAsync(int idChef)
        {
            IsBusy = true;

            var comentarioChefServices = new ComentarioChefServices();
            ListaComentariosChef = await comentarioChefServices.GetComentariosChefAsync(idChef);

            IsBusy = false;
        }

        public void FiltrarPlatosMenus()
        {
            IsBusy = true;
            
            if (TipoCocinaSeleccionado != null)
            {
                ListaPlatos = allPlatos.Where(plato => plato.TipoCocina.Id == TipoCocinaSeleccionado.Id).ToList();
                ListaMenus = allMenus.Where(menu => menu.TipoCocina.Id == TipoCocinaSeleccionado.Id).ToList();
            }
            else
            {
                ListaPlatos = new List<Plato>();
                ListaMenus = new List<Menu>();
            }

            IsBusy = false;
        }

        public async void FiltrarChefs()
        {
            IsBusy = true;

            if (TipoCocinaSeleccionado != null)
            {
                ListaChefs = allChefs.Where(chef => chef.TipoCocina.Id == TipoCocinaSeleccionado.Id).ToList();
            }
            else
            {
                ListaChefs = allChefs;
            }

            if (ZonaSeleccionada != null)
            {
                ListaChefs = ListaChefs.Where(chef => chef.Zona.Id == ZonaSeleccionada.Id).ToList();
            }

            if (Fecha != null)
            {
                var disponibilidadServices = new DisponibilidadServices();
                var disponibilidadesChefsFecha = await disponibilidadServices.GetDisponibilidadesByDateAsync(fecha);

                List<Chef> nuevaListChefs = new List<Chef>();
                foreach (Disponibilidad disponibilidad in disponibilidadesChefsFecha)
                {
                    // cada disponibilidad corresponde a un chef diferente
                    // ya que Chef+Fecha es una clave unica
                    Chef chefReserva = ListaChefs.Where(c => c.Id == disponibilidad.ChefId).FirstOrDefault();
                    if (disponibilidad.EstaDisponible && chefReserva != null)
                    {
                        //chef disponible en fecha y ha pasado los filtros anteriores
                        var reservadoServices = new ReservadoServices();
                        var reservados = await reservadoServices.GetReservadosByDisponibilidadAsync(disponibilidad.Id);
                        // reservados 2 horas - 4 de cada 30 min
                        var reservado1 = reservados.Where(r => r.Hora.Hour == hora / 2 && r.Hora.Minute == hora % 2 * 30).FirstOrDefault();
                        var reservado2 = reservados.Where(r => r.Hora.Hour == (hora + 1) / 2 && r.Hora.Minute == (hora + 1) % 2 * 30).FirstOrDefault();
                        var reservado3 = reservados.Where(r => r.Hora.Hour == (hora + 2) / 2 && r.Hora.Minute == (hora + 2) % 2 * 30).FirstOrDefault();
                        var reservado4 = reservados.Where(r => r.Hora.Hour == (hora + 3) / 2 && r.Hora.Minute == (hora + 3) % 2 * 30).FirstOrDefault();

                        if (reservado1 != null && reservado1.PedidoId == -1
                            && reservado2 != null && reservado2.PedidoId == -1
                            && reservado3 != null && reservado3.PedidoId == -1
                            && reservado4 != null && reservado4.PedidoId == -1)
                        {
                            // Hora no reservada durante las 2 horas siguientes
                            nuevaListChefs.Add(chefReserva);

                        }
                    }
                }
                ListaChefs = nuevaListChefs;
            }
            IsBusy = false;
        }

        public async Task<bool> NuevoPedido(Pedido pedido)
        {
            IsBusy = true;

            var pedidoServices = new PedidoServices();
            var platoCarritoServices = new PlatoCarritoServices();
            var menuCarritoServices = new MenuCarritoServices();
            
            var isSuccessStatusCode = await pedidoServices.PostPedidoAsync(pedido);

            // Vaciar carrito de la compra y variables de pago.
            var isSuccessBorrado = await platoCarritoServices.DeletePlatoCarritoByUserAsync(UsuarioLogueado.Id);
            if (isSuccessBorrado)
            {
                ListaPlatoCarrito = new List<PlatoCarrito>();
            }
            isSuccessBorrado = await menuCarritoServices.DeleteMenuCarritoByUserAsync(UsuarioLogueado.Id);
            if (isSuccessBorrado)
            {
                ListaMenuCarrito = new List<MenuCarrito>();
            }

            IsBusy = false;
            return isSuccessStatusCode;

        }

        public async Task<bool> ModificarUsuarioAsync()
        {
            IsBusy = true;

            var usuarioServices = new UsuarioServices();

            var isSuccess = await usuarioServices.PutUsuarioAsync(usuarioLogueado.Id, usuarioLogueado);

            IsBusy = false;

            return isSuccess;
        }

        public async Task<bool> QuitarElementoCarritoAsync(string tipoElemento, int id) 
        {
            IsBusy = true;

            if (tipoElemento == "P")
            {
                // Es un plato
                var platoCarrito = ListaPlatoCarrito.FirstOrDefault(l => l.Plato.Id == id);
                if (!platoCarrito.Equals(new PlatoCarrito()))
                {
                    var cant = platoCarrito.Cantidad - 1;
                    var platoCarritoServices = new PlatoCarritoServices();
                    if (cant <= 0)
                    {
                        var isSuccess = await platoCarritoServices.DeletePlatoCarritoAsync(platoCarrito.Id);
                        if (isSuccess)
                        {
                            ListaPlatoCarrito.Remove(platoCarrito);
                        }

                        IsBusy = false;

                        return isSuccess;
                    }
                    else
                    {
                        PlatoCarrito newPlatoCarrito = new PlatoCarrito();
                        newPlatoCarrito.Id = platoCarrito.Id;
                        newPlatoCarrito.PlatoId = platoCarrito.PlatoId;
                        newPlatoCarrito.UsuarioId = platoCarrito.UsuarioId;
                        newPlatoCarrito.Cantidad = cant;
                        var isSuccess = await platoCarritoServices.PutPlatoCarritoAsync(newPlatoCarrito);
                        if(isSuccess)
                        {
                            platoCarrito.Cantidad--;
                        }

                        IsBusy = false;

                        return isSuccess;
                    }
                }
            }

            if (tipoElemento == "M")
            {
                // Es un menu
                var menuCarrito = ListaMenuCarrito.FirstOrDefault(l => l.Menu.Id == id);
                
                if (!menuCarrito.Equals(new MenuCarrito()))
                {
                    var cant = menuCarrito.Cantidad - 1;
                    var menuCarritoServices = new MenuCarritoServices();
                    if (cant <= 0)
                    {
                        var isSuccess = await menuCarritoServices.DeleteMenuCarritoAsync(menuCarrito.Id);
                        if (isSuccess)
                        {
                            ListaMenuCarrito.Remove(menuCarrito);
                        }

                        IsBusy = false;

                        return isSuccess;
                    }
                    else
                    {
                        MenuCarrito newMenuCarrito = new MenuCarrito();
                        newMenuCarrito.Id = menuCarrito.Id;
                        newMenuCarrito.MenuId = menuCarrito.MenuId;
                        newMenuCarrito.UsuarioId = menuCarrito.UsuarioId;
                        newMenuCarrito.Cantidad = cant;
                        var isSuccess = await menuCarritoServices.PutMenuCarritoAsync(newMenuCarrito);
                        if(isSuccess)
                        {
                            menuCarrito.Cantidad--;
                        }

                        IsBusy = false;

                        return isSuccess;
                    }
                }
            }

            IsBusy = false;
            return false;
        }

        public async void VaciarCarritoAsync()
        {
            IsBusy = true;

            if (ListaPlatoCarrito.Count > 0)
            {
                var platoCarritoServices = new PlatoCarritoServices();
                var isSuccess = await platoCarritoServices.DeletePlatoCarritoByUserAsync(UsuarioLogueado.Id);
                if (isSuccess)
                {
                    ListaPlatoCarrito = new List<PlatoCarrito>();
                }
            }
            if (ListaMenuCarrito.Count > 0)
            {
                var menuCarritoServices = new MenuCarritoServices();
                var isSuccess = await menuCarritoServices.DeleteMenuCarritoByUserAsync(UsuarioLogueado.Id);
                if (isSuccess)
                {
                    ListaMenuCarrito = new List<MenuCarrito>();
                }
            }

            IsBusy = false;
        }

        public async Task ListaPedidosAsync()
        {
            IsBusy = true;

            var pedidoServices = new PedidoServices();
            var listPedidos = await pedidoServices.GetPedidosUsuarioAsync(UsuarioLogueado.Id);
            foreach (Pedido pedido in listPedidos)
            {
                //FALTA COMPROBAR DISPONIBILIDAD PARA FILTRAR
                ListaPedidosActivos.Add(pedido);
            }

            IsBusy = false;
        }

        public async Task ElegirTipoCocinaAsync(TipoCocina tipoCocinaSel)
        {
            IsBusy = true;

            tipoCocinaSeleccionado = tipoCocinaSel;
            var usuarioServices = new UsuarioServices();
            Usuario usuario = UsuarioLogueado;
            usuario.TipoCocinaId = tipoCocinaSeleccionado.Id;
            usuario.ChefSeleccionadoId = null;

            var isSuccessStatusCode = await usuarioServices.PutUsuarioAsync(usuario.Id, usuario);
            if (isSuccessStatusCode)
            {
                UsuarioLogueado.TipoCocina = tipoCocinaSeleccionado;
                UsuarioLogueado.TipoCocinaId = tipoCocinaSeleccionado.Id;
                UsuarioLogueado.ChefSeleccionadoId = null;
                StatusMessage = "Se ha elegido el tipo cocina " + tipoCocinaSeleccionado.Titulo + " correctamente.";
            }
            else
            {
                StatusMessage = "Hubo un problema al elegir el tipo cocina " + tipoCocinaSeleccionado.Titulo + ".";
            }

            VaciarCarritoAsync();
            FiltrarPlatosMenus();
            FiltrarChefs();

            IsBusy = false;
        }


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
