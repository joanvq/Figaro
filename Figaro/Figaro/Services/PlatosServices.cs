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

            RestClient<Plato> restClient = new RestClient<Plato>();

            var listaPlatos = await restClient.GetAsync();

            return listaPlatos;

            /*var list = new List<Plato>
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
            return list;*/
        }

        public async Task PostPlatoAsync(Plato plato)
        {

            RestClient<Plato> restClient = new RestClient<Plato>();

            var listaPlatos = await restClient.PostAsync(plato);
            
        }

        public async Task PutPlatoAsync(int id, Plato plato)
        {

            RestClient<Plato> restClient = new RestClient<Plato>();

            var listaPlatos = await restClient.PutAsync(id, plato);

        }

        public async Task DeletePlatoAsync(int id)
        {

            RestClient<Plato> restClient = new RestClient<Plato>();

            var listaPlatos = await restClient.DeleteAsync(id);

        }
    }
}
