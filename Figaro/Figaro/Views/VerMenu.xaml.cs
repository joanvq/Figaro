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

            //Cargar NavBar
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
            int numMenus = int.Parse(NumeroMenus.Items[NumeroMenus.SelectedIndex]);
            Tuple<int, int> idCant = new Tuple<int, int>(idMenu, numMenus);
            mainViewModel.AnadirMenuCesta.Execute(idCant);
            if (numMenus > 1)
            {
                DisplayAlert("Añadido", "Menus añadidos a la cesta de la compra", "OK");
            }
            else
            {
                DisplayAlert("Añadido", "Menu añadido a la cesta de la compra", "OK");
            }
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
