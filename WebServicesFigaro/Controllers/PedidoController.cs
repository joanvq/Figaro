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
    public class PedidoController : ApiController
    {
        private DBContext db = new DBContext();

        //// GET: api/Pedido
        //public IQueryable<Pedido> GetPedidoes()
        //{
        //    return db.Pedidoes;
        //}

        // GET: api/Pedido/5
        [ResponseType(typeof(Pedido))]
        public IHttpActionResult GetPedido(int id)
        {
            Pedido pedido = db.Pedidoes.Find(id);
            if (pedido == null)
            {
                return NotFound();
            }

            return Ok(pedido);
        }

        // GET: api/Pedido/NPedido/{nPedido}
        [ResponseType(typeof(Pedido))]
        [Route("api/Pedido/NPedido/{nPedido}")]
        public IQueryable<Pedido> GetPedidoByNPedido(string nPedido)
        {
            return db.Pedidoes.Where(p => p.NPedido == nPedido)
                .Include(p => p.Usuario)
                .Include(p => p.Zona);
        }

        // GET: api/Pedido/Usuario/{idUsuario}
        [ResponseType(typeof(Pedido))]
        [Route("api/Pedido/Usuario/{id}")]
        public IQueryable<Pedido> GetPedidosByUsuario (int id)
        {
            return db.Pedidoes.Where(p => p.UsuarioId == id)
                .Include(p => p.Usuario)
                .Include(p => p.Zona);
        }

        //// PUT: api/Pedido/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutPedido(int id, Pedido pedido)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != pedido.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(pedido).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PedidoExists(id))
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

        // POST: api/Pedido
        [ResponseType(typeof(Pedido))]
        public IHttpActionResult PostPedido(Pedido pedido)
        {

            var usuario = db.Usuarios.FirstOrDefault(u => u.Id == pedido.UsuarioId);
            var listaPlatosCarrito = db.PlatoCarritoes.Where(p => p.UsuarioId == pedido.UsuarioId).ToArray();
            var listaMenuCarrito = db.MenuCarritoes.Where(m => m.UsuarioId == pedido.UsuarioId).ToArray();
            // Viene NombreApellidos, Direccion, CP, UsuarioId, ZonaId, PrecioTotal, Comentario, 
            // TipoCocina

            //Para numero pedido deber generar y 
            //comprovar que no existe, si existe generará uno nuevo
            //Generar Numero Pedido unico en funcion del tiempo 
            long ticks = DateTime.Now.Ticks;
            byte[] bytes = BitConverter.GetBytes(ticks);
            string nPedido = Convert.ToBase64String(bytes)
                                    .Replace('+', '_')
                                    .Replace('/', '-')
                                    .TrimEnd('=');
            pedido.NPedido = nPedido;
            pedido.Estado = "Pagado";
            pedido.FechaPedido = DateTime.Now;

            var chefSeleccionado = db.Chefs.FirstOrDefault(c => c.Id == usuario.ChefSeleccionadoId);
            if(chefSeleccionado != null)
            {
                pedido.NombreChef = chefSeleccionado.Nombre + " " + chefSeleccionado.Apellidos;
            }
            else
            {
                pedido.NombreChef = "No especificado";
            }

            pedido.PrecioTotal = 0;
            foreach(PlatoCarrito platoCarrito in listaPlatosCarrito)
            {
                var plato = db.Platoes.FirstOrDefault(p => p.Id == platoCarrito.PlatoId);
                if (plato != null)
                {
                    var precioPlato = plato.Precio;
                    pedido.PrecioTotal += platoCarrito.Cantidad * precioPlato;
                }
            }
            foreach (MenuCarrito menuCarrito in listaMenuCarrito)
            {
                var menu = db.Menus.FirstOrDefault(m => m.Id == menuCarrito.MenuId);
                if (menu != null)
                {
                    var precioMenu = menu.Precio;
                    pedido.PrecioTotal += menuCarrito.Cantidad * precioMenu;
                }
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pedidoes.Add(pedido);

            db.SaveChanges();

            // Obtengo el pedido que acabamos de crear para obtener el Id 
            // creado automaticamente por la BD.
            Pedido pedidoCreado = db.Pedidoes.FirstOrDefault(p => p.NPedido == nPedido);

            foreach (PlatoCarrito platoCarrito in listaPlatosCarrito)
            {
                PlatoPedido platoPedido = new PlatoPedido();
                platoPedido.PedidoId = pedidoCreado.Id;
                var plato = db.Platoes.FirstOrDefault(p => p.Id == platoCarrito.PlatoId);
                if (plato != null)
                {
                    platoPedido.PrecioPlato = plato.Precio;
                    platoPedido.Ingredientes = plato.Ingredientes;
                    platoPedido.TiempoCocinado = plato.TiempoCocinado;
                    platoPedido.TituloPlato = plato.Titulo;
                    platoPedido.Utensilios = plato.Utensilios;
                    platoPedido.Cantidad = platoCarrito.Cantidad;

                }

                db.PlatoPedidoes.Add(platoPedido);
            }

            foreach (MenuCarrito menuCarrito in listaMenuCarrito)
            {
                MenuPedido menuPedido = new MenuPedido();
                menuPedido.PedidoId = pedidoCreado.Id;
                var menu = db.Menus.FirstOrDefault(p => p.Id == menuCarrito.MenuId);
                if (menu != null)
                {
                    menuPedido.PrecioMenu = menu.Precio;
                    menuPedido.Ingredientes = menu.Ingredientes;
                    menuPedido.TiempoCocinado = menu.TiempoCocinado;
                    menuPedido.TituloMenu = menu.Titulo;
                    menuPedido.Utensilios = menu.Utensilios;
                    menuPedido.Cantidad = menuCarrito.Cantidad;

                }

                db.MenuPedidoes.Add(menuPedido);
            }

            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pedido.Id }, pedido);
        }

        // DELETE: api/Pedido/5
        //[ResponseType(typeof(Pedido))]
        //public IHttpActionResult DeletePedido(int id)
        //{
        //    Pedido pedido = db.Pedidoes.Find(id);
        //    if (pedido == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Pedidoes.Remove(pedido);
        //    db.SaveChanges();

        //    return Ok(pedido);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        private bool PedidoExists(int id)
        {
            return db.Pedidoes.Count(e => e.Id == id) > 0;
        }
    }
}