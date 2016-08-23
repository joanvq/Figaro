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
        public PlatoViewModel PlatoViewModel { get; }
        

        public ViewModelLocator()
        {
            MainViewModel = new MainViewModel();
            PlatoViewModel = new PlatoViewModel();
        }
    }
}
