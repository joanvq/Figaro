namespace WebServicesFigaro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMenu : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        Descripcion = c.String(),
                        EntranteId = c.Int(nullable: true),
                        PrimeroId = c.Int(nullable: true),
                        SegundoId = c.Int(nullable: true),
                        GuarnicionId = c.Int(nullable: true),
                        PostreId = c.Int(nullable: true),
                        Imagen = c.String(),
                        TiempoCocinado = c.Int(nullable: true),
                        Precio = c.Decimal(nullable: true, precision: 18, scale: 2),
                        Valoracion = c.Double(nullable: false),
                        TipoCocinaId = c.Int(nullable: false),
                        Categoria = c.String(),
                        Ingredientes = c.String(),
                        Utensilios = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Platoes", t => t.EntranteId, cascadeDelete: false)
                .ForeignKey("dbo.Platoes", t => t.GuarnicionId, cascadeDelete: false)
                .ForeignKey("dbo.Platoes", t => t.PostreId, cascadeDelete: false)
                .ForeignKey("dbo.Platoes", t => t.PrimeroId, cascadeDelete: false)
                .ForeignKey("dbo.Platoes", t => t.SegundoId, cascadeDelete: false)
                .ForeignKey("dbo.TipoCocinas", t => t.TipoCocinaId, cascadeDelete: false)
                .Index(t => t.EntranteId)
                .Index(t => t.PrimeroId)
                .Index(t => t.SegundoId)
                .Index(t => t.GuarnicionId)
                .Index(t => t.PostreId)
                .Index(t => t.TipoCocinaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Menus", "TipoCocinaId", "dbo.TipoCocinas");
            DropForeignKey("dbo.Menus", "SegundoId", "dbo.Platoes");
            DropForeignKey("dbo.Menus", "PrimeroId", "dbo.Platoes");
            DropForeignKey("dbo.Menus", "PostreId", "dbo.Platoes");
            DropForeignKey("dbo.Menus", "GuarnicionId", "dbo.Platoes");
            DropForeignKey("dbo.Menus", "EntranteId", "dbo.Platoes");
            DropIndex("dbo.Menus", new[] { "TipoCocinaId" });
            DropIndex("dbo.Menus", new[] { "PostreId" });
            DropIndex("dbo.Menus", new[] { "GuarnicionId" });
            DropIndex("dbo.Menus", new[] { "SegundoId" });
            DropIndex("dbo.Menus", new[] { "PrimeroId" });
            DropIndex("dbo.Menus", new[] { "EntranteId" });
            DropTable("dbo.Menus");
        }
    }
}
