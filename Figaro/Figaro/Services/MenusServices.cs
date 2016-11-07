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

                if(menu.Entrante != null)
                {
                    menu.Entrante.Imagen = "http://figaro.apphb.com" + menu.Entrante.Imagen;
                    menu.Entrante.HorasCocinado = (menu.Entrante.TiempoCocinado / 60).ToString();
                    if ((menu.Entrante.TiempoCocinado % 60) < 10)
                    {
                        menu.Entrante.HorasCocinado += "h 0" + (menu.Entrante.TiempoCocinado % 60).ToString() + "' ⏱";
                    }
                    else
                    {
                        menu.Entrante.HorasCocinado += "h " + (menu.Entrante.TiempoCocinado % 60).ToString() + "' ⏱";
                    }
                    menu.Entrante.PrecioEuros = menu.Entrante.Precio.ToString("0.00") + " €";
                }
                if (menu.Primero != null)
                {
                    menu.Primero.Imagen = "http://figaro.apphb.com" + menu.Primero.Imagen;
                    menu.Primero.HorasCocinado = (menu.Primero.TiempoCocinado / 60).ToString();
                    if ((menu.Primero.TiempoCocinado % 60) < 10)
                    {
                        menu.Primero.HorasCocinado += "h 0" + (menu.Primero.TiempoCocinado % 60).ToString() + "' ⏱";
                    }
                    else
                    {
                        menu.Primero.HorasCocinado += "h " + (menu.Primero.TiempoCocinado % 60).ToString() + "' ⏱";
                    }
                    menu.Primero.PrecioEuros = menu.Primero.Precio.ToString("0.00") + " €";
                }
                if (menu.Segundo != null)
                {
                    menu.Segundo.Imagen = "http://figaro.apphb.com" + menu.Segundo.Imagen;
                    menu.Segundo.HorasCocinado = (menu.Segundo.TiempoCocinado / 60).ToString();
                    if ((menu.Segundo.TiempoCocinado % 60) < 10)
                    {
                        menu.Segundo.HorasCocinado += "h 0" + (menu.Segundo.TiempoCocinado % 60).ToString() + "' ⏱";
                    }
                    else
                    {
                        menu.Segundo.HorasCocinado += "h " + (menu.Segundo.TiempoCocinado % 60).ToString() + "' ⏱";
                    }
                    menu.Segundo.PrecioEuros = menu.Segundo.Precio.ToString("0.00") + " €";
                }
                if (menu.Segundo != null)
                {
                    menu.Segundo.Imagen = "http://figaro.apphb.com" + menu.Segundo.Imagen;
                    menu.Segundo.HorasCocinado = (menu.Segundo.TiempoCocinado / 60).ToString();
                    if ((menu.Segundo.TiempoCocinado % 60) < 10)
                    {
                        menu.Segundo.HorasCocinado += "h 0" + (menu.Segundo.TiempoCocinado % 60).ToString() + "' ⏱";
                    }
                    else
                    {
                        menu.Segundo.HorasCocinado += "h " + (menu.Segundo.TiempoCocinado % 60).ToString() + "' ⏱";
                    }
                    menu.Segundo.PrecioEuros = menu.Segundo.Precio.ToString("0.00") + " €";
                }
                if (menu.Postre != null)
                {
                    menu.Postre.Imagen = "http://figaro.apphb.com" + menu.Postre.Imagen;
                    menu.Postre.HorasCocinado = (menu.Postre.TiempoCocinado / 60).ToString();
                    if ((menu.Postre.TiempoCocinado % 60) < 10)
                    {
                        menu.Postre.HorasCocinado += "h 0" + (menu.Postre.TiempoCocinado % 60).ToString() + "' ⏱";
                    }
                    else
                    {
                        menu.Postre.HorasCocinado += "h " + (menu.Postre.TiempoCocinado % 60).ToString() + "' ⏱";
                    }
                    menu.Postre.PrecioEuros = menu.Postre.Precio.ToString("0.00") + " €";
                }

            }

            return listaMenus;
            
        }

        public async Task<Menu> GetMenusAsync(int id)
        {

            RestClient<Menu> restClient = new RestClient<Menu>("Menu");

            var menu = await restClient.GetAsync(id);

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

            return menu;
        }

    }
}
