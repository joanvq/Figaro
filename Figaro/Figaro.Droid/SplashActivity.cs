using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Content.PM;

namespace Figaro.Droid
{
    [Activity(Label = "Figaro", Theme = "@style/Splash", MainLauncher = true, 
        NoHistory = true, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            System.Threading.Thread.Sleep(500);
            StartActivity(typeof(MainActivity));
        }
    }
}