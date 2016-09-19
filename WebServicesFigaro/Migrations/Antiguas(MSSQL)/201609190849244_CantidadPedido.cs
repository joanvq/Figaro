namespace WebServicesFigaro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CantidadPedido : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MenuPedidoes", "Cantidad", c => c.Int(nullable: false));
            AddColumn("dbo.PlatoPedidoes", "Cantidad", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PlatoPedidoes", "Cantidad");
            DropColumn("dbo.MenuPedidoes", "Cantidad");
        }
    }
}
