using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebServicesFigaro.Models;

namespace WebServicesFigaro.Controllers
{
    public class AsignarDisponibilidadController : Controller
    {
        // GET: AsignarDisponibilidad
        public ActionResult Index()
        {
            return View();
        }

        // GET: AsignarDisponibilidad/Details
        public ActionResult Details()
        {
            return View();
        }

        // GET: AsignarDisponibilidad/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AsignarDisponibilidad/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                DateTime fecha = new DateTime();
                var db = new DBContext();
                int x = 0;
                if (Int32.TryParse(collection.Get(1), out x))
                {
                    // Chef Id es entero
                    int chefId = x;
                    if (db.Chefs.FirstOrDefault(c => c.Id == chefId) == null)
                    {
                        return View(collection);
                    }
                    string f = collection.Get(2);
                    string fe = collection.Get(3);
                    DateTime fechaIni = DateTime.ParseExact(collection.Get(2), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    DateTime fechaFin = DateTime.ParseExact(collection.Get(3), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    if (Int32.TryParse(collection.Get(4), out x))
                    {
                        //Hora inicial es entero
                        int horaIni = x;
                        if (Int32.TryParse(collection.Get(5), out x))
                        {
                            // Hora final es entero
                            int horaFin = x;
                            int nDias = Convert.ToInt32((fechaFin - fechaIni).TotalDays);
                            int nMediasHoras = (horaFin - horaIni) * 2;
                            for (int i = 0; i <= nDias; i++)
                            {
                                // Recorremos todas las fechas comprendidas en el periodo escogido
                                // Dia Inicio y Dia Fin incluidos
                                DateTime fechaAct = fechaIni.AddDays(i);
                                var b = false;
                                switch (fechaAct.DayOfWeek)
                                {
                                    case DayOfWeek.Monday:
                                        if (collection.Get(6) == "true,false")
                                        {
                                            b = true;
                                        }
                                        break;
                                    case DayOfWeek.Tuesday:
                                        if (collection.Get(7) == "true,false")
                                        {
                                            b = true;
                                        }
                                        break;
                                    case DayOfWeek.Wednesday:
                                        if (collection.Get(8) == "true,false")
                                        {
                                            b = true;
                                        }
                                        break;
                                    case DayOfWeek.Thursday:
                                        if (collection.Get(9) == "true,false")
                                        {
                                            b = true;
                                        }
                                        break;
                                    case DayOfWeek.Friday:
                                        if (collection.Get(10) == "true,false")
                                        {
                                            b = true;
                                        }
                                        break;
                                    case DayOfWeek.Saturday:
                                        if (collection.Get(11) == "true,false")
                                        {
                                            b = true;
                                        }
                                        break;
                                    case DayOfWeek.Sunday:
                                        if (collection.Get(12) == "true,false")
                                        {
                                            b = true;
                                        }
                                        break;
                                }
                                if (b)
                                {
                                    var disp = db.Disponibilidads.FirstOrDefault(d => d.ChefId == chefId && d.Fecha == fechaAct);
                                    if (disp == null)
                                    {
                                        //Añadimos fecha disponible a disponibilidad 
                                        disp = new Disponibilidad
                                        {
                                            ChefId = chefId,
                                            EstaDisponible = true,
                                            Fecha = fechaAct
                                        };
                                        db.Disponibilidads.Add(disp);
                                        db.SaveChanges();
                                    }
                                    for (int j = 0; j < nMediasHoras; j++)
                                    {
                                        // Recorremos todas las horas comprendidas en el periodo escogido
                                        // para la disponibilidad actual.
                                        // Como las horas que se pasan son siempre exactas las medias horas seran 
                                        // los numeros impares.
                                        int horaAct = (horaIni + j/2);
                                        int minAct = ((horaIni*2 + j) % 2) * 30;
                                        var res = db.Reservadoes.FirstOrDefault(r => r.DisponibilidadId == disp.Id
                                            && r.Hora.Hour == horaAct && r.Hora.Minute == minAct);
                                        if (res == null)
                                        {
                                            // Añadir reserva 
                                            res = new Reservado
                                            {
                                                DisponibilidadId = disp.Id,
                                                Hora = new DateTime(2000, 01, 01, horaAct, minAct, 0),
                                                // Pedido -1 es el valor  para representar que no tiene 
                                                // ninguno asignado
                                                PedidoId = -1,
                                            };
                                            if(!disp.EstaDisponible)
                                            {
                                                disp.EstaDisponible = true;
                                                db.Entry(disp).State = EntityState.Modified;
                                            }
                                            db.Reservadoes.Add(res);
                                        }
                                    }
                                    db.SaveChanges();
                                }
                            }
                        }
                        else
                        {
                            return View(collection);
                        }
                    }
                    else
                    {
                        return View(collection);
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(collection);
            }
        }

        // GET: AsignarDisponibilidad/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AsignarDisponibilidad/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AsignarDisponibilidad/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AsignarDisponibilidad/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
