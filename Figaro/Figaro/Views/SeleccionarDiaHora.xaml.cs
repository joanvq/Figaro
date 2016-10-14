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
    public partial class SeleccionarDiaHora : ContentPage
    {

        public SeleccionarDiaHora()
        {
            InitializeComponent();
            fecha.MaximumDate = DateTime.Now.AddMonths(24);
            fecha.MinimumDate = DateTime.Now;
            //calendario.MaxDate = DateTime.Now.AddMonths(24);

        }

        private async void Seleccionar_OnClick(object sender, EventArgs e)
        {
            if (fecha.Date == null|| hora.Time == null)
            {
                this.DisplayAlert("", "Debe seleccionar dia y hora", "OK");
            }
            else
            {
                var mainViewModel = BindingContext as MainViewModel;
                //mainViewModel.Fecha = calendario.SelectedDate.Value;
                mainViewModel.Fecha = new DateTime(fecha.Date.Year, fecha.Date.Month, fecha.Date.Day);
                // Guarda de media hora en media hora, sera 1 o 0 dependiendo de si
                // se le suma la media hora o no
                int minutos = (hora.Time.Minutes >= 30) ? 1 : 0;
                mainViewModel.Hora = hora.Time.Hours*2 + minutos;

                Navigation.PopAsync();
                mainViewModel.FiltrarChefs();
            }
        }

        private void Time_OnChanged(object sender, EventArgs e)
        {
            if(hora == null)
            {
                return;
            }
            
            if(hora.Time.Minutes > 0 && hora.Time.Minutes < 30)
            {
                TimeSpan time = new TimeSpan(hora.Time.Hours, 0, 0);
                hora.Time = time;
            }
            if (hora.Time.Minutes > 30)
            {
                TimeSpan time = new TimeSpan(hora.Time.Hours, 30, 0);
                hora.Time = time;
            }
        }

        }
}
