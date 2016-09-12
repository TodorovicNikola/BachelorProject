namespace ConstructIT.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class idNullable : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.PromenaZadatka", new[] { "PZ_KorisnikID" });
            AlterColumn("dbo.PromenaZadatka", "PZ_KorisnikID", c => c.Int());
            CreateIndex("dbo.PromenaZadatka", "PZ_KorisnikID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.PromenaZadatka", new[] { "PZ_KorisnikID" });
            AlterColumn("dbo.PromenaZadatka", "PZ_KorisnikID", c => c.Int(nullable: false));
            CreateIndex("dbo.PromenaZadatka", "PZ_KorisnikID");
        }
    }
}
