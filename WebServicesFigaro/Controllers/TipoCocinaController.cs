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
    public class TipoCocinaController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/TipoCocina
        public IQueryable<TipoCocina> GetTipoCocinas()
        {
            return db.TipoCocinas;
        }

        // GET: api/TipoCocina/5
        [ResponseType(typeof(TipoCocina))]
        public IHttpActionResult GetTipoCocina(int id)
        {
            TipoCocina tipoCocina = db.TipoCocinas.Find(id);
            if (tipoCocina == null)
            {
                return NotFound();
            }

            return Ok(tipoCocina);
        }

        // PUT: api/TipoCocina/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTipoCocina(int id, TipoCocina tipoCocina)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoCocina.Id)
            {
                return BadRequest();
            }

            db.Entry(tipoCocina).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoCocinaExists(id))
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

        // POST: api/TipoCocina
        [ResponseType(typeof(TipoCocina))]
        public IHttpActionResult PostTipoCocina(TipoCocina tipoCocina)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TipoCocinas.Add(tipoCocina);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tipoCocina.Id }, tipoCocina);
        }

        // DELETE: api/TipoCocina/5
        [ResponseType(typeof(TipoCocina))]
        public IHttpActionResult DeleteTipoCocina(int id)
        {
            TipoCocina tipoCocina = db.TipoCocinas.Find(id);
            if (tipoCocina == null)
            {
                return NotFound();
            }

            db.TipoCocinas.Remove(tipoCocina);
            db.SaveChanges();

            return Ok(tipoCocina);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipoCocinaExists(int id)
        {
            return db.TipoCocinas.Count(e => e.Id == id) > 0;
        }
    }
}