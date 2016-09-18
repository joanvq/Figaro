using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebServicesFigaro.Models;

namespace WebServicesFigaro.Controllers
{
    public class PlatoPedidoMvcController : Controller
    {
        private DBContext db = new DBContext();

        // GET: PlatoPedidoMvc
        public ActionResult Index()
        {
            var platoPedidoes = db.PlatoPedidoes.Include(p => p.Pedido);
            return View(platoPedidoes.ToList());
        }

        // GET: PlatoPedidoMvc/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlatoPedido platoPedido = db.PlatoPedidoes.Find(id);
            if (platoPedido == null)
            {
                return HttpNotFound();
            }
            return View(platoPedido);
        }

        // GET: PlatoPedidoMvc/Create
        public ActionResult Create()
        {
            ViewBag.PedidoId = new SelectList(db.Pedidoes, "Id", "NPedido");
            return View();
        }

        // POST: PlatoPedidoMvc/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PedidoId,TituloPlato,PrecioPlato,TiempoCocinado,Ingredientes,Utensilios")] PlatoPedido platoPedido)
        {
            if (ModelState.IsValid)
            {
                db.PlatoPedidoes.Add(platoPedido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PedidoId = new SelectList(db.Pedidoes, "Id", "NPedido", platoPedido.PedidoId);
            return View(platoPedido);
        }

        // GET: PlatoPedidoMvc/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlatoPedido platoPedido = db.PlatoPedidoes.Find(id);
            if (platoPedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.PedidoId = new SelectList(db.Pedidoes, "Id", "NPedido", platoPedido.PedidoId);
            return View(platoPedido);
        }

        // POST: PlatoPedidoMvc/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PedidoId,TituloPlato,PrecioPlato,TiempoCocinado,Ingredientes,Utensilios")] PlatoPedido platoPedido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(platoPedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PedidoId = new SelectList(db.Pedidoes, "Id", "NPedido", platoPedido.PedidoId);
            return View(platoPedido);
        }

        // GET: PlatoPedidoMvc/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlatoPedido platoPedido = db.PlatoPedidoes.Find(id);
            if (platoPedido == null)
            {
                return HttpNotFound();
            }
            return View(platoPedido);
        }

        // POST: PlatoPedidoMvc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlatoPedido platoPedido = db.PlatoPedidoes.Find(id);
            db.PlatoPedidoes.Remove(platoPedido);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
