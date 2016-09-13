using Figaro.Models;
using Plugin.RestClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figaro.Services
{
    class UsuarioServices
    {
        public async Task<Usuario> GetUsuariosAsync(int id)
        {

            RestClient<Usuario> restClient = new RestClient<Usuario>("Usuario");

            var usuario = await restClient.GetAsync(id);

            usuario.Imagen = "http://figaro.apphb.com" + usuario.Imagen;
            usuario.NombreApellidos = usuario.Nombre + " " + usuario.Apellidos;

            return usuario;
        }
    }
}
