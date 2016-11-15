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

        public SeleccionarTipoComida(Usuario usuarioLog)
        {
            NavigationPage.SetHasNavigationBar(this, true);
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, true);
            Init(usuarioLog);

        }

        public async void Init(Usuario usuarioLog)
        {
            var mainViewModel = BindingContext as MainViewModel;
            var isSuccess = await mainViewModel.InitializeDataAsync(usuarioLog);
            if (isSuccess)
            {
                InitializeComponent();
            }
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

            var ciudades = new ToolbarItem
            {
                Text = "Seleccionar zona",
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
                Text = "Cesta",
                Icon = "cesta.png",
                Command = new Command(() =>
                {
                    //DisplayAlert("Menu", "Cesta tapped", "OK");
                    Navigation.PushAsync(new VerCarrito());
                })
            };
            this.ToolbarItems.Add(cesta);

            // ESTO NO FUNCIONA YA QUE AUN NO ESTÁ CARGADA LA LISTA TIPO COCINA
            // PERO SE TENDRIA QUE HACER QUE SE MARCARA EL TIPOCOCINA SELECCIONADO INICIALMENTE
            // O HACERLO CON UN CHECK COMO EN ZONA
            //var mainViewModel = BindingContext as MainViewModel;
            //foreach (var item in ListaTipoCocinaView.ItemsSource) {
            //    if(item == mainViewModel.TipoCocinaSeleccionado)
            //    {
            //        ListaTipoCocinaView.SelectedItem = item;
            //    }
            //}
        }
        
        public async void TipoCocina_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var tipoCocina = ListaTipoCocinaView.SelectedItem as TipoCocina;
            if (tipoCocina != null)
            {
                var mainViewModel = BindingContext as MainViewModel;
                if (mainViewModel != null)
                {
                    this.IsPresented = false;
                    await mainViewModel.ElegirTipoCocinaAsync(tipoCocina);
                    //Navigation.PopToRootAsync();
                    //mainViewModel.Refresh.Execute(null);
                    InitializeComponent();

                }
            }
        }
    }
}
