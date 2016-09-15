namespace ConstructIT.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bla : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.KomentarZadatak", "KomentarZadatakVremeIzmene", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.KomentarZadatak", "KomentarZadatakVremeIzmene", c => c.DateTime(nullable: false));
        }
    }
}
