using Figaro.Models;
using Plugin.RestClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figaro.Services
{
    class GeoPC_PlacesServices
    {
        public async Task<List<GeoPC_Places>> GetGeoPC_PlacesByZonaAsync(int idZona)
        {
            RestClient<GeoPC_Places> restClient = new RestClient<GeoPC_Places>("GeoPC_Places/Zona");

            var listaDisponibilidades = await restClient.GetByKeyAsync(idZona);

            return listaDisponibilidades;
        }
    }
}
