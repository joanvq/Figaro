namespace WebServicesFigaro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImagen : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TipoCocinas", "Imagen", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TipoCocinas", "Imagen");
        }
    }
}
