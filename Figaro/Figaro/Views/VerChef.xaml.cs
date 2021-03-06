﻿using Figaro.Models;
using Figaro.Services;
using Figaro.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XLabs.Forms.Controls;

namespace Figaro.Views
{
    public partial class VerChef : ContentPage
    {
        private DateTime currentDate;
        private CalendarView _calendarView;
        private ActivityIndicator _activityIndicator;

        public VerChef(MainViewModel mainViewModel)
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
                LineaPerfilTab.Color = Color.FromHex("#CC0311");
                LineaPerfilTab.Opacity = 1;

                PlatosTab.FontAttributes = FontAttributes.None;
                PlatosTab.TextColor = Color.Default;
                LineaPlatosTab.Color = Color.Black;
                LineaPlatosTab.Opacity = 0.5;

                OpinionesTab.FontAttributes = FontAttributes.None;
                OpinionesTab.TextColor = Color.Default;
                LineaOpinionesTab.Color = Color.Black;
                LineaOpinionesTab.Opacity = 0.5;

                PerfilAMostrar.IsVisible = true;
                PlatosAMostrar.IsVisible = false;
                OpinionesAMostrar.IsVisible = false;
            };
            PerfilTab.GestureRecognizers.Add(tapPerfilTab);

            tapDisponibilidadTab.Tapped += (s, e) =>
            {
                // handle the tap
                PerfilTab.FontAttributes = FontAttributes.None;
                PerfilTab.TextColor = Color.Default;
                LineaPerfilTab.Color = Color.Black;
                LineaPerfilTab.Opacity = 0.5;

                PlatosTab.FontAttributes = FontAttributes.Bold;
                PlatosTab.TextColor = Color.FromHex("#CC0311");
                LineaPlatosTab.Color = Color.FromHex("#CC0311");
                LineaPlatosTab.Opacity = 1;

                OpinionesTab.FontAttributes = FontAttributes.None;
                OpinionesTab.TextColor = Color.Default;
                LineaOpinionesTab.Color = Color.Black;
                LineaOpinionesTab.Opacity = 0.5;

                PerfilAMostrar.IsVisible = false;
                PlatosAMostrar.IsVisible = true;
                OpinionesAMostrar.IsVisible = false;
            };
            PlatosTab.GestureRecognizers.Add(tapDisponibilidadTab);

            tapOpinionesTab.Tapped += (s, e) =>
            {
                // handle the tap
                PerfilTab.FontAttributes = FontAttributes.None;
                PerfilTab.TextColor = Color.Default;
                LineaPerfilTab.Color = Color.Black;
                LineaPerfilTab.Opacity = 0.5;

                PlatosTab.FontAttributes = FontAttributes.None;
                PlatosTab.TextColor = Color.Default;
                LineaPlatosTab.Color = Color.Black;
                LineaPlatosTab.Opacity = 0.5;

                OpinionesTab.FontAttributes = FontAttributes.Bold;
                OpinionesTab.TextColor = Color.FromHex("#CC0311");
                LineaOpinionesTab.Color = Color.FromHex("#CC0311");
                LineaOpinionesTab.Opacity = 1;

                PerfilAMostrar.IsVisible = false;
                PlatosAMostrar.IsVisible = false;
                OpinionesAMostrar.IsVisible = true;
            };
            OpinionesTab.GestureRecognizers.Add(tapOpinionesTab);

            //Inicializar comentarios Opiniones Chef
            mainViewModel.InitializeComentariosChefAsync(mainViewModel.ChefSeleccionado.Id);

            //Inicializar calendario disponibilidad
            _calendarView = new CalendarView()
            {
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                MinDate = DateTime.Today,
                MaxDate = DateTime.Now.AddMonths(24),
                HighlightedDateBackgroundColor = Color.Transparent,
                ShouldHighlightDaysOfWeekLabels = false,
                SelectionBackgroundStyle = CalendarView.BackgroundStyle.CircleFill,
                TodayBackgroundStyle = CalendarView.BackgroundStyle.CircleOutline,
                ShowNavigationArrows = true,
                IsVisible = false          
            };
            _activityIndicator = new ActivityIndicator()
            {
                IsRunning = true,
                IsVisible = true
            };
            Calendario.Children.Add(_calendarView);
            Calendario.Children.Add(_activityIndicator);

            _calendarView.DateSelected += (object sender, DateTime selectedDate) =>
            {
                RefreshCalendarListView(selectedDate, mainViewModel);
                currentDate = selectedDate.Date;
            };
            InitDisponibilidad(mainViewModel);
        }

        private async void InitDisponibilidad(MainViewModel mvm)
        {
            await mvm.InitLibres();
            _activityIndicator.IsVisible = false;
            _activityIndicator.IsRunning = false;
            _calendarView.IsVisible = true;
        }

        private void RefreshCalendarListView(DateTime selectedDate, MainViewModel mvm)
        {
            SeleccioneFecha.IsVisible = false;
            listViewCalendars.SelectedItem = null;
            var listaHoras = mvm.ListaLibres.Where(l => l.Disponibilidad.Fecha.Date == selectedDate);
            if (selectedDate == DateTime.Today)
            {
                listaHoras = listaHoras.Where(l => l.Hora.Hour > DateTime.Now.Hour);
            }
            if (listaHoras.Count() < 4)
            {
                NoDisponible.IsVisible = true;
                listViewCalendars.ItemsSource = null;
                listViewCalendars.SelectedItem = null;
            }
            else
            {
                var listaFinal = new List<Reservado>();
                var count = 1;
                for(int i = 1; i < listaHoras.Count(); i++)
                {
                    var horaAct = listaHoras.ElementAt(i);
                    var horaAnt = listaHoras.ElementAt(i-1);
                    if (horaAnt.Hora.AddMinutes(30) == horaAct.Hora)
                    {
                        count++;
                    }
                    else
                    {
                        count = 1;
                    }
                    if(count >= 4)
                    {
                        // Si hay 2 horas seguidas libres (4 medias horas) añade a la lista
                        // el elemento de 2 horas anterior
                        listaFinal.Add(listaHoras.ElementAt(i - 3));
                    }
                }
                if (listaFinal.Count == 0)
                {
                    NoDisponible.IsVisible = true;
                    listViewCalendars.ItemsSource = null;
                    listViewCalendars.SelectedItem = null;
                }
                else
                {
                    NoDisponible.IsVisible = false;
                    listViewCalendars.ItemsSource = listaFinal;
                }
            }
        }

        private async void Elegir_OnClick(object sender, EventArgs e)
        {
            if (currentDate == null || listViewCalendars == null || listViewCalendars.SelectedItem == null)
            {
                DisplayAlert("Error", "Por favor, seleccione una fecha y hora disponible", "OK");
            }
            else
            {
                var mainViewModel = BindingContext as MainViewModel;
                var idChef = mainViewModel.ChefSeleccionado.Id;

                mainViewModel.Fecha = currentDate.Date;
                var hora = (Reservado)listViewCalendars.SelectedItem;
                await mainViewModel.ElegirFechaHoraAsync(currentDate.Date, hora.Hora);
                await mainViewModel.ElegirChef(idChef);
                DisplayAlert("Seleccionado", "Chef seleccionado correctamente", "OK");
                if (mainViewModel.ListaMenuCarrito.Count == 0 && mainViewModel.ListaPlatoCarrito.Count == 0)
                {
                    Navigation.PopAsync();                
                } 
                else
                {
                    Navigation.PushAsync(new VerCarrito());
                }
            }
        }

        private void Hora_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
        }

        private void Plato_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var plato = PlatosAMostrar.SelectedItem as Plato;
            PlatosAMostrar.SelectedItem = null;

            if (plato != null)
            {
                var mainViewModel = BindingContext as MainViewModel;

                if (mainViewModel != null)
                {
                    mainViewModel.PlatoSeleccionado = plato;

                    Navigation.PushAsync(new VerPlato(mainViewModel));
                }
            }
        }

        private void AnadirCesta_OnClick(object sender, EventArgs e)
        {
            var mainViewModel = BindingContext as MainViewModel;
            Button btn = (Button)sender;
            Tuple<int, int> idCant = new Tuple<int, int>(int.Parse(btn.ClassId), 1);
            mainViewModel.AnadirPlatoCesta.Execute(idCant);
            DisplayAlert("Añadido", "Plato añadido a la cesta de la compra", "OK");
        }

        // Imágenes estrellas valoración
        private void StarOne_OnChanged(object sender, EventArgs e)
        {
            Image star = (Image)sender;
            if (star.ClassId != null && star.Source == null)
            {
                var mvm = BindingContext as MainViewModel;
                var comchef = mvm.ListaComentariosChef.FirstOrDefault(l => l.Id == Convert.ToInt32(star.ClassId));
                if(comchef != null)
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
                var comchef = mvm.ListaComentariosChef.FirstOrDefault(l => l.Id == Convert.ToInt32(star.ClassId));
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
                var comchef = mvm.ListaComentariosChef.FirstOrDefault(l => l.Id == Convert.ToInt32(star.ClassId));
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
                var comchef = mvm.ListaComentariosChef.FirstOrDefault(l => l.Id == Convert.ToInt32(star.ClassId));
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
                var comchef = mvm.ListaComentariosChef.FirstOrDefault(l => l.Id == Convert.ToInt32(star.ClassId));
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
