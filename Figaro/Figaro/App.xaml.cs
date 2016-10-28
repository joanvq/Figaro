using Figaro.Models;
using Figaro.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Figaro
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Navigate();

        }


        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        private async void Navigate()
        {
            //var usuario = await loadSettings();
            Usuario usuario = null;

            MainPage = new NavigationPage(new MainPage(usuario));
        }

        //private async Task<Usuario> loadSettings()
        //{
            // load file
            //try
            //{
            //    // NO FUNCIONA
            //    //open root folder
            //    IFolder rootFolder = FileSystem.Current.LocalStorage;
            //    //open folder if exists

            //    IFolder folder = await rootFolder.CreateFolderAsync("Conf", CreationCollisionOption.OpenIfExists);
            //    //open file if exists
            //    IFile file = await folder.GetFileAsync("conf");
            //    var content = await file.ReadAllTextAsync();
            //    string[] contents = content.Split(null);
            //    Usuario usuario = new Usuario();
            //    if(contents.Length >= 2)
            //    {
            //        usuario.Email = contents[0];
            //        usuario.Password = contents[1];
            //        return usuario;
            //    }
            //    return null;
            //}
            //catch
            //{
            //    // No existeix el fitxer
            //    //return null;
            //    throw new Exception();
            //}

        //}
    }
}
