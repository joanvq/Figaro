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
    public class GeoPC_PlaceMvcController : Controller
    {
        private DBContext db = new DBContext();

        // GET: GeoPC_PlaceMvc
        public ActionResult Index()
        {
            return View(db.GeoPC_Places.ToList());
        }

        // GET: GeoPC_PlaceMvc/Details/5
        public ActionResult Details(string ISO, string postCode)
        {
            if (ISO == null && postCode == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GeoPC_Places geoPC_Place = db.GeoPC_Places
                .Where(g => g.ISO == ISO && g.PostCode == postCode)
                .FirstOrDefault();
            if (geoPC_Place == null)
            {
                return HttpNotFound();
            }
            return View(geoPC_Place);
        }

        //// GET: GeoPC_PlaceMvc/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: GeoPC_PlaceMvc/Create
        //// Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        //// más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ISO,PostCode,PlaceName,AdminName1,AdminCode1,AdminName2,AdminCode2,AdminName3,AdminCode3,Latitude,Longitude,Accuracy,ZonaId")] GeoPC_Place geoPC_Place)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.GeoPC_Place.Add(geoPC_Place);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(geoPC_Place);
        //}

        // GET: GeoPC_PlaceMvc/Edit/{ISO}/{PostalCode}
        [Route("api/Reservado/{ISO}/{postalCode}")]
        public ActionResult Edit(string ISO, string postCode)
        {
            if (ISO == null || postCode == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GeoPC_Places geoPC_Place = db.GeoPC_Places
                .Where(g => g.ISO == ISO && g.PostCode == postCode)
                .FirstOrDefault();
            if (geoPC_Place == null)
            {
                return HttpNotFound();
            }
            ViewBag.ZonaId = new SelectList(db.Zonas, "Id", "Titulo", geoPC_Place.ZonaId);
            return View(geoPC_Place);
        }

        // POST: GeoPC_PlaceMvc/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ISO,PostCode,PlaceName,AdminName1,AdminCode1,AdminName2,AdminCode2,AdminName3,AdminCode3,Latitude,Longitude,Accuracy,ZonaId")] GeoPC_Places geoPC_Place)
        {
            if (ModelState.IsValid)
            {
                db.Entry(geoPC_Place).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ZonaId = new SelectList(db.Zonas, "Id", "Titulo", geoPC_Place.ZonaId);
            return View(geoPC_Place);
        }

        // GET: GeoPC_PlaceMvc/Delete/5
        //public ActionResult Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    GeoPC_Place geoPC_Place = db.GeoPC_Place.Find(id);
        //    if (geoPC_Place == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(geoPC_Place);
        //}

        // POST: GeoPC_PlaceMvc/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(string id)
        //{
        //    GeoPC_Place geoPC_Place = db.GeoPC_Place.Find(id);
        //    db.GeoPC_Place.Remove(geoPC_Place);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
