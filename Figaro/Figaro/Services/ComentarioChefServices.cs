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
            
            foreach(var comentarioChef in listaComentariosChef)
            {
                comentarioChef.Usuario.NombreApellidos = comentarioChef.Usuario.Nombre + " " + comentarioChef.Usuario.Apellidos;
                if (comentarioChef.Usuario.Imagen != null)
                {
                    var index = comentarioChef.Usuario.Imagen.IndexOf("/Content");
                    if (index > -1)
                    {
                        // La Imagen es local
                        comentarioChef.Usuario.Imagen = "http://figaro.apphb.com" + comentarioChef.Usuario.Imagen;
                    }
                }
            }

            return listaComentariosChef;
        }

        public async Task<ComentarioChef> GetComentarioChefAsync(int id)
        {

            RestClient<ComentarioChef> restClient = new RestClient<ComentarioChef>("ComentariosChef");

            var comentarioChef = await restClient.GetAsync(id);

            comentarioChef.Usuario.NombreApellidos = comentarioChef.Usuario.Nombre + " " + comentarioChef.Usuario.Apellidos;
            if (comentarioChef.Usuario.Imagen != null)
            {
                var index = comentarioChef.Usuario.Imagen.IndexOf("/Content");
                if (index > -1)
                {
                    // La Imagen es local
                    comentarioChef.Usuario.Imagen = "http://figaro.apphb.com" + comentarioChef.Usuario.Imagen;
                }
            }

            return comentarioChef;
        }
    }
}
