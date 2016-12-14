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
    public partial class SeleccionarTipoCocina : ContentPage
    {
        public SeleccionarTipoCocina()
        {
            InitializeComponent();
        }

        public async void TipoCocina_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var tipoCocina = ListaTipoCocinaView.SelectedItem as TipoCocina;
            if (tipoCocina != null)
            {
                var mainViewModel = BindingContext as MainViewModel;
                if (mainViewModel != null)
                {
                    await mainViewModel.ElegirTipoCocinaAsync(tipoCocina);
                    Navigation.PopAsync();

                }
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            this.Content = null;
        }
    }
}
