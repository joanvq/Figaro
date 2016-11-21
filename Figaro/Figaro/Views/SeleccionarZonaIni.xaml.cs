using Figaro.Models;
using Figaro.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Figaro.Views
{
    public partial class SeleccionarZonaIni : ContentPage
    {
        public SeleccionarZonaIni(Usuario usuario)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, true);
            Init(usuario);
        }

        private async void Init(Usuario usuario)
        {
            var vm = BindingContext as LoginViewModel;
            var isSuccess = await vm.InitializeZonasAsync(usuario);
            ListaZonaView.ItemsSource = vm.ListaZonas;
        }

        public async void Zona_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var zona = ListaZonaView.SelectedItem as Zona;
            if (zona != null)
            {
                var vm = BindingContext as LoginViewModel;
                if (vm != null)
                {
                    bool isSuccess = await vm.ElegirZonaAsync(zona);
                    if(isSuccess)
                    {
                        //Login
                        var lvm = new LoginViewModel();
                        lvm.UsuarioLogueado = vm.UsuarioLogueado;
                        lvm.LoginAccess();
                    }
                    else
                    {
                        Message.Text = "Hubo un problema al elegir el tipo cocina " + zona.Titulo + ".";
                        Message.IsEnabled = true;
                        Message.IsVisible = true;
                    }
                }
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            this.Content = null;
        }
    }
}
