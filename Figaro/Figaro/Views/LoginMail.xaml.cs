﻿using Figaro.Other;
using Figaro.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Figaro.Views
{
    public partial class LoginMail : ContentPage
    {
        public LoginMail()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        public async void Login_OnClicked(object sender, EventArgs e)
        {
            var vm = BindingContext as LoginViewModel;
            var util = new Utils();

            if(Email.Text != null && Email.Text != "" && Password.Text != null && Password.Text != "")
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
                    var usu = await vm.GetUsuarioByEmail(Email.Text, Password.Text);
                    if(usu == null)
                    {
                        Message.Text = "Correo electrónico y/o contraseña no correctos";
                        Message.IsEnabled = true;
                        Message.IsVisible = true;
                    }
                    else
                    {
                        // Loguear
                        vm.UsuarioLogueado = usu;
                        vm.LoginAccess();
                    }
                }
            }
        }

        public void Cancel_OnClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}
