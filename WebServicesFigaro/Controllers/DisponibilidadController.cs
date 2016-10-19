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
    public class DisponibilidadController : ApiController
    {
        private DBContext db = new DBContext();

        // No se devuelven todas las disponibilidades en general solo por chef
        // GET: api/Disponibilidad
        public IQueryable<Disponibilidad> GetDisponibilidads()
        {
            return db.Disponibilidads;
        }

        // GET: api/Disponibilidad/Chef/
        [Route("api/Disponibilidad/Chef/{id}")]
        public IQueryable<Disponibilidad> GetDisponibilidades(int id)
        {
            return db.Disponibilidads
                .Where(d => d.ChefId == id)
                .Include(d => d.Chef);
        }

        // Obtiene las disponibilidades de los chefs en date
        // GET: api/Disponibilidad/Fecha/
        [Route("api/Disponibilidad/Fecha/{year}/{month}/{day}")]
        public IQueryable<Disponibilidad> GetDisponibilidades(int year, int month, int day)
        {
            return db.Disponibilidads
                .Where(d => d.Fecha.Year == year && d.Fecha.Month == month && d.Fecha.Day == day)
                .Include(d => d.Chef);
        }

        // GET: api/Disponibilidad/5
        [ResponseType(typeof(Disponibilidad))]
        public IHttpActionResult GetDisponibilidad(int id)
        {
            Disponibilidad disponibilidad = db.Disponibilidads
                .Include(d => d.Chef)
                .FirstOrDefault(d => d.Id == id);
            if (disponibilidad == null)
            {
                return NotFound();
            }

            return Ok(disponibilidad);
        }

        // PUT: api/Disponibilidad/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDisponibilidad(int id, Disponibilidad disponibilidad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != disponibilidad.Id)
            {
                return BadRequest();
            }

            db.Entry(disponibilidad).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DisponibilidadExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Disponibilidad
        [Route("api/Disponibilidad/{desde}/{hasta}")]
        [ResponseType(typeof(Disponibilidad))]
        public IHttpActionResult PostDisponibilidadReserva(Disponibilidad disponibilidad, string desde, string hasta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Disponibilidads.Add(disponibilidad);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = disponibilidad.Id }, disponibilidad);
        }

        // POST: api/Disponibilidad
        [ResponseType(typeof(Disponibilidad))]
        public IHttpActionResult PostDisponibilidad(Disponibilidad disponibilidad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Disponibilidads.Add(disponibilidad);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = disponibilidad.Id }, disponibilidad);
        }

        //// DELETE: api/Disponibilidad/5
        //[ResponseType(typeof(Disponibilidad))]
        //public IHttpActionResult DeleteDisponibilidad(int id)
        //{
        //    Disponibilidad disponibilidad = db.Disponibilidads.Find(id);
        //    if (disponibilidad == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Disponibilidads.Remove(disponibilidad);
        //    db.SaveChanges();

        //    return Ok(disponibilidad);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DisponibilidadExists(int id)
        {
            return db.Disponibilidads.Count(e => e.Id == id) > 0;
        }
    }
}