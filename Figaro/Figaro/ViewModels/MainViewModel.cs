using Figaro.Models;
using Figaro.Other;
using Figaro.Services;
using Figaro.Views;
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
        private bool noPlatos;
        private List<Plato> searchedPlatos;
        private string keywordPlato;
        private bool isBusy;
        private string statusMessage;
        private Plato platoSeleccionado = new Plato();
        
        private List<TipoCocina> listaTipoCocina;
        private TipoCocina tipoCocinaSeleccionado = null;

        private List<Menu> allMenus;
        private List<Menu> listaMenus;
        private bool noMenus;
        private Menu menuSeleccionado = new Menu();

        private List<Chef> allChefs;
        private List<Chef> listaChefs;
        private bool noChefs;
        private bool noFecha;
        private Chef chefSeleccionado = new Chef();
        
        private List<Zona> listaZonas;
        private Zona zonaSeleccionada = null;

        private List<ComentarioChef> listaComentariosChef;
        private List<ComentarioPlatoMenu> listaComentarioPlatoMenu;

        private Usuario usuarioLogueado;
        
        //private static Carrito carritoCompra = new Carrito();

        private List<PlatoCarrito> listaPlatoCarrito;
        private List<MenuCarrito> listaMenuCarrito;

        private List<Pedido> listaPedidosRealizados = new List<Pedido>();
        private List<Pedido> listaPedidosActivos = new List<Pedido>();

        private DateTime? fecha = null;
        // De 0 a 47 --> 24 horas + medias horas
        private int hora = DateTime.Now.Hour * 2 + 1;

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

        public bool NoPlatos
        {
            get { return noPlatos; }
            set
            {
                noPlatos = value;
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

        public bool NoMenus
        {
            get { return noMenus; }
            set
            {
                noMenus = value;
                OnPropertyChanged();
            }
        }

        /* CHEF */

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

        public bool NoChefs
        {
            get { return noChefs; }
            set
            {
                noChefs = value;
                OnPropertyChanged();
            }
        }

        public bool NoFecha
        {
            get { return noFecha; }
            set
            {
                noFecha = value;
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

        /* COMENTARIOS */

        public List<ComentarioChef> ListaComentariosChef
        {
            get { return listaComentariosChef; }
            set
            {
                listaComentariosChef = value;
                OnPropertyChanged();
            }
        }

        public List<ComentarioPlatoMenu> ListaComentarioPlatoMenu
        {
            get { return listaComentarioPlatoMenu; }
            set
            {
                listaComentarioPlatoMenu = value;
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

        public DateTime? Fecha
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

        public string PlatoFooter
        {
            get {
                if (UsuarioLogueado != null)
                {
                    if (UsuarioLogueado.TipoCocinaId == 1)
                    {
                        return "bottom_asian.png";
                    }
                    else if (UsuarioLogueado.TipoCocinaId == 2)
                    {
                        return "bottom_italian.png";
                    }
                    return "bottom_world.png";
                }
                return "";
            }
        }

        public string PlatoFooterActual
        {
            get
            {
                if (UsuarioLogueado != null)
                {
                    if (UsuarioLogueado.TipoCocinaId == 1)
                    {
                        return "bottom_asian_select.png";
                    }
                    else if (UsuarioLogueado.TipoCocinaId == 2)
                    {
                        return "bottom_italian_select.png";
                    }
                    return "bottom_world_select.png";
                }
                return "";
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
                return new Command(async () => await InitializeDataAsync(UsuarioLogueado));
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

        }

        public async Task<bool> InitializeDataAsync(Usuario usuLog)
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
            UsuarioLogueado = usuLog;

            var platoCarritoServices = new PlatoCarritoServices();
            ListaPlatoCarrito = await platoCarritoServices.GetPlatoCarritoByUsuarioAsync(UsuarioLogueado.Id);
            var menuCarritoServices = new MenuCarritoServices();
            ListaMenuCarrito = await menuCarritoServices.GetMenuCarritoByUsuarioAsync(UsuarioLogueado.Id);
            Zona zona = ListaZonas.FirstOrDefault(z => z.Id == UsuarioLogueado.ZonaId);
            if(zona != null)
            {
                zona.Actual = true;
                zona.NoActual = false;
                ZonaSeleccionada = zona;
            }
            TipoCocina tipoCocina = ListaTipoCocina.FirstOrDefault(t => t.Id == UsuarioLogueado.TipoCocinaId);
            if (tipoCocina != null)
            {
                tipoCocina.Actual = true;
                tipoCocina.NoActual = false;
            }
            TipoCocinaSeleccionado = tipoCocina;
            FiltrarPlatosMenus();
            IsBusy = true;

            FiltrarChefs();
            IsBusy = true;
            
            IsBusy = false;

            return true;
        }

        public async Task InitializeComentariosChefAsync(int idChef)
        {
            IsBusy = true;

            var comentarioChefServices = new ComentarioChefServices();
            ListaComentariosChef = await comentarioChefServices.GetComentariosChefAsync(idChef);

            IsBusy = false;
        }

        public async Task InitializeComentariosPlatoAsync(int idPlato)
        {
            IsBusy = true;

            var comentarioPlatoMenuServices = new ComentarioPlatoMenuServices();
            ListaComentarioPlatoMenu = await comentarioPlatoMenuServices.GetComentariosPlatoAsync(idPlato);

            IsBusy = false;
        }

        public async Task InitializeComentariosMenuAsync(int idMenu)
        {
            IsBusy = true;

            var comentarioPlatoMenuServices = new ComentarioPlatoMenuServices();
            ListaComentarioPlatoMenu = await comentarioPlatoMenuServices.GetComentariosMenuAsync(idMenu);

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

            NoPlatos = ListaPlatos.Count.Equals(0);
            NoMenus = ListaMenus.Count.Equals(0);

            IsBusy = false;
        }

        public async void FiltrarChefs()
        {
            IsBusy = true;

            List<Chef> listChefs = new List<Chef>();
            ListaChefs = new List<Chef>();

            if (TipoCocinaSeleccionado != null)
            {
                listChefs = allChefs.Where(chef => chef.TipoCocina.Id == TipoCocinaSeleccionado.Id).ToList();
            }
            else
            {
                listChefs = new List<Chef>();
            }

            if (ZonaSeleccionada != null)
            {
                listChefs = listChefs.Where(chef => chef.Zona.Id == ZonaSeleccionada.Id).ToList();
            }

            if (Fecha != null)
            {
                DateTime fec = (DateTime)fecha;

                var disponibilidadServices = new DisponibilidadServices();
                var disponibilidadesChefsFecha = await disponibilidadServices.GetDisponibilidadesByDateAsync(fec);

                List<Chef> nuevaListChefs = new List<Chef>();
                foreach (Disponibilidad disponibilidad in disponibilidadesChefsFecha)
                {
                    // cada disponibilidad corresponde a un chef diferente
                    // ya que Chef+Fecha es una clave unica
                    Chef chefReserva = listChefs.Where(c => c.Id == disponibilidad.ChefId).FirstOrDefault();
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
                listChefs = nuevaListChefs;
            }
            else
            {
                listChefs = new List<Chef>();
            }

            NoFecha = listChefs.Count.Equals(0) && !Fecha.Equals(null);
            NoChefs = listChefs.Count.Equals(0);
            ListaChefs = listChefs;

            IsBusy = false;
        }

        public async Task<Pedido> NuevoPedido(Pedido pedido)
        {
            IsBusy = true;

            var pedidoServices = new PedidoServices();
            var platoCarritoServices = new PlatoCarritoServices();
            var menuCarritoServices = new MenuCarritoServices();
            var reservadoServices = new ReservadoServices();
            var disponibilidadServices = new DisponibilidadServices();
            
            Pedido pedidoCreado = await pedidoServices.PostPedidoAsync(pedido);
            List<Disponibilidad> listDisponibilidad = await disponibilidadServices.GetDisponibilidadesByChefAsync(UsuarioLogueado.ChefSeleccionadoId);
            var disp = listDisponibilidad.FirstOrDefault(l => l.Fecha.Date == Fecha.Value.Date);
            if (disp != null)
            {
                List<Reservado> listReservado = await reservadoServices.GetReservadosByDisponibilidadAsync(disp.Id);
                var h = Hora / 2;
                var m = (Hora % 2) * 30;
                IEnumerable<Reservado> reservas = null;
                if (m == 0)
                {
                    reservas = listReservado.Where(l => l.Hora.Hour == h && l.Hora.Minute == m ||
                        l.Hora.Hour == h && l.Hora.Minute == m + 30 ||
                        l.Hora.Hour == h+1 && l.Hora.Minute == m ||
                        l.Hora.Hour == h+1 && l.Hora.Minute == m + 30);
                }
                else if (m == 30)
                {
                    reservas = listReservado.Where(l => l.Hora.Hour == h && l.Hora.Minute == m ||
                        l.Hora.Hour == h+1 && l.Hora.Minute == m - 30 ||
                        l.Hora.Hour == h + 1 && l.Hora.Minute == m ||
                        l.Hora.Hour == h + 2 && l.Hora.Minute == m - 30);
                }
                foreach (Reservado reserva in reservas)
                {
                    var isSuccessReserva = await reservadoServices.PutReservadoEnPedidoAsync(reserva.Id, pedidoCreado.Id);
                }
            }

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
            Fecha = null;
            Hora = DateTime.Now.Hour*2 + 1;

            FiltrarChefs();

            IsBusy = false;
            return pedidoCreado;

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

            ListaPedidosActivos = new List<Pedido>();
            ListaPedidosRealizados = new List<Pedido>();
            var pedidoServices = new PedidoServices();
            var listPedidos = await pedidoServices.GetPedidosUsuarioAsync(UsuarioLogueado.Id);
            foreach (Pedido pedido in listPedidos)
            {
                //FALTA COMPROBAR DISPONIBILIDAD PARA FILTRAR
                var reservadoServices = new ReservadoServices();
                var listReservados = await reservadoServices.GetReservadosByPedidoAsync(pedido.Id);
                DateTime fecha = listReservados.FirstOrDefault().Disponibilidad.Fecha;
                if (fecha.Date >= DateTime.Now.Date)
                {
                    ListaPedidosActivos.Add(pedido);
                }
                else
                {
                    ListaPedidosRealizados.Add(pedido);
                }
            }

            IsBusy = false;
        }

        public async Task ElegirTipoCocinaAsync(TipoCocina tipoCocinaSel)
        {
            IsBusy = true;

            // Modificar actual en TipoCocina Anterior y Actual
            if (tipoCocinaSel != null)
            {
                TipoCocina tipoCocinaAnt = ListaTipoCocina.FirstOrDefault(l => l.Id == TipoCocinaSeleccionado.Id);
                if (tipoCocinaAnt != null)
                {
                    tipoCocinaAnt.Actual = false;
                    tipoCocinaAnt.NoActual = true;
                }
            }

            TipoCocina tipoCocinaAct = ListaTipoCocina.FirstOrDefault(l => l.Id == tipoCocinaSel.Id);
            if (tipoCocinaAct != null)
            {
                tipoCocinaAct.Actual = true;
                tipoCocinaAct.NoActual = false;
                TipoCocinaSeleccionado = tipoCocinaAct;
            }

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
                UsuarioLogueado.ChefSeleccionado = null;
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

        public async Task ElegirZonaAsync(Zona zonaSel)
        {
            IsBusy = true;

            // Modificar actual en Zona Anterior y Actual
            if(ZonaSeleccionada != null)
            {
                Zona zonaAnt = ListaZonas.FirstOrDefault(l => l.Id == ZonaSeleccionada.Id);
                if (zonaAnt != null)
                {
                    zonaAnt.Actual = false;
                    zonaAnt.NoActual = true;
                }
            }
            
            Zona zonaAct = ListaZonas.FirstOrDefault(l => l.Id == zonaSel.Id);
            if (zonaAct != null)
            {
                zonaAct.Actual = true;
                zonaAct.NoActual = false;
                ZonaSeleccionada = zonaAct;
            }

            // Añadir ZonaSeleccionada a Usuario y poner a null el ChefSeleccionado
            var usuarioServices = new UsuarioServices();
            Usuario usuario = UsuarioLogueado;
            usuario.ZonaId = zonaSeleccionada.Id;
            usuario.ChefSeleccionadoId = null;

            var isSuccessStatusCode = await usuarioServices.PutUsuarioAsync(usuario.Id, usuario);
            if (isSuccessStatusCode)
            {
                UsuarioLogueado.Zona = zonaSeleccionada;
                UsuarioLogueado.ZonaId = zonaSeleccionada.Id;
                UsuarioLogueado.ChefSeleccionadoId = null;
                UsuarioLogueado.ChefSeleccionado = null;
                StatusMessage = "Se ha guardado la zona " + zonaSeleccionada.Titulo + " en las opciones de Usuario.";
            }
            else
            {
                StatusMessage = "Hubo un problema al guardar la zona " + zonaSeleccionada.Titulo + " en las opciones de Usuario.";
            }

            FiltrarChefs();

            IsBusy = false;
        }

        public async Task ElegirFechaHoraAsync(DatePicker fecha, TimePicker hora)
        {
            IsBusy = true;
            
            Fecha = new DateTime(fecha.Date.Year, fecha.Date.Month, fecha.Date.Day);

            // Guarda de media hora en media hora, sera 1 o 0 dependiendo de si
            // se le suma la media hora o no
            int minutos = (hora.Time.Minutes >= 30) ? 1 : 0;
            Hora = hora.Time.Hours * 2 + minutos;
            
            var usuarioServices = new UsuarioServices();
            Usuario usuario = UsuarioLogueado;
            usuario.ChefSeleccionadoId = null;

            var isSuccessStatusCode = await usuarioServices.PutUsuarioAsync(usuario.Id, usuario);
            if (isSuccessStatusCode)
            {
                UsuarioLogueado.ChefSeleccionadoId = null;
                UsuarioLogueado.ChefSeleccionado = null;
            }
            else
            {
                StatusMessage = "Hubo un problema cambiar la hora y borrar el chef seleccionado: " + chefSeleccionado.NombreApellidos + ".";
            }
            
            FiltrarChefs();
            IsBusy = false;
        }


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
