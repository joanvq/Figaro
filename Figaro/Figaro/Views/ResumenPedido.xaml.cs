using Figaro.Models;
using Figaro.Services;
using Figaro.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Figaro.Views
{
    public partial class ResumenPedido : ContentPage
    {
        public ResumenPedido()
        {
            InitializeComponent();
            
        }

        public async void InitializeData(Pedido pedido)
        {
            var mvm = BindingContext as MainViewModel;
            mvm.IsBusy = true;

            nPedido.Text = pedido.NPedido;
            NombreApellidos.Text = pedido.NombreApellidos;
            Direccion.Text = pedido.Direccion;
            CP.Text = pedido.CP;
            if(pedido.Zona != null)
            {
                Zona.Text = pedido.Zona.Titulo;
            }
            TipoCocina.Text = pedido.TipoCocina;
            NombreChef.Text = pedido.NombreChef;
            NombreApellidos.Text = pedido.NombreApellidos;
            // Obtener Fecha, Hora Inicial y Hora final de la reserva
            var reservadoServices = new ReservadoServices();
            DateTime horaResMin = DateTime.MaxValue;
            DateTime horaResMax = DateTime.MinValue;
            List<Reservado> listaReservados = await reservadoServices.GetReservadosByPedidoAsync(pedido.Id);
            foreach(Reservado reservado in listaReservados)
            {
                if (horaResMin > reservado.Hora)
                {
                    horaResMin = reservado.Hora;
                }
                if (horaResMax < reservado.Hora)
                {
                    horaResMax = reservado.Hora;
                }
            }
            var hor = horaResMin.Hour.ToString();
            var min = horaResMax.Hour.ToString();
            if (hor.Length == 1)
            {
                hor = "0" + hor;
            }
            if (min.Length == 1)
            {
                min = "0" + min;
            }

            var res = listaReservados.FirstOrDefault();
            if (res != null)
            {
                FechaReservada.Text = res.Disponibilidad.Fecha.ToString("dd'/'MM'/'yyyy");
            }
            
            FechaPedido.Text = pedido.FechaPedido.ToString("dd/MM/yyyy HH:mm");
            Precio.Text = pedido.PrecioTotal.ToString() + " €";

            InitializeComponent();

            mvm.IsBusy = false;

        }

        public void EnviarMail(Pedido pedido)
        {
            if (pedido != null)
            {
                //Enviará mail

                var mainViewModel = BindingContext as MainViewModel;
                status.Text = "Se ha enviado un correo a " + mainViewModel.UsuarioLogueado.Email;
            }
            else
            {
                //MIRAR COM CONTROLAR AQUEST ERROR

                //status.Text = "Ha ocurrido un problema mientras se guardaba el pedido." +
                //    "Porfavor contacte con ..... Se ha enviado un mail con la incidancia.";
                //Enviar mail al admministrador
            }
        }

        public void Cerrar_OnClicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }
    }
}
