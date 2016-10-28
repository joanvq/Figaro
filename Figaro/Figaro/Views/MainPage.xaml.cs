using Figaro.Models;
using Figaro.Services;
using Figaro.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Figaro.Views
{
    public partial class  MainPage : ContentPage
    {
        public MainPage(Usuario usuario)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            if (usuario == null)
            {
                // No se ha guardado perfil en local
                // Comprobar cache e intentat conectar a facebook

                // Si no se puede mostrar botones
                ConectarFace.IsVisible = true;
                Registrarse.IsVisible = true;
                IniciarSesion.IsVisible = true;
            }
            else
            {
                // Comprobar usuario logueado
                LoguearUsuarioMail(usuario);
                
            }
        }
        
        public async void LoguearUsuarioMail(Usuario usuario)
        {
            var usuarioServices = new UsuarioServices();
            var usu = await usuarioServices.GetUsuarioByEmailAsync(usuario.Email, usuario.Password);
            if (usu != null)
            {
                var lvm = new LoginViewModel();
                lvm.LoginAccess();
            }
            else
            {
                ConectarFace.IsVisible = true;
                Registrarse.IsVisible = true;
                IniciarSesion.IsVisible = true;
            }
        }

        public void LoginFacebook_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginFacebook());
        }

        public void Registrar_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registrar());
        }

        public void Login_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginMail());
        }

    }
}
