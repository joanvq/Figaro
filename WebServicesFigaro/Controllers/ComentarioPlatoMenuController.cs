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
    public class ComentarioPlatoMenuController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/ComentarioPlatoMenu
        public IQueryable<ComentarioPlatoMenu> GetComentarioPlatoMenus()
        {
            return db.ComentarioPlatoMenus
                 .Include(c => c.Menu)
                 .Include(c => c.Plato);
        }

        // GET: api/ComentarioPlatoMenu/Plato/{idPlato}
        [ResponseType(typeof(ComentarioPlatoMenu))]
        [Route("api/ComentarioPlatoMenu/Plato/{id}")]
        public IQueryable<ComentarioPlatoMenu> GetComentarioPlatos(int id)
        {
            return db.ComentarioPlatoMenus.Where(c => c.PlatoId == id)
                 .Include(c => c.Menu)
                 .Include(c => c.Plato);
        }

        // GET: api/ComentarioPlatoMenu/Menu/{idMenu}
        [ResponseType(typeof(ComentarioPlatoMenu))]
        [Route("api/ComentarioPlatoMenu/Menu/{id}")]
        public IQueryable<ComentarioPlatoMenu> GetComentarioMenus(int id)
        {
            return db.ComentarioPlatoMenus.Where(c => c.MenuId == id)
                 .Include(c => c.Menu)
                 .Include(c => c.Plato);
        }

        // GET: api/ComentarioPlatoMenu/5
        [ResponseType(typeof(ComentarioPlatoMenu))]
        public IHttpActionResult GetComentarioPlatoMenu(int id)
        {
            ComentarioPlatoMenu comentarioPlatoMenu = db.ComentarioPlatoMenus.Find(id);
            if (comentarioPlatoMenu == null)
            {
                return NotFound();
            }

            return Ok(comentarioPlatoMenu);
        }

        // PUT: api/ComentarioPlatoMenu/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutComentarioPlatoMenu(int id, ComentarioPlatoMenu comentarioPlatoMenu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != comentarioPlatoMenu.Id)
            {
                return BadRequest();
            }

            db.Entry(comentarioPlatoMenu).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComentarioPlatoMenuExists(id))
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

        // POST: api/ComentarioPlatoMenu
        [ResponseType(typeof(ComentarioPlatoMenu))]
        public IHttpActionResult PostComentarioPlatoMenu(ComentarioPlatoMenu comentarioPlatoMenu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ComentarioPlatoMenus.Add(comentarioPlatoMenu);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = comentarioPlatoMenu.Id }, comentarioPlatoMenu);
        }

        // DELETE: api/ComentarioPlatoMenu/5
        [ResponseType(typeof(ComentarioPlatoMenu))]
        public IHttpActionResult DeleteComentarioPlatoMenu(int id)
        {
            ComentarioPlatoMenu comentarioPlatoMenu = db.ComentarioPlatoMenus.Find(id);
            if (comentarioPlatoMenu == null)
            {
                return NotFound();
            }

            db.ComentarioPlatoMenus.Remove(comentarioPlatoMenu);
            db.SaveChanges();

            return Ok(comentarioPlatoMenu);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ComentarioPlatoMenuExists(int id)
        {
            return db.ComentarioPlatoMenus.Count(e => e.Id == id) > 0;
        }
    }
}