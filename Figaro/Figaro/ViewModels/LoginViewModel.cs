using Figaro.Models;
using Figaro.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Figaro.ViewModels
{
    class LoginViewModel
    {
        private Usuario _usuarioLogueado;
        private bool _isBusy;

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

        public LoginViewModel()
        {

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


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
