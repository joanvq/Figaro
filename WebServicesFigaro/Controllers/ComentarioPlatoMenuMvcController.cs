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
    public class ComentarioPlatoMenuMvcController : Controller
    {
        private DBContext db = new DBContext();

        // GET: ComentarioPlatoMenuMvc
        public ActionResult Index()
        {
            var comentarioPlatoMenus = db.ComentarioPlatoMenus.Include(c => c.Menu).Include(c => c.Plato);
            return View(comentarioPlatoMenus.ToList());
        }

        // GET: ComentarioPlatoMenuMvc/Plato/{idPlato}
        public ActionResult IndexPlato(int id)
        {
            var comentarioPlatoMenu = db.ComentarioPlatoMenus.Where(c => c.PlatoId == id)
                .Include(c => c.Plato)
                .Include(c => c.Menu);

            ComentarioPlatoMenu idPlato = new ComentarioPlatoMenu();
            idPlato.PlatoId = id;
            idPlato.Id = 0;
            // Se añade elemento adicional para que cuando no haya 
            // ningun comentario se pueda activar el boton de atras
            var listaComentarios = comentarioPlatoMenu.ToList();
            listaComentarios.Add(idPlato);

            return View("Index", listaComentarios);
        }

        // GET: ComentarioPlatoMenuMvc/Menu/{idMenu}
        public ActionResult IndexMenu(int id)
        {
            var comentarioPlatoMenu = db.ComentarioPlatoMenus.Where(c => c.MenuId == id)
                .Include(c => c.Plato)
                .Include(c => c.Menu);

            ComentarioPlatoMenu idMenu = new ComentarioPlatoMenu();
            idMenu.PlatoId = id;
            idMenu.Id = 0;
            // Se añade elemento adicional para que cuando no haya 
            // ningun comentario se pueda activar el boton de atras
            var listaComentarios = comentarioPlatoMenu.ToList();
            listaComentarios.Add(idMenu);

            return View("Index", listaComentarios);
        }

        // GET: ComentarioPlatoMenuMvc/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComentarioPlatoMenu comentarioPlatoMenu = db.ComentarioPlatoMenus
                .Include(c => c.Menu)
                .Include(c => c.Plato)
                .SingleOrDefault(c => c.Id == id);
            if (comentarioPlatoMenu == null)
            {
                return HttpNotFound();
            }
            return View(comentarioPlatoMenu);
        }

        // GET: ComentarioPlatoMenuMvc/Create
        public ActionResult Create()
        {
            ViewBag.MenuId = new SelectList(db.Menus, "Id", "Titulo");
            ViewBag.PlatoId = new SelectList(db.Platoes, "Id", "Titulo");
            return View();
        }

        // POST: ComentarioPlatoMenuMvc/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Autor,Descripcion,Valoracion,MenuId,PlatoId")] ComentarioPlatoMenu comentarioPlatoMenu)
        {
            if (ModelState.IsValid)
            {
                db.ComentarioPlatoMenus.Add(comentarioPlatoMenu);
                db.SaveChanges();
                if(comentarioPlatoMenu.MenuId != null)
                {
                    return RedirectToAction("IndexMenu", new { id = comentarioPlatoMenu.MenuId });
                }
                else if (comentarioPlatoMenu.PlatoId != null)
                {
                    return RedirectToAction("IndexPlato", new { id = comentarioPlatoMenu.PlatoId });
                }
                else {
                    return RedirectToAction("Index");
                }
            }

            ViewBag.MenuId = new SelectList(db.Menus, "Id", "Titulo", comentarioPlatoMenu.MenuId);
            ViewBag.PlatoId = new SelectList(db.Platoes, "Id", "Titulo", comentarioPlatoMenu.PlatoId);
            return View(comentarioPlatoMenu);
        }

        // GET: ComentarioPlatoMenuMvc/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComentarioPlatoMenu comentarioPlatoMenu = db.ComentarioPlatoMenus.Find(id);
            if (comentarioPlatoMenu == null)
            {
                return HttpNotFound();
            }
            ViewBag.MenuId = new SelectList(db.Menus, "Id", "Titulo", comentarioPlatoMenu.MenuId);
            ViewBag.PlatoId = new SelectList(db.Platoes, "Id", "Titulo", comentarioPlatoMenu.PlatoId);
            return View(comentarioPlatoMenu);
        }

        // POST: ComentarioPlatoMenuMvc/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Autor,Descripcion,Valoracion,MenuId,PlatoId")] ComentarioPlatoMenu comentarioPlatoMenu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comentarioPlatoMenu).State = EntityState.Modified;
                db.SaveChanges();
                if (comentarioPlatoMenu.MenuId != null)
                {
                    return RedirectToAction("IndexMenu", new { id = comentarioPlatoMenu.MenuId });
                }
                else if (comentarioPlatoMenu.PlatoId != null)
                {
                    return RedirectToAction("IndexPlato", new { id = comentarioPlatoMenu.PlatoId });
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            ViewBag.MenuId = new SelectList(db.Menus, "Id", "Titulo", comentarioPlatoMenu.MenuId);
            ViewBag.PlatoId = new SelectList(db.Platoes, "Id", "Titulo", comentarioPlatoMenu.PlatoId);
            return View(comentarioPlatoMenu);
        }

        // GET: ComentarioPlatoMenuMvc/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComentarioPlatoMenu comentarioPlatoMenu = db.ComentarioPlatoMenus.Find(id);
            if (comentarioPlatoMenu == null)
            {
                return HttpNotFound();
            }
            return View(comentarioPlatoMenu);
        }

        // POST: ComentarioPlatoMenuMvc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ComentarioPlatoMenu comentarioPlatoMenu = db.ComentarioPlatoMenus.Find(id);
            db.ComentarioPlatoMenus.Remove(comentarioPlatoMenu);
            db.SaveChanges();
            if (comentarioPlatoMenu.MenuId != null)
            {
                return RedirectToAction("IndexMenu", new { id = comentarioPlatoMenu.MenuId });
            }
            else if (comentarioPlatoMenu.PlatoId != null)
            {
                return RedirectToAction("IndexPlato", new { id = comentarioPlatoMenu.PlatoId });
            }
            else
            {
                return RedirectToAction("Index");
            }
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
