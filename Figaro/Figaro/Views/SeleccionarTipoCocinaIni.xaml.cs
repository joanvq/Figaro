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
    public partial class SeleccionarTipoCocinaIni : ContentPage
    {
        public SeleccionarTipoCocinaIni(Usuario usuario)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, true);

            var vm = BindingContext as TipoCocinaViewModel;
            vm.InitializeDataAsync(usuario);
        }

        public async void TipoCocina_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var tipoCocina = ListaTipoCocinaView.SelectedItem as TipoCocina;
            if (tipoCocina != null)
            {
                var vm = BindingContext as TipoCocinaViewModel;
                if (vm != null)
                {
                    bool isSuccess = await vm.ElegirTipoCocinaAsync(tipoCocina);
                    if(isSuccess)
                    {
                        //Login
                        var lvm = new LoginViewModel();
                        lvm.UsuarioLogueado = vm.UsuarioLogueado;
                        lvm.LoginAccess();
                    }
                    else
                    {
                        Message.Text = "Hubo un problema al elegir el tipo cocina " + tipoCocina.Titulo + ".";
                        Message.IsEnabled = true;
                        Message.IsVisible = true;
                    }
                }
            }
        }
    }
}
