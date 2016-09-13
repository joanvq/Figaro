using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Figaro.Views;
using Xamarin.Forms;
using Figaro.ViewModels;

namespace Figaro.Other
{
    class MenuInferior
    {

        public TapGestureRecognizer tapMenu = new TapGestureRecognizer();
        public TapGestureRecognizer tapPlato = new TapGestureRecognizer();
        public TapGestureRecognizer tapChefs = new TapGestureRecognizer();
        public TapGestureRecognizer tapProfile = new TapGestureRecognizer();
        public MainViewModel mainViewmodel;

        public MenuInferior(Page sender)
        {
            tapMenu.Tapped += (s, e) => {
                // handle the tap
                var app = Application.Current as App;
                var mainPage = (NavigationPage)app.MainPage;
                var currentPage = (MasterDetailPage)mainPage.CurrentPage;
                currentPage.Detail = new MenuPage();
            };

            tapPlato.Tapped += (s, e) => {
                // handle the tap
                var app = Application.Current as App;
                var mainPage = (NavigationPage)app.MainPage;
                var currentPage = (MasterDetailPage)mainPage.CurrentPage;
                currentPage.Detail = new PlatosPage();
            };

            tapChefs.Tapped += (s, e) => {
                // handle the tap
                var app = Application.Current as App;
                var mainPage = (NavigationPage)app.MainPage;
                var currentPage = (MasterDetailPage)mainPage.CurrentPage;
                currentPage.Detail = new ChefsPage();

            };

            tapProfile.Tapped += (s, e) => {
                // handle the tap
                sender.DisplayAlert("Perfil", "Usuario logueado: " + mainViewmodel.UsuarioLogueado.NombreApellidos, "OK");
            };
        }
        
    }
}
