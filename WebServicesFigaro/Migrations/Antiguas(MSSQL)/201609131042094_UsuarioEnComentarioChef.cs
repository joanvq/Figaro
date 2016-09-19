namespace WebServicesFigaro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UsuarioEnComentarioChef : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ComentarioChefs", "UsuarioId", c => c.Int(nullable: false));
            CreateIndex("dbo.ComentarioChefs", "UsuarioId");
            AddForeignKey("dbo.ComentarioChefs", "UsuarioId", "dbo.Usuarios", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ComentarioChefs", "UsuarioId", "dbo.Usuarios");
            DropIndex("dbo.ComentarioChefs", new[] { "UsuarioId" });
            DropColumn("dbo.ComentarioChefs", "UsuarioId");
        }
    }
}
