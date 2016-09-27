using Figaro.Models;
using Figaro.Other;
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
    public partial class VerCarrito : ContentPage
    {
        private decimal costeTotal = 0;

        private List<KeyValuePair<PlatoMenu, int>> listaCarrito = null;

        private List<KeyValuePair<PlatoMenu, int>> ListaCarrito
        {
            get { return listaCarrito; }
            set
            {
                listaCarrito = value;
                OnPropertyChanged();
            }
        }

        public VerCarrito()
        {

            InitializeComponent();

            InitializeData();
        }

        public void InitializeData() { 

            var mainViewModel = BindingContext as MainViewModel;

            // Combinar lista menus y platos para poder imprimir una sola lista 
            // Se usa la clase PlatoMenu, que es una classe generica que puede contener los 
            // campos que comparten el plato y el menú. 
            ListaCarrito = new List<KeyValuePair<PlatoMenu, int>>();
            foreach (var menuCarrito in mainViewModel.ListaMenuCarrito)
            {
                PlatoMenu menu = new PlatoMenu();
                menu.Id = "M" + menuCarrito.Menu.Id;
                menu.Categoria = menuCarrito.Menu.Categoria;
                menu.Descripcion = menuCarrito.Menu.Descripcion;
                menu.HorasCocinado = menuCarrito.Menu.HorasCocinado;
                menu.Imagen = menuCarrito.Menu.Imagen;
                menu.Ingredientes = menuCarrito.Menu.Ingredientes;
                menu.Precio = menuCarrito.Menu.Precio;
                menu.TiempoCocinado = menuCarrito.Menu.TiempoCocinado;
                menu.Titulo = menuCarrito.Menu.Titulo;
                menu.Utensilios = menuCarrito.Menu.Utensilios;
                menu.Valoracion = menuCarrito.Menu.Valoracion;
                KeyValuePair<PlatoMenu, int> platoMenuCant = new KeyValuePair<PlatoMenu, int>(menu, menuCarrito.Cantidad);
                ListaCarrito.Add(platoMenuCant);
            }
            foreach (var platoCarrito in mainViewModel.ListaPlatoCarrito)
            {
                PlatoMenu plato = new PlatoMenu();
                plato.Id = "P" + platoCarrito.Plato.Id;
                plato.Categoria = platoCarrito.Plato.Categoria;
                plato.Descripcion = platoCarrito.Plato.Descripcion;
                plato.HorasCocinado = platoCarrito.Plato.HorasCocinado;
                plato.Imagen = platoCarrito.Plato.Imagen;
                plato.Ingredientes = platoCarrito.Plato.Ingredientes;
                plato.Precio = platoCarrito.Plato.Precio;
                plato.TiempoCocinado = platoCarrito.Plato.TiempoCocinado;
                plato.Titulo = platoCarrito.Plato.Titulo;
                plato.Utensilios = platoCarrito.Plato.Utensilios;
                plato.Valoracion = platoCarrito.Plato.Valoracion;
                KeyValuePair<PlatoMenu, int> platoMenuCant = new KeyValuePair<PlatoMenu, int>(plato, platoCarrito.Cantidad);
                ListaCarrito.Add(platoMenuCant);
            }

            ListaPlatosMenus.ItemsSource = ListaCarrito;

            int tiempoTotal = 0;
            decimal coste = 0;
            decimal desplazamiento = 0;

            //Falta calculo de tiempo correcto
            foreach (MenuCarrito menuCarrito in mainViewModel.ListaMenuCarrito)
            {
                tiempoTotal += menuCarrito.Menu.TiempoCocinado;
                coste += menuCarrito.Menu.Precio * menuCarrito.Cantidad;
            }
            foreach (PlatoCarrito platoCarrito in mainViewModel.ListaPlatoCarrito)
            {
                tiempoTotal += platoCarrito.Plato.TiempoCocinado;
                coste += platoCarrito.Plato.Precio * platoCarrito.Cantidad;
            }

            TiempoTotal.Text = (tiempoTotal / 60).ToString();
            if ((tiempoTotal % 60) < 10)
            {
                TiempoTotal.Text += "h 0" + (tiempoTotal % 60).ToString() + "' ⏱";
            }
            else
            {
                TiempoTotal.Text += "h " + (tiempoTotal % 60).ToString() + "' ⏱";
            }

            Coste.Text = coste.ToString() + " €";

            //Cálculo de desplazamiento

            Desplazamiento.Text = desplazamiento.ToString() + " €";

            costeTotal = coste + desplazamiento;
            Total.Text = costeTotal.ToString() + " €";
        }

        private void Menu_OnItemTapped(object sender, ItemTappedEventArgs e) 
        {
            ((ListView)sender).SelectedItem = null; // de-select the row
            var button = new Button
            {
                Text = "Open popup"
            };
            var popup = new PopupLayout
            {
                Content = new StackLayout
                {
                    Orientation = StackOrientation.Vertical,
                    Children =
                    {
                      button
                    }
                }
            };
            button.Clicked += (s, ev) =>
            {
                button.IsEnabled = false;
                popup.DismissPopup();
                button.IsEnabled = true;
            };
            var label = new Label
            {
                Text = "Test"
            };

            var popLayout = new StackLayout
            {
                WidthRequest = 250,
                HeightRequest = 400,
                BackgroundColor = Color.White,
                Children =
                {
                    button,
                    label
                }
            };

            popup.ShowPopup(popLayout);
            
        }

        private void Plato_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null; // de-select the row
        }

        private async void QuitarElemento_OnTapped(object sender, EventArgs e)
        {
            var mainViewModel = BindingContext as MainViewModel;
            Image img = (Image)sender;

            //quitar elemento del carrito local y BD
            var isStatus = await mainViewModel.QuitarElementoCarritoAsync(img.ClassId.Substring(0, 1), Int32.Parse(img.ClassId.Substring(1)));
            
            InitializeData();
        }

        private void Pedir_OnClicked(object sender, EventArgs e)
        {
            var mainViewModel = BindingContext as MainViewModel;

            if (mainViewModel.ZonaSeleccionada == null)
            {
                DisplayAlert("Error", "No hay ninguna Zona seleccioanda.", "OK");
            }
            else if (mainViewModel.TipoCocinaSeleccionado == null)
            {
                DisplayAlert("Error", "No hay ningun Tipo de Cocina seleccionado.", "OK");
            }
            else if (mainViewModel.UsuarioLogueado.ChefSeleccionado.Nombre == null || mainViewModel.UsuarioLogueado.ChefSeleccionado.Nombre == "")
            {
                DisplayAlert("Error", "No hay ningun Chef seleccionado.", "OK");
            }
            else if (mainViewModel.ListaPlatoCarrito.Count == 0
                    && mainViewModel.ListaMenuCarrito.Count == 0)
            {
                DisplayAlert("Error", "No hay ningun Plato o Menú seleccionado.", "OK");
            }
            else
            {
                Navigation.PushAsync(new PedirDatos(costeTotal));
            }
        }
    }
}
