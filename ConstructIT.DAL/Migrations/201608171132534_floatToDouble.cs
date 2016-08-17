namespace ConstructIT.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class floatToDouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DodelaMaterijala", "DodMatKolicina", c => c.Double(nullable: false));
            AlterColumn("dbo.PotrebaMaterijala", "PotrMatKolicina", c => c.Double(nullable: false));
            AlterColumn("dbo.Materijal", "MaterijalRaspolozivaKolicina", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Materijal", "MaterijalRaspolozivaKolicina", c => c.Single(nullable: false));
            AlterColumn("dbo.PotrebaMaterijala", "PotrMatKolicina", c => c.Single(nullable: false));
            AlterColumn("dbo.DodelaMaterijala", "DodMatKolicina", c => c.Single(nullable: false));
        }
    }
}
