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
    public class ComentarioChefMvcController : Controller
    {
        private DBContext db = new DBContext();

        //NO FUNCIONA
        // GET: ComentarioChefMvc
        public ActionResult Index()
        {
            var comentarioChefs = db.ComentarioChefs
                .Include(c => c.Chef)
                .Include(c => c.Usuario);
            return View(comentarioChefs.ToList());
        }

        // GET: ComentarioChefMvc/{idChef}
        //[Route("ComentarioChefMvc/IndexChef/{id}")]
        public ActionResult IndexChef(int id)
        {
            var comentarioChefs = db.ComentarioChefs.Where(c => c.ChefId == id)
                .Include(c => c.Chef)
                .Include(c => c.Usuario);

            ComentarioChef idChef = new ComentarioChef();
            idChef.ChefId = id;
            idChef.Id = 0;
            // Se añade elemento adicional para que cuando no haya 
            // ningun comentario se pueda activar el boton de atras
            var listaComentarios = comentarioChefs.ToList();
            listaComentarios.Add(idChef);

            return View("Index", listaComentarios);
        }

        // GET: ComentarioChefMvc/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComentarioChef comentarioChef = db.ComentarioChefs
                .Include(c => c.Chef)
                .Include(c => c.Usuario)
                .SingleOrDefault(c => c.Id==id);
            if (comentarioChef == null)
            {
                return HttpNotFound();
            }
            return View(comentarioChef);
        }

        // GET: ComentarioChefMvc/Create/5
        public ActionResult Create(int idChef)
        {
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "Nombre");
            ViewBag.ChefId = new SelectList(db.Chefs, "Id", "Nombre");
            ComentarioChef comentario = new ComentarioChef();
            comentario.ChefId = idChef;
            comentario.Chef = db.Chefs.Find(idChef);
            return View(comentario);
        }

        // POST: ComentarioChefMvc/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripcion,Valoracion,ChefId,UsuarioId")] ComentarioChef comentarioChef)
        {
            if (ModelState.IsValid)
            {
                db.ComentarioChefs.Add(comentarioChef);
                db.SaveChanges();
                return RedirectToAction("IndexChef", new { id = comentarioChef.ChefId });
            }

            ViewBag.ChefId = new SelectList(db.Chefs, "Id", "Nombre", comentarioChef.ChefId);
            return View(comentarioChef);
        }

        // GET: ComentarioChefMvc/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComentarioChef comentarioChef = db.ComentarioChefs.Find(id);
            if (comentarioChef == null)
            {
                return HttpNotFound();
            }
            ViewBag.ChefId = new SelectList(db.Chefs, "Id", "Nombre", comentarioChef.ChefId);
            return View(comentarioChef);
        }

        // POST: ComentarioChefMvc/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripcion,Valoracion,ChefId,UsuarioId")] ComentarioChef comentarioChef)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comentarioChef).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("IndexChef", new { id = comentarioChef.ChefId });
            }
            ViewBag.ChefId = new SelectList(db.Chefs, "Id", "Nombre", comentarioChef.ChefId);
            return View(comentarioChef);
        }

        // GET: ComentarioChefMvc/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComentarioChef comentarioChef = db.ComentarioChefs.Find(id);
            if (comentarioChef == null)
            {
                return HttpNotFound();
            }
            return View(comentarioChef);
        }

        // POST: ComentarioChefMvc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ComentarioChef comentarioChef = db.ComentarioChefs.Find(id);
            db.ComentarioChefs.Remove(comentarioChef);
            db.SaveChanges();
            return RedirectToAction("IndexChef", new { id = comentarioChef.ChefId });
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
