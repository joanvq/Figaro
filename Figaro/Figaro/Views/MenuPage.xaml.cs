using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Figaro.Other;
using Figaro.Models;
using Figaro.ViewModels;

namespace Figaro.Views
{
    public partial class MenuPage : ContentPage
    {

        public MenuPage()
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

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var menu = ListaMenusView.SelectedItem as Menu;
            ListaMenusView.SelectedItem = null;

            if (menu != null)
            {
                var mainViewModel = BindingContext as MainViewModel;

                if (mainViewModel != null)
                {
                    mainViewModel.MenuSeleccionado = menu;

                    Navigation.PushAsync(new VerMenu(mainViewModel));
                    //DisplayAlert("Menu", "Menu " + menu.Titulo + " tapped", "OK");
                }
            }
        }

        private void AnadirCesta_OnClick(object sender, EventArgs e)
        {
            var mainViewModel = BindingContext as MainViewModel;
            Button btn = (Button)sender;
            Tuple<int, int> idCant = new Tuple<int, int>(int.Parse(btn.ClassId), 1);
            mainViewModel.AnadirMenuCesta.Execute(idCant);
            DisplayAlert("Añadido", "Menu añadido a la cesta de la compra", "OK");
        }
    }
}
