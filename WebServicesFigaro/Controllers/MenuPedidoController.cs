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
    public class MenuPedidoController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/MenuPedido
        public IQueryable<MenuPedido> GetMenuPedidoes()
        {
            return db.MenuPedidoes;
        }

        // GET: api/MenuPedido/5
        [ResponseType(typeof(MenuPedido))]
        public IHttpActionResult GetMenuPedido(int id)
        {
            MenuPedido menuPedido = db.MenuPedidoes.Find(id);
            if (menuPedido == null)
            {
                return NotFound();
            }

            return Ok(menuPedido);
        }

        // PUT: api/MenuPedido/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMenuPedido(int id, MenuPedido menuPedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != menuPedido.Id)
            {
                return BadRequest();
            }

            db.Entry(menuPedido).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuPedidoExists(id))
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

        // POST: api/MenuPedido
        [ResponseType(typeof(MenuPedido))]
        public IHttpActionResult PostMenuPedido(MenuPedido menuPedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MenuPedidoes.Add(menuPedido);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = menuPedido.Id }, menuPedido);
        }

        // DELETE: api/MenuPedido/5
        [ResponseType(typeof(MenuPedido))]
        public IHttpActionResult DeleteMenuPedido(int id)
        {
            MenuPedido menuPedido = db.MenuPedidoes.Find(id);
            if (menuPedido == null)
            {
                return NotFound();
            }

            db.MenuPedidoes.Remove(menuPedido);
            db.SaveChanges();

            return Ok(menuPedido);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MenuPedidoExists(int id)
        {
            return db.MenuPedidoes.Count(e => e.Id == id) > 0;
        }
    }
}