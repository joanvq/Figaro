using Figaro.Models;
using Plugin.RestClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figaro.Services
{
    class MenusServices
    {
        public async Task<List<Menu>> GetMenusAsync()
        {
            
            RestClient<Menu> restClient = new RestClient<Menu>("Menu");

            var listaMenus = await restClient.GetAsync();

            foreach(Menu menu in listaMenus)
            {
                menu.Imagen = "http://figaro.apphb.com" + menu.Imagen;
                menu.HorasCocinado = (menu.TiempoCocinado / 60).ToString();
                if ((menu.TiempoCocinado % 60) < 10)
                {
                    menu.HorasCocinado += "h 0" + (menu.TiempoCocinado % 60).ToString() + "' ⏱";
                }
                else
                {
                    menu.HorasCocinado += "h " + (menu.TiempoCocinado % 60).ToString() + "' ⏱";
                }
                menu.PrecioEuros = menu.Precio.ToString("0.00") + " €";
            }

            return listaMenus;
            
        }

        public async Task<Menu> GetMenusAsync(int id)
        {

            RestClient<Menu> restClient = new RestClient<Menu>("Menu");

            var menu = await restClient.GetAsync(id);

            return menu;
        }

    }
}
