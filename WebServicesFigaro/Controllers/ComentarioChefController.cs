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
    public class ComentarioChefController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/ComentarioChef
        public IQueryable<ComentarioChef> GetComentarioChefs()
        {
            return db.ComentarioChefs
                .Include(c => c.Chef);
        }

        // GET: api/ComentariosChef/{idChef}
        [ResponseType(typeof(ComentarioChef))]
        [Route("api/ComentariosChef/{id}")]
        public IQueryable<ComentarioChef> GetComentariosChef(int id)
        {
           return db.ComentarioChefs.Where(c => c.ChefId == id)
                .Include(c => c.Chef);
        }

        // GET: api/ComentarioChef/5
        [ResponseType(typeof(ComentarioChef))]
        public IHttpActionResult GetComentarioChef(int id)
        {
            ComentarioChef comentarioChef = db.ComentarioChefs
                .Include(c => c.Chef)
                .SingleOrDefault(c => c.Id == id);
            if (comentarioChef == null)
            {
                return NotFound();
            }

            return Ok(comentarioChef);
        }

        // PUT: api/ComentarioChef/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutComentarioChef(int id, ComentarioChef comentarioChef)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != comentarioChef.Id)
            {
                return BadRequest();
            }

            db.Entry(comentarioChef).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComentarioChefExists(id))
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

        // POST: api/ComentarioChef
        [ResponseType(typeof(ComentarioChef))]
        public IHttpActionResult PostComentarioChef(ComentarioChef comentarioChef)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ComentarioChefs.Add(comentarioChef);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = comentarioChef.Id }, comentarioChef);
        }

        // DELETE: api/ComentarioChef/5
        [ResponseType(typeof(ComentarioChef))]
        public IHttpActionResult DeleteComentarioChef(int id)
        {
            ComentarioChef comentarioChef = db.ComentarioChefs.Find(id);
            if (comentarioChef == null)
            {
                return NotFound();
            }

            db.ComentarioChefs.Remove(comentarioChef);
            db.SaveChanges();

            return Ok(comentarioChef);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ComentarioChefExists(int id)
        {
            return db.ComentarioChefs.Count(e => e.Id == id) > 0;
        }
    }
}