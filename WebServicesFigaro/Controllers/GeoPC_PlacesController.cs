using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebServicesFigaro.Models;

namespace WebServicesFigaro.Controllers
{
    public class GeoPC_PlacesController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/GeoPC_Places
        public IQueryable<GeoPC_Places> GetGeoPC_Places()
        {
            return db.GeoPC_Places;
        }

        // GET: api/GeoPC_Places/5
        [ResponseType(typeof(GeoPC_Places))]
        public IHttpActionResult GetGeoPC_Places(string id)
        {
            GeoPC_Places geoPC_Places = db.GeoPC_Places.Find(id);
            if (geoPC_Places == null)
            {
                return NotFound();
            }

            return Ok(geoPC_Places);
        }

        //Si id == null devueve todas las zonas no asignadas
        // GET: api/GeoPC_Places/Zona/{ZonaId}
        [Route("api/GeoPC_Places/Zona/{id}")]
        [ResponseType(typeof(GeoPC_Places))]
        public IQueryable<GeoPC_Places> GetGeoPC_PlacesByZona(int? id)
        {
            return db.GeoPC_Places
                .Where(g => g.ZonaId == id);
        }

        //// PUT: api/GeoPC_Places/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutGeoPC_Places(string id, GeoPC_Places geoPC_Places)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != geoPC_Places.ISO)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(geoPC_Places).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!GeoPC_PlacesExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/GeoPC_Places
        //[ResponseType(typeof(GeoPC_Places))]
        //public IHttpActionResult PostGeoPC_Places(GeoPC_Places geoPC_Places)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.GeoPC_Places.Add(geoPC_Places);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (GeoPC_PlacesExists(geoPC_Places.ISO))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtRoute("DefaultApi", new { id = geoPC_Places.ISO }, geoPC_Places);
        //}

        //// DELETE: api/GeoPC_Places/5
        //[ResponseType(typeof(GeoPC_Places))]
        //public IHttpActionResult DeleteGeoPC_Places(string id)
        //{
        //    GeoPC_Places geoPC_Places = db.GeoPC_Places.Find(id);
        //    if (geoPC_Places == null)
        //    {
        //        return NotFound();
        //    }

        //    db.GeoPC_Places.Remove(geoPC_Places);
        //    db.SaveChanges();

        //    return Ok(geoPC_Places);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GeoPC_PlacesExists(string id)
        {
            return db.GeoPC_Places.Count(e => e.ISO == id) > 0;
        }
    }
}