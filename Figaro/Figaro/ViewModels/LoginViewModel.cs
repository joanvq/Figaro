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
    class LoginViewModel
    {
        private Usuario _usuarioLogueado;
        private bool _isBusy;
        private List<Zona> listaZonas;
        private Zona zonaSeleccionada;

        public Usuario UsuarioLogueado
        {
            get { return _usuarioLogueado; }
            set
            {
                _usuarioLogueado = value;
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

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        public LoginViewModel()
        {

        }

        public async Task<bool> InitializeZonasAsync(Usuario usuario)
        {
            IsBusy = true;

            var zonasServices = new ZonaServices();
            ListaZonas = await zonasServices.GetZonaAsync();
            UsuarioLogueado = usuario;
            return true;

            IsBusy = false;
        }

        public async Task<bool> ExisteEmail(Usuario usuario)
        {
            IsBusy = true;

            var usuarioServices = new UsuarioServices();
            var existe = await usuarioServices.GetExisteUsuarioByEmailAsync(usuario.Email);

            IsBusy = false;

            return existe;
        }

        public async Task<bool> RegistrarUsuario(Usuario usuario)
        {
            IsBusy = true;

            UsuarioLogueado = usuario;

            var usuarioServices = new UsuarioServices();
            var isSuccess = await usuarioServices.PostUsuarioAsync(usuario);

            IsBusy = false;

            return isSuccess;
        }

        public async Task<Usuario> GetUsuarioByEmail(string email, string password)
        {
            IsBusy = true;

            var usuarioServices = new UsuarioServices();
            var usu = await usuarioServices.GetUsuarioByEmailAsync(email, password);

            IsBusy = false;

            return usu;
        }

        public async void LoginAccess()
        {
            if (UsuarioLogueado.Email == null)
            {
                // Añadir Email
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() => App.Current.MainPage = new NavigationPage(new SeleccionarMail(UsuarioLogueado)));
            }
            else if (UsuarioLogueado.TipoCocinaId == null)
            {
                // Añadir Tipo Cocina Seleccionada
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() => App.Current.MainPage = new NavigationPage(new SeleccionarTipoCocinaIni(UsuarioLogueado)));
            }
            else if (UsuarioLogueado.ZonaId == null)
            {
                // Añadir Zona Seleccionada
                App.Current.MainPage = new NavigationPage(new SeleccionarZonaIni(UsuarioLogueado));
                //Xamarin.Forms.Device.BeginInvokeOnMainThread(() => App.Current.MainPage = new NavigationPage(new SeleccionarZonaIni(UsuarioLogueado)));
            }
            else {
                // FALTA Encriptar pass i Guardar

                // Guardar usuario en local
                //IFolder rootFolder = FileSystem.Current.LocalStorage;
                //IFolder folder = await rootFolder.CreateFolderAsync("Conf",
                //    CreationCollisionOption.OpenIfExists);
                //IFile file = await folder.CreateFileAsync("conf",
                //    CreationCollisionOption.ReplaceExisting);
                //await file.WriteAllTextAsync(UsuarioLogueado.Email + " " + UsuarioLogueado.Password);

                //Xamarin.Forms.Device.BeginInvokeOnMainThread(() => App.Current.MainPage = new NavigationPage(new SeleccionarTipoComida(UsuarioLogueado)));
                
                App.Current.MainPage = new NavigationPage(new SeleccionarTipoComida(UsuarioLogueado));
            }

        }

        public async Task<bool> AddMail(string email)
        {
            IsBusy = true;
            if (UsuarioLogueado != null)
            {
                UsuarioLogueado.Email = email;
                var usuarioServices = new UsuarioServices();
                var isSuccess = await usuarioServices.PutUsuarioAsync(UsuarioLogueado.Id, UsuarioLogueado);
                IsBusy = false;
                return isSuccess;
            }
            IsBusy = false;
            return false;
        }

        public async Task<bool> ElegirZonaAsync(Zona zonaSel)
        {
            IsBusy = true;

            // Modificar actual en Zona Anterior y Actual
            if (ZonaSeleccionada != null)
            {
                Zona zonaAnt = ListaZonas.FirstOrDefault(l => l.Id == ZonaSeleccionada.Id);
                if (zonaAnt != null)
                {
                    zonaAnt.Actual = false;
                }
            }

            Zona zonaAct = ListaZonas.FirstOrDefault(l => l.Id == zonaSel.Id);
            if (zonaAct != null)
            {
                zonaAct.Actual = true;
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
            }

            IsBusy = false;

            return isSuccessStatusCode;
        }



        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
