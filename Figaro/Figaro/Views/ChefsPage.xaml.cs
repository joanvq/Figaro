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

            var menuInferior = new MenuInferior(this);
            Menu_Button.GestureRecognizers.Add(menuInferior.tapMenu);
            Plato_Button.GestureRecognizers.Add(menuInferior.tapPlato);
            Chefs_Button.GestureRecognizers.Add(menuInferior.tapChefs);
            Profile_Button.GestureRecognizers.Add(menuInferior.tapProfile);

            //Cargar estrellas valoración
            //foreach (Chef chef in ListaChefsView.ItemsSource)
            //{
            //    var valoracion = Convert.ToInt32(chef.Valoracion);
            //    switch (valoracion)
            //    {
            //        case 0:
            //            ListaChefsView..Source = "icono_star_empty.png";
            //            starTwo.Source = "icono_star_empty.png";
            //            starThree.Source = "icono_star_empty.png";
            //            starFour.Source = "icono_star_empty.png";
            //            starFive.Source = "icono_star_empty.png";
            //            break;
            //        case 1:
            //            starOne.Source = "icono_star.png";
            //            starTwo.Source = "icono_star_empty.png";
            //            starThree.Source = "icono_star_empty.png";
            //            starFour.Source = "icono_star_empty.png";
            //            starFive.Source = "icono_star_empty.png";
            //            break;
            //        case 2:
            //            starOne.Source = "icono_star.png";
            //            starTwo.Source = "icono_star.png";
            //            starThree.Source = "icono_star_empty.png";
            //            starFour.Source = "icono_star_empty.png";
            //            starFive.Source = "icono_star_empty.png";
            //            break;
            //        case 3:
            //            starOne.Source = "icono_star.png";
            //            starTwo.Source = "icono_star.png";
            //            starThree.Source = "icono_star.png";
            //            starFour.Source = "icono_star_empty.png";
            //            starFive.Source = "icono_star_empty.png";
            //            break;
            //        case 4:
            //            starOne.Source = "icono_star.png";
            //            starTwo.Source = "icono_star.png";
            //            starThree.Source = "icono_star.png";
            //            starFour.Source = "icono_star.png";
            //            starFive.Source = "icono_star_empty.png";
            //            break;
            //        case 5:
            //            starOne.Source = "icono_star.png";
            //            starTwo.Source = "icono_star.png";
            //            starThree.Source = "icono_star.png";
            //            starFour.Source = "icono_star.png";
            //            starFive.Source = "icono_star.png";
            //            break;
            //    }
            //}
        }

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var chef = ListaChefsView.SelectedItem as Chef;

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
        }
    }
}
