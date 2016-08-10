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
    public class PlatosController : ApiController
    {
        private PlatosContext db = new PlatosContext();

        // GET: api/Platos
        public IQueryable<Plato> GetPlatoes()
        {
            return db.Platoes;
        }

        // GET: api/Platos/5
        [ResponseType(typeof(Plato))]
        public IHttpActionResult GetPlato(int id)
        {
            Plato plato = db.Platoes.Find(id);
            if (plato == null)
            {
                return NotFound();
            }

            return Ok(plato);
        }

        // PUT: api/Platos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPlato(int id, Plato plato)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != plato.Id)
            {
                return BadRequest();
            }

            db.Entry(plato).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlatoExists(id))
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

        // POST: api/Platos
        [ResponseType(typeof(Plato))]
        public IHttpActionResult PostPlato(Plato plato)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Platoes.Add(plato);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = plato.Id }, plato);
        }

        // DELETE: api/Platos/5
        [ResponseType(typeof(Plato))]
        public IHttpActionResult DeletePlato(int id)
        {
            Plato plato = db.Platoes.Find(id);
            if (plato == null)
            {
                return NotFound();
            }

            db.Platoes.Remove(plato);
            db.SaveChanges();

            return Ok(plato);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlatoExists(int id)
        {
            return db.Platoes.Count(e => e.Id == id) > 0;
        }
    }
}