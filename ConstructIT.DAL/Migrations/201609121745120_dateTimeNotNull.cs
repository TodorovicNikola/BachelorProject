namespace ConstructIT.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dateTimeNotNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PromenaZadatka", "PZ_ZadatakDatumPocetkaStari", c => c.DateTime());
            AlterColumn("dbo.PromenaZadatka", "PZ_ZadatakDatumPocetkaNovi", c => c.DateTime());
            AlterColumn("dbo.PromenaZadatka", "PZ_ZadatakDatumZavrsetkaStari", c => c.DateTime());
            AlterColumn("dbo.PromenaZadatka", "PZ_ZadatakDatumZavrsetkaNovi", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PromenaZadatka", "PZ_ZadatakDatumZavrsetkaNovi", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PromenaZadatka", "PZ_ZadatakDatumZavrsetkaStari", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PromenaZadatka", "PZ_ZadatakDatumPocetkaNovi", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PromenaZadatka", "PZ_ZadatakDatumPocetkaStari", c => c.DateTime(nullable: false));
        }
    }
}
