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
            InitNavBar();
        }

        public MenuPage(Usuario usuarioLog)
        {
            InitializeComponent();

            Init(usuarioLog);

        }

        public async void Init(Usuario usuarioLog)
        {
            var mainViewModel = BindingContext as MainViewModel;
            var isSuccess = await mainViewModel.InitializeDataAsync(usuarioLog);
            if (isSuccess)
            {
                InitializeComponent();
                var menuInferior = new MenuInferior(this);
                menuInferior.mainViewmodel = mainViewModel;
                Menu_Button.GestureRecognizers.Add(menuInferior.tapMenu);
                Plato_Button.GestureRecognizers.Add(menuInferior.tapPlato);
                Chefs_Button.GestureRecognizers.Add(menuInferior.tapChefs);
                Profile_Button.GestureRecognizers.Add(menuInferior.tapProfile);
            }
            InitNavBar();
        }
        
        public void InitNavBar() { 
            //var calendario = new ToolbarItem
            //{
            //    Icon = "icono_time.png",
            //    Command = new Command(() =>
            //    {
            //        //DisplayAlert("Menu", "Ciudades tapped", "OK");
            //        Navigation.PushAsync(new SeleccionarDiaHora());
            //    })
            //};
            //this.ToolbarItems.Add(calendario);

            var cocina = new ToolbarItem
            {
                Text = "Seleccionar cocina",
                Icon = "seleccion_comida.png",
                Command = new Command(() =>
                {
                    //DisplayAlert("Menu", "Ciudades tapped", "OK");
                    Navigation.PushAsync(new SeleccionarTipoCocina());
                })
            };
            this.ToolbarItems.Add(cocina);

            var ciudades = new ToolbarItem
            {
                Text = "Seleccionar zona",
                Icon = "map_maker.png",
                Command = new Command(() =>
                {
                    //DisplayAlert("Menu", "Ciudades tapped", "OK");
                    Navigation.PushAsync(new SeleccionarZona());
                })
            };
            this.ToolbarItems.Add(ciudades);

            var cesta = new ToolbarItem
            {
                Text = "Cesta",
                Icon = "cesta.png",
                Command = new Command(() =>
                {
                    //DisplayAlert("Menu", "Cesta tapped", "OK");
                    Navigation.PushAsync(new VerCarrito());
                })
            };
            this.ToolbarItems.Add(cesta);
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
            Image img = (Image)sender;
            Tuple<int, int> idCant = new Tuple<int, int>(int.Parse(img.ClassId), 1);
            mainViewModel.AnadirMenuCesta.Execute(idCant);
            DisplayAlert("Añadido", "Menu añadido a la cesta de la compra", "OK");
        }

    }
}
