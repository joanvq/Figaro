using Figaro.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Figaro.Models;
using Figaro.Other;
using System.Runtime.CompilerServices;

namespace Figaro.Views
{
    public partial class PlatosPage : ContentPage
    {
        //private ListView listViewPlatos; 
        //private int TipoCocinaSeleccinado { get; set; }

        public PlatosPage()
        {
            InitializeComponent();

            var mainViewModel = BindingContext as MainViewModel;
            
            var menuInferior = new MenuInferior(this);
            
            menuInferior.mainViewmodel = mainViewModel;
            Menu_Button.GestureRecognizers.Add(menuInferior.tapMenu);
            Plato_Button.GestureRecognizers.Add(menuInferior.tapPlato);
            Chefs_Button.GestureRecognizers.Add(menuInferior.tapChefs);
            Profile_Button.GestureRecognizers.Add(menuInferior.tapProfile);
        }

        //private async void Button_OnClicked(object sender, EventArgs e)
        //{

        //    await Navigation.PushAsync(new NuevoPlato());
        //}

        //private async void Search_OnClicked(object sender, EventArgs e)
        //{
        //    var mainViewModel = BindingContext as MainViewModel;

        //    if (mainViewModel != null)
        //    {
        //        await Navigation.PushAsync(new BuscarPlato());
        //    }
        //}

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var plato = ListaPlatosView.SelectedItem as Plato;
            ListaPlatosView.SelectedItem = null;

            if(plato != null)
            {
                var mainViewModel = BindingContext as MainViewModel;

                if (mainViewModel != null)
                {
                    mainViewModel.PlatoSeleccionado = plato;

                    Navigation.PushAsync(new VerPlato(mainViewModel));
                }
            }
        }

        private void AnadirCesta_OnClick(object sender, EventArgs e)
        {
            var mainViewModel = BindingContext as MainViewModel;
            Image img = (Image)sender;
            Tuple<int, int> idCant = new Tuple<int, int>(int.Parse(img.ClassId), 1);
            mainViewModel.AnadirPlatoCesta.Execute(idCant);
            DisplayAlert("Añadido", "Plato añadido a la cesta de la compra", "OK");
        }

    }
}
