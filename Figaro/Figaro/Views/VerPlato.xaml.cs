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
                LineaIngredientesTab.Color = Color.FromHex("#CC0311");
                LineaIngredientesTab.Opacity = 1;

                UtensiliosTab.FontAttributes = FontAttributes.None;
                UtensiliosTab.TextColor = Color.Default;
                LineaUtensiliosTab.Color = Color.Black;
                LineaUtensiliosTab.Opacity = 0.5;

                OpinionesTab.FontAttributes = FontAttributes.None;
                OpinionesTab.TextColor = Color.Default;
                LineaOpinionesTab.Color = Color.Black;
                LineaOpinionesTab.Opacity = 0.5;

                IngredientesAMostrar.IsVisible = true;
                UtensiliosAMostrar.IsVisible = false;
                OpinionesAMostrar.IsVisible = false;

            };
            IngredientesTab.GestureRecognizers.Add(tapIngredientesTab);

            tapUtensiliosTab.Tapped += (s, e) => {
                // handle the tap
                IngredientesTab.FontAttributes = FontAttributes.None;
                IngredientesTab.TextColor = Color.Default;
                LineaIngredientesTab.Color = Color.Black;
                LineaIngredientesTab.Opacity = 0.5;

                UtensiliosTab.FontAttributes = FontAttributes.Bold;
                UtensiliosTab.TextColor = Color.FromHex("#CC0311");
                LineaUtensiliosTab.Color = Color.FromHex("#CC0311");
                LineaUtensiliosTab.Opacity = 1;

                OpinionesTab.FontAttributes = FontAttributes.None;
                OpinionesTab.TextColor = Color.Default;
                LineaOpinionesTab.Color = Color.Black;
                LineaOpinionesTab.Opacity = 0.5;

                IngredientesAMostrar.IsVisible = false;
                UtensiliosAMostrar.IsVisible = true;
                OpinionesAMostrar.IsVisible = false;
            };
            UtensiliosTab.GestureRecognizers.Add(tapUtensiliosTab);

            tapOpinionesTab.Tapped += (s, e) => {
                // handle the tap
                IngredientesTab.FontAttributes = FontAttributes.None;
                IngredientesTab.TextColor = Color.Default;
                LineaIngredientesTab.Color = Color.Black;
                LineaIngredientesTab.Opacity = 0.5;

                UtensiliosTab.FontAttributes = FontAttributes.None;
                UtensiliosTab.TextColor = Color.Default;
                LineaUtensiliosTab.Color = Color.Black;
                LineaUtensiliosTab.Opacity = 0.5;

                OpinionesTab.FontAttributes = FontAttributes.Bold;
                OpinionesTab.TextColor = Color.FromHex("#CC0311");
                LineaOpinionesTab.Color = Color.FromHex("#CC0311");
                LineaOpinionesTab.Opacity = 1;

                IngredientesAMostrar.IsVisible = false;
                UtensiliosAMostrar.IsVisible = false;
                OpinionesAMostrar.IsVisible = true;
            };
            OpinionesTab.GestureRecognizers.Add(tapOpinionesTab);

            //Inicializar comentarios Opiniones Plato
            mainViewModel.InitializeComentariosPlatoAsync(mainViewModel.PlatoSeleccionado.Id);
        }

        private void Anadir_OnClick(object sender, EventArgs e)
        {
            var mainViewModel = BindingContext as MainViewModel;
            int idPlato = mainViewModel.PlatoSeleccionado.Id;
            Tuple<int, int> idCant = new Tuple<int, int>(idPlato, int.Parse(NumeroPlatos.Items[NumeroPlatos.SelectedIndex]));
            mainViewModel.AnadirPlatoCesta.Execute(idCant);

        }

        // Imágenes estrellas valoración
        private void StarOne_OnChanged(object sender, EventArgs e)
        {
            Image star = (Image)sender;
            if (star.ClassId != null && star.Source == null)
            {
                var mvm = BindingContext as MainViewModel;
                var comchef = mvm.ListaComentarioPlatoMenu.FirstOrDefault(l => l.Id == Convert.ToInt32(star.ClassId));
                if (comchef != null)
                {
                    if (comchef.Valoracion > 0)
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
                var comchef = mvm.ListaComentarioPlatoMenu.FirstOrDefault(l => l.Id == Convert.ToInt32(star.ClassId));
                if (comchef != null)
                {
                    if (comchef.Valoracion > 1)
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
                var comchef = mvm.ListaComentarioPlatoMenu.FirstOrDefault(l => l.Id == Convert.ToInt32(star.ClassId));
                if (comchef != null)
                {
                    if (comchef.Valoracion > 2)
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
                var comchef = mvm.ListaComentarioPlatoMenu.FirstOrDefault(l => l.Id == Convert.ToInt32(star.ClassId));
                if (comchef != null)
                {
                    if (comchef.Valoracion > 3)
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
                var comchef = mvm.ListaComentarioPlatoMenu.FirstOrDefault(l => l.Id == Convert.ToInt32(star.ClassId));
                if (comchef != null)
                {
                    if (comchef.Valoracion > 4)
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

        private void Comentario_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null; // de-select the row
        }
    }
}
