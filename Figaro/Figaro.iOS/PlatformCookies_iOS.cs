using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;

namespace Figaro.iOS
{
    class PlatformCookies_iOS
    {
        public PlatformCookies_iOS()
        {
        }

        public void DeleteCookies()
        {
            var cookieStorage = NSHttpCookieStorage.SharedStorage;
            foreach (var cookie in cookieStorage.CookiesForUrl(new NSUrl("facebook.com")).ToList())
            {
                cookieStorage.DeleteCookie(cookie);
            }
            // you MUST call the .Sync method or those cookies may hang around for a bit
            NSUserDefaults.StandardUserDefaults.Synchronize();
        }
    }
}