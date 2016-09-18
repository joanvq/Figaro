namespace WebServicesFigaro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MenuPlatoPedidosAnadidos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MenuPedidoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PedidoId = c.Int(nullable: false),
                        TituloMenu = c.String(),
                        PrecioMenu = c.String(),
                        Entrante = c.String(),
                        Primero = c.String(),
                        Segundo = c.String(),
                        Guarnicion = c.String(),
                        Postre = c.String(),
                        TiempoCocinado = c.String(),
                        Ingredientes = c.String(),
                        Utensilios = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pedidoes", t => t.PedidoId, cascadeDelete: true)
                .Index(t => t.PedidoId);
            
            CreateTable(
                "dbo.PlatoPedidoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PedidoId = c.Int(nullable: false),
                        TituloPlato = c.String(),
                        PrecioPlato = c.String(),
                        TiempoCocinado = c.String(),
                        Ingredientes = c.String(),
                        Utensilios = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pedidoes", t => t.PedidoId, cascadeDelete: true)
                .Index(t => t.PedidoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlatoPedidoes", "PedidoId", "dbo.Pedidoes");
            DropForeignKey("dbo.MenuPedidoes", "PedidoId", "dbo.Pedidoes");
            DropIndex("dbo.PlatoPedidoes", new[] { "PedidoId" });
            DropIndex("dbo.MenuPedidoes", new[] { "PedidoId" });
            DropTable("dbo.PlatoPedidoes");
            DropTable("dbo.MenuPedidoes");
        }
    }
}
