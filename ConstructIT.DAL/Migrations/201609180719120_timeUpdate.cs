namespace ConstructIT.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class timeUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EvidencijaAngazovanjaMasine", "EvidAngMasVremeOd", c => c.Int(nullable: false));
            AlterColumn("dbo.EvidencijaAngazovanjaMasine", "EvidAngMasVremeDo", c => c.Int(nullable: false));
            AlterColumn("dbo.EvidencijaRadnogVremena", "EvRadnVrVremeOd", c => c.Int(nullable: false));
            AlterColumn("dbo.EvidencijaRadnogVremena", "EvRadnVrVremeDo", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EvidencijaRadnogVremena", "EvRadnVrVremeDo", c => c.String(nullable: false, maxLength: 5));
            AlterColumn("dbo.EvidencijaRadnogVremena", "EvRadnVrVremeOd", c => c.String(nullable: false, maxLength: 5));
            AlterColumn("dbo.EvidencijaAngazovanjaMasine", "EvidAngMasVremeDo", c => c.String(nullable: false, maxLength: 5));
            AlterColumn("dbo.EvidencijaAngazovanjaMasine", "EvidAngMasVremeOd", c => c.String(nullable: false, maxLength: 5));
        }
    }
}
