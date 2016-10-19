using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebServicesFigaro.Models;

namespace WebServicesFigaro.Controllers
{
    public class UsuarioController : ApiController
    {
        private DBContext db = new DBContext();

        // Bloqueado poder obtener todos los usuarios
        // GET: api/Usuario
        //public IQueryable<Usuario> GetUsuarios()
        //{
        //    var usuarios = db.Usuarios
        //        .Include(p => p.Zona)
        //        .Include(p => p.ChefSeleccionado);
            
        //}

        // GET: api/Usuario/5
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult GetUsuario(int id)
        {
            Usuario usuario = db.Usuarios
                .Include(u => u.Zona)
                .Include(u => u.ChefSeleccionado)
                .Include(u => u.TipoCocina)
                .FirstOrDefault(u => u.Id == id);
            //no devuelve el password
            //usuario.Password = null;
            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        // PUT: api/Usuario/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUsuario(int id, Usuario usuario)
        {

            if (id != usuario.Id)
            {
                return BadRequest();
            }

            //usuario.Password = db.Usuarios.FirstOrDefault(u => u.Id == id).Password;

            //var errors = ModelState.Values.SelectMany(v => v.Errors);
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(usuario).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Usuario
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult PostUsuario(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Usuarios.Add(usuario);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = usuario.Id }, usuario);
        }

        //// DELETE: api/Usuario/5
        //[ResponseType(typeof(Usuario))]
        //public IHttpActionResult DeleteUsuario(int id)
        //{
        //    Usuario usuario = db.Usuarios.Find(id);
        //    if (usuario == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Usuarios.Remove(usuario);
        //    db.SaveChanges();

        //    return Ok(usuario);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsuarioExists(int id)
        {
            return db.Usuarios.Count(e => e.Id == id) > 0;
        }
    }
}