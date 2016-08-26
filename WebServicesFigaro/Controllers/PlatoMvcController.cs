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
    public class PlatoMvcController : Controller
    {
        private DBContext db = new DBContext();

        // GET: PlatoMvc
        public ActionResult Index()
        {
            var platoes = db.Platoes.Include(p => p.TipoCocina);
            return View(platoes.ToList());
        }

        // GET: PlatoMvc/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plato plato = db.Platoes.Find(id);
            if (plato == null)
            {
                return HttpNotFound();
            }
            return View(plato);
        }

        // GET: PlatoMvc/Create
        public ActionResult Create()
        {
            ViewBag.TipoCocinaId = new SelectList(db.TipoCocinas, "Id", "Titulo");
            return View();
        }

        // POST: PlatoMvc/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Titulo,Descripcion,Imagen,TiempoCocinado,TipoPlato,Precio,Valoracion,TipoCocinaId,Categoria,Ingredientes,Utensilios")] Plato plato)
        {
            if (ModelState.IsValid)
            {
                db.Platoes.Add(plato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TipoCocinaId = new SelectList(db.TipoCocinas, "Id", "Titulo", plato.TipoCocinaId);
            return View(plato);
        }

        // GET: PlatoMvc/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plato plato = db.Platoes.Find(id);
            if (plato == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoCocinaId = new SelectList(db.TipoCocinas, "Id", "Titulo", plato.TipoCocinaId);
            return View(plato);
        }

        // POST: PlatoMvc/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Titulo,Descripcion,Imagen,TiempoCocinado,TipoPlato,Precio,Valoracion,TipoCocinaId,Categoria,Ingredientes,Utensilios")] Plato plato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TipoCocinaId = new SelectList(db.TipoCocinas, "Id", "Titulo", plato.TipoCocinaId);
            return View(plato);
        }

        // GET: PlatoMvc/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plato plato = db.Platoes.Find(id);
            if (plato == null)
            {
                return HttpNotFound();
            }
            return View(plato);
        }

        // POST: PlatoMvc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Plato plato = db.Platoes.Find(id);
            db.Platoes.Remove(plato);
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
