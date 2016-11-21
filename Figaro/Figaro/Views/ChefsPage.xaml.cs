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
            InitializeComponent();

            var mainViewModel = BindingContext as MainViewModel;
            mainViewModel.IsBusy = true;

            var tgr = new TapGestureRecognizer ();
            tgr.Tapped += (s, e) => {
                // handle the tap
                Navigation.PushAsync(new SeleccionarDiaHora());
            };
            AvisoSeleccionarDiaHora.GestureRecognizers.Add(tgr);

            var menuInferior = new MenuInferior(this);
            menuInferior.mainViewmodel = mainViewModel;
            Menu_Button.GestureRecognizers.Add(menuInferior.tapMenu);
            Plato_Button.GestureRecognizers.Add(menuInferior.tapPlato);
            Chefs_Button.GestureRecognizers.Add(menuInferior.tapChefs) ;
            Profile_Button.GestureRecognizers.Add(menuInferior.tapProfile);

            if (mainViewModel.Fecha == null)
            {
                AvisoSeleccionarDiaHora.IsVisible = true;
                AvisoChefs.IsVisible = false;
            }
            else if (mainViewModel.NoChefs)
            {
                AvisoSeleccionarDiaHora.IsVisible = true;
                AvisoChefs.IsVisible = true;
            }
            else
            {
                AvisoSeleccionarDiaHora.IsVisible = false;
                AvisoChefs.IsVisible = false;
            }

            mainViewModel.IsBusy = false;
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

        private void ElegirChef_OnTapped(object sender, EventArgs e)
        {
            var mainViewModel = BindingContext as MainViewModel;
            Image img = (Image)sender;
            mainViewModel.ElegirChef.Execute(int.Parse(img.ClassId));
            DisplayAlert("Seleccionado", "Chef seleccionado correctamente", "OK");
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
