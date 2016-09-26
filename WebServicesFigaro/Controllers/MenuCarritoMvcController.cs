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
    public class MenuCarritoMvcController : Controller
    {
        private DBContext db = new DBContext();

        // GET: MenuCarritoMvc
        public ActionResult Index()
        {
            var menuCarritoes = db.MenuCarritoes.Include(m => m.Menu).Include(m => m.Usuario);
            return View(menuCarritoes.ToList());
        }

        // GET: MenuCarritoMvc/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuCarrito menuCarrito = db.MenuCarritoes.Include(m => m.Menu).Include(m => m.Usuario)
                .FirstOrDefault(m => m.Id == id);
            if (menuCarrito == null)
            {
                return HttpNotFound();
            }
            return View(menuCarrito);
        }

        // GET: MenuCarritoMvc/Create
        public ActionResult Create()
        {
            ViewBag.MenuId = new SelectList(db.Menus, "Id", "Titulo");
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "Nombre");
            return View();
        }

        // POST: MenuCarritoMvc/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UsuarioId,MenuId,Cantidad")] MenuCarrito menuCarrito)
        {
            if (ModelState.IsValid)
            {
                db.MenuCarritoes.Add(menuCarrito);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MenuId = new SelectList(db.Menus, "Id", "Titulo", menuCarrito.MenuId);
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "Nombre", menuCarrito.UsuarioId);
            return View(menuCarrito);
        }

        // GET: MenuCarritoMvc/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuCarrito menuCarrito = db.MenuCarritoes.Find(id);
            if (menuCarrito == null)
            {
                return HttpNotFound();
            }
            ViewBag.MenuId = new SelectList(db.Menus, "Id", "Titulo", menuCarrito.MenuId);
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "Nombre", menuCarrito.UsuarioId);
            return View(menuCarrito);
        }

        // POST: MenuCarritoMvc/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UsuarioId,MenuId,Cantidad")] MenuCarrito menuCarrito)
        {
            if (ModelState.IsValid)
            {
                db.Entry(menuCarrito).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MenuId = new SelectList(db.Menus, "Id", "Titulo", menuCarrito.MenuId);
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "Nombre", menuCarrito.UsuarioId);
            return View(menuCarrito);
        }

        // GET: MenuCarritoMvc/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuCarrito menuCarrito = db.MenuCarritoes.Include(m => m.Menu).Include(m => m.Usuario)
                .FirstOrDefault(m => m.Id == id);
            if (menuCarrito == null)
            {
                return HttpNotFound();
            }
            return View(menuCarrito);
        }

        // POST: MenuCarritoMvc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MenuCarrito menuCarrito = db.MenuCarritoes.Find(id);
            db.MenuCarritoes.Remove(menuCarrito);
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
