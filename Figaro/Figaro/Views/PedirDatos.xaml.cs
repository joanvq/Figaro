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

        private decimal precioTotal;

        public PedirDatos(decimal costeTotal)
        {
            precioTotal = costeTotal;
            InitializeComponent();
            
        }

        public async void Pagar_OnClicked(object sender, EventArgs e)
        {
            var mainViewModel = BindingContext as MainViewModel;
            if (mainViewModel.ZonaSeleccionada == null 
                || mainViewModel.UsuarioLogueado.ChefSeleccionado == null 
                || (mainViewModel.ListaMenuCarrito.Count == 0 
                    && mainViewModel.ListaPlatoCarrito.Count == 0))
            {
                DisplayAlert("Error", "Faltan datos", "OK");
            }
            else if(direccion.Text != null && cp.Text != null && direccion.Text != "" && cp.Text != "")
            {
                Pedido nuevoPedido = new Pedido();
                nuevoPedido.Direccion = direccion.Text;
                nuevoPedido.UsuarioId = mainViewModel.UsuarioLogueado.Id;
                nuevoPedido.Estado = "No pagado";
                nuevoPedido.ZonaId = mainViewModel.ZonaSeleccionada.Id;
                nuevoPedido.PrecioTotal = precioTotal;
                nuevoPedido.Comentario = comentario.Text;
                nuevoPedido.CP = cp.Text;
                nuevoPedido.NombreApellidos = nombreApellidos.Text;
                //Para numero pedido deber generar y 
                //comprovar que no existe, si existe generará uno nuevo
                //Generar Numero Pedido unico en funcion del tiempo 
                long ticks = DateTime.Now.Ticks;
                byte[] bytes = BitConverter.GetBytes(ticks);
                string nPedido = Convert.ToBase64String(bytes)
                                        .Replace('+', '_')
                                        .Replace('/', '-')
                                        .TrimEnd('=');
                nuevoPedido.NPedido = nPedido;
                nuevoPedido.FechaPedido = DateTime.Now;
                nuevoPedido.NombreChef = mainViewModel.UsuarioLogueado.ChefSeleccionado.NombreApellidos;
                nuevoPedido.TipoCocina = mainViewModel.TipoCocinaSeleccionado.Titulo;

                Navigation.PushAsync(new ModoPago(nuevoPedido));
            }

        }
    }
}
