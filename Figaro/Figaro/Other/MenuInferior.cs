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
                App.Current.MainPage = new NavigationPage(new MenuPage());
            };

            tapPlato.Tapped += (s, e) => {
                // handle the tap
                App.Current.MainPage = new NavigationPage(new PlatosPage());
            };

            tapChefs.Tapped += (s, e) => {
                // handle the tap
                App.Current.MainPage = new NavigationPage(new  ChefsPage());

            };

            tapProfile.Tapped += (s, e) => {
                // handle the tap
                App.Current.MainPage = new NavigationPage(new UserPage());
            };
        }
        
    }
}
