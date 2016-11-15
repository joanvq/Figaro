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
        

    }
}
