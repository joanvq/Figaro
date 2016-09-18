namespace WebServicesFigaro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CpActualizado2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pedidoes", "CP", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pedidoes", "CP");
        }
    }
}
