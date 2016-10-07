using Figaro.Models;
using Plugin.RestClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figaro.Services
{
    class DisponibilidadServices
    {
        public async Task<List<Disponibilidad>> GetDisponibilidadesAsync()
        {
            RestClient<Disponibilidad> restClient = new RestClient<Disponibilidad>("Disponibilidad");

            var listaDisponibilidades = await restClient.GetAsync();

            return listaDisponibilidades;
        }

        public async Task<List<Disponibilidad>> GetDisponibilidadesByChefAsync(int idChef)
        {
            RestClient<Disponibilidad> restClient = new RestClient<Disponibilidad>("Disponibilidad/Chef");

            var listaDisponibilidades = await restClient.GetByKeyAsync(idChef);

            return listaDisponibilidades;
        }

        public async Task<List<Disponibilidad>> GetDisponibilidadesByDateAsync(DateTime fecha)
        {
            RestClient<Disponibilidad> restClient = new RestClient<Disponibilidad>("Disponibilidad/Fecha");

            var listaDisponibilidades = await restClient.GetByDateAsync(fecha);

            return listaDisponibilidades;
        }

        public async Task<Disponibilidad> GetDisponibilidadesAsync(int id)
        {
            RestClient<Disponibilidad> restClient = new RestClient<Disponibilidad>("Disponibilidad");

            var disponibilidad = await restClient.GetAsync(id);

            return disponibilidad;
        }
    }
}
