namespace WebServicesFigaro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TipoCocina : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TipoCocinas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TipoCocinas");
        }
    }
}
