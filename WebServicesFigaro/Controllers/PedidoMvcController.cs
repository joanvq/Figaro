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
    public class PedidoMvcController : Controller
    {
        private DBContext db = new DBContext();

        // GET: PedidoMvc
        public ActionResult Index()
        {
            var pedidoes = db.Pedidoes.Include(p => p.Usuario).Include(p => p.Zona);
            return View(pedidoes.ToList());
        }

        // GET: PedidoMvc/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedidoes
                .Include(p => p.Usuario)
                .Include(p => p.Zona)
                .SingleOrDefault(p => p.Id == id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // GET: PedidoMvc/Create
        public ActionResult Create()
        {
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "Nombre");
            ViewBag.ZonaId = new SelectList(db.Zonas, "Id", "Titulo");
            return View();
        }

        // POST: PedidoMvc/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NPedido,Direccion,Estado,UsuarioId,ZonaId")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                db.Pedidoes.Add(pedido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "Nombre", pedido.UsuarioId);
            ViewBag.ZonaId = new SelectList(db.Zonas, "Id", "Titulo", pedido.ZonaId);
            return View(pedido);
        }

        // GET: PedidoMvc/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedidoes.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "Nombre", pedido.UsuarioId);
            ViewBag.ZonaId = new SelectList(db.Zonas, "Id", "Titulo", pedido.ZonaId);
            return View(pedido);
        }

        // POST: PedidoMvc/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NPedido,Direccion,Estado,UsuarioId,ZonaId")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "Nombre", pedido.UsuarioId);
            ViewBag.ZonaId = new SelectList(db.Zonas, "Id", "Titulo", pedido.ZonaId);
            return View(pedido);
        }

        // GET: PedidoMvc/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedidoes.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // POST: PedidoMvc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pedido pedido = db.Pedidoes.Find(id);
            db.Pedidoes.Remove(pedido);
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
