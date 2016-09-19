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

            NombreApellidos.Text = pedido.Usuario.NombreApellidos;
            Direccion.Text = pedido.Direccion;
            Zona.Text = pedido.Zona.Titulo;
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
            var result = await CrossPayPalManager.Current.Buy(new PayPalItem[] {
                new PayPalItem ("sample item #1", 2, new Decimal (87.50), "USD",
                    "sku-12345678"),
                new PayPalItem ("free sample item #2", 1, new Decimal (0.00),
                    "USD", "sku-zero-price"),
                new PayPalItem ("sample item #3 with a longer name", 6, new Decimal (37.99),
                    "USD", "sku-33333")
            }, new Decimal(20.5), new Decimal(13.20));

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
                await Navigation.PopToRootAsync();

                var pedidoServices = new PedidoServices();

                var mainViewModel = BindingContext as MainViewModel;

                //Añadir pedido a BD
                var isSuccessStatusCode = await mainViewModel.NuevoPedido(pedidoActual);
                
                //Vaciar carrito de la compra y variables de pago.
                mainViewModel.CarritoCompra = new Carrito();

                if (isSuccessStatusCode == false)
                    await DisplayAlert("Error", "Error guardando pedido en la Base de Datos. Por favor contácte con ....", "OK");

                else await DisplayAlert("Pago", "El pago se realizó correctamente", "OK");
                
            }
        }
    }
}
