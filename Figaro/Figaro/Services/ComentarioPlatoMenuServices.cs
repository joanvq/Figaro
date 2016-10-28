using Figaro.Models;
using Plugin.RestClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figaro.Services
{
    class ComentarioPlatoMenuServices
    {
        public async Task<List<ComentarioPlatoMenu>> GetComentariosPlatoAsync(int idPlato)
        {
            RestClient<ComentarioPlatoMenu> restClient = new RestClient<ComentarioPlatoMenu>("ComentarioPlatoMenu/Plato");

            var listaComentarioPlatoMenu = await restClient.GetByKeyAsync(idPlato);

            return listaComentarioPlatoMenu;
        }

        public async Task<List<ComentarioPlatoMenu>> GetComentariosMenuAsync(int idMenu)
        {
            RestClient<ComentarioPlatoMenu> restClient = new RestClient<ComentarioPlatoMenu>("ComentarioPlatoMenu/Menu");

            var listaComentarioPlatoMenu = await restClient.GetByKeyAsync(idMenu);

            return listaComentarioPlatoMenu;
        }

        public async Task<ComentarioPlatoMenu> GetComentariosPlatoMenuAsync(int id)
        {

            RestClient<ComentarioPlatoMenu> restClient = new RestClient<ComentarioPlatoMenu>("ComentarioPlatoMenu");

            var comentarioPlatoMenu = await restClient.GetAsync(id);

            return comentarioPlatoMenu;
        }
    }
}
