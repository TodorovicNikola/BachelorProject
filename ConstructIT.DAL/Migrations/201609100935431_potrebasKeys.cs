namespace ConstructIT.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class potrebasKeys : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DodelaMaterijala", new[] { "ProjekatID", "ZadatakID", "MaterijalID", "PotrMatOdDatuma", "PotrMatDoDatuma" }, "dbo.PotrebaMaterijala");
            DropIndex("dbo.DodelaMaterijala", new[] { "ProjekatID", "ZadatakID", "MaterijalID", "PotrMatOdDatuma", "PotrMatDoDatuma" });
            RenameColumn(table: "dbo.DodelaMaterijala", name: "ProjekatID", newName: "PotrebaMaterijalaID");
            DropPrimaryKey("dbo.DodelaMaterijala");
            DropPrimaryKey("dbo.PotrebaMaterijala");
            AddColumn("dbo.DodelaMaterijala", "DodelaMaterijalaID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.PotrebaMaterijala", "PotrebaMaterijalaID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.DodelaMaterijala", "DodelaMaterijalaID");
            AddPrimaryKey("dbo.PotrebaMaterijala", "PotrebaMaterijalaID");
            CreateIndex("dbo.DodelaMaterijala", "PotrebaMaterijalaID");
            AddForeignKey("dbo.DodelaMaterijala", "PotrebaMaterijalaID", "dbo.PotrebaMaterijala", "PotrebaMaterijalaID");
            DropColumn("dbo.DodelaMaterijala", "ZadatakID");
            DropColumn("dbo.DodelaMaterijala", "MaterijalID");
            DropColumn("dbo.DodelaMaterijala", "PotrMatOdDatuma");
            DropColumn("dbo.DodelaMaterijala", "PotrMatDoDatuma");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DodelaMaterijala", "PotrMatDoDatuma", c => c.DateTime(nullable: false));
            AddColumn("dbo.DodelaMaterijala", "PotrMatOdDatuma", c => c.DateTime(nullable: false));
            AddColumn("dbo.DodelaMaterijala", "MaterijalID", c => c.Int(nullable: false));
            AddColumn("dbo.DodelaMaterijala", "ZadatakID", c => c.Int(nullable: false));
            DropForeignKey("dbo.DodelaMaterijala", "PotrebaMaterijalaID", "dbo.PotrebaMaterijala");
            DropIndex("dbo.DodelaMaterijala", new[] { "PotrebaMaterijalaID" });
            DropPrimaryKey("dbo.PotrebaMaterijala");
            DropPrimaryKey("dbo.DodelaMaterijala");
            DropColumn("dbo.PotrebaMaterijala", "PotrebaMaterijalaID");
            DropColumn("dbo.DodelaMaterijala", "DodelaMaterijalaID");
            AddPrimaryKey("dbo.PotrebaMaterijala", new[] { "ProjekatID", "ZadatakID", "MaterijalID", "PotrMatOdDatuma", "PotrMatDoDatuma" });
            AddPrimaryKey("dbo.DodelaMaterijala", new[] { "ProjekatID", "ZadatakID", "MaterijalID", "PotrMatOdDatuma", "PotrMatDoDatuma", "DodMatDatumDodele" });
            RenameColumn(table: "dbo.DodelaMaterijala", name: "PotrebaMaterijalaID", newName: "ProjekatID");
            CreateIndex("dbo.DodelaMaterijala", new[] { "ProjekatID", "ZadatakID", "MaterijalID", "PotrMatOdDatuma", "PotrMatDoDatuma" });
            AddForeignKey("dbo.DodelaMaterijala", new[] { "ProjekatID", "ZadatakID", "MaterijalID", "PotrMatOdDatuma", "PotrMatDoDatuma" }, "dbo.PotrebaMaterijala", new[] { "ProjekatID", "ZadatakID", "MaterijalID", "PotrMatOdDatuma", "PotrMatDoDatuma" });
        }
    }
}
