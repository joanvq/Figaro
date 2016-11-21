using System;
using Xamarin.Forms;
using Figaro.Droid;
using System.Collections.Generic;
using Figaro.Interfaces;
using Android.Speech.Tts;

[assembly: Dependency(typeof(PlatformCookies_Android))]

namespace Figaro.Droid
{
    public class PlatformCookies_Android : Java.Lang.Object, IPlatformCookies
    {
        public PlatformCookies_Android() {}
        
        public void DeleteCookies()
        {
            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Lollipop)
                Android.Webkit.CookieManager.Instance.RemoveAllCookies(null);
            else
                Android.Webkit.CookieManager.Instance.RemoveAllCookie();
        }
    }
}