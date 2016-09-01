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
    public class MenuMvcController : Controller
    {
        private DBContext db = new DBContext();

        // GET: MenuMvc
        public ActionResult Index()
        {
            var menus = db.Menus.Include(m => m.Entrante).Include(m => m.Guarnicion).Include(m => m.Postre).Include(m => m.Primero).Include(m => m.Segundo).Include(m => m.TipoCocina);
            return View(menus.ToList());
        }

        // GET: MenuMvc/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu menu = db.Menus.Find(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        // GET: MenuMvc/Create
        public ActionResult Create()
        {
            ViewBag.EntranteId = new SelectList(db.Platoes, "Id", "Titulo");
            ViewBag.GuarnicionId = new SelectList(db.Platoes, "Id", "Titulo");
            ViewBag.PostreId = new SelectList(db.Platoes, "Id", "Titulo");
            ViewBag.PrimeroId = new SelectList(db.Platoes, "Id", "Titulo");
            ViewBag.SegundoId = new SelectList(db.Platoes, "Id", "Titulo");
            ViewBag.TipoCocinaId = new SelectList(db.TipoCocinas, "Id", "Titulo");
            return View();
        }

        // POST: MenuMvc/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Titulo,Descripcion,EntranteId,PrimeroId,SegundoId,GuarnicionId,PostreId,Imagen,TiempoCocinado,Precio,Valoracion,TipoCocinaId,Categoria,Ingredientes,Utensilios")] Menu menu)
        {
            if (ModelState.IsValid)
            {
                db.Menus.Add(menu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EntranteId = new SelectList(db.Platoes, "Id", "Titulo", menu.EntranteId);
            ViewBag.GuarnicionId = new SelectList(db.Platoes, "Id", "Titulo", menu.GuarnicionId);
            ViewBag.PostreId = new SelectList(db.Platoes, "Id", "Titulo", menu.PostreId);
            ViewBag.PrimeroId = new SelectList(db.Platoes, "Id", "Titulo", menu.PrimeroId);
            ViewBag.SegundoId = new SelectList(db.Platoes, "Id", "Titulo", menu.SegundoId);
            ViewBag.TipoCocinaId = new SelectList(db.TipoCocinas, "Id", "Titulo", menu.TipoCocinaId);
            return View(menu);
        }

        // GET: MenuMvc/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu menu = db.Menus.Find(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            ViewBag.EntranteId = new SelectList(db.Platoes.Where(x => x.Titulo == "Fideos"), "Id", "Titulo", menu.EntranteId);
            ViewBag.GuarnicionId = new SelectList(db.Platoes, "Id", "Titulo", menu.GuarnicionId);
            ViewBag.PostreId = new SelectList(db.Platoes, "Id", "Titulo", menu.PostreId);
            ViewBag.PrimeroId = new SelectList(db.Platoes, "Id", "Titulo", menu.PrimeroId);
            ViewBag.SegundoId = new SelectList(db.Platoes, "Id", "Titulo", menu.SegundoId);
            ViewBag.TipoCocinaId = new SelectList(db.TipoCocinas, "Id", "Titulo", menu.TipoCocinaId);
            return View(menu);
        }

        // POST: MenuMvc/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Titulo,Descripcion,EntranteId,PrimeroId,SegundoId,GuarnicionId,PostreId,Imagen,TiempoCocinado,Precio,Valoracion,TipoCocinaId,Categoria,Ingredientes,Utensilios")] Menu menu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(menu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EntranteId = new SelectList(db.Platoes, "Id", "Titulo", menu.EntranteId);
            ViewBag.GuarnicionId = new SelectList(db.Platoes, "Id", "Titulo", menu.GuarnicionId);
            ViewBag.PostreId = new SelectList(db.Platoes, "Id", "Titulo", menu.PostreId);
            ViewBag.PrimeroId = new SelectList(db.Platoes, "Id", "Titulo", menu.PrimeroId);
            ViewBag.SegundoId = new SelectList(db.Platoes, "Id", "Titulo", menu.SegundoId);
            ViewBag.TipoCocinaId = new SelectList(db.TipoCocinas, "Id", "Titulo", menu.TipoCocinaId);
            return View(menu);
        }

        // GET: MenuMvc/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu menu = db.Menus.Find(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        // POST: MenuMvc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Menu menu = db.Menus.Find(id);
            db.Menus.Remove(menu);
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
