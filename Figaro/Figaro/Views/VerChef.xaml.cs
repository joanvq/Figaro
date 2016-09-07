using Figaro.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Figaro.Views
{
    public partial class VerChef : ContentPage
    {
        public VerChef(MainViewModel mainViewModel)
        {
            InitializeComponent();
            //Cargar estrellas valoración
            var valoracion = Convert.ToInt32(mainViewModel.ChefSeleccionado.Valoracion);
            switch (valoracion)
            {
                case 0:
                    starOne.Source = "icono_star_empty.png";
                    starTwo.Source = "icono_star_empty.png";
                    starThree.Source = "icono_star_empty.png";
                    starFour.Source = "icono_star_empty.png";
                    starFive.Source = "icono_star_empty.png";
                    break;
                case 1:
                    starOne.Source = "icono_star.png";
                    starTwo.Source = "icono_star_empty.png";
                    starThree.Source = "icono_star_empty.png";
                    starFour.Source = "icono_star_empty.png";
                    starFive.Source = "icono_star_empty.png";
                    break;
                case 2:
                    starOne.Source = "icono_star.png";
                    starTwo.Source = "icono_star.png";
                    starThree.Source = "icono_star_empty.png";
                    starFour.Source = "icono_star_empty.png";
                    starFive.Source = "icono_star_empty.png";
                    break;
                case 3:
                    starOne.Source = "icono_star.png";
                    starTwo.Source = "icono_star.png";
                    starThree.Source = "icono_star.png";
                    starFour.Source = "icono_star_empty.png";
                    starFive.Source = "icono_star_empty.png";
                    break;
                case 4:
                    starOne.Source = "icono_star.png";
                    starTwo.Source = "icono_star.png";
                    starThree.Source = "icono_star.png";
                    starFour.Source = "icono_star.png";
                    starFive.Source = "icono_star_empty.png";
                    break;
                case 5:
                    starOne.Source = "icono_star.png";
                    starTwo.Source = "icono_star.png";
                    starThree.Source = "icono_star.png";
                    starFour.Source = "icono_star.png";
                    starFive.Source = "icono_star.png";
                    break;
            }

        }

        private void Elegir_OnClick(object sender, EventArgs e)
        {
            var mainViewModel = BindingContext as MainViewModel;
            var idChef = mainViewModel.ChefSeleccionado.Id;
            mainViewModel.ElegirChef.Execute(idChef);
        }
    }
}
