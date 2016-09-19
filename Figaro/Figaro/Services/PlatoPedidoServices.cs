using Figaro.Models;
using Plugin.RestClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figaro.Services
{
    class PlatoPedidoServices
    {
        public async Task<List<PlatoPedido>> GetPlatoPedidosAsync()
        {

            RestClient<PlatoPedido> restClient = new RestClient<PlatoPedido>("PlatoPedido");

            var listaPlatoPedidos = await restClient.GetAsync();

            return listaPlatoPedidos;

        }

        public async Task<List<PlatoPedido>> GetPlatoPedidosByPedidoAsync(int idPedido)
        {
            RestClient<PlatoPedido> restClient = new RestClient<PlatoPedido>("PlatoPedido/Pedido");

            var listaPlatoPedidos = await restClient.GetByKeyAsync(idPedido);

            return listaPlatoPedidos;
        }

        public async Task<PlatoPedido> GetPlatoPedidosAsync(int id)
        {

            RestClient<PlatoPedido> restClient = new RestClient<PlatoPedido>("PlatoPedido");

            var platoPedido = await restClient.GetAsync(id);

            return platoPedido;
        }

        // Añadir plato pedido
        public async Task<bool> PostPlatoPedidoAsync(PlatoPedido platoPedido)
        {

            RestClient<PlatoPedido> restClient = new RestClient<PlatoPedido>("PlatoPedido");

            var isSuccessStatusCode = await restClient.PostAsync(platoPedido);

            return isSuccessStatusCode;


        }
    }
}
