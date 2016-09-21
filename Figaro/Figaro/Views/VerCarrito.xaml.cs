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

        public VerCarrito()
        {
            
            InitializeComponent();

            var mainViewModel = BindingContext as MainViewModel;

            // Combinar lista menus y platos para poder imprimir una sola lista 
            // Se usa la clase PlatoMenu, que es una classe generica que puede contener los 
            // campos que comparten el plato y el menú. 
            listaCarrito = new List<KeyValuePair<PlatoMenu, int>>();
            foreach (var menuCant in mainViewModel.CarritoCompra.listaMenus)
            {
                PlatoMenu menu = new PlatoMenu();
                menu.Categoria = menuCant.Key.Categoria;
                menu.Descripcion = menuCant.Key.Descripcion;
                menu.HorasCocinado = menuCant.Key.HorasCocinado;
                menu.Imagen = menuCant.Key.Imagen;
                menu.Ingredientes = menuCant.Key.Ingredientes;
                menu.Precio = menuCant.Key.Precio;
                menu.TiempoCocinado = menuCant.Key.TiempoCocinado;
                menu.Titulo = menuCant.Key.Titulo;
                menu.Utensilios = menuCant.Key.Utensilios;
                menu.Valoracion = menuCant.Key.Valoracion;
                KeyValuePair<PlatoMenu, int> platoMenuCant = new KeyValuePair<PlatoMenu, int>(menu, menuCant.Value);
                listaCarrito.Add(platoMenuCant);
            }
            foreach (var platoCant in mainViewModel.CarritoCompra.listaPlatos)
            {
                PlatoMenu plato = new PlatoMenu();
                plato.Categoria = platoCant.Key.Categoria;
                plato.Descripcion = platoCant.Key.Descripcion;
                plato.HorasCocinado = platoCant.Key.HorasCocinado;
                plato.Imagen = platoCant.Key.Imagen;
                plato.Ingredientes = platoCant.Key.Ingredientes;
                plato.Precio = platoCant.Key.Precio;
                plato.TiempoCocinado = platoCant.Key.TiempoCocinado;
                plato.Titulo = platoCant.Key.Titulo;
                plato.Utensilios = platoCant.Key.Utensilios;
                plato.Valoracion = platoCant.Key.Valoracion;
                KeyValuePair<PlatoMenu, int> platoMenuCant = new KeyValuePair<PlatoMenu, int>(plato, platoCant.Value);
                listaCarrito.Add(platoMenuCant);
            }

            ListaPlatosMenus.ItemsSource = listaCarrito;

            int tiempoTotal = 0;
            decimal coste = 0;
            decimal desplazamiento = 0;

            //Falta calculo de tiempo correcto
            foreach (KeyValuePair<Menu, int> menuCant in mainViewModel.CarritoCompra.listaMenus)
            {
                tiempoTotal += menuCant.Key.TiempoCocinado;
                coste += menuCant.Key.Precio * menuCant.Value;
            }
            foreach (KeyValuePair<Plato, int> platoCant in mainViewModel.CarritoCompra.listaPlatos)
            {
                tiempoTotal += platoCant.Key.TiempoCocinado;
                coste += platoCant.Key.Precio * platoCant.Value;
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

        public void Menu_OnItemTapped(object sender, ItemTappedEventArgs e) 
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

        public void Plato_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null; // de-select the row
        }

        public void Pedir_OnClicked(object sender, EventArgs e)
        {
            var mainViewModel = BindingContext as MainViewModel;

            if (mainViewModel.ZonaSeleccionada == null)
            {
                DisplayAlert("Error", "No hay ninguna Zona seleccioanda.", "OK");
            }
            else if (mainViewModel.CarritoCompra.chef.Nombre == "")
            {
                DisplayAlert("Error", "No hay ningun Chef seleccionado.", "OK");
            }
            else if (mainViewModel.CarritoCompra.listaMenus.Count == 0
                    && mainViewModel.CarritoCompra.listaPlatos.Count == 0)
            {
                DisplayAlert("Error", "No hay ningun Plato o Menú seleccionado.", "OK");
            }
                Navigation.PushAsync(new PedirDatos(costeTotal));
        }
    }
}
