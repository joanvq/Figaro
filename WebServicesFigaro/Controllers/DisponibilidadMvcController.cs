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
    public class DisponibilidadMvcController : Controller
    {
        private DBContext db = new DBContext();

        // GET: DisponibilidadMvc
        public ActionResult Index()
        {
            var disponibilidads = db.Disponibilidads.Include(d => d.Chef);
            return View(disponibilidads.ToList());
        }

        // GET: DisponibilidadMvc/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disponibilidad disponibilidad = db.Disponibilidads.Find(id);
            if (disponibilidad == null)
            {
                return HttpNotFound();
            }
            return View(disponibilidad);
        }

        // GET: DisponibilidadMvc/Create
        public ActionResult Create()
        {
            ViewBag.ChefId = new SelectList(db.Chefs, "Id", "Nombre");
            return View();
        }

        // POST: DisponibilidadMvc/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Fecha,EstaDisponible,ChefId")] Disponibilidad disponibilidad)
        {
            if (ModelState.IsValid)
            {
                db.Disponibilidads.Add(disponibilidad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ChefId = new SelectList(db.Chefs, "Id", "Nombre", disponibilidad.ChefId);
            return View(disponibilidad);
        }

        // GET: DisponibilidadMvc/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disponibilidad disponibilidad = db.Disponibilidads.Find(id);
            if (disponibilidad == null)
            {
                return HttpNotFound();
            }
            ViewBag.ChefId = new SelectList(db.Chefs, "Id", "Nombre", disponibilidad.ChefId);
            return View(disponibilidad);
        }

        // POST: DisponibilidadMvc/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Fecha,EstaDisponible,ChefId")] Disponibilidad disponibilidad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(disponibilidad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ChefId = new SelectList(db.Chefs, "Id", "Nombre", disponibilidad.ChefId);
            return View(disponibilidad);
        }

        // GET: DisponibilidadMvc/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disponibilidad disponibilidad = db.Disponibilidads.Find(id);
            if (disponibilidad == null)
            {
                return HttpNotFound();
            }
            return View(disponibilidad);
        }

        // POST: DisponibilidadMvc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Disponibilidad disponibilidad = db.Disponibilidads.Find(id);
            db.Disponibilidads.Remove(disponibilidad);
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
