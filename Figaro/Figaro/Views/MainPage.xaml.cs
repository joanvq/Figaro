using Figaro.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Figaro.Views;
using Figaro.Models;

namespace Figaro
{
    public partial class MainPage : ContentPage
    {
        private ListView listViewPlatos; 
        private int TipoCocinaSeleccinado { get; set; }

        public MainPage()
        {
            InitializeComponent();
            //this.ToolbarItems.Add(new ToolbarItem { Text = "BTN 1", Icon = "myicon.png" });
            
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

        private async void Menu_OnClicked(object sender, EventArgs e)
        {
            
        }


    }
}
