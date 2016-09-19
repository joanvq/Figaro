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
    public class MenuPedidoMvcController : Controller
    {
        private DBContext db = new DBContext();

        // GET: MenuPedidoMvc
        public ActionResult Index()
        {
            var menuPedidoes = db.MenuPedidoes.Include(m => m.Pedido);
            return View(menuPedidoes.ToList());
        }

        // GET: MenuPedidoMvc/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuPedido menuPedido = db.MenuPedidoes.Find(id);
            if (menuPedido == null)
            {
                return HttpNotFound();
            }
            return View(menuPedido);
        }

        // GET: MenuPedidoMvc/Create
        public ActionResult Create()
        {
            ViewBag.PedidoId = new SelectList(db.Pedidoes, "Id", "NPedido");
            return View();
        }

        // POST: MenuPedidoMvc/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PedidoId,TituloMenu,PrecioMenu,Entrante,Primero,Segundo,Guarnicion,Postre,TiempoCocinado,Ingredientes,Utensilios,Cantidad")] MenuPedido menuPedido)
        {
            if (ModelState.IsValid)
            {
                db.MenuPedidoes.Add(menuPedido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PedidoId = new SelectList(db.Pedidoes, "Id", "NPedido", menuPedido.PedidoId);
            return View(menuPedido);
        }

        // GET: MenuPedidoMvc/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuPedido menuPedido = db.MenuPedidoes.Find(id);
            if (menuPedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.PedidoId = new SelectList(db.Pedidoes, "Id", "NPedido", menuPedido.PedidoId);
            return View(menuPedido);
        }

        // POST: MenuPedidoMvc/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PedidoId,TituloMenu,PrecioMenu,Entrante,Primero,Segundo,Guarnicion,Postre,TiempoCocinado,Ingredientes,Utensilios,Cantidad")] MenuPedido menuPedido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(menuPedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PedidoId = new SelectList(db.Pedidoes, "Id", "NPedido", menuPedido.PedidoId);
            return View(menuPedido);
        }

        // GET: MenuPedidoMvc/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuPedido menuPedido = db.MenuPedidoes.Find(id);
            if (menuPedido == null)
            {
                return HttpNotFound();
            }
            return View(menuPedido);
        }

        // POST: MenuPedidoMvc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MenuPedido menuPedido = db.MenuPedidoes.Find(id);
            db.MenuPedidoes.Remove(menuPedido);
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
