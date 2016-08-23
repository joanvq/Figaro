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
    public class TipoCocinaMvcController : Controller
    {
        private TipoCocinaContext db = new TipoCocinaContext();

        // GET: TipoCocinaMvc
        public ActionResult Index()
        {
            return View(db.TipoCocina.ToList());
        }

        // GET: TipoCocinaMvc/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoCocina tipoCocina = db.TipoCocina.Find(id);
            if (tipoCocina == null)
            {
                return HttpNotFound();
            }
            return View(tipoCocina);
        }

        // GET: TipoCocinaMvc/Create
        public ActionResult Create()
        {
            //ViewBag.TipoCocina = db.TipoCocina;
            return View();
        }

        // POST: TipoCocinaMvc/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Titulo")] TipoCocina tipoCocina)
        {
            if (ModelState.IsValid)
            {
                db.TipoCocina.Add(tipoCocina);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoCocina);
        }

        // GET: TipoCocinaMvc/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoCocina tipoCocina = db.TipoCocina.Find(id);
            if (tipoCocina == null)
            {
                return HttpNotFound();
            }
            return View(tipoCocina);
        }

        // POST: TipoCocinaMvc/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Titulo")] TipoCocina tipoCocina)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoCocina).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoCocina);
        }

        // GET: TipoCocinaMvc/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoCocina tipoCocina = db.TipoCocina.Find(id);
            if (tipoCocina == null)
            {
                return HttpNotFound();
            }
            return View(tipoCocina);
        }

        // POST: TipoCocinaMvc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoCocina tipoCocina = db.TipoCocina.Find(id);
            db.TipoCocina.Remove(tipoCocina);
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
