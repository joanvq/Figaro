using Figaro.Models;
using Figaro.Other;
using Figaro.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Figaro.Views
{
    public partial class Registrar : ContentPage
    {
        public Registrar()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        public async void Registrar_OnClicked(object sender, EventArgs e)
        {
            RegistrarB.IsEnabled = false;
            Ocupado.IsEnabled = true;
            Ocupado.IsRunning = true;
            Ocupado.IsVisible = true;
            var vm = BindingContext as LoginViewModel;
            if (ComprovarCampos())
            {
                // Registrar y volver a la pagina de login
                Usuario usuario = new Usuario();
                usuario.Nombre = Nombre.Text;
                usuario.Apellidos = Apellidos.Text;
                usuario.Email = Email.Text;
                usuario.Password = Password.Text;
                usuario.Imagen = "/Content/Images/user.jpg";

                bool existe = await vm.ExisteEmail(usuario);
                if (existe)
                {
                    this.DisplayAlert("Error", "El correo electrónico introducido ya está registrado.", "OK");
                    RegistrarB.IsEnabled = true;
                    Ocupado.IsEnabled = false;
                    Ocupado.IsRunning = false;
                    Ocupado.IsVisible = false;
                }
                else
                {
                    bool isSuccess = await vm.RegistrarUsuario(usuario);
                    if (isSuccess)
                    {
                        await this.DisplayAlert("Registro", "Registrado correctamente.", "OK");
                        var usu = await vm.GetUsuarioByEmail(Email.Text, Password.Text);
                        if (usu == null)
                        {
                            await Navigation.PopAsync();
                            Navigation.PushAsync(new LoginMail());
                        }
                        else
                        {
                            // Loguear
                            vm.UsuarioLogueado = usu;
                            vm.LoginAccess();
                        }
                    }
                    else
                    {
                        this.DisplayAlert("Error", "Ha ocurrido un error en el registro.", "OK");
                        RegistrarB.IsEnabled = true;
                        Ocupado.IsEnabled = false;
                        Ocupado.IsRunning = false;
                        Ocupado.IsVisible = false;
                    }
                }
            }
            else
            {
                RegistrarB.IsEnabled = true;
                Ocupado.IsEnabled = false;
                Ocupado.IsRunning = false;
                Ocupado.IsVisible = false;
            }
        }

        private bool ComprovarCampos()
        {
            var comprobacion = true;
            if (Nombre.Text == "" || Nombre.Text == null) {
                comprobacion = false;
                Nombre.PlaceholderColor = Color.Red;
                Nombre.Placeholder = "NOMBRE (Campo Obligatorio)";
                AvisoNombre.IsEnabled = true;
                AvisoNombre.IsVisible = true;
            }
            else
            {
                Nombre.PlaceholderColor = Color.White;
                Nombre.Placeholder = "NOMBRE";
                AvisoNombre.IsEnabled = false;
                AvisoNombre.IsVisible = false;
            }
            if (Apellidos.Text == "" || Apellidos.Text == null)
            {
                comprobacion = false;
                Apellidos.PlaceholderColor = Color.Red;
                Apellidos.Placeholder = "APELLIDOS (Campo Obligatorio)";
            }
            else
            {
                Apellidos.PlaceholderColor = Color.White;
                Apellidos.Placeholder = "APELLIDOS";
            }
            if (Email.Text == "" || Email.Text == null)
            {
                comprobacion = false;
                Email.PlaceholderColor = Color.Red;
                Email.Placeholder = "CORREO ELECTRÓNICO (Campo Obligatorio)";
            }
            else
            {
                var util = new Utils();
                if (!util.IsValidEmail(Email.Text))
                {
                    comprobacion = false;
                    Email.TextColor = Color.Red;
                    Email.Placeholder = "CORREO ELECTRÓNICO (Campo Obligatorio)";
                }
                else
                {
                    Email.PlaceholderColor = Color.White;
                    Email.Placeholder = "CORREO ELECTRÓNICO";
                }
            }
            if (Password.Text == "" || Password.Text == null)
            {
                comprobacion = false;
                Password.PlaceholderColor = Color.Red;
                Password.Placeholder = "CONTRSEÑA (Campo Obligatorio)";

            }
            else if (Password.Text.Length < 7)
            {
                comprobacion = false;
                Password.TextColor = Color.Red;
                Password.Placeholder = "CONTRSEÑA (Campo Obligatorio)";
            }
            else
            {
                Password.PlaceholderColor = Color.White;
                Password.Placeholder = "CONTRSEÑA";
            }
            return comprobacion;
        }

        public void Cancel_OnClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}
