using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebServicesFigaro.Models;

namespace WebServicesFigaro.Controllers
{
    public class UsuarioMvcController : Controller
    {
        private DBContext db = new DBContext();

        // GET: UsuarioMvc
        public ActionResult Index()
        {
            var usuarios = db.Usuarios
                .Include(u => u.Zona);
            return View(usuarios.ToList());
        }

        // GET: UsuarioMvc/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Include(u => u.Zona).Include(u => u.ChefSeleccionado)
                .Include(u => u.TipoCocina)
                .FirstOrDefault(u => u.Id == id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: UsuarioMvc/Create
        public ActionResult Create()
        {
            ViewBag.ZonaId = new SelectList(db.Zonas, "Id", "Titulo");
            ViewBag.ChefSeleccionadoId = new SelectList(db.Chefs, "Id", "Apellidos");
            ViewBag.TipoCocinaId = new SelectList(db.TipoCocinas, "Id", "Titulo");
            ViewBag.genero = new SelectList(
            new List<SelectListItem> {
                    new SelectListItem { Text = "Sin especificar", Value = "Sin especificar" },
                    new SelectListItem { Text = "Hombre", Value = "Hombre" },
                    new SelectListItem { Text = "Mujer", Value = "Mujer" }
            }, "Value", "Text");
            return View();
        }

        // POST: UsuarioMvc/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Apellidos,Email,Imagen,Password,ZonaId,Ciudad,Direccion,Estado,FechaRegistro,genero,FacebookId,ChefSeleccionadoId,TipoCocinaId")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.Password = HashPass(usuario.Password);
                db.Usuarios.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ZonaId = new SelectList(db.Zonas, "Id", "Titulo", usuario.ZonaId);
            ViewBag.ChefSeleccionadoId = new SelectList(db.Chefs, "Id", "Apellidos", usuario.ChefSeleccionadoId);
            ViewBag.TipoCocinaId = new SelectList(db.TipoCocinas, "Id", "Titulo", usuario.TipoCocinaId);
            ViewBag.genero = new SelectList(
                new List<SelectListItem> {
                    new SelectListItem { Text = "Sin especificar", Value = "Sin especificar" },
                    new SelectListItem { Text = "Hombre", Value = "Hombre" },
                    new SelectListItem { Text = "Mujer", Value = "Mujer" }
                }, "Value", "Text", usuario.genero);
            return View(usuario);
        }

        // GET: UsuarioMvc/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.ZonaId = new SelectList(db.Zonas, "Id", "Titulo", usuario.ZonaId);
            ViewBag.ChefSeleccionadoId = new SelectList(db.Chefs, "Id", "Apellidos", usuario.ChefSeleccionadoId);
            ViewBag.TipoCocinaId = new SelectList(db.TipoCocinas, "Id", "Titulo", usuario.TipoCocinaId);
            ViewBag.genero = new SelectList(
                new List<SelectListItem> {
                    new SelectListItem { Text = "Sin especificar", Value = "Sin especificar" },
                    new SelectListItem { Text = "Hombre", Value = "Hombre" },
                    new SelectListItem { Text = "Mujer", Value = "Mujer" }
                }, "Value", "Text", usuario.genero);

            return View(usuario);
        }

        // POST: UsuarioMvc/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Apellidos,Email,Imagen,ZonaId,Ciudad,Direccion,Estado,FechaRegistro,genero,FacebookId,Password,ChefSeleccionadoId,TipoCocinaId")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ZonaId = new SelectList(db.Zonas, "Id", "Titulo", usuario.ZonaId);
            ViewBag.ChefSeleccionadoId = new SelectList(db.Chefs, "Id", "Apellidos", usuario.ChefSeleccionadoId);
            ViewBag.TipoCocinaId = new SelectList(db.TipoCocinas, "Id", "Titulo", usuario.TipoCocinaId);
            ViewBag.genero = new SelectList(
                            new List<SelectListItem> {
                    new SelectListItem { Text = "Sin especificar", Value = "Sin especificar" },
                    new SelectListItem { Text = "Hombre", Value = "Hombre" },
                    new SelectListItem { Text = "Mujer", Value = "Mujer" }
                            }, "Value", "Text", usuario.genero);

            return View(usuario);
        }

        // GET: UsuarioMvc/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Include(u => u.Zona).Include(u => u.ChefSeleccionado).FirstOrDefault(u => u.Id == id); ;
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: UsuarioMvc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.Usuarios.Include(u => u.Zona).Include(u => u.ChefSeleccionado).FirstOrDefault(u => u.Id == id);
            db.Usuarios.Remove(usuario);
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

        protected string HashPass(string originalpassword)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            Byte[] originalBytes = ASCIIEncoding.Default.GetBytes(originalpassword);
            Byte[] encodedBytes = md5.ComputeHash(originalBytes);
            string added = "ew#%¬plfñ@@|ºdaç";
            Byte[] additionalBytes = ASCIIEncoding.Default.GetBytes(added);

            int length = 0;
            if (encodedBytes.Length < additionalBytes.Length)
            {
                length = encodedBytes.Length;
            }
            else
            {
                length = additionalBytes.Length;
            }
            for (int i = 0; i < length; i++)
            {
                encodedBytes[i] = (byte)(encodedBytes[i] ^ additionalBytes[i]);
            }
            string hex = BitConverter.ToString(encodedBytes).Replace("-", "");
            return hex;
        }

    }
}
