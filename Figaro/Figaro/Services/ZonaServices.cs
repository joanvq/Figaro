using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Figaro.Models;
using Plugin.RestClient;

namespace Figaro.Services
{
    class ZonaServices
    {
        public async Task<List<Zona>> GetZonaAsync()
        {
            RestClient<Zona> restClient = new RestClient<Zona>("Zona");

            var listaZona = await restClient.GetAsync();

            foreach(var zona in listaZona)
            {
                zona.NoActual = true;
            }

            return listaZona;
        }
    }
}
