using Figaro.Models;
using Plugin.RestClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figaro.Services
{
    class PlatosServices
    {
        public async Task<List<Plato>> GetPlatosAsync()
        {
            
            RestClient<Plato> restClient = new RestClient<Plato>("Plato");

            var listaPlatos = await restClient.GetAsync();

            return listaPlatos;

            /*
            var list = new List<Plato>
            {
                new Plato
                {
                    Titulo = "Entrecot",
                    Descripcion=""
                },
                new Plato
                {
                    Titulo = "Espaguetis",
                    Descripcion = "con tomate"
                }
            };
            return list;
            */

        }

        public async Task<bool> PostPlatoAsync(Plato plato)
        {

            RestClient<Plato> restClient = new RestClient<Plato>("Plato");

            var isSuccessStatusCode = await restClient.PostAsync(plato);

            return isSuccessStatusCode;


        }

        public async Task<bool> PutPlatoAsync(int id, Plato plato)
        {
            
            RestClient<Plato> restClient = new RestClient<Plato>("Plato");

            var isSuccessStatusCode = await restClient.PutAsync(id, plato);

            return isSuccessStatusCode;

        }

        public async Task<bool> DeletePlatoAsync(int id)
        {

            RestClient<Plato> restClient = new RestClient<Plato>("Plato");

            var isSuccessStatusCode = await restClient.DeleteAsync(id);

            return isSuccessStatusCode;

        }

        public async Task<List<Plato>> GetPlatosByKeywordAsync(string keyword)
        {

            RestClient<Plato> restClient = new RestClient<Plato>("Plato");

            var listaPlatos = await restClient.GetByKeywordAsync(keyword);

            return listaPlatos;
        }

    }
}
