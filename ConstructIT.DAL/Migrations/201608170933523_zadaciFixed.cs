namespace ConstructIT.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zadaciFixed : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Zadatak", "ZadatakOpis", c => c.String(nullable: false, maxLength: 2048));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Zadatak", "ZadatakOpis", c => c.String(nullable: false, maxLength: 128));
        }
    }
}
