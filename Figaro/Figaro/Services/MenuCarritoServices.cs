using Figaro.Models;
using Plugin.RestClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figaro.Services
{
    class MenuCarritoServices
    {

        //Get todos menus carritos (no se usa)
        public async Task<List<MenuCarrito>> GetMenuCarritoAsync()
        {

            RestClient<MenuCarrito> restClient = new RestClient<MenuCarrito>("MenuCarrito");

            var listaMenuCarrito = await restClient.GetAsync();

            foreach (MenuCarrito menuCarrito in listaMenuCarrito)
            {
                menuCarrito.Menu.Imagen = "http://figaro.apphb.com" + menuCarrito.Menu.Imagen;
                menuCarrito.Menu.HorasCocinado = (menuCarrito.Menu.TiempoCocinado / 60).ToString();
                if ((menuCarrito.Menu.TiempoCocinado % 60) < 10)
                {
                    menuCarrito.Menu.HorasCocinado += "h 0" + (menuCarrito.Menu.TiempoCocinado % 60).ToString() + "' ⏱";
                }
                else
                {
                    menuCarrito.Menu.HorasCocinado += "h " + (menuCarrito.Menu.TiempoCocinado % 60).ToString() + "' ⏱";
                }
                menuCarrito.Menu.PrecioEuros = menuCarrito.Menu.Precio.ToString("0.00") + " €";

                if (menuCarrito.Menu.Entrante != null)
                {
                    menuCarrito.Menu.Entrante.Imagen = "http://figaro.apphb.com" + menuCarrito.Menu.Entrante.Imagen;
                    menuCarrito.Menu.Entrante.HorasCocinado = (menuCarrito.Menu.Entrante.TiempoCocinado / 60).ToString();
                    if ((menuCarrito.Menu.Entrante.TiempoCocinado % 60) < 10)
                    {
                        menuCarrito.Menu.Entrante.HorasCocinado += "h 0" + (menuCarrito.Menu.Entrante.TiempoCocinado % 60).ToString() + "' ⏱";
                    }
                    else
                    {
                        menuCarrito.Menu.Entrante.HorasCocinado += "h " + (menuCarrito.Menu.Entrante.TiempoCocinado % 60).ToString() + "' ⏱";
                    }
                    menuCarrito.Menu.Entrante.PrecioEuros = menuCarrito.Menu.Entrante.Precio.ToString("0.00") + " €";
                }
                if (menuCarrito.Menu.Primero != null)
                {
                    menuCarrito.Menu.Primero.Imagen = "http://figaro.apphb.com" + menuCarrito.Menu.Primero.Imagen;
                    menuCarrito.Menu.Primero.HorasCocinado = (menuCarrito.Menu.Primero.TiempoCocinado / 60).ToString();
                    if ((menuCarrito.Menu.Primero.TiempoCocinado % 60) < 10)
                    {
                        menuCarrito.Menu.Primero.HorasCocinado += "h 0" + (menuCarrito.Menu.Primero.TiempoCocinado % 60).ToString() + "' ⏱";
                    }
                    else
                    {
                        menuCarrito.Menu.Primero.HorasCocinado += "h " + (menuCarrito.Menu.Primero.TiempoCocinado % 60).ToString() + "' ⏱";
                    }
                    menuCarrito.Menu.Primero.PrecioEuros = menuCarrito.Menu.Primero.Precio.ToString("0.00") + " €";
                }
                if (menuCarrito.Menu.Segundo != null)
                {
                    menuCarrito.Menu.Segundo.Imagen = "http://figaro.apphb.com" + menuCarrito.Menu.Segundo.Imagen;
                    menuCarrito.Menu.Segundo.HorasCocinado = (menuCarrito.Menu.Segundo.TiempoCocinado / 60).ToString();
                    if ((menuCarrito.Menu.Segundo.TiempoCocinado % 60) < 10)
                    {
                        menuCarrito.Menu.Segundo.HorasCocinado += "h 0" + (menuCarrito.Menu.Segundo.TiempoCocinado % 60).ToString() + "' ⏱";
                    }
                    else
                    {
                        menuCarrito.Menu.Segundo.HorasCocinado += "h " + (menuCarrito.Menu.Segundo.TiempoCocinado % 60).ToString() + "' ⏱";
                    }
                    menuCarrito.Menu.Segundo.PrecioEuros = menuCarrito.Menu.Segundo.Precio.ToString("0.00") + " €";
                }
                if (menuCarrito.Menu.Segundo != null)
                {
                    menuCarrito.Menu.Segundo.Imagen = "http://figaro.apphb.com" + menuCarrito.Menu.Segundo.Imagen;
                    menuCarrito.Menu.Segundo.HorasCocinado = (menuCarrito.Menu.Segundo.TiempoCocinado / 60).ToString();
                    if ((menuCarrito.Menu.Segundo.TiempoCocinado % 60) < 10)
                    {
                        menuCarrito.Menu.Segundo.HorasCocinado += "h 0" + (menuCarrito.Menu.Segundo.TiempoCocinado % 60).ToString() + "' ⏱";
                    }
                    else
                    {
                        menuCarrito.Menu.Segundo.HorasCocinado += "h " + (menuCarrito.Menu.Segundo.TiempoCocinado % 60).ToString() + "' ⏱";
                    }
                    menuCarrito.Menu.Segundo.PrecioEuros = menuCarrito.Menu.Segundo.Precio.ToString("0.00") + " €";
                }
                if (menuCarrito.Menu.Postre != null)
                {
                    menuCarrito.Menu.Postre.Imagen = "http://figaro.apphb.com" + menuCarrito.Menu.Postre.Imagen;
                    menuCarrito.Menu.Postre.HorasCocinado = (menuCarrito.Menu.Postre.TiempoCocinado / 60).ToString();
                    if ((menuCarrito.Menu.Postre.TiempoCocinado % 60) < 10)
                    {
                        menuCarrito.Menu.Postre.HorasCocinado += "h 0" + (menuCarrito.Menu.Postre.TiempoCocinado % 60).ToString() + "' ⏱";
                    }
                    else
                    {
                        menuCarrito.Menu.Postre.HorasCocinado += "h " + (menuCarrito.Menu.Postre.TiempoCocinado % 60).ToString() + "' ⏱";
                    }
                    menuCarrito.Menu.Postre.PrecioEuros = menuCarrito.Menu.Postre.Precio.ToString("0.00") + " €";
                }
            }

            return listaMenuCarrito;

        }

        //Get todos menus carritos del usuario
        public async Task<List<MenuCarrito>> GetMenuCarritoByUsuarioAsync(int idUsuario)
        {
            RestClient<MenuCarrito> restClient = new RestClient<MenuCarrito>("MenuCarrito/Usuario");

            var listaMenuCarrito = await restClient.GetByKeyAsync(idUsuario);

            foreach (MenuCarrito menuCarrito in listaMenuCarrito)
            {
                menuCarrito.Menu.Imagen = "http://figaro.apphb.com" + menuCarrito.Menu.Imagen;
                menuCarrito.Menu.HorasCocinado = (menuCarrito.Menu.TiempoCocinado / 60).ToString();
                if ((menuCarrito.Menu.TiempoCocinado % 60) < 10)
                {
                    menuCarrito.Menu.HorasCocinado += "h 0" + (menuCarrito.Menu.TiempoCocinado % 60).ToString() + "' ⏱";
                }
                else
                {
                    menuCarrito.Menu.HorasCocinado += "h " + (menuCarrito.Menu.TiempoCocinado % 60).ToString() + "' ⏱";
                }
                menuCarrito.Menu.PrecioEuros = menuCarrito.Menu.Precio.ToString("0.00") + " €";

                if (menuCarrito.Menu.Entrante != null)
                {
                    menuCarrito.Menu.Entrante.Imagen = "http://figaro.apphb.com" + menuCarrito.Menu.Entrante.Imagen;
                    menuCarrito.Menu.Entrante.HorasCocinado = (menuCarrito.Menu.Entrante.TiempoCocinado / 60).ToString();
                    if ((menuCarrito.Menu.Entrante.TiempoCocinado % 60) < 10)
                    {
                        menuCarrito.Menu.Entrante.HorasCocinado += "h 0" + (menuCarrito.Menu.Entrante.TiempoCocinado % 60).ToString() + "' ⏱";
                    }
                    else
                    {
                        menuCarrito.Menu.Entrante.HorasCocinado += "h " + (menuCarrito.Menu.Entrante.TiempoCocinado % 60).ToString() + "' ⏱";
                    }
                    menuCarrito.Menu.Entrante.PrecioEuros = menuCarrito.Menu.Entrante.Precio.ToString("0.00") + " €";
                }
                if (menuCarrito.Menu.Primero != null)
                {
                    menuCarrito.Menu.Primero.Imagen = "http://figaro.apphb.com" + menuCarrito.Menu.Primero.Imagen;
                    menuCarrito.Menu.Primero.HorasCocinado = (menuCarrito.Menu.Primero.TiempoCocinado / 60).ToString();
                    if ((menuCarrito.Menu.Primero.TiempoCocinado % 60) < 10)
                    {
                        menuCarrito.Menu.Primero.HorasCocinado += "h 0" + (menuCarrito.Menu.Primero.TiempoCocinado % 60).ToString() + "' ⏱";
                    }
                    else
                    {
                        menuCarrito.Menu.Primero.HorasCocinado += "h " + (menuCarrito.Menu.Primero.TiempoCocinado % 60).ToString() + "' ⏱";
                    }
                    menuCarrito.Menu.Primero.PrecioEuros = menuCarrito.Menu.Primero.Precio.ToString("0.00") + " €";
                }
                if (menuCarrito.Menu.Segundo != null)
                {
                    menuCarrito.Menu.Segundo.Imagen = "http://figaro.apphb.com" + menuCarrito.Menu.Segundo.Imagen;
                    menuCarrito.Menu.Segundo.HorasCocinado = (menuCarrito.Menu.Segundo.TiempoCocinado / 60).ToString();
                    if ((menuCarrito.Menu.Segundo.TiempoCocinado % 60) < 10)
                    {
                        menuCarrito.Menu.Segundo.HorasCocinado += "h 0" + (menuCarrito.Menu.Segundo.TiempoCocinado % 60).ToString() + "' ⏱";
                    }
                    else
                    {
                        menuCarrito.Menu.Segundo.HorasCocinado += "h " + (menuCarrito.Menu.Segundo.TiempoCocinado % 60).ToString() + "' ⏱";
                    }
                    menuCarrito.Menu.Segundo.PrecioEuros = menuCarrito.Menu.Segundo.Precio.ToString("0.00") + " €";
                }
                if (menuCarrito.Menu.Segundo != null)
                {
                    menuCarrito.Menu.Segundo.Imagen = "http://figaro.apphb.com" + menuCarrito.Menu.Segundo.Imagen;
                    menuCarrito.Menu.Segundo.HorasCocinado = (menuCarrito.Menu.Segundo.TiempoCocinado / 60).ToString();
                    if ((menuCarrito.Menu.Segundo.TiempoCocinado % 60) < 10)
                    {
                        menuCarrito.Menu.Segundo.HorasCocinado += "h 0" + (menuCarrito.Menu.Segundo.TiempoCocinado % 60).ToString() + "' ⏱";
                    }
                    else
                    {
                        menuCarrito.Menu.Segundo.HorasCocinado += "h " + (menuCarrito.Menu.Segundo.TiempoCocinado % 60).ToString() + "' ⏱";
                    }
                    menuCarrito.Menu.Segundo.PrecioEuros = menuCarrito.Menu.Segundo.Precio.ToString("0.00") + " €";
                }
                if (menuCarrito.Menu.Postre != null)
                {
                    menuCarrito.Menu.Postre.Imagen = "http://figaro.apphb.com" + menuCarrito.Menu.Postre.Imagen;
                    menuCarrito.Menu.Postre.HorasCocinado = (menuCarrito.Menu.Postre.TiempoCocinado / 60).ToString();
                    if ((menuCarrito.Menu.Postre.TiempoCocinado % 60) < 10)
                    {
                        menuCarrito.Menu.Postre.HorasCocinado += "h 0" + (menuCarrito.Menu.Postre.TiempoCocinado % 60).ToString() + "' ⏱";
                    }
                    else
                    {
                        menuCarrito.Menu.Postre.HorasCocinado += "h " + (menuCarrito.Menu.Postre.TiempoCocinado % 60).ToString() + "' ⏱";
                    }
                    menuCarrito.Menu.Postre.PrecioEuros = menuCarrito.Menu.Postre.Precio.ToString("0.00") + " €";
                }
            }

            return listaMenuCarrito;
        }

        // Get un menu carrito en concreto
        public async Task<MenuCarrito> GetMenuCarritoAsync(int id)
        {

            RestClient<MenuCarrito> restClient = new RestClient<MenuCarrito>("MenuCarrito");

            var menuCarrito = await restClient.GetAsync(id);
            
            menuCarrito.Menu.Imagen = "http://figaro.apphb.com" + menuCarrito.Menu.Imagen;
            menuCarrito.Menu.HorasCocinado = (menuCarrito.Menu.TiempoCocinado / 60).ToString();
            if ((menuCarrito.Menu.TiempoCocinado % 60) < 10)
            {
                menuCarrito.Menu.HorasCocinado += "h 0" + (menuCarrito.Menu.TiempoCocinado % 60).ToString() + "' ⏱";
            }
            else
            {
                menuCarrito.Menu.HorasCocinado += "h " + (menuCarrito.Menu.TiempoCocinado % 60).ToString() + "' ⏱";
            }
            menuCarrito.Menu.PrecioEuros = menuCarrito.Menu.Precio.ToString("0.00") + " €";

            if (menuCarrito.Menu.Entrante != null)
            {
                menuCarrito.Menu.Entrante.Imagen = "http://figaro.apphb.com" + menuCarrito.Menu.Entrante.Imagen;
                menuCarrito.Menu.Entrante.HorasCocinado = (menuCarrito.Menu.Entrante.TiempoCocinado / 60).ToString();
                if ((menuCarrito.Menu.Entrante.TiempoCocinado % 60) < 10)
                {
                    menuCarrito.Menu.Entrante.HorasCocinado += "h 0" + (menuCarrito.Menu.Entrante.TiempoCocinado % 60).ToString() + "' ⏱";
                }
                else
                {
                    menuCarrito.Menu.Entrante.HorasCocinado += "h " + (menuCarrito.Menu.Entrante.TiempoCocinado % 60).ToString() + "' ⏱";
                }
                menuCarrito.Menu.Entrante.PrecioEuros = menuCarrito.Menu.Entrante.Precio.ToString("0.00") + " €";
            }
            if (menuCarrito.Menu.Primero != null)
            {
                menuCarrito.Menu.Primero.Imagen = "http://figaro.apphb.com" + menuCarrito.Menu.Primero.Imagen;
                menuCarrito.Menu.Primero.HorasCocinado = (menuCarrito.Menu.Primero.TiempoCocinado / 60).ToString();
                if ((menuCarrito.Menu.Primero.TiempoCocinado % 60) < 10)
                {
                    menuCarrito.Menu.Primero.HorasCocinado += "h 0" + (menuCarrito.Menu.Primero.TiempoCocinado % 60).ToString() + "' ⏱";
                }
                else
                {
                    menuCarrito.Menu.Primero.HorasCocinado += "h " + (menuCarrito.Menu.Primero.TiempoCocinado % 60).ToString() + "' ⏱";
                }
                menuCarrito.Menu.Primero.PrecioEuros = menuCarrito.Menu.Primero.Precio.ToString("0.00") + " €";
            }
            if (menuCarrito.Menu.Segundo != null)
            {
                menuCarrito.Menu.Segundo.Imagen = "http://figaro.apphb.com" + menuCarrito.Menu.Segundo.Imagen;
                menuCarrito.Menu.Segundo.HorasCocinado = (menuCarrito.Menu.Segundo.TiempoCocinado / 60).ToString();
                if ((menuCarrito.Menu.Segundo.TiempoCocinado % 60) < 10)
                {
                    menuCarrito.Menu.Segundo.HorasCocinado += "h 0" + (menuCarrito.Menu.Segundo.TiempoCocinado % 60).ToString() + "' ⏱";
                }
                else
                {
                    menuCarrito.Menu.Segundo.HorasCocinado += "h " + (menuCarrito.Menu.Segundo.TiempoCocinado % 60).ToString() + "' ⏱";
                }
                menuCarrito.Menu.Segundo.PrecioEuros = menuCarrito.Menu.Segundo.Precio.ToString("0.00") + " €";
            }
            if (menuCarrito.Menu.Segundo != null)
            {
                menuCarrito.Menu.Segundo.Imagen = "http://figaro.apphb.com" + menuCarrito.Menu.Segundo.Imagen;
                menuCarrito.Menu.Segundo.HorasCocinado = (menuCarrito.Menu.Segundo.TiempoCocinado / 60).ToString();
                if ((menuCarrito.Menu.Segundo.TiempoCocinado % 60) < 10)
                {
                    menuCarrito.Menu.Segundo.HorasCocinado += "h 0" + (menuCarrito.Menu.Segundo.TiempoCocinado % 60).ToString() + "' ⏱";
                }
                else
                {
                    menuCarrito.Menu.Segundo.HorasCocinado += "h " + (menuCarrito.Menu.Segundo.TiempoCocinado % 60).ToString() + "' ⏱";
                }
                menuCarrito.Menu.Segundo.PrecioEuros = menuCarrito.Menu.Segundo.Precio.ToString("0.00") + " €";
            }
            if (menuCarrito.Menu.Postre != null)
            {
                menuCarrito.Menu.Postre.Imagen = "http://figaro.apphb.com" + menuCarrito.Menu.Postre.Imagen;
                menuCarrito.Menu.Postre.HorasCocinado = (menuCarrito.Menu.Postre.TiempoCocinado / 60).ToString();
                if ((menuCarrito.Menu.Postre.TiempoCocinado % 60) < 10)
                {
                    menuCarrito.Menu.Postre.HorasCocinado += "h 0" + (menuCarrito.Menu.Postre.TiempoCocinado % 60).ToString() + "' ⏱";
                }
                else
                {
                    menuCarrito.Menu.Postre.HorasCocinado += "h " + (menuCarrito.Menu.Postre.TiempoCocinado % 60).ToString() + "' ⏱";
                }
                menuCarrito.Menu.Postre.PrecioEuros = menuCarrito.Menu.Postre.Precio.ToString("0.00") + " €";
            }

            return menuCarrito;
        }

        // Añadir menu carrito
        public async Task<bool> PostMenuCarritoAsync(MenuCarrito menuCarrito)
        {

            RestClient<MenuCarrito> restClient = new RestClient<MenuCarrito>("MenuCarrito");

            var isSuccessStatusCode = await restClient.PostAsync(menuCarrito);

            return isSuccessStatusCode;


        }

        // Modificar menu carrito
        public async Task<bool> PutMenuCarritoAsync(MenuCarrito menuCarrito)
        {

            RestClient<MenuCarrito> restClient = new RestClient<MenuCarrito>("MenuCarrito");

            var isSuccessStatusCode = await restClient.PutAsync(menuCarrito.Id, menuCarrito);

            return isSuccessStatusCode;

        }

        // Eliminar menu carrito
        public async Task<bool> DeleteMenuCarritoAsync(int id)
        {

            RestClient<MenuCarrito> restClient = new RestClient<MenuCarrito>("MenuCarrito");

            var isSuccessStatusCode = await restClient.DeleteAsync(id);

            return isSuccessStatusCode;

        }

        // Eliminar menu carrito por usuario
        public async Task<bool> DeleteMenuCarritoByUserAsync(int userId)
        {

            RestClient<MenuCarrito> restClient = new RestClient<MenuCarrito>("MenuCarrito/Usuario");

            var isSuccessStatusCode = await restClient.DeleteAsync(userId);

            return isSuccessStatusCode;

        }

    }
}
