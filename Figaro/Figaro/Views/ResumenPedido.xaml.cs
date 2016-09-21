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
    public partial class ResumenPedido : ContentPage
    {
        public ResumenPedido(Pedido pedido)
        {
            InitializeComponent();

            nPedido.Text = pedido.NPedido;
            
        }

        public void EnviarMail(bool WasSuccessful)
        {
            if (WasSuccessful)
            {
                //Enviará mail

                var mainViewModel = BindingContext as MainViewModel;
                status.Text = "Se ha enviado un correo a " + mainViewModel.UsuarioLogueado.Email;
            }
            else
            {
                status.Text = "Ha ocurrido un problema mientras se guardaba el pedido." +
                    "Porfavor contacte con ..... Se ha enviado un mail con la incidancia.";
                //Enviar mail al admministrador
            }
        }

        public void Cerrar_OnClicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }
    }
}
