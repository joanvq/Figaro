using Figaro.Models;
using Figaro.Other;
using Figaro.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Figaro.Views
{
    public partial class UserPage : ContentPage
    {
        public UserPage()
        {
            InitializeComponent();

            var mainViewModel = BindingContext as MainViewModel;
            
            var menuInferior = new MenuInferior(this);
            menuInferior.mainViewmodel = mainViewModel;
            Menu_Button.GestureRecognizers.Add(menuInferior.tapMenu);
            Plato_Button.GestureRecognizers.Add(menuInferior.tapPlato);
            Chefs_Button.GestureRecognizers.Add(menuInferior.tapChefs);
            Profile_Button.GestureRecognizers.Add(menuInferior.tapProfile);

            var genero = mainViewModel.UsuarioLogueado.genero;
            if (genero=="Sin especificar")
            {
                Genero.SelectedIndex = 0;
            }
            else if (genero=="Hombre")
            {
                Genero.SelectedIndex = 1;
            }
            else if (genero=="Mujer")
            {
                Genero.SelectedIndex = 2;
            }
            InitNavBar();
        }

        public void InitNavBar()
        {
            //var calendario = new ToolbarItem
            //{
            //    Icon = "icono_time.png",
            //    Command = new Command(() =>
            //    {
            //        //DisplayAlert("Menu", "Ciudades tapped", "OK");
            //        Navigation.PushAsync(new SeleccionarDiaHora());
            //    })
            //};
            //this.ToolbarItems.Add(calendario);

            var cocina = new ToolbarItem
            {
                Text = "Seleccionar cocina",
                Icon = "seleccion_comida.png",
                Command = new Command(() =>
                {
                    //DisplayAlert("Menu", "Ciudades tapped", "OK");
                    Navigation.PushAsync(new SeleccionarTipoCocina());
                })
            };
            this.ToolbarItems.Add(cocina);

            var ciudades = new ToolbarItem
            {
                Text = "Seleccionar zona",
                Icon = "map_maker.png",
                Command = new Command(() =>
                {
                    //DisplayAlert("Menu", "Ciudades tapped", "OK");
                    Navigation.PushAsync(new SeleccionarZona());
                })
            };
            this.ToolbarItems.Add(ciudades);

            var cesta = new ToolbarItem
            {
                Text = "Cesta",
                Icon = "cesta.png",
                Command = new Command(() =>
                {
                    //DisplayAlert("Menu", "Cesta tapped", "OK");
                    Navigation.PushAsync(new VerCarrito());
                })
            };
            this.ToolbarItems.Add(cesta);
        }

        private async void Post_OnClicked(object sender, EventArgs e)
        {
            var mainViewModel = BindingContext as MainViewModel;
            var isSuccess = await mainViewModel.ModificarUsuarioAsync();
            if (isSuccess)
            {
                await DisplayAlert("Perfil","Perfil de usuario modificado correctamente.","OK");
            }
            else
            {
                await DisplayAlert("Perfil", "Ocurrió un error modificando el perfil de usuario.","OK");
            }
        }

        private void ActualizarUsuario_OnClicked(object sender, EventArgs e)
        {
            var mainViewModel = BindingContext as MainViewModel;
            if (Genero.SelectedIndex != -1)
            {
                mainViewModel.UsuarioLogueado.genero = Genero.Items[Genero.SelectedIndex];
            }
        }

        private void VerPedidos_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new VerPedidos());
        }
        
        private void Logout_OnClicked(object sender, EventArgs e)
        {
            var mvm = BindingContext as MainViewModel;
            mvm.LogOut();
        }

    }
}
