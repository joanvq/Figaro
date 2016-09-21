using Figaro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using PayPal.Forms.Abstractions;
using PayPal.Forms.Abstractions.Enum;
using System.Diagnostics;
using PayPal.Forms;
using Figaro.Services;
using Figaro.ViewModels;
using Figaro.Other;

namespace Figaro.Views
{
    public partial class ModoPago : ContentPage
    {

        private Pedido pedidoActual = new Pedido(); 

        public ModoPago(Pedido pedido)
        {
            InitializeComponent();

            var mainViewModel = BindingContext as MainViewModel; 

            NombreApellidos.Text = mainViewModel.UsuarioLogueado.NombreApellidos;
            Direccion.Text = pedido.Direccion;
            Zona.Text = mainViewModel.ZonaSeleccionada.Titulo;
            NombreChef.Text = "nombrechef"; //cambiar
            ApellidosChef.Text = "apellidochef1 apellidochef2"; //cambiar
            FechaHora.Text = "14/09/2016 21:00"; //cambiar

            pedidoActual = pedido;
        }

        public void Plato_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null; // de-select the row
        }

        public void Menu_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null; // de-select the row
        }

        public async void PagarPaypal_OnClicked(object sender, EventArgs e)
        {
            
            var mainViewModel = BindingContext as MainViewModel;

            //Numero de platos y menus diferentes que hay en el carrito
            var cantidad = mainViewModel.CarritoCompra.listaMenus.Count 
                + mainViewModel.CarritoCompra.listaPlatos.Count;

            var listaPayPalItems = new PayPalItem[cantidad];

            int i = 0;

            //Sku number = numero de pedido
            foreach (KeyValuePair<Menu,int> menuCant in mainViewModel.CarritoCompra.listaMenus)
            {
                if(i < cantidad)
                {
                    listaPayPalItems[i] = new PayPalItem(menuCant.Key.Titulo, (uint)menuCant.Value,
                        menuCant.Key.Precio, "EUR", pedidoActual.NPedido);
                    i++;
                }
            }

            foreach (KeyValuePair<Plato, int> platoCant in mainViewModel.CarritoCompra.listaPlatos)
            {
                if (i < cantidad)
                {
                    listaPayPalItems[i] = new PayPalItem(platoCant.Key.Titulo, (uint)platoCant.Value,
                        platoCant.Key.Precio, "EUR", pedidoActual.NPedido);
                    i++;
                }
            }

            var result = await CrossPayPalManager.Current.Buy(listaPayPalItems, new Decimal(0), new Decimal(0));

            if (result.Status == PayPalStatus.Cancelled)
            {
                //Debug.WriteLine("Cancelled");
                await DisplayAlert("Cancelado", "Se ha cancelado el pago", "OK");
            }
            else if (result.Status == PayPalStatus.Error)
            {
                //Debug.WriteLine(result.ErrorMessage);
                
                await DisplayAlert("Error", "Hubo un error durante el pago", "OK");
            }
            else if (result.Status == PayPalStatus.Successful)
            {
                //Debug.WriteLine(result.ServerResponse.Response.Id);
                //Navegar a una nueva pagina con los datos del pedido.
                //await Navigation.PopToRootAsync();

                ResumenPedido resumenPedido = new ResumenPedido(pedidoActual);
                //Pop al inicio
                await Navigation.PushAsync(resumenPedido);

                var pedidoServices = new PedidoServices();

                //Añadir pedido a BD
                var isSuccessStatusCode = await mainViewModel.NuevoPedido(pedidoActual);

                //Vaciar carrito de la compra y variables de pago.
                mainViewModel.CarritoCompra = new Carrito();

                resumenPedido.EnviarMail(isSuccessStatusCode);


            }
        }
    }
}
