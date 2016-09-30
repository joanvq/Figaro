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
    public class MenuCarritoController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/MenuCarrito
        public IQueryable<MenuCarrito> GetMenuCarritoes()
        {
            return db.MenuCarritoes
                .Include(p => p.Usuario)
                .Include(p => p.Menu);
        }

        // GET: api/MenuCarrito/5
        [ResponseType(typeof(MenuCarrito))]
        public IHttpActionResult GetMenuCarrito(int id)
        {
            MenuCarrito menuCarrito = db.MenuCarritoes.Find(id);
            if (menuCarrito == null)
            {
                return NotFound();
            }

            return Ok(menuCarrito);
        }

        // GET: api/MenuCarrito/Usuario/{idUsuario}
        [ResponseType(typeof(MenuCarrito))]
        [Route("api/MenuCarrito/Usuario/{id}")]
        public IQueryable<MenuCarrito> GetPlatoPedidosByPedido(int id)
        {
            return db.MenuCarritoes.Where(m => m.UsuarioId == id)
                .Include(p => p.Usuario)
                .Include(m => m.Menu);
        }

        // PUT: api/MenuCarrito/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMenuCarrito(int id, MenuCarrito menuCarrito)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != menuCarrito.Id)
            {
                return BadRequest();
            }

            db.Entry(menuCarrito).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuCarritoExists(id))
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

        // POST: api/MenuCarrito
        [ResponseType(typeof(MenuCarrito))]
        public IHttpActionResult PostMenuCarrito(MenuCarrito menuCarrito)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MenuCarritoes.Add(menuCarrito);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = menuCarrito.Id }, menuCarrito);
        }

        // DELETE: api/MenuCarrito/5
        [ResponseType(typeof(MenuCarrito))]
        public IHttpActionResult DeleteMenuCarrito(int id)
        {
            MenuCarrito menuCarrito = db.MenuCarritoes.Find(id);
            if (menuCarrito == null)
            {
                return NotFound();
            }

            db.MenuCarritoes.Remove(menuCarrito);
            db.SaveChanges();

            return Ok(menuCarrito);
        }

        // DELETE: api/MenuCarrito/Usuario/5
        [ResponseType(typeof(MenuCarrito))]
        [Route("api/MenuCarrito/Usuario/{userId}")]
        public IHttpActionResult DeleteMenuCarritoByUser(int userId)
        {
            var listaMenuCarrito = db.MenuCarritoes.Where(m => m.UsuarioId == userId);
            if (listaMenuCarrito == null)
            {
                return NotFound();
            }

            foreach (MenuCarrito menuCarrito in listaMenuCarrito)
            {
                db.MenuCarritoes.Remove(menuCarrito);
            }
            db.SaveChanges();

            return Ok(listaMenuCarrito);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MenuCarritoExists(int id)
        {
            return db.MenuCarritoes.Count(e => e.Id == id) > 0;
        }
    }
}