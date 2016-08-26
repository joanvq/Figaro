namespace WebServicesFigaro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Platoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        Descripcion = c.String(),
                        Imagen = c.String(),
                        TiempoCocinado = c.Int(nullable: false),
                        TipoPlato = c.String(),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Valoracion = c.Double(nullable: false),
                        TipoCocinaId = c.Int(nullable: false),
                        Categoria = c.String(),
                        Ingredientes = c.String(),
                        Utensilios = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TipoCocinas", t => t.TipoCocinaId, cascadeDelete: true)
                .Index(t => t.TipoCocinaId);
            
            CreateTable(
                "dbo.TipoCocinas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Zonas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Platoes", "TipoCocinaId", "dbo.TipoCocinas");
            DropIndex("dbo.Platoes", new[] { "TipoCocinaId" });
            DropTable("dbo.Zonas");
            DropTable("dbo.TipoCocinas");
            DropTable("dbo.Platoes");
        }
    }
}
