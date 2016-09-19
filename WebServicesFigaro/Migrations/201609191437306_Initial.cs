namespace WebServicesFigaro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MenuPedidoes", "TiempoCocinado", c => c.Int(nullable: true));
            AlterColumn("dbo.PlatoPedidoes", "TiempoCocinado", c => c.Int(nullable: true));

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
