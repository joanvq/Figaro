using Figaro.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Figaro.Views
{
    public partial class VerMenu : ContentPage
    {
        public VerMenu(MainViewModel mainViewModel)
        {
            InitializeComponent();
            //Cargar estrellas valoración
            var valoracion = Convert.ToInt32(mainViewModel.MenuSeleccionado.Valoracion);
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

            //Cargar platos del menu a visible si no es null
            if(mainViewModel.MenuSeleccionado.Entrante != null)
            {
                Entrante.IsVisible = true;
            }
            if (mainViewModel.MenuSeleccionado.Primero != null)
            {
                Primero.IsVisible = true;
            }
            if (mainViewModel.MenuSeleccionado.Segundo != null)
            {
                Segundo.IsVisible = true;
            }
            if (mainViewModel.MenuSeleccionado.Guarnicion != null)
            {
                Guarnicion.IsVisible = true;
            }
            if (mainViewModel.MenuSeleccionado.Postre != null)
            {
                Postre.IsVisible = true;
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

                IngredientesAMostrar.IsVisible = true;
                UtensiliosAMostrar.IsVisible = false;
                OpinionesAMostrar.IsVisible = false;
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

                IngredientesAMostrar.IsVisible = false;
                UtensiliosAMostrar.IsVisible = true;
                OpinionesAMostrar.IsVisible = false;
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

                IngredientesAMostrar.IsVisible = false;
                UtensiliosAMostrar.IsVisible = false;
                OpinionesAMostrar.IsVisible = true;
            };
            OpinionesTab.GestureRecognizers.Add(tapOpinionesTab);

            //Inicializar comentarios Opiniones Menu
            mainViewModel.InitializeComentariosMenuAsync(mainViewModel.MenuSeleccionado.Id);
        }

        void Entrante_OnTapped(object sender, EventArgs e)
        {
            
            var mainViewModel = BindingContext as MainViewModel;

            if (mainViewModel != null)
            {

                var plato = mainViewModel.MenuSeleccionado.Entrante;

                if (plato != null)
                {
                    mainViewModel.PlatoSeleccionado = plato;

                    Navigation.PushAsync(new VerPlato(mainViewModel));
                }
            }
        }

        void Postre_OnTapped(object sender, EventArgs e)
        {

            var mainViewModel = BindingContext as MainViewModel;

            if (mainViewModel != null)
            {

                var plato = mainViewModel.MenuSeleccionado.Postre;

                if (plato != null)
                {
                    mainViewModel.PlatoSeleccionado = plato;

                    Navigation.PushAsync(new VerPlato(mainViewModel));
                }
            }
        }

        void Primero_OnTapped(object sender, EventArgs e)
        {

            var mainViewModel = BindingContext as MainViewModel;

            if (mainViewModel != null)
            {

                var plato = mainViewModel.MenuSeleccionado.Primero;

                if (plato != null)
                {
                    mainViewModel.PlatoSeleccionado = plato;

                    Navigation.PushAsync(new VerPlato(mainViewModel));
                }
            }
        }

        void Segundo_OnTapped(object sender, EventArgs e)
        {

            var mainViewModel = BindingContext as MainViewModel;

            if (mainViewModel != null)
            {

                var plato = mainViewModel.MenuSeleccionado.Segundo;

                if (plato != null)
                {
                    mainViewModel.PlatoSeleccionado = plato;

                    Navigation.PushAsync(new VerPlato(mainViewModel));
                }
            }
        }

        void Guarnicion_OnTapped(object sender, EventArgs e)
        {

            var mainViewModel = BindingContext as MainViewModel;

            if (mainViewModel != null)
            {

                var plato = mainViewModel.MenuSeleccionado.Guarnicion;

                if (plato != null)
                {
                    mainViewModel.PlatoSeleccionado = plato;

                    Navigation.PushAsync(new VerPlato(mainViewModel));
                }
            }
        }

        private void Anadir_OnClick(object sender, EventArgs e)
        {
            var mainViewModel = BindingContext as MainViewModel;
            int idMenu = mainViewModel.MenuSeleccionado.Id;
            Tuple<int, int> idCant = new Tuple<int, int>(idMenu, int.Parse(NumeroMenus.Items[NumeroMenus.SelectedIndex]));
            mainViewModel.AnadirMenuCesta.Execute(idCant);
            
        }
    }
}
