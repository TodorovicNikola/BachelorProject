namespace ConstructIT.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class komentarSlika : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KomentarSlika",
                c => new
                    {
                        SlikaID = c.Int(nullable: false),
                        KomentarSlikaID = c.Int(nullable: false, identity: true),
                        KomentarSlikaNaslov = c.String(nullable: false, maxLength: 32),
                        KomentarSlikaSadrzaj = c.String(nullable: false, maxLength: 1024),
                        KomentarSlikaVremePostavljanja = c.DateTime(nullable: false),
                        KorisnikID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SlikaID, t.KomentarSlikaID })
                .ForeignKey("dbo.Korisnik", t => t.KorisnikID)
                .ForeignKey("dbo.Slika", t => t.SlikaID)
                .Index(t => t.SlikaID)
                .Index(t => t.KorisnikID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KomentarSlika", "SlikaID", "dbo.Slika");
            DropForeignKey("dbo.KomentarSlika", "KorisnikID", "dbo.Korisnik");
            DropIndex("dbo.KomentarSlika", new[] { "KorisnikID" });
            DropIndex("dbo.KomentarSlika", new[] { "SlikaID" });
            DropTable("dbo.KomentarSlika");
        }
    }
}
