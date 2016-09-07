using Figaro.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Figaro.Views
{
    public partial class VerPlato : ContentPage
    {
        public VerPlato(MainViewModel mainViewModel)
        {
            InitializeComponent();
            //Cargar estrellas valoración
            var valoracion = Convert.ToInt32(mainViewModel.PlatoSeleccionado.Valoracion);
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

            //Cargar tabs de abajo
            var tapIngredientesTab = new TapGestureRecognizer();
            var tapUtensiliosTab = new TapGestureRecognizer();
            var tapOpinionesTab = new TapGestureRecognizer();

            tapIngredientesTab.Tapped += (s, e) => {
                // handle the tap
                IngredientesTab.FontAttributes = FontAttributes.Bold;
                IngredientesTab.TextColor = Color.FromHex("#CC0311");
                LineaIngredientesTab.IsVisible = true;

                UtensiliosTab.FontAttributes = FontAttributes.None;
                UtensiliosTab.TextColor = Color.Default;
                LineaUtensiliosTab.IsVisible = false;

                OpinionesTab.FontAttributes = FontAttributes.None;
                OpinionesTab.TextColor = Color.Default;
                LineaOpinionesTab.IsVisible = false;

                TabAMostrar.Text = mainViewModel.PlatoSeleccionado.Ingredientes;
            };
            IngredientesTab.GestureRecognizers.Add(tapIngredientesTab);

            tapUtensiliosTab.Tapped += (s, e) => {
                // handle the tap
                IngredientesTab.FontAttributes = FontAttributes.None;
                IngredientesTab.TextColor = Color.Default;
                LineaIngredientesTab.IsVisible = false;

                UtensiliosTab.FontAttributes = FontAttributes.Bold;
                UtensiliosTab.TextColor = Color.FromHex("#CC0311");
                LineaUtensiliosTab.IsVisible = true;

                OpinionesTab.FontAttributes = FontAttributes.None;
                OpinionesTab.TextColor = Color.Default;
                LineaOpinionesTab.IsVisible = false;

                TabAMostrar.Text = mainViewModel.PlatoSeleccionado.Utensilios;
            };
            UtensiliosTab.GestureRecognizers.Add(tapUtensiliosTab);

            tapOpinionesTab.Tapped += (s, e) => {
                // handle the tap
                IngredientesTab.FontAttributes = FontAttributes.None;
                IngredientesTab.TextColor = Color.Default;
                LineaIngredientesTab.IsVisible = false;

                UtensiliosTab.FontAttributes = FontAttributes.None;
                UtensiliosTab.TextColor = Color.Default;
                LineaUtensiliosTab.IsVisible = false;

                OpinionesTab.FontAttributes = FontAttributes.Bold;
                OpinionesTab.TextColor = Color.FromHex("#CC0311");
                LineaOpinionesTab.IsVisible = true;

                TabAMostrar.Text = "";
            };
            OpinionesTab.GestureRecognizers.Add(tapOpinionesTab);
        }

        private void Anadir_OnClick(object sender, EventArgs e)
        {
            var mainViewModel = BindingContext as MainViewModel;
            int idPlato = mainViewModel.PlatoSeleccionado.Id;
            Tuple<int, int> idCant = new Tuple<int, int>(idPlato, int.Parse(NumeroPlatos.Items[NumeroPlatos.SelectedIndex]));
            mainViewModel.AnadirPlatoCesta.Execute(idCant);

        }
        
    }
}
