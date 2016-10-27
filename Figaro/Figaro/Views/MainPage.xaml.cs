using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Figaro.Views
{
    public partial class  MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        public void LoginFacebook_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginFacebook());
        }

        public void Registrar_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registrar());
        }

        public void Login_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginMail());
        }

    }
}
