namespace WebServicesFigaro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImagenFondoZona : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Zonas", "ImagenFondo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Zonas", "ImagenFondo");
        }
    }
}
