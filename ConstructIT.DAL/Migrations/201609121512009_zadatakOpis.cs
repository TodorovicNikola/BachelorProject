namespace ConstructIT.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zadatakOpis : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PromenaZadatka", "PZ_ZadatakOpis", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PromenaZadatka", "PZ_ZadatakOpis");
        }
    }
}
