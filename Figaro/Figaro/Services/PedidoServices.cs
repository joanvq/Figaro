using Figaro.Models;
using Plugin.RestClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figaro.Services
{
    class PedidoServices
    {
        public async Task<List<Pedido>> GetPedidosAsync()
        {

            RestClient<Pedido> restClient = new RestClient<Pedido>("Pedido");

            var listaPedidos = await restClient.GetAsync();

            return listaPedidos;

        }

        public async Task<List<Pedido>> GetPedidosUsuarioAsync(int idUsuario)
        {
            RestClient<Pedido> restClient = new RestClient<Pedido>("Pedido/Usuario");

            var listaPedidos = await restClient.GetByKeyAsync(idUsuario);

            return listaPedidos;
        }

        public async Task<Pedido> GetPedidosAsync(int id)
        {
            RestClient<Pedido> restClient = new RestClient<Pedido>("Pedido");

            var pedido = await restClient.GetAsync(id);

            return pedido;
        }

        public async Task<Pedido> GetPedidoByNPedidoAsync(string nPedido)
        {
            RestClient<Pedido> restClient = new RestClient<Pedido>("Pedido/NPedido");

            var listPedido = await restClient.GetByKeywordAsync(nPedido);

            var pedido = listPedido.FirstOrDefault();

            return pedido;
        }

        public async Task<Pedido> PostPedidoAsync(Pedido pedido)
        {

            RestClient<Pedido> restClient = new RestClient<Pedido>("Pedido");

            Pedido result = await restClient.PostAsyncContent(pedido);

            return result;
            
        }
    }
}
