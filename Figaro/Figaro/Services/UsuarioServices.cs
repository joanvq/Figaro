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

        public async Task<bool> PutUsuarioAsync(int id, Usuario usuario)
        {
            Usuario nuevoUsuario = new Usuario();
            nuevoUsuario.Id = usuario.Id;
            nuevoUsuario.Nombre = usuario.Nombre;
            nuevoUsuario.Apellidos = usuario.Apellidos;
            nuevoUsuario.Ciudad = usuario.Ciudad;
            nuevoUsuario.Direccion = usuario.Direccion;
            nuevoUsuario.genero = usuario.genero;
            nuevoUsuario.Email = usuario.Email;
            nuevoUsuario.Estado = usuario.Estado;
            nuevoUsuario.FechaRegistro = usuario.FechaRegistro;
            nuevoUsuario.ChefSeleccionadoId = usuario.ChefSeleccionadoId;
            nuevoUsuario.TipoCocinaId = usuario.TipoCocinaId;
            var index = usuario.Imagen.IndexOf("/Content");
            if (index > -1)
            {
                nuevoUsuario.Imagen = usuario.Imagen.Substring(index);
            }
            else
            {
                nuevoUsuario.Imagen = usuario.Imagen;
            }
            nuevoUsuario.Password = usuario.Password;
            nuevoUsuario.ZonaId = usuario.ZonaId;

            RestClient<Usuario> restClient = new RestClient<Usuario>("Usuario");

            var isSuccessStatusCode = await restClient.PutAsync(id, nuevoUsuario);

            return isSuccessStatusCode;

        }

        public async Task<Usuario> PostUsuarioFacebookAsync(Usuario usuario)
        {

            RestClient<Usuario> restClient = new RestClient<Usuario>("Usuario/Facebook");

            usuario.FechaRegistro = DateTime.Now;
            Usuario result = await restClient.PostAsyncContent(usuario);

            return result;
            
        }

        public async Task<bool> PostUsuarioAsync(Usuario usuario)
        {

            RestClient<Usuario> restClient = new RestClient<Usuario>("Usuario");

            usuario.FechaRegistro = DateTime.Now;
            usuario.FacebookId = "";
            bool isSuccess = await restClient.PostAsync(usuario);

            return isSuccess;

        }
    }

    //internal class UsuarioPost
    //{
    //    public int Id { get; set; }
    //    public string Nombre { get; set; }
    //    public string Apellidos { get; set; }
    //    public string Email { get; set; }
    //    public string Imagen { get; set; }
    //    public string Password { get; set; }
    //    public int ZonaId { get; set; }
    //    public string Ciudad { get; set; }
    //    public string Direccion { get; set; }
    //    public string Estado { get; set; }
    //    public DateTime FechaRegistro { get; set; }
    //    public string genero { get; set; }
    //}
}
