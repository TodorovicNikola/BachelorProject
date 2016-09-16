namespace ConstructIT.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class clientusersepparation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Korisnik", "KlijentovProjekatID", c => c.Int());
            CreateIndex("dbo.Korisnik", "KlijentovProjekatID");
            AddForeignKey("dbo.Korisnik", "KlijentovProjekatID", "dbo.Projekat", "ProjekatID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Korisnik", "KlijentovProjekatID", "dbo.Projekat");
            DropIndex("dbo.Korisnik", new[] { "KlijentovProjekatID" });
            DropColumn("dbo.Korisnik", "KlijentovProjekatID");
        }
    }
}
