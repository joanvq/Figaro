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

namespace WebServicesFigaro.Cntrollers
{
    public class ZonaController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/Zona
        public IQueryable<Zona> GetZonas()
        {
            return db.Zonas;
        }

        // GET: api/Zona/5
        [ResponseType(typeof(Zona))]
        public IHttpActionResult GetZona(int id)
        {
            Zona zona = db.Zonas.Find(id);
            if (zona == null)
            {
                return NotFound();
            }

            return Ok(zona);
        }

        // PUT: api/Zona/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutZona(int id, Zona zona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != zona.Id)
            {
                return BadRequest();
            }

            db.Entry(zona).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZonaExists(id))
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

        // POST: api/Zona
        [ResponseType(typeof(Zona))]
        public IHttpActionResult PostZona(Zona zona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Zonas.Add(zona);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = zona.Id }, zona);
        }

        // DELETE: api/Zona/5
        [ResponseType(typeof(Zona))]
        public IHttpActionResult DeleteZona(int id)
        {
            Zona zona = db.Zonas.Find(id);
            if (zona == null)
            {
                return NotFound();
            }

            db.Zonas.Remove(zona);
            db.SaveChanges();

            return Ok(zona);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ZonaExists(int id)
        {
            return db.Zonas.Count(e => e.Id == id) > 0;
        }
    }
}