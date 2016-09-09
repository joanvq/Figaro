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
    public partial class VerCarrito : ContentPage
    {
        public VerCarrito()
        {
            InitializeComponent();

            var mainViewModel = BindingContext as MainViewModel;

            int tiempoTotal = 0;
            decimal coste = 0;
            decimal desplazamiento = 0;

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
        }

        public void Menu_OnItemTapped(object sender, ItemTappedEventArgs e) 
        {
            ((ListView)sender).SelectedItem = null; // de-select the row
        }

        public void Plato_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null; // de-select the row
        }
    }
}
