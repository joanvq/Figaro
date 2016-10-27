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
        private Usuario usuarioLogueado;

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

        public TipoCocinaViewModel()
        {
        }

        public async Task InitializeDataAsync(Usuario usuario)
        {
            IsBusy = true;

            var tipoCocinaServices = new TipoCocinaServices();
            ListaTipoCocina = await tipoCocinaServices.GetTipoCocinaAsync();
            UsuarioLogueado = usuario;

            IsBusy = false;
        }

        public async Task<bool> ElegirTipoCocinaAsync(TipoCocina tipoCocinaSel)
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
                UsuarioLogueado.ChefSeleccionado = null;
            }

            IsBusy = false;

            return isSuccessStatusCode;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
