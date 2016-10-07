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
    public class ReservadoMvcController : Controller
    {
        private DBContext db = new DBContext();

        // GET: ReservadoMvc
        public ActionResult Index()
        {
            var reservadoes = db.Reservadoes.Include(r => r.Disponibilidad).Include(r => r.Pedido);
            return View(reservadoes.ToList());
        }

        // GET: ReservadoMvc/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservado reservado = db.Reservadoes.Find(id);
            if (reservado == null)
            {
                return HttpNotFound();
            }
            return View(reservado);
        }

        // GET: ReservadoMvc/Create
        public ActionResult Create()
        {
            ViewBag.DisponibilidadId = new SelectList(db.Disponibilidads, "Id", "Id");
            ViewBag.PedidoId = new SelectList(db.Pedidoes, "Id", "NPedido");
            return View();
        }

        // POST: ReservadoMvc/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Hora,DisponibilidadId,PedidoId")] Reservado reservado)
        {
            if (ModelState.IsValid)
            {
                db.Reservadoes.Add(reservado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DisponibilidadId = new SelectList(db.Disponibilidads, "Id", "Id", reservado.DisponibilidadId);
            ViewBag.PedidoId = new SelectList(db.Pedidoes, "Id", "NPedido", reservado.PedidoId);
            return View(reservado);
        }

        // GET: ReservadoMvc/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservado reservado = db.Reservadoes.Find(id);
            if (reservado == null)
            {
                return HttpNotFound();
            }
            ViewBag.DisponibilidadId = new SelectList(db.Disponibilidads, "Id", "Id", reservado.DisponibilidadId);
            ViewBag.PedidoId = new SelectList(db.Pedidoes, "Id", "NPedido", reservado.PedidoId);
            return View(reservado);
        }

        // POST: ReservadoMvc/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Hora,DisponibilidadId,PedidoId")] Reservado reservado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DisponibilidadId = new SelectList(db.Disponibilidads, "Id", "Id", reservado.DisponibilidadId);
            ViewBag.PedidoId = new SelectList(db.Pedidoes, "Id", "NPedido", reservado.PedidoId);
            return View(reservado);
        }

        // GET: ReservadoMvc/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservado reservado = db.Reservadoes.Find(id);
            if (reservado == null)
            {
                return HttpNotFound();
            }
            return View(reservado);
        }

        // POST: ReservadoMvc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reservado reservado = db.Reservadoes.Find(id);
            db.Reservadoes.Remove(reservado);
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
