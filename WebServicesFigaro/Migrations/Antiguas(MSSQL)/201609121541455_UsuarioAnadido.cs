namespace WebServicesFigaro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UsuarioAnadido : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Apellidos = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Imagen = c.String(),
                        Password = c.String(nullable: false),
                        ZonaId = c.Int(nullable: false),
                        Ciudad = c.String(),
                        Direccion = c.String(),
                        Estado = c.String(),
                        FechaRegistro = c.DateTime(nullable: false),
                        genero = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Zonas", t => t.ZonaId, cascadeDelete: true)
                .Index(t => t.ZonaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuarios", "ZonaId", "dbo.Zonas");
            DropIndex("dbo.Usuarios", new[] { "ZonaId" });
            DropTable("dbo.Usuarios");
        }
    }
}
