namespace ConstructIT.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class galleryKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Slika", new[] { "ProjekatID", "GalerijaDatum" }, "dbo.Galerija");
            DropForeignKey("dbo.KomentarGalerija", new[] { "ProjekatID", "GalerijaDatum" }, "dbo.Galerija");
            DropPrimaryKey("dbo.Galerija");
            AlterColumn("dbo.Galerija", "GalerijaDatum", c => c.DateTime(nullable: false));
            AddPrimaryKey("dbo.Galerija", new[] { "ProjekatID", "GalerijaDatum" });
            AddForeignKey("dbo.Slika", new[] { "ProjekatID", "GalerijaDatum" }, "dbo.Galerija", new[] { "ProjekatID", "GalerijaDatum" });
            AddForeignKey("dbo.KomentarGalerija", new[] { "ProjekatID", "GalerijaDatum" }, "dbo.Galerija", new[] { "ProjekatID", "GalerijaDatum" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KomentarGalerija", new[] { "ProjekatID", "GalerijaDatum" }, "dbo.Galerija");
            DropForeignKey("dbo.Slika", new[] { "ProjekatID", "GalerijaDatum" }, "dbo.Galerija");
            DropPrimaryKey("dbo.Galerija");
            AlterColumn("dbo.Galerija", "GalerijaDatum", c => c.DateTime(nullable: false));
            AddPrimaryKey("dbo.Galerija", new[] { "ProjekatID", "GalerijaDatum" });
            AddForeignKey("dbo.KomentarGalerija", new[] { "ProjekatID", "GalerijaDatum" }, "dbo.Galerija", new[] { "ProjekatID", "GalerijaDatum" });
            AddForeignKey("dbo.Slika", new[] { "ProjekatID", "GalerijaDatum" }, "dbo.Galerija", new[] { "ProjekatID", "GalerijaDatum" });
        }
    }
}
