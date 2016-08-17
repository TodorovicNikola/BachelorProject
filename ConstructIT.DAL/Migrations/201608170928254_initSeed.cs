namespace ConstructIT.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initSeed : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DodelaMaterijala",
                c => new
                    {
                        ProjekatID = c.Int(nullable: false),
                        ZadatakID = c.Int(nullable: false),
                        MaterijalID = c.Int(nullable: false),
                        PotrMatOdDatuma = c.DateTime(nullable: false),
                        PotrMatDoDatuma = c.DateTime(nullable: false),
                        DodMatDatumDodele = c.DateTime(nullable: false),
                        DodMatKolicina = c.Single(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProjekatID, t.ZadatakID, t.MaterijalID, t.PotrMatOdDatuma, t.PotrMatDoDatuma, t.DodMatDatumDodele })
                .ForeignKey("dbo.PotrebaMaterijala", t => new { t.ProjekatID, t.ZadatakID, t.MaterijalID, t.PotrMatOdDatuma, t.PotrMatDoDatuma })
                .Index(t => new { t.ProjekatID, t.ZadatakID, t.MaterijalID, t.PotrMatOdDatuma, t.PotrMatDoDatuma });
            
            CreateTable(
                "dbo.PotrebaMaterijala",
                c => new
                    {
                        ProjekatID = c.Int(nullable: false),
                        ZadatakID = c.Int(nullable: false),
                        MaterijalID = c.Int(nullable: false),
                        PotrMatOdDatuma = c.DateTime(nullable: false),
                        PotrMatDoDatuma = c.DateTime(nullable: false),
                        PotrMatKolicina = c.Single(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProjekatID, t.ZadatakID, t.MaterijalID, t.PotrMatOdDatuma, t.PotrMatDoDatuma })
                .ForeignKey("dbo.Materijal", t => t.MaterijalID)
                .ForeignKey("dbo.Zadatak", t => new { t.ProjekatID, t.ZadatakID })
                .Index(t => new { t.ProjekatID, t.ZadatakID })
                .Index(t => t.MaterijalID);
            
            CreateTable(
                "dbo.Materijal",
                c => new
                    {
                        MaterijalID = c.Int(nullable: false, identity: true),
                        MaterijalNaziv = c.String(nullable: false, maxLength: 64),
                        MaterijalProizvodjac = c.String(nullable: false, maxLength: 64),
                        MaterijalOpis = c.String(maxLength: 1024),
                        MaterijalRaspolozivaKolicina = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.MaterijalID);
            
            CreateTable(
                "dbo.Zadatak",
                c => new
                    {
                        ProjekatID = c.Int(nullable: false),
                        ZadatakID = c.Int(nullable: false, identity: true),
                        ZadatakNaziv = c.String(nullable: false, maxLength: 128),
                        ZadatakDatumPocetka = c.DateTime(nullable: false),
                        ZadatakDatumZavrsetka = c.DateTime(nullable: false),
                        ZadatakOpis = c.String(nullable: false, maxLength: 128),
                        StatusID = c.Int(nullable: false),
                        PrioritetID = c.Int(nullable: false),
                        KorisnikID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProjekatID, t.ZadatakID })
                .ForeignKey("dbo.Korisnik", t => t.KorisnikID)
                .ForeignKey("dbo.Prioritet", t => t.PrioritetID)
                .ForeignKey("dbo.Projekat", t => t.ProjekatID)
                .ForeignKey("dbo.Status", t => t.StatusID)
                .Index(t => t.ProjekatID)
                .Index(t => t.StatusID)
                .Index(t => t.PrioritetID)
                .Index(t => t.KorisnikID);
            
            CreateTable(
                "dbo.EvidencijaAngazovanjaMasine",
                c => new
                    {
                        ProjekatID = c.Int(nullable: false),
                        ZadatakID = c.Int(nullable: false),
                        EvidencijaAngazovanjaMasineID = c.Int(nullable: false, identity: true),
                        MasinaID = c.Int(nullable: false),
                        EvidAngMasDatum = c.DateTime(nullable: false),
                        EvidAngMasVremeOd = c.String(nullable: false, maxLength: 5),
                        EvidAngMasVremeDo = c.String(nullable: false, maxLength: 5),
                    })
                .PrimaryKey(t => t.EvidencijaAngazovanjaMasineID)
                .ForeignKey("dbo.Masina", t => t.MasinaID)
                .ForeignKey("dbo.Zadatak", t => new { t.ProjekatID, t.ZadatakID })
                .Index(t => new { t.ProjekatID, t.ZadatakID })
                .Index(t => t.MasinaID);
            
            CreateTable(
                "dbo.Masina",
                c => new
                    {
                        MasinaID = c.Int(nullable: false, identity: true),
                        MasinaProizvodjac = c.String(nullable: false, maxLength: 128),
                        MasinaOpis = c.String(maxLength: 1024),
                        TipMasineID = c.Int(nullable: false),
                        MasinaDostupnaKolicina = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MasinaID)
                .ForeignKey("dbo.TipMasine", t => t.TipMasineID)
                .Index(t => t.TipMasineID);
            
            CreateTable(
                "dbo.TipMasine",
                c => new
                    {
                        TipMasineID = c.Int(nullable: false, identity: true),
                        TipMasineNaziv = c.String(nullable: false, maxLength: 32),
                    })
                .PrimaryKey(t => t.TipMasineID);
            
            CreateTable(
                "dbo.PotrebaTipaMasine",
                c => new
                    {
                        ProjekatID = c.Int(nullable: false),
                        ZadatakID = c.Int(nullable: false),
                        PotrebaTipaMasineID = c.Int(nullable: false, identity: true),
                        PotrTipaMasOdDatuma = c.DateTime(nullable: false),
                        PotrTipaMasDoDatuma = c.DateTime(nullable: false),
                        PotrTipaMasKolicina = c.Int(nullable: false),
                        TipMasineID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PotrebaTipaMasineID)
                .ForeignKey("dbo.TipMasine", t => t.TipMasineID)
                .ForeignKey("dbo.Zadatak", t => new { t.ProjekatID, t.ZadatakID })
                .Index(t => new { t.ProjekatID, t.ZadatakID, t.TipMasineID, t.PotrTipaMasOdDatuma, t.PotrTipaMasDoDatuma }, name: "PTMUniqueness_IDX");
            
            CreateTable(
                "dbo.EvidencijaRadnogVremena",
                c => new
                    {
                        ProjekatID = c.Int(nullable: false),
                        ZadatakID = c.Int(nullable: false),
                        EvidencijaRadnogVremenaID = c.Int(nullable: false, identity: true),
                        EvRadnVrDatum = c.DateTime(nullable: false),
                        EvRadnVrVremeOd = c.String(nullable: false, maxLength: 5),
                        EvRadnVrVremeDo = c.String(nullable: false, maxLength: 5),
                        ProizvodniRadnikID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EvidencijaRadnogVremenaID)
                .ForeignKey("dbo.ProizvodniRadnik", t => t.ProizvodniRadnikID)
                .ForeignKey("dbo.Zadatak", t => new { t.ProjekatID, t.ZadatakID })
                .Index(t => new { t.ProjekatID, t.ZadatakID })
                .Index(t => t.ProizvodniRadnikID);
            
            CreateTable(
                "dbo.ProizvodniRadnik",
                c => new
                    {
                        ProizvodniRadnikID = c.Int(nullable: false, identity: true),
                        ProizRadJMBG = c.String(maxLength: 13),
                        ProizRadIme = c.String(nullable: false, maxLength: 64),
                        ProizRadPrezime = c.String(nullable: false, maxLength: 64),
                        ProizRadEMail = c.String(maxLength: 64),
                        ProizRadAdresa = c.String(maxLength: 64),
                        ProizRadTelKucni = c.String(maxLength: 32),
                        ProizRadTelMob = c.String(maxLength: 32),
                        StrukaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProizvodniRadnikID)
                .ForeignKey("dbo.Struka", t => t.StrukaID)
                .Index(t => t.StrukaID);
            
            CreateTable(
                "dbo.Struka",
                c => new
                    {
                        StrukaID = c.Int(nullable: false, identity: true),
                        StrukaNaziv = c.String(nullable: false, maxLength: 64),
                    })
                .PrimaryKey(t => t.StrukaID);
            
            CreateTable(
                "dbo.PotrebaStruke",
                c => new
                    {
                        ProjekatiID = c.Int(nullable: false),
                        ZadatakID = c.Int(nullable: false),
                        PotrebaStrukeID = c.Int(nullable: false, identity: true),
                        PotrebaStrukeOdDatuma = c.DateTime(nullable: false),
                        PotrebaStrukeDoDatuma = c.DateTime(nullable: false),
                        PotrebaStrukeKolicina = c.Int(nullable: false),
                        StrukaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PotrebaStrukeID)
                .ForeignKey("dbo.Struka", t => t.StrukaID)
                .ForeignKey("dbo.Zadatak", t => new { t.ProjekatiID, t.ZadatakID })
                .Index(t => new { t.ProjekatiID, t.ZadatakID })
                .Index(t => t.StrukaID);
            
            CreateTable(
                "dbo.KomentarZadatak",
                c => new
                    {
                        ProjekatID = c.Int(nullable: false),
                        ZadatakID = c.Int(nullable: false),
                        KomentarZadatakID = c.Int(nullable: false, identity: true),
                        KomentarZadatakNaslov = c.String(nullable: false, maxLength: 32),
                        KomentarZadatakSadrzaj = c.String(nullable: false, maxLength: 1024),
                        KomentarZadatakVremePostavljanja = c.DateTime(nullable: false),
                        KomentarZadatakVremeIzmene = c.DateTime(nullable: false),
                        KorisnikID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProjekatID, t.ZadatakID, t.KomentarZadatakID })
                .ForeignKey("dbo.Korisnik", t => t.KorisnikID)
                .ForeignKey("dbo.Zadatak", t => new { t.ProjekatID, t.ZadatakID })
                .Index(t => new { t.ProjekatID, t.ZadatakID })
                .Index(t => t.KorisnikID);
            
            CreateTable(
                "dbo.Korisnik",
                c => new
                    {
                        KorisnikID = c.Int(nullable: false, identity: true),
                        KorisnikLozinka = c.String(nullable: false, maxLength: 64),
                        KorisnikIme = c.String(nullable: false, maxLength: 64),
                        KorisnikPrezime = c.String(nullable: false, maxLength: 64),
                        KorisnikEMail = c.String(nullable: false, maxLength: 64),
                        KorisnikTip = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.KorisnikID);
            
            CreateTable(
                "dbo.KomentarGalerija",
                c => new
                    {
                        ProjekatID = c.Int(nullable: false),
                        GalerijaDatum = c.DateTime(nullable: false),
                        KomentarGalerijaID = c.Int(nullable: false, identity: true),
                        KomentarGalerijaNaslov = c.String(nullable: false, maxLength: 32),
                        KomentarGalerijaSadrzaj = c.String(nullable: false, maxLength: 1024),
                        KomentarGalerijaVremePostavljanja = c.DateTime(nullable: false),
                        KomentarGalerijaVremeIzmene = c.DateTime(nullable: false),
                        KorisnikID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProjekatID, t.GalerijaDatum, t.KomentarGalerijaID })
                .ForeignKey("dbo.Galerija", t => new { t.ProjekatID, t.GalerijaDatum })
                .ForeignKey("dbo.Korisnik", t => t.KorisnikID)
                .Index(t => new { t.ProjekatID, t.GalerijaDatum })
                .Index(t => t.KorisnikID);
            
            CreateTable(
                "dbo.Galerija",
                c => new
                    {
                        ProjekatID = c.Int(nullable: false),
                        GalerijaDatum = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProjekatID, t.GalerijaDatum })
                .ForeignKey("dbo.Projekat", t => t.ProjekatID)
                .Index(t => t.ProjekatID);
            
            CreateTable(
                "dbo.Projekat",
                c => new
                    {
                        ProjekatID = c.Int(nullable: false, identity: true),
                        ProjekatNaziv = c.String(nullable: false, maxLength: 128),
                        ProjekatKod = c.String(nullable: false, maxLength: 8),
                        ProjekatOpis = c.String(maxLength: 1024),
                        ProjekatAdresa = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ProjekatID)
                .Index(t => t.ProjekatKod, unique: true);
            
            CreateTable(
                "dbo.Slika",
                c => new
                    {
                        ProjekatID = c.Int(nullable: false),
                        GalerijaDatum = c.DateTime(nullable: false),
                        SlikaNaziv = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ProjekatID, t.GalerijaDatum, t.SlikaNaziv })
                .ForeignKey("dbo.Galerija", t => new { t.ProjekatID, t.GalerijaDatum })
                .Index(t => new { t.ProjekatID, t.GalerijaDatum });
            
            CreateTable(
                "dbo.PromenaZadatka",
                c => new
                    {
                        ProjekatID = c.Int(nullable: false),
                        ZadatakID = c.Int(nullable: false),
                        PromenaZadatkaID = c.Int(nullable: false, identity: true),
                        PZ_ZadatakNaziv = c.String(),
                        PZ_ZadatakDatumPocetka = c.DateTime(nullable: false),
                        PZ_ZadatakDatumZavrsetka = c.DateTime(nullable: false),
                        PZ_VremeIzmene = c.DateTime(nullable: false),
                        PZ_StatusID = c.Int(nullable: false),
                        PZ_PrioritetID = c.Int(nullable: false),
                        PZ_KorisnikID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProjekatID, t.ZadatakID, t.PromenaZadatkaID })
                .ForeignKey("dbo.Korisnik", t => t.PZ_KorisnikID)
                .ForeignKey("dbo.Prioritet", t => t.PZ_PrioritetID)
                .ForeignKey("dbo.Status", t => t.PZ_StatusID)
                .ForeignKey("dbo.Zadatak", t => new { t.ProjekatID, t.ZadatakID })
                .Index(t => new { t.ProjekatID, t.ZadatakID })
                .Index(t => t.PZ_StatusID)
                .Index(t => t.PZ_PrioritetID)
                .Index(t => t.PZ_KorisnikID);
            
            CreateTable(
                "dbo.Prioritet",
                c => new
                    {
                        PrioritetID = c.Int(nullable: false, identity: true),
                        PrioritetNaziv = c.String(nullable: false),
                        PrioritetTezina = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.PrioritetID);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        StatusID = c.Int(nullable: false, identity: true),
                        StatusNaziv = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.StatusID);
            
            CreateTable(
                "dbo.ProjekatKorisnik",
                c => new
                    {
                        Projekat_ProjekatID = c.Int(nullable: false),
                        Korisnik_KorisnikID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Projekat_ProjekatID, t.Korisnik_KorisnikID })
                .ForeignKey("dbo.Projekat", t => t.Projekat_ProjekatID, cascadeDelete: true)
                .ForeignKey("dbo.Korisnik", t => t.Korisnik_KorisnikID, cascadeDelete: true)
                .Index(t => t.Projekat_ProjekatID)
                .Index(t => t.Korisnik_KorisnikID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DodelaMaterijala", new[] { "ProjekatID", "ZadatakID", "MaterijalID", "PotrMatOdDatuma", "PotrMatDoDatuma" }, "dbo.PotrebaMaterijala");
            DropForeignKey("dbo.PotrebaMaterijala", new[] { "ProjekatID", "ZadatakID" }, "dbo.Zadatak");
            DropForeignKey("dbo.Zadatak", "StatusID", "dbo.Status");
            DropForeignKey("dbo.Zadatak", "ProjekatID", "dbo.Projekat");
            DropForeignKey("dbo.Zadatak", "PrioritetID", "dbo.Prioritet");
            DropForeignKey("dbo.Zadatak", "KorisnikID", "dbo.Korisnik");
            DropForeignKey("dbo.KomentarZadatak", new[] { "ProjekatID", "ZadatakID" }, "dbo.Zadatak");
            DropForeignKey("dbo.KomentarZadatak", "KorisnikID", "dbo.Korisnik");
            DropForeignKey("dbo.PromenaZadatka", new[] { "ProjekatID", "ZadatakID" }, "dbo.Zadatak");
            DropForeignKey("dbo.PromenaZadatka", "PZ_StatusID", "dbo.Status");
            DropForeignKey("dbo.PromenaZadatka", "PZ_PrioritetID", "dbo.Prioritet");
            DropForeignKey("dbo.PromenaZadatka", "PZ_KorisnikID", "dbo.Korisnik");
            DropForeignKey("dbo.KomentarGalerija", "KorisnikID", "dbo.Korisnik");
            DropForeignKey("dbo.KomentarGalerija", new[] { "ProjekatID", "GalerijaDatum" }, "dbo.Galerija");
            DropForeignKey("dbo.Slika", new[] { "ProjekatID", "GalerijaDatum" }, "dbo.Galerija");
            DropForeignKey("dbo.Galerija", "ProjekatID", "dbo.Projekat");
            DropForeignKey("dbo.ProjekatKorisnik", "Korisnik_KorisnikID", "dbo.Korisnik");
            DropForeignKey("dbo.ProjekatKorisnik", "Projekat_ProjekatID", "dbo.Projekat");
            DropForeignKey("dbo.EvidencijaRadnogVremena", new[] { "ProjekatID", "ZadatakID" }, "dbo.Zadatak");
            DropForeignKey("dbo.EvidencijaRadnogVremena", "ProizvodniRadnikID", "dbo.ProizvodniRadnik");
            DropForeignKey("dbo.ProizvodniRadnik", "StrukaID", "dbo.Struka");
            DropForeignKey("dbo.PotrebaStruke", new[] { "ProjekatiID", "ZadatakID" }, "dbo.Zadatak");
            DropForeignKey("dbo.PotrebaStruke", "StrukaID", "dbo.Struka");
            DropForeignKey("dbo.EvidencijaAngazovanjaMasine", new[] { "ProjekatID", "ZadatakID" }, "dbo.Zadatak");
            DropForeignKey("dbo.EvidencijaAngazovanjaMasine", "MasinaID", "dbo.Masina");
            DropForeignKey("dbo.Masina", "TipMasineID", "dbo.TipMasine");
            DropForeignKey("dbo.PotrebaTipaMasine", new[] { "ProjekatID", "ZadatakID" }, "dbo.Zadatak");
            DropForeignKey("dbo.PotrebaTipaMasine", "TipMasineID", "dbo.TipMasine");
            DropForeignKey("dbo.PotrebaMaterijala", "MaterijalID", "dbo.Materijal");
            DropIndex("dbo.ProjekatKorisnik", new[] { "Korisnik_KorisnikID" });
            DropIndex("dbo.ProjekatKorisnik", new[] { "Projekat_ProjekatID" });
            DropIndex("dbo.PromenaZadatka", new[] { "PZ_KorisnikID" });
            DropIndex("dbo.PromenaZadatka", new[] { "PZ_PrioritetID" });
            DropIndex("dbo.PromenaZadatka", new[] { "PZ_StatusID" });
            DropIndex("dbo.PromenaZadatka", new[] { "ProjekatID", "ZadatakID" });
            DropIndex("dbo.Slika", new[] { "ProjekatID", "GalerijaDatum" });
            DropIndex("dbo.Projekat", new[] { "ProjekatKod" });
            DropIndex("dbo.Galerija", new[] { "ProjekatID" });
            DropIndex("dbo.KomentarGalerija", new[] { "KorisnikID" });
            DropIndex("dbo.KomentarGalerija", new[] { "ProjekatID", "GalerijaDatum" });
            DropIndex("dbo.KomentarZadatak", new[] { "KorisnikID" });
            DropIndex("dbo.KomentarZadatak", new[] { "ProjekatID", "ZadatakID" });
            DropIndex("dbo.PotrebaStruke", new[] { "StrukaID" });
            DropIndex("dbo.PotrebaStruke", new[] { "ProjekatiID", "ZadatakID" });
            DropIndex("dbo.ProizvodniRadnik", new[] { "StrukaID" });
            DropIndex("dbo.EvidencijaRadnogVremena", new[] { "ProizvodniRadnikID" });
            DropIndex("dbo.EvidencijaRadnogVremena", new[] { "ProjekatID", "ZadatakID" });
            DropIndex("dbo.PotrebaTipaMasine", "PTMUniqueness_IDX");
            DropIndex("dbo.Masina", new[] { "TipMasineID" });
            DropIndex("dbo.EvidencijaAngazovanjaMasine", new[] { "MasinaID" });
            DropIndex("dbo.EvidencijaAngazovanjaMasine", new[] { "ProjekatID", "ZadatakID" });
            DropIndex("dbo.Zadatak", new[] { "KorisnikID" });
            DropIndex("dbo.Zadatak", new[] { "PrioritetID" });
            DropIndex("dbo.Zadatak", new[] { "StatusID" });
            DropIndex("dbo.Zadatak", new[] { "ProjekatID" });
            DropIndex("dbo.PotrebaMaterijala", new[] { "MaterijalID" });
            DropIndex("dbo.PotrebaMaterijala", new[] { "ProjekatID", "ZadatakID" });
            DropIndex("dbo.DodelaMaterijala", new[] { "ProjekatID", "ZadatakID", "MaterijalID", "PotrMatOdDatuma", "PotrMatDoDatuma" });
            DropTable("dbo.ProjekatKorisnik");
            DropTable("dbo.Status");
            DropTable("dbo.Prioritet");
            DropTable("dbo.PromenaZadatka");
            DropTable("dbo.Slika");
            DropTable("dbo.Projekat");
            DropTable("dbo.Galerija");
            DropTable("dbo.KomentarGalerija");
            DropTable("dbo.Korisnik");
            DropTable("dbo.KomentarZadatak");
            DropTable("dbo.PotrebaStruke");
            DropTable("dbo.Struka");
            DropTable("dbo.ProizvodniRadnik");
            DropTable("dbo.EvidencijaRadnogVremena");
            DropTable("dbo.PotrebaTipaMasine");
            DropTable("dbo.TipMasine");
            DropTable("dbo.Masina");
            DropTable("dbo.EvidencijaAngazovanjaMasine");
            DropTable("dbo.Zadatak");
            DropTable("dbo.Materijal");
            DropTable("dbo.PotrebaMaterijala");
            DropTable("dbo.DodelaMaterijala");
        }
    }
}
