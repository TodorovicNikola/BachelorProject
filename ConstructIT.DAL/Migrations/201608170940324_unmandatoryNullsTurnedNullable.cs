namespace ConstructIT.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class unmandatoryNullsTurnedNullable : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Zadatak", new[] { "KorisnikID" });
            DropIndex("dbo.PromenaZadatka", new[] { "PZ_StatusID" });
            DropIndex("dbo.PromenaZadatka", new[] { "PZ_PrioritetID" });
            AlterColumn("dbo.Zadatak", "KorisnikID", c => c.Int());
            AlterColumn("dbo.PromenaZadatka", "PZ_StatusID", c => c.Int());
            AlterColumn("dbo.PromenaZadatka", "PZ_PrioritetID", c => c.Int());
            CreateIndex("dbo.Zadatak", "KorisnikID");
            CreateIndex("dbo.PromenaZadatka", "PZ_StatusID");
            CreateIndex("dbo.PromenaZadatka", "PZ_PrioritetID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.PromenaZadatka", new[] { "PZ_PrioritetID" });
            DropIndex("dbo.PromenaZadatka", new[] { "PZ_StatusID" });
            DropIndex("dbo.Zadatak", new[] { "KorisnikID" });
            AlterColumn("dbo.PromenaZadatka", "PZ_PrioritetID", c => c.Int(nullable: false));
            AlterColumn("dbo.PromenaZadatka", "PZ_StatusID", c => c.Int(nullable: false));
            AlterColumn("dbo.Zadatak", "KorisnikID", c => c.Int(nullable: false));
            CreateIndex("dbo.PromenaZadatka", "PZ_PrioritetID");
            CreateIndex("dbo.PromenaZadatka", "PZ_StatusID");
            CreateIndex("dbo.Zadatak", "KorisnikID");
        }
    }
}
