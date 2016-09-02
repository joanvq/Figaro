namespace WebServicesFigaro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableFKTipoPlato : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Menus", "EntranteId", "dbo.Platoes");
            DropForeignKey("dbo.Menus", "GuarnicionId", "dbo.Platoes");
            DropForeignKey("dbo.Menus", "PostreId", "dbo.Platoes");
            DropForeignKey("dbo.Menus", "PrimeroId", "dbo.Platoes");
            DropForeignKey("dbo.Menus", "SegundoId", "dbo.Platoes");
            DropIndex("dbo.Menus", new[] { "EntranteId" });
            DropIndex("dbo.Menus", new[] { "PrimeroId" });
            DropIndex("dbo.Menus", new[] { "SegundoId" });
            DropIndex("dbo.Menus", new[] { "GuarnicionId" });
            DropIndex("dbo.Menus", new[] { "PostreId" });
            AlterColumn("dbo.Menus", "EntranteId", c => c.Int());
            AlterColumn("dbo.Menus", "PrimeroId", c => c.Int());
            AlterColumn("dbo.Menus", "SegundoId", c => c.Int());
            AlterColumn("dbo.Menus", "GuarnicionId", c => c.Int());
            AlterColumn("dbo.Menus", "PostreId", c => c.Int());
            CreateIndex("dbo.Menus", "EntranteId");
            CreateIndex("dbo.Menus", "PrimeroId");
            CreateIndex("dbo.Menus", "SegundoId");
            CreateIndex("dbo.Menus", "GuarnicionId");
            CreateIndex("dbo.Menus", "PostreId");
            AddForeignKey("dbo.Menus", "EntranteId", "dbo.Platoes", "Id");
            AddForeignKey("dbo.Menus", "GuarnicionId", "dbo.Platoes", "Id");
            AddForeignKey("dbo.Menus", "PostreId", "dbo.Platoes", "Id");
            AddForeignKey("dbo.Menus", "PrimeroId", "dbo.Platoes", "Id");
            AddForeignKey("dbo.Menus", "SegundoId", "dbo.Platoes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Menus", "SegundoId", "dbo.Platoes");
            DropForeignKey("dbo.Menus", "PrimeroId", "dbo.Platoes");
            DropForeignKey("dbo.Menus", "PostreId", "dbo.Platoes");
            DropForeignKey("dbo.Menus", "GuarnicionId", "dbo.Platoes");
            DropForeignKey("dbo.Menus", "EntranteId", "dbo.Platoes");
            DropIndex("dbo.Menus", new[] { "PostreId" });
            DropIndex("dbo.Menus", new[] { "GuarnicionId" });
            DropIndex("dbo.Menus", new[] { "SegundoId" });
            DropIndex("dbo.Menus", new[] { "PrimeroId" });
            DropIndex("dbo.Menus", new[] { "EntranteId" });
            AlterColumn("dbo.Menus", "PostreId", c => c.Int(nullable: false));
            AlterColumn("dbo.Menus", "GuarnicionId", c => c.Int(nullable: false));
            AlterColumn("dbo.Menus", "SegundoId", c => c.Int(nullable: false));
            AlterColumn("dbo.Menus", "PrimeroId", c => c.Int(nullable: false));
            AlterColumn("dbo.Menus", "EntranteId", c => c.Int(nullable: false));
            CreateIndex("dbo.Menus", "PostreId");
            CreateIndex("dbo.Menus", "GuarnicionId");
            CreateIndex("dbo.Menus", "SegundoId");
            CreateIndex("dbo.Menus", "PrimeroId");
            CreateIndex("dbo.Menus", "EntranteId");
            AddForeignKey("dbo.Menus", "SegundoId", "dbo.Platoes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Menus", "PrimeroId", "dbo.Platoes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Menus", "PostreId", "dbo.Platoes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Menus", "GuarnicionId", "dbo.Platoes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Menus", "EntranteId", "dbo.Platoes", "Id", cascadeDelete: true);
        }
    }
}
