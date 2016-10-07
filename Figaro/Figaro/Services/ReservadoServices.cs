using Figaro.Models;
using Plugin.RestClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figaro.Services
{
    class ReservadoServices
    {
        public async Task<List<Reservado>> GetReservadosByDisponibilidadAsync(int idDisponibilidad)
        {
            RestClient<Reservado> restClient = new RestClient<Reservado>("Reservado/Disponibilidad");

            var listaReservados = await restClient.GetByKeyAsync(idDisponibilidad);

            return listaReservados;
        }

        public async Task<List<Reservado>> GetReservadosByPedidoAsync(int idPedido)
        {
            RestClient<Reservado> restClient = new RestClient<Reservado>("Reservado/Pedido");

            var listaReservados = await restClient.GetByKeyAsync(idPedido);

            return listaReservados;
        }

        public async Task<Reservado> GetReservadosAsync(int id)
        {
            RestClient<Reservado> restClient = new RestClient<Reservado>("Reservado");

            var disponibilidad = await restClient.GetAsync(id);

            return disponibilidad;
        }

        public async Task<bool> PutReservadoEnPedidoAsync(int reservadoId, int pedidoId)
        {

            Reservado reservado = await GetReservadosAsync(reservadoId);

            RestClient<Reservado> restClient = new RestClient<Reservado>("Reservado");

            var isSuccessStatusCode = await restClient.PutLinkAsync(reservadoId, pedidoId, reservado);

            return isSuccessStatusCode;

        }

    }
}
