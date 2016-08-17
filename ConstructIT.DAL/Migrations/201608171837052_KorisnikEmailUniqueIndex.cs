namespace ConstructIT.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KorisnikEmailUniqueIndex : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Korisnik", "KorisnikEMail", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Korisnik", new[] { "KorisnikEMail" });
        }
    }
}
