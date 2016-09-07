using Figaro.Models;
using Plugin.RestClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figaro.Services
{
    class ChefServices
    {
        public async Task<List<Chef>> GetChefsAsync()
        {

            RestClient<Chef> restClient = new RestClient<Chef>("Chef");

            var listaChefs = await restClient.GetAsync();

            foreach (Chef chef in listaChefs)
            {
                chef.Imagen = "http://figaro.apphb.com" + chef.Imagen;
                chef.ImagenFondo = "http://figaro.apphb.com" + chef.ImagenFondo;
                chef.NombreApellidos = chef.Nombre + " " + chef.Apellidos;

            }

            return listaChefs;

        }

        public async Task<Chef> GetChefsAsync(int id)
        {

            RestClient<Chef> restClient = new RestClient<Chef>("Chef");

            var chef = await restClient.GetAsync(id);

            chef.Imagen = "http://figaro.apphb.com" + chef.Imagen;
            chef.ImagenFondo = "http://figaro.apphb.com" + chef.ImagenFondo;
            chef.NombreApellidos = chef.Nombre + " " + chef.Apellidos;

            return chef;
        }
    }
}
