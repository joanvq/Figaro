using Figaro.Models;
using Figaro.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figaro.Configuration
{
    class ViewModelLocator
    {
        public MainViewModel MainViewModel { get; }
        public FacebookViewModel FacebookViewModel { get; }
        public LoginViewModel LoginViewModel { get; }
        //public PlatoViewModel PlatoViewModel { get; }
        //public TipoCocinaViewModel TipoCocinaViewModel { get; }
        

        public ViewModelLocator()
        {
            FacebookViewModel = new FacebookViewModel();
            LoginViewModel = new LoginViewModel();
            MainViewModel = new MainViewModel();
            //PlatoViewModel = new PlatoViewModel();
            //TipoCocinaViewModel = new TipoCocinaViewModel();
        }
    }
}
