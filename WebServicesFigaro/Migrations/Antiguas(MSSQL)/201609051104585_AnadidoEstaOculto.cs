namespace WebServicesFigaro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnadidoEstaOculto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menus", "EstaOculto", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Menus", "EstaOculto");
        }
    }
}
