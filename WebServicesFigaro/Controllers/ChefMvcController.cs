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
    public class ChefMvcController : Controller
    {
        private DBContext db = new DBContext();

        // GET: ChefMvc
        public ActionResult Index()
        {
            var chefs = db.Chefs.Include(c => c.TipoCocina).Include(c => c.Zona);
            return View(chefs.ToList());
        }

        // GET: ChefMvc/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chef chef = db.Chefs.Find(id);
            if (chef == null)
            {
                return HttpNotFound();
            }
            return View(chef);
        }

        // GET: ChefMvc/Create
        public ActionResult Create()
        {
            ViewBag.TipoCocinaId = new SelectList(db.TipoCocinas, "Id", "Titulo");
            ViewBag.ZonaId = new SelectList(db.Zonas, "Id", "Titulo");
            return View();
        }

        // POST: ChefMvc/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Apellidos,Imagen,ImagenFondo,Subtitulo,ZonaId,TipoCocinaId,Valoracion,Descripcion,FechaNacimiento,Genero")] Chef chef)
        {
            if (ModelState.IsValid)
            {
                db.Chefs.Add(chef);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TipoCocinaId = new SelectList(db.TipoCocinas, "Id", "Titulo", chef.TipoCocinaId);
            ViewBag.ZonaId = new SelectList(db.Zonas, "Id", "Titulo", chef.ZonaId);
            return View(chef);
        }

        // GET: ChefMvc/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chef chef = db.Chefs.Find(id);
            if (chef == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoCocinaId = new SelectList(db.TipoCocinas, "Id", "Titulo", chef.TipoCocinaId);
            ViewBag.ZonaId = new SelectList(db.Zonas, "Id", "Titulo", chef.ZonaId);
            return View(chef);
        }

        // POST: ChefMvc/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Apellidos,Imagen,ImagenFondo,Subtitulo,ZonaId,TipoCocinaId,Valoracion,Descripcion,FechaNacimiento,Genero")] Chef chef)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chef).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TipoCocinaId = new SelectList(db.TipoCocinas, "Id", "Titulo", chef.TipoCocinaId);
            ViewBag.ZonaId = new SelectList(db.Zonas, "Id", "Titulo", chef.ZonaId);
            return View(chef);
        }

        // GET: ChefMvc/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chef chef = db.Chefs.Find(id);
            if (chef == null)
            {
                return HttpNotFound();
            }
            return View(chef);
        }

        // POST: ChefMvc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Chef chef = db.Chefs.Find(id);
            db.Chefs.Remove(chef);
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
