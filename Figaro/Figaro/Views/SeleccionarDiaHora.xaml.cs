﻿using Figaro.ViewModels;
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
            var mainViewModel = BindingContext as MainViewModel;
            if(mainViewModel.Fecha != null)
            {
                fecha.Date = (DateTime) mainViewModel.Fecha;
            }
            if(mainViewModel.Hora != null)
            {
                var h = mainViewModel.Hora / 2;
                var m = (mainViewModel.Hora % 2) * 30;
                TimeSpan timeIni = new TimeSpan(h, m, 0);                
                hora.Time = timeIni;
            }
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
                mainViewModel.ElegirFechaHoraAsync(fecha, hora);
               
                Navigation.PopAsync();
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
