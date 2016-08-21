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
    public class PlatoController : ApiController
    {
        private PlatoContext db = new PlatoContext();

        // GET: api/Plato
        public IQueryable<Plato> GetPlatoes()
        {
            return db.Platoes;
        }

        // GET: api/Plato/5
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

        // GET: api/Plato/Search/titulo
        [Route("api/Plato/Search/{keyword}")]
        [ResponseType(typeof(List<Plato>))]
        public IHttpActionResult GetPlatos(string keyword)
        {
            List<Plato> plato = db.Platoes.Where(p => p.Titulo.Contains(keyword)).ToList();
            if (plato == null)
            {
                return NotFound();
            }

            return Ok(plato);
        }

        // PUT: api/Plato/5
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

        // POST: api/Plato
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

        // DELETE: api/Plato/5
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