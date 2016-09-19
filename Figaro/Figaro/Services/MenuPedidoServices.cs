using Figaro.Models;
using Plugin.RestClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figaro.Services
{
    class MenuPedidoServices
    {
        public async Task<List<MenuPedido>> GetMenuPedidosAsync()
        {

            RestClient<MenuPedido> restClient = new RestClient<MenuPedido>("MenuPedido");

            var listaMenuPedidos = await restClient.GetAsync();

            return listaMenuPedidos;

        }

        public async Task<List<MenuPedido>> GetMenuPedidosByPedidoAsync(int idPedido)
        {
            RestClient<MenuPedido> restClient = new RestClient<MenuPedido>("MenuPedido/Pedido");

            var listaMenuPedidos = await restClient.GetByKeyAsync(idPedido);

            return listaMenuPedidos;
        }

        public async Task<MenuPedido> GetMenuPedidosAsync(int id)
        {

            RestClient<MenuPedido> restClient = new RestClient<MenuPedido>("MenuPedido");

            var menuPedido = await restClient.GetAsync(id);

            return menuPedido;
        }

        // Añadir pedido
        public async Task<bool> PostMenuPedidoAsync(MenuPedido menuPedido)
        {

            RestClient<MenuPedido> restClient = new RestClient<MenuPedido>("MenuPedido");

            var isSuccessStatusCode = await restClient.PostAsync(menuPedido);

            return isSuccessStatusCode;


        }
    }
}
