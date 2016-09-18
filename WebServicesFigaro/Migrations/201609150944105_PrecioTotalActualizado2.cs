namespace WebServicesFigaro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrecioTotalActualizado2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pedidoes", "PrecioTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pedidoes", "PrecioTotal");
        }
    }
}
