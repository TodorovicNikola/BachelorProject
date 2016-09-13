namespace ConstructIT.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GalleryAndImages : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Slika");
            AddColumn("dbo.Slika", "SlikaID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Slika", "SlikaOpis", c => c.String());
            AlterColumn("dbo.Slika", "SlikaNaziv", c => c.String());
            AddPrimaryKey("dbo.Slika", "SlikaID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Slika");
            AlterColumn("dbo.Slika", "SlikaNaziv", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Slika", "SlikaOpis");
            DropColumn("dbo.Slika", "SlikaID");
            AddPrimaryKey("dbo.Slika", new[] { "ProjekatID", "GalerijaDatum", "SlikaNaziv" });
        }
    }
}
