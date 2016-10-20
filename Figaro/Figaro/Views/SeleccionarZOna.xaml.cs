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
    public partial class SeleccionarZona : ContentPage
    {
        public SeleccionarZona()
        {
            InitializeComponent();
        }

        private void Zona_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var zona = ListaZonaView.SelectedItem as Zona;

            if (zona != null)
            {
                var mainViewModel = BindingContext as MainViewModel;

                if (mainViewModel != null)
                {
                    mainViewModel.ElegirZonaAsync(zona);
                    Navigation.PopAsync();
                }
            }
        }
    }
}
