namespace WebServicesFigaro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PedidoAnadido2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pedidoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NPedido = c.Int(nullable: false),
                        Direccion = c.String(),
                        Estado = c.String(),
                        UsuarioId = c.Int(nullable: false),
                        ZonaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: false)
                .ForeignKey("dbo.Zonas", t => t.ZonaId, cascadeDelete: false)
                .Index(t => t.NPedido, unique: true, name: "NPedidoIndex")
                .Index(t => t.UsuarioId)
                .Index(t => t.ZonaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pedidoes", "ZonaId", "dbo.Zonas");
            DropForeignKey("dbo.Pedidoes", "UsuarioId", "dbo.Usuarios");
            DropIndex("dbo.Pedidoes", new[] { "ZonaId" });
            DropIndex("dbo.Pedidoes", new[] { "UsuarioId" });
            DropIndex("dbo.Pedidoes", "NPedidoIndex");
            DropTable("dbo.Pedidoes");
        }
    }
}
