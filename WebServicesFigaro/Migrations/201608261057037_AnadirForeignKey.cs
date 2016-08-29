namespace WebServicesFigaro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnadirForeignKey : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Platoes", "TipoCocinaId");
            AddForeignKey("dbo.Platoes", "TipoCocinaId", "dbo.TipoCocinas", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Platoes", "TipoCocinaId", "dbo.TipoCocinas");
            DropIndex("dbo.Platoes", new[] { "TipoCocinaId" });
        }
    }
}
