using Figaro.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Figaro.Models;
using Figaro.Other;

namespace Figaro.Views
{
    public partial class PlatosPage : ContentPage
    {
        //private ListView listViewPlatos; 
        //private int TipoCocinaSeleccinado { get; set; }

        public PlatosPage()
        {
            InitializeComponent();

            var menuInferior = new MenuInferior(this);
            Menu_Button.GestureRecognizers.Add(menuInferior.tapMenu);
            Plato_Button.GestureRecognizers.Add(menuInferior.tapPlato);
            Chefs_Button.GestureRecognizers.Add(menuInferior.tapChefs);
            Profile_Button.GestureRecognizers.Add(menuInferior.tapProfile);

            //var tapMenu = new TapGestureRecognizer();
            //var tapPlato = new TapGestureRecognizer();
            //var tapChefs = new TapGestureRecognizer();
            //var tapProfile = new TapGestureRecognizer();

            //tapMenu.Tapped += (s, e) => {
            //    // handle the tap
            //    var app = Application.Current as App;
            //    var mainPage = (NavigationPage)app.MainPage;
            //    var currentPage = (MasterDetailPage)mainPage.CurrentPage;
            //    currentPage.Detail = new MenuPage();
            //};
            //Menu_Button.GestureRecognizers.Add(tapMenu);

            //tapPlato.Tapped += (s, e) => {
            //    // handle the tap
            //    DisplayAlert("Menu", "Plato tapped", "OK");
            //};
            //Plato_Button.GestureRecognizers.Add(tapPlato);

            //tapChefs.Tapped += (s, e) => {
            //    // handle the tap
            //    DisplayAlert("Menu", "Chefs tapped", "OK");
            //};
            //Chefs_Button.GestureRecognizers.Add(tapChefs);

            //tapProfile.Tapped += (s, e) => {
            //    // handle the tap
            //    DisplayAlert("Menu", "Perfil tapped", "OK");
            //};
            //Profile_Button.GestureRecognizers.Add(tapProfile);

            //var ciudades = new ToolbarItem
            //{
            //    Icon = "icono_map_maker.png",
            //    Command = new Command(() =>
            //    {
            //        DisplayAlert("Menu", "Ciudades tapped", "OK");
            //    })
            //};
            //this.ToolbarItems.Add(ciudades);

            //var cesta = new ToolbarItem {
            //    Icon = "icono_shopping_bag_empty.png",
            //    Command = new Command(() =>
            //    {
            //        DisplayAlert("Menu", "Cesta tapped", "OK");
            //    })
            //};
            //this.ToolbarItems.Add(cesta);
            
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
            Button btn = (Button)sender;
            mainViewModel.AnadirPlatoCesta.Execute(btn.ClassId);
        }
        

    }
}
