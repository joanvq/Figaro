using Figaro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Figaro.Views
{
    public partial class ModoPago : ContentPage
    {
        public ModoPago(Pedido pedido)
        {
            InitializeComponent();

            NombreApellidos.Text = pedido.Usuario.NombreApellidos;
            Direccion.Text = pedido.Direccion;
            Zona.Text = pedido.Zona.Titulo;
            NombreChef.Text = "nombrechef"; //cambiar
            ApellidosChef.Text = "apellidochef1 apellidochef2"; //cambiar
            FechaHora.Text = "14/09/2016 21:00"; //cambiar
        }

        public void Plato_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null; // de-select the row
        }

        public void Menu_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null; // de-select the row
        }

        public void PagarPaypal_OnClicked(object sender, EventArgs e)
        {

        }
    }
}
