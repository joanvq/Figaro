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
    public class PlatoCarritoMvcController : Controller
    {
        private DBContext db = new DBContext();

        // GET: PlatoCarritoMvc
        public ActionResult Index()
        {
            var platoCarritoes = db.PlatoCarritoes.Include(p => p.Plato).Include(p => p.Usuario);
            return View(platoCarritoes.ToList());
        }

        // GET: PlatoCarritoMvc/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlatoCarrito platoCarrito = db.PlatoCarritoes.Include(p => p.Plato).Include(p => p.Usuario)
                .FirstOrDefault(p => p.Id == id);
            if (platoCarrito == null)
            {
                return HttpNotFound();
            }
            return View(platoCarrito);
        }

        // GET: PlatoCarritoMvc/Create
        public ActionResult Create()
        {
            ViewBag.PlatoId = new SelectList(db.Platoes, "Id", "Titulo");
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "Nombre");
            return View();
        }

        // POST: PlatoCarritoMvc/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UsuarioId,PlatoId,Cantidad")] PlatoCarrito platoCarrito)
        {
            if (ModelState.IsValid)
            {
                db.PlatoCarritoes.Add(platoCarrito);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PlatoId = new SelectList(db.Platoes, "Id", "Titulo", platoCarrito.PlatoId);
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "Nombre", platoCarrito.UsuarioId);
            return View(platoCarrito);
        }

        // GET: PlatoCarritoMvc/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlatoCarrito platoCarrito = db.PlatoCarritoes.Find(id);
            if (platoCarrito == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlatoId = new SelectList(db.Platoes, "Id", "Titulo", platoCarrito.PlatoId);
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "Nombre", platoCarrito.UsuarioId);
            return View(platoCarrito);
        }

        // POST: PlatoCarritoMvc/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UsuarioId,PlatoId,Cantidad")] PlatoCarrito platoCarrito)
        {
            if (ModelState.IsValid)
            {
                db.Entry(platoCarrito).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlatoId = new SelectList(db.Platoes, "Id", "Titulo", platoCarrito.PlatoId);
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "Nombre", platoCarrito.UsuarioId);
            return View(platoCarrito);
        }

        // GET: PlatoCarritoMvc/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlatoCarrito platoCarrito = db.PlatoCarritoes.Find(id);
            if (platoCarrito == null)
            {
                return HttpNotFound();
            }
            return View(platoCarrito);
        }

        // POST: PlatoCarritoMvc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlatoCarrito platoCarrito = db.PlatoCarritoes.Include(p => p.Plato).Include(p => p.Usuario)
                .FirstOrDefault(p => p.Id == id);
            db.PlatoCarritoes.Remove(platoCarrito);
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
