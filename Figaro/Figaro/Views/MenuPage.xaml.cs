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
            var menuInferior = new MenuInferior(this);
            Menu_Button.GestureRecognizers.Add(menuInferior.tapMenu);
            Plato_Button.GestureRecognizers.Add(menuInferior.tapPlato);
            Chefs_Button.GestureRecognizers.Add(menuInferior.tapChefs);
            Profile_Button.GestureRecognizers.Add(menuInferior.tapProfile);
        }

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var menu = ListaMenusView.SelectedItem as Menu;

            if (menu != null)
            {
                var mainViewModel = BindingContext as MainViewModel;

                if (mainViewModel != null)
                {
                    mainViewModel.MenuSeleccionado = menu;

                    //Navigation.PushAsync(new VerPlato(mainViewModel));
                    DisplayAlert("Menu", "Menu " + menu.Titulo + " tapped", "OK");
                }
            }
        }

        private void AnadirCesta_OnClick(object sender, EventArgs e)
        {
            var mainViewModel = BindingContext as MainViewModel;
            Button btn = (Button)sender;
            mainViewModel.AnadirMenuCesta.Execute(btn.ClassId);
        }

    }
}
