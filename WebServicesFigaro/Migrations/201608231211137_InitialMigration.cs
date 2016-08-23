namespace WebServicesFigaro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Platoes", "Imagen");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Platoes", "Imagen", c => c.String());
        }
    }
}
