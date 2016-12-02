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
    public class MenuController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/Menu
        public IQueryable<Menu> GetMenus()
        {
            return db.Menus
                .Include(p => p.TipoCocina)
                .Include(p => p.Entrante)
                .Include(p => p.Primero)
                .Include(p => p.Segundo)
                .Include(p => p.Guarnicion)
                .Include(p => p.Postre)
                .Include(p => p.Entrante.TipoCocina)
                .Include(p => p.Primero.TipoCocina)
                .Include(p => p.Segundo.TipoCocina)
                .Include(p => p.Guarnicion.TipoCocina)
                .Include(p => p.Postre.TipoCocina)
                .Where(p => p.EstaOculto != true);
        }

        // GET: api/Menu/5
        [ResponseType(typeof(Menu))]
        public IHttpActionResult GetMenu(int id)
        {
            Menu menu = db.Menus
                .Include(p => p.Entrante)
                .Include(p => p.Primero)
                .Include(p => p.Segundo)
                .Include(p => p.Guarnicion)
                .Include(p => p.Postre)
                .Include(p => p.Entrante.TipoCocina)
                .Include(p => p.Primero.TipoCocina)
                .Include(p => p.Segundo.TipoCocina)
                .Include(p => p.Guarnicion.TipoCocina)
                .Include(p => p.Postre.TipoCocina)
                .SingleOrDefault(p => p.Id == id);
            if (menu == null || menu.EstaOculto)
            {
                return NotFound();
            }

            return Ok(menu);
        }

        // PUT: api/Menu/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMenu(int id, Menu menu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != menu.Id)
            {
                return BadRequest();
            }

            db.Entry(menu).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuExists(id))
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

        // POST: api/Menu
        [ResponseType(typeof(Menu))]
        public IHttpActionResult PostMenu(Menu menu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Menus.Add(menu);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = menu.Id }, menu);
        }

        // DELETE: api/Menu/5
        [ResponseType(typeof(Menu))]
        public IHttpActionResult DeleteMenu(int id)
        {
            Menu menu = db.Menus.Find(id);
            if (menu == null)
            {
                return NotFound();
            }

            db.Menus.Remove(menu);
            db.SaveChanges();

            return Ok(menu);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MenuExists(int id)
        {
            return db.Menus.Count(e => e.Id == id) > 0;
        }
    }
}