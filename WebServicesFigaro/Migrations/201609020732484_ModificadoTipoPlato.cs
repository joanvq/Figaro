namespace WebServicesFigaro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModificadoTipoPlato : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Platoes", "EsEntrante", c => c.Boolean(nullable: false));
            AddColumn("dbo.Platoes", "EsPrimero", c => c.Boolean(nullable: false));
            AddColumn("dbo.Platoes", "EsSegundo", c => c.Boolean(nullable: false));
            AddColumn("dbo.Platoes", "EsGuarnicion", c => c.Boolean(nullable: false));
            AddColumn("dbo.Platoes", "EsPostre", c => c.Boolean(nullable: false));
            DropColumn("dbo.Platoes", "TipoPlato");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Platoes", "TipoPlato", c => c.String());
            DropColumn("dbo.Platoes", "EsPostre");
            DropColumn("dbo.Platoes", "EsGuarnicion");
            DropColumn("dbo.Platoes", "EsSegundo");
            DropColumn("dbo.Platoes", "EsPrimero");
            DropColumn("dbo.Platoes", "EsEntrante");
        }
    }
}
