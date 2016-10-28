using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Figaro.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace Figaro.Services
{
    public class FacebookServices
    {

        public async Task<FacebookProfile> GetFacebookProfileAsync(string accessToken)
        {
            var requestUrl =
                "https://graph.facebook.com/v2.7/me/?fields=name,picture,work,website,religion,location,locale,link,cover,age_range,birthday,devices,email,first_name,last_name,gender,hometown,is_verified,languages&access_token="
                + accessToken;

            var httpClient = new HttpClient();

            var userJson = await httpClient.GetStringAsync(requestUrl);

            var facebookProfile = JsonConvert.DeserializeObject<FacebookProfile>(userJson);

            return facebookProfile;
        }

        public void LogoutFacebookAsync()
        {
            //var newView = new WebView();
            
            //NSHttpCookieStorage storage = NSHttpCookieStorage.SharedStorage;

            //foreach (NSHttpCookie cookie in storage.Cookies)
            //{
            //    if (cookie.Domain == ".facebook.com")
            //    {
            //        storage.DeleteCookie(cookie);
            //    }

            //}



        }
    }
}
