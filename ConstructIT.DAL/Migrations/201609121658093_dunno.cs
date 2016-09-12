namespace ConstructIT.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dunno : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PromenaZadatka", "PZ_ZadatakNazivStari", c => c.String());
            AddColumn("dbo.PromenaZadatka", "PZ_ZadatakOpisStari", c => c.String());
            AddColumn("dbo.PromenaZadatka", "PZ_ZadatakDatumPocetkaStari", c => c.DateTime(nullable: false));
            AddColumn("dbo.PromenaZadatka", "PZ_ZadatakDatumZavrsetkaStari", c => c.DateTime(nullable: false));
            DropColumn("dbo.PromenaZadatka", "PZ_ZadatakNaziv");
            DropColumn("dbo.PromenaZadatka", "PZ_ZadatakOpis");
            DropColumn("dbo.PromenaZadatka", "PZ_ZadatakDatumPocetka");
            DropColumn("dbo.PromenaZadatka", "PZ_ZadatakDatumZavrsetka");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PromenaZadatka", "PZ_ZadatakDatumZavrsetka", c => c.DateTime(nullable: false));
            AddColumn("dbo.PromenaZadatka", "PZ_ZadatakDatumPocetka", c => c.DateTime(nullable: false));
            AddColumn("dbo.PromenaZadatka", "PZ_ZadatakOpis", c => c.String());
            AddColumn("dbo.PromenaZadatka", "PZ_ZadatakNaziv", c => c.String());
            DropColumn("dbo.PromenaZadatka", "PZ_ZadatakDatumZavrsetkaStari");
            DropColumn("dbo.PromenaZadatka", "PZ_ZadatakDatumPocetkaStari");
            DropColumn("dbo.PromenaZadatka", "PZ_ZadatakOpisStari");
            DropColumn("dbo.PromenaZadatka", "PZ_ZadatakNazivStari");
        }
    }
}
