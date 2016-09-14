using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Figaro.ViewModels;
using Figaro.Models;

namespace Figaro.Views
{
    public partial class SeleccionarTipoComida : MasterDetailPage
    {

        public SeleccionarTipoComida()
        {
            
            InitializeComponent();
            var ciudades = new ToolbarItem
            {
                Icon = "icono_map_maker.png",
                Command = new Command(() =>
                {
                    //DisplayAlert("Menu", "Ciudades tapped", "OK");
                    Navigation.PushAsync(new SeleccionarZona());
                })
            };
            this.ToolbarItems.Add(ciudades);

            var cesta = new ToolbarItem
            {
                Icon = "icono_shopping_bag_empty.png",
                Command = new Command(() =>
                {
                    //DisplayAlert("Menu", "Cesta tapped", "OK");
                    Navigation.PushAsync(new VerCarrito());
                })
            };
            this.ToolbarItems.Add(cesta);

        }       

        public void TipoCocina_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var tipoCocina = ListaTipoCocinaView.SelectedItem as TipoCocina;
            if (tipoCocina != null)
            {
                var mainViewModel = BindingContext as MainViewModel;
                if (mainViewModel != null)
                {
                    this.IsPresented = false;
                    mainViewModel.TipoCocinaSeleccionado = tipoCocina;
                    //Navigation.PopToRootAsync();
                    mainViewModel.Refresh.Execute(null);
                    //InitializeComponent();
                }
            }
        }
    }
}
