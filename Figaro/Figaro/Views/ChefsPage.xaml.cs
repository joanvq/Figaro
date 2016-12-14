using Figaro.Models;
using Figaro.Other;
using Figaro.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Figaro.Views
{
    public partial class ChefsPage : ContentPage
    {
        public ChefsPage()
        {
            InitChefPage();
            
        }

        private void InitChefPage()
        {
            InitializeComponent();

            var mainViewModel = BindingContext as MainViewModel;
            mainViewModel.IsBusy = true;

            var tgr = new TapGestureRecognizer();
            tgr.Tapped += (s, e) => {
                // handle the tap
                Navigation.PushAsync(new SeleccionarDiaHora());
            };
            AvisoSeleccionarDiaHora.GestureRecognizers.Add(tgr);

            var menuInferior = new MenuInferior(this);
            menuInferior.mainViewmodel = mainViewModel;
            Menu_Button.GestureRecognizers.Add(menuInferior.tapMenu);
            Plato_Button.GestureRecognizers.Add(menuInferior.tapPlato);
            Chefs_Button.GestureRecognizers.Add(menuInferior.tapChefs);
            Profile_Button.GestureRecognizers.Add(menuInferior.tapProfile);

            if (mainViewModel.Fecha == null)
            {
                AvisoSeleccionarDiaHora.IsVisible = true;
                AvisoChefs.IsVisible = false;
                AvisoFiltro.IsVisible = false;
                CerrarFiltro.IsVisible = false;
            }
            else if (mainViewModel.NoChefs)
            {
                AvisoSeleccionarDiaHora.IsVisible = true;
                AvisoChefs.IsVisible = true;
                string strHora, strMinuto;
                int hora = mainViewModel.Hora / 2;
                int minuto = (mainViewModel.Hora % 2) * 30;
                if (hora < 10)
                {
                    strHora = "0" + hora;
                }
                else
                {
                    strHora = hora.ToString();
                }
                if (minuto < 10)
                {
                    strMinuto = "0" + minuto;
                }
                else {
                    strMinuto = minuto.ToString();
                }
                AvisoFiltro.Text = "Chefs filtrados para: " + mainViewModel.Fecha.Value.Date.ToString("dd/MM/yyyy") +
                    " " + strHora + ":" + strMinuto;
                AvisoFiltro.IsVisible = true;
                CerrarFiltro.IsVisible = true;
            }
            else
            {
                AvisoSeleccionarDiaHora.IsVisible = false;
                AvisoChefs.IsVisible = false;
                AvisoFiltro.Text = "Chefs filtrados para: " + mainViewModel.Fecha.Value.Date.ToString("dd/MM/yyyy") +
                    " " + (mainViewModel.Hora) / 2 + ":" + (mainViewModel.Hora % 2) * 30;
                AvisoFiltro.IsVisible = true;
                CerrarFiltro.IsVisible = true;
            }
            InitNavBar();

            mainViewModel.IsBusy = false;
        }

        public void InitNavBar()
        {
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
            var chef = ListaChefsView.SelectedItem as Chef;
            ListaChefsView.SelectedItem = null;

            if (chef != null)
            {
                var mainViewModel = BindingContext as MainViewModel;

                if (mainViewModel != null)
                {
                    mainViewModel.ChefSeleccionado = chef;

                    Navigation.PushAsync(new VerChef(mainViewModel));
                    //DisplayAlert("Chef", "Mostrar chef " + chef.NombreApellidos, "OK");
                }
            }
        }

        private async void ElegirChef_OnTapped(object sender, EventArgs e)
        {
            var mainViewModel = BindingContext as MainViewModel;
            Image img = (Image)sender;
            await mainViewModel.ElegirChef(int.Parse(img.ClassId));
            if (mainViewModel.Fecha == null)
            {
                mainViewModel.ChefSeleccionado = mainViewModel.ListaChefs.FirstOrDefault(l => l.Id == int.Parse(img.ClassId));
                Navigation.PushAsync(new VerChef(mainViewModel));
                DisplayAlert("", "Seleccione una fecha y hora de reserva", "OK");
            }
            else
            {
                if (mainViewModel.ListaMenuCarrito.Count == 0 && mainViewModel.ListaPlatoCarrito.Count == 0)
                {
                    DisplayAlert("", "Elige un menu o plato", "OK");
                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Seleccionado", "Chef seleccionado correctamente", "OK");
                    Navigation.PushAsync(new VerCarrito());
                }
            }
        }

        private async void CerrarFiltro_OnTapped(object sender, EventArgs e)
        {
            var mainViewModel = BindingContext as MainViewModel;
            mainViewModel.Fecha = null;
            await mainViewModel.FiltrarChefs();
            InitChefPage();
        }

        // Imagenes estrellas valoracion
        private void StarOne_OnChanged(object sender, EventArgs e)
        {
            Image star = (Image)sender;
            if(star.ClassId != null && star.Source == null)
            {
                var mvm = BindingContext as MainViewModel;
                var chef = mvm.ListaChefs.FirstOrDefault(l => l.Id == Convert.ToInt32(star.ClassId));
                if (chef != null)
                {
                    if (chef.Valoracion > 0)
                    {
                        star.Source = "icono_star_gold.png";
                    }
                    else
                    {
                        star.Source = "icono_star_gold_empty.png";
                    }
                }
            }
        }
        private void StarTwo_OnChanged(object sender, EventArgs e)
        {
            Image star = (Image)sender;
            if (star.ClassId != null && star.Source == null)
            {
                var mvm = BindingContext as MainViewModel;
                var chef = mvm.ListaChefs.FirstOrDefault(l => l.Id == Convert.ToInt32(star.ClassId));
                if (chef != null)
                {
                    if (chef.Valoracion > 1)
                    {
                        star.Source = "icono_star_gold.png";
                    }
                    else
                    {
                        star.Source = "icono_star_gold_empty.png";
                    }
                }
            }
        }
        private void StarThree_OnChanged(object sender, EventArgs e)
        {
            Image star = (Image)sender;
            if (star.ClassId != null && star.Source == null)
            {
                var mvm = BindingContext as MainViewModel;
                var chef = mvm.ListaChefs.FirstOrDefault(l => l.Id == Convert.ToInt32(star.ClassId));
                if (chef != null)
                {
                    if (chef.Valoracion > 2)
                    {
                        star.Source = "icono_star_gold.png";
                    }
                    else
                    {
                        star.Source = "icono_star_gold_empty.png";
                    }
                }
            }
        }
        private void StarFour_OnChanged(object sender, EventArgs e)
        {
            Image star = (Image)sender;
            if (star.ClassId != null && star.Source == null)
            {
                var mvm = BindingContext as MainViewModel;
                var chef = mvm.ListaChefs.FirstOrDefault(l => l.Id == Convert.ToInt32(star.ClassId));
                if (chef != null)
                {
                    if (chef.Valoracion > 3)
                    {
                        star.Source = "icono_star_gold.png";
                    }
                    else
                    {
                        star.Source = "icono_star_gold_empty.png";
                    }
                }
            }
        }
        private void StarFive_OnChanged(object sender, EventArgs e)
        {
            Image star = (Image)sender;
            if (star.ClassId != null && star.Source == null)
            {
                var mvm = BindingContext as MainViewModel;
                var chef = mvm.ListaChefs.FirstOrDefault(l => l.Id == Convert.ToInt32(star.ClassId));
                if (chef != null)
                {
                    if (chef.Valoracion > 4)
                    {
                        star.Source = "icono_star_gold.png";
                    }
                    else
                    {
                        star.Source = "icono_star_gold_empty.png";
                    }
                }
            }
        }

        //private void Actu_OnChnged (object sender, EventArgs e)
        //{
        //    var mvm = BindingContext as MainViewModel;
        //    var p = mvm.NoChefs;
        //    var b = mvm.NoFecha;
        //}
    }
}
