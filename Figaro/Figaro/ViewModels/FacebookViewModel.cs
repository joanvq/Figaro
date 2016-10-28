using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Figaro.Models;
using Figaro.Services;

namespace Figaro.ViewModels
{
    public class FacebookViewModel : INotifyPropertyChanged
    {
        private FacebookProfile _facebookProfile;
        private Usuario _usuarioLogueado;
        private bool _isBusy;

        public FacebookProfile FacebookProfile
        {
            get { return _facebookProfile; }
            set
            {
                _facebookProfile = value;
                OnPropertyChanged();
            }
        }

        public Usuario UsuarioLogueado
        {
            get { return _usuarioLogueado; }
            set
            {
                _usuarioLogueado = value;
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

        public async Task<bool> SetFacebookUserProfileAsync(string accessToken)
        {
            IsBusy = true;

            var facebookServices = new FacebookServices();

            FacebookProfile = await facebookServices.GetFacebookProfileAsync(accessToken);

            UsuarioLogueado = new Usuario();
            UsuarioLogueado.Apellidos = FacebookProfile.LastName;
            UsuarioLogueado.Nombre = FacebookProfile.FirstName;
            UsuarioLogueado.Password = "none";
            UsuarioLogueado.Imagen = FacebookProfile.Picture.Data.Url;
            UsuarioLogueado.FacebookId = FacebookProfile.Id;
             
            var usuarioServices = new UsuarioServices();
            var usuario = await usuarioServices.PostUsuarioFacebookAsync(UsuarioLogueado);
            if(usuario != null)
            {
                
                UsuarioLogueado = usuario;
                
                IsBusy = false;
                return true;
            }
            else
            {
                IsBusy = false;
                return false;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
