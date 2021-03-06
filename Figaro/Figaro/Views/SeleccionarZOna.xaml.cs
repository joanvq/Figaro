﻿using Figaro.Models;
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
                    ChangeZonaAsync(mainViewModel, zona);
                }
            }
        }

        private async Task ChangeZonaAsync(MainViewModel mainViewModel, Zona zona)
        {
            mainViewModel.ElegirZonaAsync(zona);
            //Update Binding from view
            Navigation.PopAsync();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            this.Content = null;
        }
    }
}
