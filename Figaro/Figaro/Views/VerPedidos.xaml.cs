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
    public partial class VerPedidos : ContentPage
    {
        public VerPedidos()
        {
            InitializeComponent();

            var mainViewModel = BindingContext as MainViewModel;
            mainViewModel.ListaPedidosAsync();
        }
    }
}
