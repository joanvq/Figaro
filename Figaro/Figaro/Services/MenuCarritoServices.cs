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

            return listaMenuCarrito;

        }

        //Get todos menus carritos del usuario
        public async Task<List<MenuCarrito>> GetMenuCarritoByUsuarioAsync(int idUsuario)
        {
            RestClient<MenuCarrito> restClient = new RestClient<MenuCarrito>("MenuCarrito/Usuario");

            var listaMenuCarrito = await restClient.GetByKeyAsync(idUsuario);

            return listaMenuCarrito;
        }

        //Get un menu carrito en concreto
        public async Task<MenuCarrito> GetMenuCarritoAsync(int id)
        {

            RestClient<MenuCarrito> restClient = new RestClient<MenuCarrito>("MenuCarrito");

            var menuCarrito = await restClient.GetAsync(id);

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

    }
}
