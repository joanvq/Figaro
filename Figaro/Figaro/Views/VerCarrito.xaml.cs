using Figaro.Models;
using Figaro.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XLabs.Forms.Controls;

namespace Figaro.Views
{
    public partial class VerCarrito : ContentPage
    {
        public VerCarrito()
        {
            InitializeComponent();

            var mainViewModel = BindingContext as MainViewModel;

            int tiempoTotal = 0;
            decimal coste = 0;
            decimal desplazamiento = 0;
            decimal costeTotal = 0;

            //Falta calculo de tiempo correcto
            foreach (KeyValuePair<Menu, int> menuCant in mainViewModel.CarritoCompra.listaMenus)
            {
                tiempoTotal += menuCant.Key.TiempoCocinado;
                coste += menuCant.Key.Precio * menuCant.Value;
            }
            foreach (KeyValuePair<Plato, int> platoCant in mainViewModel.CarritoCompra.listaPlatos)
            {
                tiempoTotal += platoCant.Key.TiempoCocinado;
                coste += platoCant.Key.Precio * platoCant.Value;
            }

            TiempoTotal.Text = (tiempoTotal / 60).ToString();
            if ((tiempoTotal % 60) < 10)
            {
                TiempoTotal.Text += "h 0" + (tiempoTotal % 60).ToString() + "' ⏱";
            }
            else
            {
                TiempoTotal.Text += "h " + (tiempoTotal % 60).ToString() + "' ⏱";
            }

            Coste.Text = coste.ToString() + " €";

            //Cálculo de desplazamiento

            Desplazamiento.Text = desplazamiento.ToString() + " €";

            costeTotal = coste + desplazamiento;
            Total.Text = costeTotal.ToString() + " €";
        }

        public void Menu_OnItemTapped(object sender, ItemTappedEventArgs e) 
        {
            ((ListView)sender).SelectedItem = null; // de-select the row
            var button = new Button
            {
                Text = "Open popup"
            };
            var popup = new PopupLayout
            {
                Content = new StackLayout
                {
                    Orientation = StackOrientation.Vertical,
                    Children =
                    {
                      button
                    }
                }
            };
            button.Clicked += (s, ev) =>
            {
                button.IsEnabled = false;
                popup.DismissPopup();
                button.IsEnabled = true;
            };
            var label = new Label
            {
                Text = "Test"
            };

            var popLayout = new StackLayout
            {
                WidthRequest = 250,
                HeightRequest = 400,
                BackgroundColor = Color.White,
                Children =
                {
                    button,
                    label
                }
            };

            popup.ShowPopup(popLayout);
            
        }

        public void Plato_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null; // de-select the row
        }

        public void Pedir_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PedirDatos());
        }
    }
}
