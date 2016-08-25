using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Figaro.ViewModels;
using Figaro.Models;

namespace Figaro
{
    public partial class SeleccionarTipoComida : MasterDetailPage
    {

        public SeleccionarTipoComida()
        {
            InitializeComponent();
        }       

        public void TipoCocina_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var tipoCocina = ListaTipoCocinaView.SelectedItem as TipoCocina;
            if (tipoCocina != null)
            {
                var mainViewModel = BindingContext as MainViewModel;
                if (mainViewModel != null)
                {
                    mainViewModel.TipoCocinaSeleccionado = tipoCocina;
                    //Navigation.PopToRootAsync();
                    mainViewModel.Refresh.Execute(null);
                    //InitializeComponent();
                }
            }
        }
    }
}
