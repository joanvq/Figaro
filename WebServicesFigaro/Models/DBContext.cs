using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebServicesFigaro.Models
{
    public class DBContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
        
        public DBContext() : base("name=DBContext")
        {
        }

        public System.Data.Entity.DbSet<WebServicesFigaro.Models.Plato> Platoes { get; set; }
        public System.Data.Entity.DbSet<WebServicesFigaro.Models.Zona> Zonas { get; set; }
        public System.Data.Entity.DbSet<WebServicesFigaro.Models.TipoCocina> TipoCocinas { get; set; }

        public System.Data.Entity.DbSet<WebServicesFigaro.Models.Menu> Menus { get; set; }

        public System.Data.Entity.DbSet<WebServicesFigaro.Models.Chef> Chefs { get; set; }

        public System.Data.Entity.DbSet<WebServicesFigaro.Models.ComentarioChef> ComentarioChefs { get; set; }

        public System.Data.Entity.DbSet<WebServicesFigaro.Models.Usuario> Usuarios { get; set; }

        public System.Data.Entity.DbSet<WebServicesFigaro.Models.Pedido> Pedidoes { get; set; }

        public System.Data.Entity.DbSet<WebServicesFigaro.Models.PlatoPedido> PlatoPedidoes { get; set; }

        public System.Data.Entity.DbSet<WebServicesFigaro.Models.MenuPedido> MenuPedidoes { get; set; }

        public System.Data.Entity.DbSet<WebServicesFigaro.Models.PlatoCarrito> PlatoCarritoes { get; set; }

        public System.Data.Entity.DbSet<WebServicesFigaro.Models.MenuCarrito> MenuCarritoes { get; set; }

        public System.Data.Entity.DbSet<WebServicesFigaro.Models.Disponibilidad> Disponibilidads { get; set; }

        public System.Data.Entity.DbSet<WebServicesFigaro.Models.Reservado> Reservadoes { get; set; }
    }
}
