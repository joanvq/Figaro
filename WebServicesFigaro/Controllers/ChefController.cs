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
    public class ChefController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/Chef
        public IQueryable<Chef> GetChefs()
        {
            return db.Chefs
                .Include(p => p.TipoCocina)
                .Include(p => p.Zona);

        }

        // GET: api/Chef/5
        [ResponseType(typeof(Chef))]
        public IHttpActionResult GetChef(int id)
        {
            Chef chef = db.Chefs
                .Include(p => p.TipoCocina)
                .Include(p => p.Zona)
                .SingleOrDefault(p => p.Id == id);
            if (chef == null)
            {
                return NotFound();
            }

            return Ok(chef);
        }

        // PUT: api/Chef/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutChef(int id, Chef chef)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != chef.Id)
            {
                return BadRequest();
            }

            db.Entry(chef).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChefExists(id))
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

        // POST: api/Chef
        [ResponseType(typeof(Chef))]
        public IHttpActionResult PostChef(Chef chef)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Chefs.Add(chef);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = chef.Id }, chef);
        }

        // DELETE: api/Chef/5
        [ResponseType(typeof(Chef))]
        public IHttpActionResult DeleteChef(int id)
        {
            Chef chef = db.Chefs.Find(id);
            if (chef == null)
            {
                return NotFound();
            }

            db.Chefs.Remove(chef);
            db.SaveChanges();

            return Ok(chef);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ChefExists(int id)
        {
            return db.Chefs.Count(e => e.Id == id) > 0;
        }
    }
}