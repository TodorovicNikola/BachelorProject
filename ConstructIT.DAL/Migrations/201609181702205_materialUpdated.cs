namespace ConstructIT.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class materialUpdated : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Materijal", "MaterijalProizvodjac");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Materijal", "MaterijalProizvodjac", c => c.String(nullable: false, maxLength: 64));
        }
    }
}
