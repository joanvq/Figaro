using Figaro.Models;
using Plugin.RestClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figaro.Services
{
    class PlatoCarritoServices
    {

        //Get todos platos carritos (no se usa)
        public async Task<List<PlatoCarrito>> GetPlatoCarritoAsync()
        {

            RestClient<PlatoCarrito> restClient = new RestClient<PlatoCarrito>("PlatoCarrito");

            var listaPlatoCarrito = await restClient.GetAsync();

            return listaPlatoCarrito;

        }

        //Get todos platos carritos del usuario
        public async Task<List<PlatoCarrito>> GetPlatoCarritoByUsuarioAsync(int idUsuario)
        {
            RestClient<PlatoCarrito> restClient = new RestClient<PlatoCarrito>("PlatoCarrito/Usuario");

            var listaPlatoCarrito = await restClient.GetByKeyAsync(idUsuario);

            return listaPlatoCarrito;
        }

        //Get un plato carrito en concreto
        public async Task<PlatoCarrito> GetPlatoCarritoAsync(int id)
        {

            RestClient<PlatoCarrito> restClient = new RestClient<PlatoCarrito>("PlatoCarrito");

            var platoCarrito = await restClient.GetAsync(id);

            return platoCarrito;
        }

        // Añadir plato carrito
        public async Task<bool> PostPlatoCarritoAsync(PlatoCarrito platoCarrito)
        {

            RestClient<PlatoCarrito> restClient = new RestClient<PlatoCarrito>("PlatoCarrito");

            var isSuccessStatusCode = await restClient.PostAsync(platoCarrito);

            return isSuccessStatusCode;


        }

        // Modificar plato carrito
        public async Task<bool> PutPlatoCarritoAsync(PlatoCarrito platoCarrito)
        {

            RestClient<PlatoCarrito> restClient = new RestClient<PlatoCarrito>("PlatoCarrito");

            var isSuccessStatusCode = await restClient.PutAsync(platoCarrito.Id,platoCarrito);

            return isSuccessStatusCode;

        }

        // Eliminar plato carrito
        public async Task<bool> DeletePlatoCarritoAsync(int id)
        {

            RestClient<PlatoCarrito> restClient = new RestClient<PlatoCarrito>("PlatoCarrito");

            var isSuccessStatusCode = await restClient.DeleteAsync(id);

            return isSuccessStatusCode;

        }

        // Eliminar plato carrito por usuario
        public async Task<bool> DeletePlatoCarritoByUserAsync(int userId)
        {

            RestClient<PlatoCarrito> restClient = new RestClient<PlatoCarrito>("PlatoCarrito/Usuario");

            var isSuccessStatusCode = await restClient.DeleteAsync(userId);

            return isSuccessStatusCode;

        }

    }
}
