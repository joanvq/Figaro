namespace WebServicesFigaro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class carrito : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chefs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(unicode: false),
                        Apellidos = c.String(unicode: false),
                        Imagen = c.String(unicode: false),
                        ImagenFondo = c.String(unicode: false),
                        Subtitulo = c.String(unicode: false),
                        ZonaId = c.Int(nullable: false),
                        TipoCocinaId = c.Int(nullable: false),
                        Valoracion = c.Double(nullable: false),
                        Descripcion = c.String(unicode: false),
                        FechaNacimiento = c.DateTime(nullable: false, precision: 0),
                        Genero = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TipoCocinas", t => t.TipoCocinaId, cascadeDelete: true)
                .ForeignKey("dbo.Zonas", t => t.ZonaId, cascadeDelete: true)
                .Index(t => t.ZonaId)
                .Index(t => t.TipoCocinaId);
            
            CreateTable(
                "dbo.TipoCocinas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(unicode: false),
                        Imagen = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Zonas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(unicode: false),
                        ImagenFondo = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ComentarioChefs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(unicode: false),
                        Valoracion = c.Double(nullable: false),
                        ChefId = c.Int(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Chefs", t => t.ChefId, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.ChefId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, unicode: false),
                        Apellidos = c.String(nullable: false, unicode: false),
                        Email = c.String(nullable: false, unicode: false),
                        Imagen = c.String(unicode: false),
                        Password = c.String(nullable: false, unicode: false),
                        ZonaId = c.Int(nullable: false),
                        Ciudad = c.String(unicode: false),
                        Direccion = c.String(unicode: false),
                        Estado = c.String(unicode: false),
                        FechaRegistro = c.DateTime(nullable: false, precision: 0),
                        genero = c.String(unicode: false),
                        ChefSeleccionadoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Chefs", t => t.ChefSeleccionadoId, cascadeDelete: true)
                .ForeignKey("dbo.Zonas", t => t.ZonaId, cascadeDelete: true)
                .Index(t => t.ZonaId)
                .Index(t => t.ChefSeleccionadoId);
            
            CreateTable(
                "dbo.MenuPedidoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PedidoId = c.Int(nullable: false),
                        TituloMenu = c.String(unicode: false),
                        PrecioMenu = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Entrante = c.String(unicode: false),
                        Primero = c.String(unicode: false),
                        Segundo = c.String(unicode: false),
                        Guarnicion = c.String(unicode: false),
                        Postre = c.String(unicode: false),
                        TiempoCocinado = c.Int(nullable: false),
                        Ingredientes = c.String(unicode: false),
                        Utensilios = c.String(unicode: false),
                        Cantidad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pedidoes", t => t.PedidoId, cascadeDelete: true)
                .Index(t => t.PedidoId);
            
            CreateTable(
                "dbo.Pedidoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NPedido = c.String(unicode: false),
                        NombreApellidos = c.String(unicode: false),
                        Direccion = c.String(unicode: false),
                        CP = c.String(unicode: false),
                        Estado = c.String(unicode: false),
                        UsuarioId = c.Int(nullable: false),
                        ZonaId = c.Int(nullable: false),
                        PrecioTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Comentario = c.String(unicode: false),
                        FechaPedido = c.DateTime(nullable: false, precision: 0),
                        NombreChef = c.String(unicode: false),
                        TipoCocina = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: true)
                .ForeignKey("dbo.Zonas", t => t.ZonaId, cascadeDelete: true)
                .Index(t => t.UsuarioId)
                .Index(t => t.ZonaId);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(unicode: false),
                        Descripcion = c.String(unicode: false),
                        EntranteId = c.Int(),
                        PrimeroId = c.Int(),
                        SegundoId = c.Int(),
                        GuarnicionId = c.Int(),
                        PostreId = c.Int(),
                        Imagen = c.String(unicode: false),
                        TiempoCocinado = c.Int(nullable: false),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Valoracion = c.Double(nullable: false),
                        TipoCocinaId = c.Int(nullable: false),
                        Categoria = c.String(unicode: false),
                        Ingredientes = c.String(unicode: false),
                        Utensilios = c.String(unicode: false),
                        EstaOculto = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Platoes", t => t.EntranteId)
                .ForeignKey("dbo.Platoes", t => t.GuarnicionId)
                .ForeignKey("dbo.Platoes", t => t.PostreId)
                .ForeignKey("dbo.Platoes", t => t.PrimeroId)
                .ForeignKey("dbo.Platoes", t => t.SegundoId)
                .ForeignKey("dbo.TipoCocinas", t => t.TipoCocinaId, cascadeDelete: true)
                .Index(t => t.EntranteId)
                .Index(t => t.PrimeroId)
                .Index(t => t.SegundoId)
                .Index(t => t.GuarnicionId)
                .Index(t => t.PostreId)
                .Index(t => t.TipoCocinaId);
            
            CreateTable(
                "dbo.Platoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(unicode: false),
                        Descripcion = c.String(unicode: false),
                        Imagen = c.String(unicode: false),
                        TiempoCocinado = c.Int(nullable: false),
                        EsEntrante = c.Boolean(nullable: false),
                        EsPrimero = c.Boolean(nullable: false),
                        EsSegundo = c.Boolean(nullable: false),
                        EsGuarnicion = c.Boolean(nullable: false),
                        EsPostre = c.Boolean(nullable: false),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Valoracion = c.Double(nullable: false),
                        TipoCocinaId = c.Int(nullable: false),
                        Categoria = c.String(unicode: false),
                        Ingredientes = c.String(unicode: false),
                        Utensilios = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TipoCocinas", t => t.TipoCocinaId, cascadeDelete: true)
                .Index(t => t.TipoCocinaId);
            
            CreateTable(
                "dbo.PlatoPedidoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PedidoId = c.Int(nullable: false),
                        TituloPlato = c.String(unicode: false),
                        PrecioPlato = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TiempoCocinado = c.Int(nullable: false),
                        Ingredientes = c.String(unicode: false),
                        Utensilios = c.String(unicode: false),
                        Cantidad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pedidoes", t => t.PedidoId, cascadeDelete: true)
                .Index(t => t.PedidoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlatoPedidoes", "PedidoId", "dbo.Pedidoes");
            DropForeignKey("dbo.Menus", "TipoCocinaId", "dbo.TipoCocinas");
            DropForeignKey("dbo.Menus", "SegundoId", "dbo.Platoes");
            DropForeignKey("dbo.Menus", "PrimeroId", "dbo.Platoes");
            DropForeignKey("dbo.Menus", "PostreId", "dbo.Platoes");
            DropForeignKey("dbo.Menus", "GuarnicionId", "dbo.Platoes");
            DropForeignKey("dbo.Menus", "EntranteId", "dbo.Platoes");
            DropForeignKey("dbo.Platoes", "TipoCocinaId", "dbo.TipoCocinas");
            DropForeignKey("dbo.MenuPedidoes", "PedidoId", "dbo.Pedidoes");
            DropForeignKey("dbo.Pedidoes", "ZonaId", "dbo.Zonas");
            DropForeignKey("dbo.Pedidoes", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.ComentarioChefs", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.Usuarios", "ZonaId", "dbo.Zonas");
            DropForeignKey("dbo.Usuarios", "ChefSeleccionadoId", "dbo.Chefs");
            DropForeignKey("dbo.ComentarioChefs", "ChefId", "dbo.Chefs");
            DropForeignKey("dbo.Chefs", "ZonaId", "dbo.Zonas");
            DropForeignKey("dbo.Chefs", "TipoCocinaId", "dbo.TipoCocinas");
            DropIndex("dbo.PlatoPedidoes", new[] { "PedidoId" });
            DropIndex("dbo.Platoes", new[] { "TipoCocinaId" });
            DropIndex("dbo.Menus", new[] { "TipoCocinaId" });
            DropIndex("dbo.Menus", new[] { "PostreId" });
            DropIndex("dbo.Menus", new[] { "GuarnicionId" });
            DropIndex("dbo.Menus", new[] { "SegundoId" });
            DropIndex("dbo.Menus", new[] { "PrimeroId" });
            DropIndex("dbo.Menus", new[] { "EntranteId" });
            DropIndex("dbo.Pedidoes", new[] { "ZonaId" });
            DropIndex("dbo.Pedidoes", new[] { "UsuarioId" });
            DropIndex("dbo.MenuPedidoes", new[] { "PedidoId" });
            DropIndex("dbo.Usuarios", new[] { "ChefSeleccionadoId" });
            DropIndex("dbo.Usuarios", new[] { "ZonaId" });
            DropIndex("dbo.ComentarioChefs", new[] { "UsuarioId" });
            DropIndex("dbo.ComentarioChefs", new[] { "ChefId" });
            DropIndex("dbo.Chefs", new[] { "TipoCocinaId" });
            DropIndex("dbo.Chefs", new[] { "ZonaId" });
            DropTable("dbo.PlatoPedidoes");
            DropTable("dbo.Platoes");
            DropTable("dbo.Menus");
            DropTable("dbo.Pedidoes");
            DropTable("dbo.MenuPedidoes");
            DropTable("dbo.Usuarios");
            DropTable("dbo.ComentarioChefs");
            DropTable("dbo.Zonas");
            DropTable("dbo.TipoCocinas");
            DropTable("dbo.Chefs");
        }
    }
}
