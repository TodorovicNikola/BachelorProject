namespace ConstructIT.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vremeIzmeneUklonjeno : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.KomentarGalerija", "KomentarGalerijaVremePostavljanja", c => c.DateTime());
            DropColumn("dbo.KomentarZadatak", "KomentarZadatakVremeIzmene");
            DropColumn("dbo.KomentarGalerija", "KomentarGalerijaVremeIzmene");
        }
        
        public override void Down()
        {
            AddColumn("dbo.KomentarGalerija", "KomentarGalerijaVremeIzmene", c => c.DateTime(nullable: false));
            AddColumn("dbo.KomentarZadatak", "KomentarZadatakVremeIzmene", c => c.DateTime());
            AlterColumn("dbo.KomentarGalerija", "KomentarGalerijaVremePostavljanja", c => c.DateTime(nullable: false));
        }
    }
}
