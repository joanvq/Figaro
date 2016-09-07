namespace WebServicesFigaro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnadidoChef : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chefs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellidos = c.String(),
                        Imagen = c.String(),
                        ImagenFondo = c.String(),
                        Subtitulo = c.String(),
                        ZonaId = c.Int(nullable: false),
                        TipoCocinaId = c.Int(nullable: false),
                        Valoracion = c.Double(nullable: false),
                        Descripcion = c.String(),
                        FechaNacimiento = c.DateTime(nullable: false),
                        Genero = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TipoCocinas", t => t.TipoCocinaId, cascadeDelete: true)
                .ForeignKey("dbo.Zonas", t => t.ZonaId, cascadeDelete: true)
                .Index(t => t.ZonaId)
                .Index(t => t.TipoCocinaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Chefs", "ZonaId", "dbo.Zonas");
            DropForeignKey("dbo.Chefs", "TipoCocinaId", "dbo.TipoCocinas");
            DropIndex("dbo.Chefs", new[] { "TipoCocinaId" });
            DropIndex("dbo.Chefs", new[] { "ZonaId" });
            DropTable("dbo.Chefs");
        }
    }
}
