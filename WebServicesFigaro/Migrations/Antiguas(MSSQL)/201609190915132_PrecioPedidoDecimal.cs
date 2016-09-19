namespace WebServicesFigaro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrecioPedidoDecimal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MenuPedidoes", "PrecioMenu", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.PlatoPedidoes", "PrecioPlato", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PlatoPedidoes", "PrecioPlato", c => c.String());
            AlterColumn("dbo.MenuPedidoes", "PrecioMenu", c => c.String());
        }
    }
}
