namespace ConstructIT.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class korisnikKojiJeUklonjen : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PromenaZadatka", "PZ_KorisnikID", "dbo.Korisnik");
            AddColumn("dbo.PromenaZadatka", "PZ_KorisnikIzmenioID", c => c.Int(nullable: false));
            CreateIndex("dbo.PromenaZadatka", "PZ_KorisnikIzmenioID");
            AddForeignKey("dbo.PromenaZadatka", "PZ_KorisnikID", "dbo.Korisnik", "KorisnikID");
            AddForeignKey("dbo.PromenaZadatka", "PZ_KorisnikIzmenioID", "dbo.Korisnik", "KorisnikID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PromenaZadatka", "PZ_KorisnikIzmenioID", "dbo.Korisnik");
            DropForeignKey("dbo.PromenaZadatka", "PZ_KorisnikID", "dbo.Korisnik");
            DropIndex("dbo.PromenaZadatka", new[] { "PZ_KorisnikIzmenioID" });
            DropColumn("dbo.PromenaZadatka", "PZ_KorisnikIzmenioID");
            AddForeignKey("dbo.PromenaZadatka", "PZ_KorisnikID", "dbo.Korisnik", "KorisnikID");
        }
    }
}
