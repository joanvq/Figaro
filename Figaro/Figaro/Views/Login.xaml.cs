using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Figaro.Views
{
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        public void LoginFacebook_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginFacebook());
        }
    }
}
