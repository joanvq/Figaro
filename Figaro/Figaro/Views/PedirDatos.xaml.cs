using Figaro.Models;
using Figaro.Other;
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

        private List<KeyValuePair<PlatoMenu, int>> listaCarrito = null;

        private List<KeyValuePair<PlatoMenu, int>> ListaCarrito
        {
            get { return listaCarrito; }
            set
            {
                listaCarrito = value;
                OnPropertyChanged();
            }
        }

        public PedirDatos(List<KeyValuePair<PlatoMenu, int>>  listCarrito, decimal costeTotal)
        {
            ListaCarrito = listCarrito;
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
                DisplayAlert("Error", "Faltan datos.", "OK");
            }
            else if(direccion.Text != null && cp.Text != null && direccion.Text != "" && cp.Text != "")
            {
                // Comprovar que el cp esta dentro de la zona
                string postCode = cp.Text;
                if(postCode.Length > 1)
                {
                    postCode = postCode.TrimStart('0');
                }
                var geoServices = new GeoPC_PlacesServices();
                var geoPlaces = await geoServices.GetGeoPC_PlacesByZonaAsync(mainViewModel.ZonaSeleccionada.Id);
                bool isValid = false;
                foreach (var place in geoPlaces)
                {
                    if(place.PostCode == postCode)
                    {
                        isValid = true;
                        break;
                    }
                }
                if(isValid)
                {
                    Pedido nuevoPedido = new Pedido();
                    nuevoPedido.Direccion = direccion.Text;
                    nuevoPedido.UsuarioId = mainViewModel.UsuarioLogueado.Id;
                    nuevoPedido.ZonaId = mainViewModel.ZonaSeleccionada.Id;
                    nuevoPedido.PrecioTotal = precioTotal;
                    nuevoPedido.Comentario = comentario.Text;
                    nuevoPedido.CP = cp.Text;
                    nuevoPedido.NombreApellidos = nombreApellidos.Text;
                    nuevoPedido.TipoCocina = mainViewModel.TipoCocinaSeleccionado.Titulo;

                    Navigation.PushAsync(new ModoPago(ListaCarrito, nuevoPedido));
                }
                else
                {
                    DisplayAlert("Error", "El código postal no coincide con la zona seleccionada.", "OK");
                }
            }
        }
    }
}
