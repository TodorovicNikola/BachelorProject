namespace ConstructIT.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stareInoveVrednosti : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.PromenaZadatka", name: "PZ_PrioritetID", newName: "PZ_PrioritetIDNovi");
            RenameColumn(table: "dbo.PromenaZadatka", name: "PZ_StatusID", newName: "PZ_StatusIDNovi");
            RenameIndex(table: "dbo.PromenaZadatka", name: "IX_PZ_StatusID", newName: "IX_PZ_StatusIDNovi");
            RenameIndex(table: "dbo.PromenaZadatka", name: "IX_PZ_PrioritetID", newName: "IX_PZ_PrioritetIDNovi");
            AddColumn("dbo.PromenaZadatka", "PZ_ZadatakNazivNovi", c => c.String());
            AddColumn("dbo.PromenaZadatka", "PZ_ZadatakOpisNovi", c => c.String());
            AddColumn("dbo.PromenaZadatka", "PZ_ZadatakDatumPocetkaNovi", c => c.DateTime(nullable: false));
            AddColumn("dbo.PromenaZadatka", "PZ_ZadatakDatumZavrsetkaNovi", c => c.DateTime(nullable: false));
            AddColumn("dbo.PromenaZadatka", "PZ_StatusIDStari", c => c.Int());
            AddColumn("dbo.PromenaZadatka", "PZ_PrioritetIDStari", c => c.Int());
            CreateIndex("dbo.PromenaZadatka", "PZ_StatusIDStari");
            CreateIndex("dbo.PromenaZadatka", "PZ_PrioritetIDStari");
            AddForeignKey("dbo.PromenaZadatka", "PZ_PrioritetIDStari", "dbo.Prioritet", "PrioritetID");
            AddForeignKey("dbo.PromenaZadatka", "PZ_StatusIDStari", "dbo.Status", "StatusID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PromenaZadatka", "PZ_StatusIDStari", "dbo.Status");
            DropForeignKey("dbo.PromenaZadatka", "PZ_PrioritetIDStari", "dbo.Prioritet");
            DropIndex("dbo.PromenaZadatka", new[] { "PZ_PrioritetIDStari" });
            DropIndex("dbo.PromenaZadatka", new[] { "PZ_StatusIDStari" });
            DropColumn("dbo.PromenaZadatka", "PZ_PrioritetIDStari");
            DropColumn("dbo.PromenaZadatka", "PZ_StatusIDStari");
            DropColumn("dbo.PromenaZadatka", "PZ_ZadatakDatumZavrsetkaNovi");
            DropColumn("dbo.PromenaZadatka", "PZ_ZadatakDatumPocetkaNovi");
            DropColumn("dbo.PromenaZadatka", "PZ_ZadatakOpisNovi");
            DropColumn("dbo.PromenaZadatka", "PZ_ZadatakNazivNovi");
            RenameIndex(table: "dbo.PromenaZadatka", name: "IX_PZ_PrioritetIDNovi", newName: "IX_PZ_PrioritetID");
            RenameIndex(table: "dbo.PromenaZadatka", name: "IX_PZ_StatusIDNovi", newName: "IX_PZ_StatusID");
            RenameColumn(table: "dbo.PromenaZadatka", name: "PZ_StatusIDNovi", newName: "PZ_StatusID");
            RenameColumn(table: "dbo.PromenaZadatka", name: "PZ_PrioritetIDNovi", newName: "PZ_PrioritetID");
        }
    }
}
