namespace WebServicesFigaro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuitarForeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Platoes", "TipoCocinaId", "dbo.TipoCocinas");
            DropIndex("dbo.Platoes", new[] { "TipoCocinaId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Platoes", "TipoCocinaId");
            AddForeignKey("dbo.Platoes", "TipoCocinaId", "dbo.TipoCocinas", "Id", cascadeDelete: true);
        }
    }
}
