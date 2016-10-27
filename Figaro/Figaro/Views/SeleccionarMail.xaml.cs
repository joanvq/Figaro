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
    public partial class SeleccionarMail : ContentPage
    {
        public SeleccionarMail(Usuario usuario)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            var vm = BindingContext as LoginViewModel;
            vm.UsuarioLogueado = usuario;
        }

        public async void Continuar_OnClicked(object sender, EventArgs e)
        {
            var vm = BindingContext as LoginViewModel;
            var util = new Utils();

            if (Email.Text != null && Email.Text != "")
            {
                if (!util.IsValidEmail(Email.Text))
                {
                    Message.Text = "Correo electrónico no válido";
                    Message.IsEnabled = true;
                    Message.IsVisible = true;
                }
                else
                {
                    // Comprobar que es correcto y Obtener el Usuario
                    var isSuccess = await vm.AddMail(Email.Text);
                    if (isSuccess)
                    {
                        //Loguear
                        vm.LoginAccess();
                    }
                    else
                    {
                        // Problema guardando el mail
                        Message.Text = "Hubo un problema guardando el correo electrónico";
                        Message.IsEnabled = true;
                        Message.IsVisible = true;
                    } 
                }
            }
        }
    }
}
