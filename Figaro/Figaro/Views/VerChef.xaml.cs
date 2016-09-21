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

            //Cargar tabs de abajo (perfil, disponibilidad, opiniones)
            var tapDisponibilidadTab = new TapGestureRecognizer();
            var tapOpinionesTab = new TapGestureRecognizer();
            var tapPerfilTab = new TapGestureRecognizer();

            tapPerfilTab.Tapped += (s, e) =>
            {
                // handle the tap
                PerfilTab.FontAttributes = FontAttributes.Bold;
                PerfilTab.TextColor = Color.FromHex("#CC0311");
                LineaPerfilTab.IsVisible = true;

                DisponibilidadTab.FontAttributes = FontAttributes.None;
                DisponibilidadTab.TextColor = Color.Default;
                LineaDisponibilidadTab.IsVisible = false;

                OpinionesTab.FontAttributes = FontAttributes.None;
                OpinionesTab.TextColor = Color.Default;
                LineaOpinionesTab.IsVisible = false;

                PerfilAMostrar.IsVisible = true;
                DisponibilidadAMostrar.IsVisible = false;
                OpinionesAMostrar.IsVisible = false;
            };
            PerfilTab.GestureRecognizers.Add(tapPerfilTab);

            tapDisponibilidadTab.Tapped += (s, e) =>
            {
                // handle the tap
                PerfilTab.FontAttributes = FontAttributes.None;
                PerfilTab.TextColor = Color.Default;
                LineaPerfilTab.IsVisible = false;

                DisponibilidadTab.FontAttributes = FontAttributes.Bold;
                DisponibilidadTab.TextColor = Color.FromHex("#CC0311");
                LineaDisponibilidadTab.IsVisible = true;

                OpinionesTab.FontAttributes = FontAttributes.None;
                OpinionesTab.TextColor = Color.Default;
                LineaOpinionesTab.IsVisible = false;

                PerfilAMostrar.IsVisible = false;
                DisponibilidadAMostrar.IsVisible = true;
                OpinionesAMostrar.IsVisible = false;
            };
            DisponibilidadTab.GestureRecognizers.Add(tapDisponibilidadTab);

            tapOpinionesTab.Tapped += (s, e) =>
            {
                // handle the tap
                PerfilTab.FontAttributes = FontAttributes.None;
                PerfilTab.TextColor = Color.Default;
                LineaPerfilTab.IsVisible = false;

                DisponibilidadTab.FontAttributes = FontAttributes.None;
                DisponibilidadTab.TextColor = Color.Default;
                LineaDisponibilidadTab.IsVisible = false;

                OpinionesTab.FontAttributes = FontAttributes.Bold;
                OpinionesTab.TextColor = Color.FromHex("#CC0311");
                LineaOpinionesTab.IsVisible = true;

                PerfilAMostrar.IsVisible = false;
                DisponibilidadAMostrar.IsVisible = false;
                OpinionesAMostrar.IsVisible = true;
            };
            OpinionesTab.GestureRecognizers.Add(tapOpinionesTab);

            //Inicializar comentarios Opiniones Chef
            mainViewModel.InitializeComentariosAsync(mainViewModel.ChefSeleccionado.Id);

        }

        private void Elegir_OnClick(object sender, EventArgs e)
        {
            var mainViewModel = BindingContext as MainViewModel;
            var idChef = mainViewModel.ChefSeleccionado.Id;
            mainViewModel.ElegirChef.Execute(idChef);
        }
    }
}
