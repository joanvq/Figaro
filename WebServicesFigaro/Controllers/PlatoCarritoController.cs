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
    public class PlatoCarritoController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/PlatoCarrito
        public IQueryable<PlatoCarrito> GetPlatoCarritoes()
        {
            return db.PlatoCarritoes
                .Include(p => p.Usuario)
                .Include(p => p.Plato);
        }

        // GET: api/PlatoCarrito/5
        [ResponseType(typeof(PlatoCarrito))]
        public IHttpActionResult GetPlatoCarrito(int id)
        {
            PlatoCarrito platoCarrito = db.PlatoCarritoes.Find(id);
            if (platoCarrito == null)
            {
                return NotFound();
            }

            return Ok(platoCarrito);
        }

        // GET: api/PlatoCarrito/Usuario/{idUsuario}
        [ResponseType(typeof(PlatoCarrito))]
        [Route("api/PlatoCarrito/Usuario/{id}")]
        public IQueryable<PlatoCarrito> GetPlatoPedidosByPedido(int id)
        {
            return db.PlatoCarritoes.Where(p => p.UsuarioId == id)
                .Include(p => p.Usuario)
                .Include(p => p.Plato);
        }

        // PUT: api/PlatoCarrito/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPlatoCarrito(int id, PlatoCarrito platoCarrito)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != platoCarrito.Id)
            {
                return BadRequest();
            }

            db.Entry(platoCarrito).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlatoCarritoExists(id))
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

        // POST: api/PlatoCarrito
        [ResponseType(typeof(PlatoCarrito))]
        public IHttpActionResult PostPlatoCarrito(PlatoCarrito platoCarrito)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PlatoCarritoes.Add(platoCarrito);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = platoCarrito.Id }, platoCarrito);
        }

        // DELETE: api/PlatoCarrito/5
        [ResponseType(typeof(PlatoCarrito))]
        public IHttpActionResult DeletePlatoCarrito(int id)
        {
            PlatoCarrito platoCarrito = db.PlatoCarritoes.Find(id);
            if (platoCarrito == null)
            {
                return NotFound();
            }

            db.PlatoCarritoes.Remove(platoCarrito);
            db.SaveChanges();

            return Ok(platoCarrito);
        }

        // DELETE: api/PlatoCarrito/Usuario/5
        [ResponseType(typeof(PlatoCarrito))]
        [Route("api/PlatoCarrito/Usuario/{userId}")]
        public IHttpActionResult DeletePlatoCarritoByUser(int userId)
        {
            var listaPlatoCarrito = db.PlatoCarritoes.Where(p => p.UsuarioId == userId);
            if (listaPlatoCarrito == null)
            {
                return NotFound();
            }

            foreach(PlatoCarrito platoCarrito in listaPlatoCarrito)
            {
                db.PlatoCarritoes.Remove(platoCarrito);
            }
            db.SaveChanges();

            return Ok(listaPlatoCarrito);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlatoCarritoExists(int id)
        {
            return db.PlatoCarritoes.Count(e => e.Id == id) > 0;
        }
    }
}