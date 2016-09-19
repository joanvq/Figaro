namespace WebServicesFigaro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ComentarioChefAnadido : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ComentarioChefs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        Valoracion = c.Double(nullable: false),
                        ChefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Chefs", t => t.ChefId, cascadeDelete: true)
                .Index(t => t.ChefId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ComentarioChefs", "ChefId", "dbo.Chefs");
            DropIndex("dbo.ComentarioChefs", new[] { "ChefId" });
            DropTable("dbo.ComentarioChefs");
        }
    }
}
