using Figaro.Models;
using Plugin.RestClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figaro.Services
{
    class ComentarioChefServices
    {
        public async Task<List<ComentarioChef>> GetComentariosChefAsync(int idChef)
        {
            RestClient<ComentarioChef> restClient = new RestClient<ComentarioChef>("ComentariosChef");

            var listaComentariosChef = await restClient.GetByKeyAsync(idChef);
            
            return listaComentariosChef;
        }

        public async Task<ComentarioChef> GetComentarioChefAsync(int id)
        {

            RestClient<ComentarioChef> restClient = new RestClient<ComentarioChef>("ComentariosChef");

            var comentarioChef = await restClient.GetAsync(id);
            
            return comentarioChef;
        }
    }
}
