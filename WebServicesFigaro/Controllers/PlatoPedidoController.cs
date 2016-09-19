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
    public class PlatoPedidoController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/PlatoPedido
        public IQueryable<PlatoPedido> GetPlatoPedidoes()
        {
            return db.PlatoPedidoes;
        }

        // GET: api/PlatoPedido/5
        [ResponseType(typeof(PlatoPedido))]
        public IHttpActionResult GetPlatoPedido(int id)
        {
            PlatoPedido platoPedido = db.PlatoPedidoes.Find(id);
            if (platoPedido == null)
            {
                return NotFound();
            }

            return Ok(platoPedido);
        }

        // GET: api/PlatoPedido/Pedido/{idPedido}
        [ResponseType(typeof(MenuPedido))]
        [Route("api/PlatoPedido/Pedido/{id}")]
        public IQueryable<PlatoPedido> GetPlatoPedidosByPedido(int id)
        {
            return db.PlatoPedidoes.Where(p => p.PedidoId == id);
        }

        // PUT: api/PlatoPedido/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPlatoPedido(int id, PlatoPedido platoPedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != platoPedido.Id)
            {
                return BadRequest();
            }

            db.Entry(platoPedido).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlatoPedidoExists(id))
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

        // POST: api/PlatoPedido
        [ResponseType(typeof(PlatoPedido))]
        public IHttpActionResult PostPlatoPedido(PlatoPedido platoPedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PlatoPedidoes.Add(platoPedido);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = platoPedido.Id }, platoPedido);
        }

        // DELETE: api/PlatoPedido/5
        [ResponseType(typeof(PlatoPedido))]
        public IHttpActionResult DeletePlatoPedido(int id)
        {
            PlatoPedido platoPedido = db.PlatoPedidoes.Find(id);
            if (platoPedido == null)
            {
                return NotFound();
            }

            db.PlatoPedidoes.Remove(platoPedido);
            db.SaveChanges();

            return Ok(platoPedido);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlatoPedidoExists(int id)
        {
            return db.PlatoPedidoes.Count(e => e.Id == id) > 0;
        }
    }
}