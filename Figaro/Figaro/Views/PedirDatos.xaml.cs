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
    public partial class PedirDatos : ContentPage
    {
        public PedirDatos()
        {
            InitializeComponent();
        }

        public void Pagar_OnClicked(object sender, EventArgs e)
        {
            if(direccion.Text != null)
            {
                var mainViewModel = BindingContext as MainViewModel;
                Pedido nuevoPedido = new Pedido();
                nuevoPedido.Direccion = direccion.Text;
                nuevoPedido.Usuario = mainViewModel.UsuarioLogueado;
                nuevoPedido.Estado = "pendiente";
                //Para numero pedido deber generar y 
                //comprovar que no existe, si existe generará uno nuevo
                Random rnd = new Random();
                nuevoPedido.NPedido = rnd.Next(0, 999999999);
                nuevoPedido.Zona = mainViewModel.ZonaSeleccionada;
                //var pedidoServices = new PedidoServices();
                //await pedidoServices.PostPlatoAsync(nuevoPedido);
                Navigation.PushAsync(new ModoPago(nuevoPedido));
            }

        }
    }
}
