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
            var horMin = horaResMin.Hour.ToString();
            var minMin = horaResMin.Minute.ToString();
            var horMax = horaResMax.Hour.ToString();
            var minMax = horaResMax.Minute.ToString();
            if (horMin.Length == 1)
            {
                horMin = "0" + horMin;
            }
            if (minMin.Length == 1)
            {
                minMin = "0" + minMin;
            }
            if (horMax.Length == 1)
            {
                horMax = "0" + horMax;
            }
            if (minMax.Length == 1)
            {
                minMax = "0" + minMax;
            }

            HoraIniRes.Text = horMin + ":" + minMin;

            HoraFinRes.Text = horMax + ":" + minMax;

            var res = listaReservados.FirstOrDefault();
            if (res != null)
            {
                FechaReservada.Text = res.Disponibilidad.Fecha.ToString("dd'/'MM'/'yyyy");
            }
            
            FechaPedido.Text = pedido.FechaPedido.ToString("dd/MM/yyyy HH:mm");
            Precio.Text = pedido.PrecioTotal.ToString() + " €";

            //InitializeComponent();

            Cerrar.IsEnabled = true;
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
            var mvm = BindingContext as MainViewModel;
            App.Current.MainPage = new NavigationPage(new SeleccionarTipoComida(mvm.UsuarioLogueado));
        }
    }
}
