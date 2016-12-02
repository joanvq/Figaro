using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebServicesFigaro.Models;

namespace WebServicesFigaro.Controllers
{
    public class ReservadoController : ApiController
    {
        private DBContext db = new DBContext();

        //// GET: api/Reservado
        //public IQueryable<Reservado> GetReservadoes()
        //{
        //    return db.Reservadoes;
        //}

        // GET: api/Reservado/Disponibilidad/{id}
        [Route("api/Reservado/Disponibilidad/{id}")]
        public IQueryable<Reservado> GetReservadoesByDisponibilidad(int id)
        {
            return db.Reservadoes
                .Include(r => r.Disponibilidad)
                .Include(r => r.Pedido)
                .Where(r => r.DisponibilidadId == id);
        }

        // GET: api/Reservado/Pedido/{id}
        [Route("api/Reservado/Pedido/{id}")]
        public IQueryable<Reservado> GetReservadoesByPedido(int id)
        {
            return db.Reservadoes
                .Include(r => r.Disponibilidad)
                .Include(r => r.Pedido)
                .Where(r => r.PedidoId == id);
        }

        // GET: api/Reservado/LibresChef/{idChef}
        [Route("api/Reservado/LibresChef/{id}")]
        public IQueryable<Reservado> GetReservadoesLibresByChef(int id)
        {
            return db.Reservadoes
                .Include(r => r.Disponibilidad)
                .Include(r => r.Disponibilidad.Chef)
                .Include(r => r.Pedido)
                .Where(r => r.Disponibilidad.ChefId == id && r.PedidoId == -1);
                //Falta filtrar fechas para que no aparezcan las anteriores a hoy
        }

        // GET: api/Reservado/5
        [ResponseType(typeof(Reservado))]
        public IHttpActionResult GetReservado(int id)
        {
            Reservado reservado = db.Reservadoes
                .Include(r => r.Pedido)
                .Include(r => r.Disponibilidad)
                .FirstOrDefault(r => r.Id == id);
            if (reservado == null)
            {
                return NotFound();
            }

            return Ok(reservado);
        }

        // PUT: api/Reservado/{idReservado}/{idPedido}
        [Route("api/Reservado/{id}/{pedidoId}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutReservadoEnPedido(int id, int pedidoId, Reservado res)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // No existe Reservado con id
            var reservados = db.Reservadoes.Where(p => p.Id == id);
            if (reservados == null)
            {
                return NotFound();
            }

            // No existe Pedido con pedidoId
            if(pedidoId != -1)
            {
                if (db.Pedidoes.Where(p => p.Id == pedidoId) == null)
                {
                    return NotFound();
                }
            }

            //Modificar Reservado
            var reservado = reservados.FirstOrDefault();
            var disponibilidadId = reservado.DisponibilidadId;
            reservado.PedidoId = pedidoId;
            db.Entry(reservado).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservadoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            // Comprovar si todos los reservados de la disponibilidad estan con pedido
            // y modificar EstaDsiponible segun este o no disponible
            var disponibilidad = db.Disponibilidads.FirstOrDefault(d => d.Id == disponibilidadId);
            var reservadosDisponibilidad = db.Reservadoes.Where(r => r.DisponibilidadId == disponibilidadId);
            int nDisponibles = 0;
            foreach (var reservadoDisponibilidad in reservadosDisponibilidad)
            {
                // Si esta reserva no tiene pedido
                if (reservadoDisponibilidad.PedidoId != -1)
                {
                    nDisponibles++;
                }
            }
            // variable que la puedo variar ahora 4 son 2 horas. para estar disponible tiene 
            // que tener mas de 2 horas disponibles
            if (disponibilidad != null)
            {
                if(nDisponibles > 0)
                {
                    disponibilidad.EstaDisponible = true;
                    db.Entry(disponibilidad).State = EntityState.Modified;
                }
                else
                {
                    disponibilidad.EstaDisponible = false;
                    db.Entry(disponibilidad).State = EntityState.Modified;
                }
            }

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }


        //// PUT: api/Reservado/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutReservado(int id, Reservado reservado)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != reservado.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(reservado).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ReservadoExists(id))
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

        //// POST: api/Reservado
        //[ResponseType(typeof(Reservado))]
        //public IHttpActionResult PostReservado(Reservado reservado)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Reservadoes.Add(reservado);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = reservado.Id }, reservado);
        //}

        //// DELETE: api/Reservado/5
        //[ResponseType(typeof(Reservado))]
        //public IHttpActionResult DeleteReservado(int id)
        //{
        //    Reservado reservado = db.Reservadoes.Find(id);
        //    if (reservado == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Reservadoes.Remove(reservado);
        //    db.SaveChanges();

        //    return Ok(reservado);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReservadoExists(int id)
        {
            return db.Reservadoes.Count(e => e.Id == id) > 0;
        }
    }
}