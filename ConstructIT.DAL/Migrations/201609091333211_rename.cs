namespace ConstructIT.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rename : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.PotrebaStruke", name: "ProjekatiID", newName: "ProjekatID");
            RenameIndex(table: "dbo.PotrebaStruke", name: "IX_ProjekatiID_ZadatakID", newName: "IX_ProjekatID_ZadatakID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.PotrebaStruke", name: "IX_ProjekatID_ZadatakID", newName: "IX_ProjekatiID_ZadatakID");
            RenameColumn(table: "dbo.PotrebaStruke", name: "ProjekatID", newName: "ProjekatiID");
        }
    }
}
