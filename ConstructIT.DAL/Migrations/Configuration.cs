namespace ConstructIT.DAL.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ConstructIT.DAL.ConstructITDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ConstructIT.DAL.ConstructITDBContext context)
        {/*
            context.Projekti.AddOrUpdate(
                new Projekat { ProjekatNaziv = "Kolektor II", ProjekatKod = "KII", ProjekatOpis = "postea dissentiunt pri eu", ProjekatAdresa = "Bulevar oslobodjenja 15 Novi Sad" },
                new Projekat { ProjekatNaziv = "Obnova Sokolskog doma", ProjekatKod = "OSD", ProjekatOpis = "lucilius constituam", ProjekatAdresa = "Kireska 4/6 Subotica" },
                new Projekat { ProjekatNaziv = "Izgradnja silosa", ProjekatKod = "IS", ProjekatOpis = "His et possim alterum", ProjekatAdresa = "Djure Djakovica 15 Subotica" },
                new Projekat { ProjekatNaziv = "Postavljanje spomenika", ProjekatKod = "WS", ProjekatOpis = "vix te assum menandri", ProjekatAdresa = "Ilirska 5/a Subotica" },
                new Projekat { ProjekatNaziv = "Obnova crkve", ProjekatKod = "M2", ProjekatOpis = "Nec eu modo clita iisque", ProjekatAdresa = "Knez Mihajlova 14 Beograd" }
            );

            context.SaveChanges();

            context.Prioriteti.AddOrUpdate(
                new Prioritet { PrioritetNaziv = "Blokirajuæi", PrioritetTezina = 1.0f },
                new Prioritet { PrioritetNaziv = "Kritièni", PrioritetTezina = 0.8f },
                new Prioritet { PrioritetNaziv = "Veliki", PrioritetTezina = 0.6f },
                new Prioritet { PrioritetNaziv = "Mali", PrioritetTezina = 0.4f },
                new Prioritet { PrioritetNaziv = "Trivijalni", PrioritetTezina = 0.2f }
            );

            context.SaveChanges();

            context.Statusi.AddOrUpdate(
                new Status { StatusNaziv = "Novo" },
                new Status { StatusNaziv = "U toku" },
                new Status { StatusNaziv = "Rešen" },
                new Status { StatusNaziv = "Obustavljen" },
                new Status { StatusNaziv = "Blokiran" }
            );

            context.SaveChanges();
            
            context.Zadaci.AddOrUpdate(
                new Zadatak { ZadatakNaziv = "Rašèišæavanje terena", ProjekatID = 1, ZadatakDatumPocetka = DateTime.Now.AddDays(-8).Date, ZadatakDatumZavrsetka = DateTime.Today.AddDays(-6).Date, PrioritetID = 4, StatusID = 3, ZadatakOpis = " Ex eos harum nullam instructior. Iuvaret iracundia instructior te ius, summo placerat moderatius eam id. Viris sapientem vulputate vis et. Postea essent quaestio cum ei, viderer fabellas urbanitas at usu, dicant persius per id. Idque integre electram id est, pro lorem aperiri periculis et." },
                new Zadatak { ZadatakNaziv = "Skidanje asfalta", ProjekatID = 1, ZadatakDatumPocetka = DateTime.Now.AddDays(-7).Date, ZadatakDatumZavrsetka = DateTime.Today.AddDays(-4).Date, PrioritetID = 4, StatusID = 3, ZadatakOpis = "Qui ut affert evertitur referrentur. Eam quis omnis tacimates in, no mei atqui clita posidonium, eam et sale lucilius eleifend. Magna ignota mentitum quo ea, eu sit magna numquam tincidunt. Euismod inimicus repudiandae est no, te animal dolorum ceteros eam, labitur accommodare qui te. Mutat libris mandamus ne quo, mei ad constituto accommodare." },
                new Zadatak { ZadatakNaziv = "Raskopavanje", ProjekatID = 1, ZadatakDatumPocetka = DateTime.Now.AddDays(-5).Date, ZadatakDatumZavrsetka = DateTime.Today.AddDays(0).Date, PrioritetID = 3, StatusID = 2, ZadatakOpis = "Ad sea numquam moderatius, ne mea sonet utroque epicurei. Aperiam definitiones has te, alterum officiis in qui, posse pertinax sea eu." },
                new Zadatak { ZadatakNaziv = "Vaðenje cevi", ProjekatID = 1, ZadatakDatumPocetka = DateTime.Now.AddDays(1).Date, ZadatakDatumZavrsetka = DateTime.Today.AddDays(8).Date, PrioritetID = 3, StatusID = 1, ZadatakOpis = "Eum te hendrerit disputationi, id appetere voluptatibus necessitatibus has. Vis ut atqui doctus sapientem. An explicari consetetur liberavisse nam, ius cu viris tempor mollis. Illud nominavi mel eu, est tale perpetua ne, nihil nominati eu pro. Feugiat qualisque intellegam vel ne, et platonem mnesarchum usu." },
                new Zadatak { ZadatakNaziv = "Postavljanje cevi", ProjekatID = 1, ZadatakDatumPocetka = DateTime.Now.AddDays(5).Date, ZadatakDatumZavrsetka = DateTime.Today.AddDays(15).Date, PrioritetID = 2, StatusID = 1, ZadatakOpis = "An dictas ocurreret mel, et odio omittam usu. Aperiam dolores an per, mel ut dicat ubique eloquentiam, mei in sale soluta tempor. Mei sonet sadipscing ne, quo cu labore iriure. Vim id labores consectetuer, erat nostrud theophrastus vel id." },
                new Zadatak { ZadatakNaziv = "Zatrpavanje", ProjekatID = 1, ZadatakDatumPocetka = DateTime.Now.AddDays(16).Date, ZadatakDatumZavrsetka = DateTime.Today.AddDays(18).Date, PrioritetID = 4, StatusID = 1, ZadatakOpis = "Nec in solet impedit, et malis referrentur theophrastus his. Ut omnis aeque reprehendunt mei, sed te docendi fierent efficiantur, ex diam reformidans vim. Vix legimus perfecto partiendo ei. Appetere maluisset ad mea, eos an modo partiendo, eu feugait intellegebat vix." },
                new Zadatak { ZadatakNaziv = "Asfaltiranje", ProjekatID = 1, ZadatakDatumPocetka = DateTime.Now.AddDays(17).Date, ZadatakDatumZavrsetka = DateTime.Today.AddDays(20).Date, PrioritetID = 4, StatusID = 1, ZadatakOpis = "Cu mel accumsan pertinacia liberavisse, cu magna aperiam adipisci vix. Ei sanctus ocurreret mei, impedit partiendo corrumpit ius ad. Altera albucius fabellas duo eu, tollit consulatu repudiare duo ad, nec ei sanctus hendrerit voluptatibus. Pro ea sumo justo mandamus, tritani maluisset qui ex" },
                new Zadatak { ZadatakNaziv = "Postavljanje skele", ProjekatID = 2, ZadatakDatumPocetka = DateTime.Now.AddDays(-5).Date, ZadatakDatumZavrsetka = DateTime.Today.AddDays(-3).Date, PrioritetID = 4, StatusID = 3, ZadatakOpis = "Ut vix solet epicuri. Eum no veri animal ancillae, possim malorum an mea. No nostro dicunt interesset usu. Et wisi commodo mel. An eam harum altera mnesarchum" },
                new Zadatak { ZadatakNaziv = "Obnova stepeništa", ProjekatID = 2, ZadatakDatumPocetka = DateTime.Now.AddDays(-4).Date, ZadatakDatumZavrsetka = DateTime.Today.AddDays(2).Date, PrioritetID = 3, StatusID = 2, ZadatakOpis = "Id mel tation oblique sensibus. No nam mentitum senserit, eum integre offendit an. Ea alii case lobortis qui, mei malorum veritus quaestio ea. Te eros placerat postulant nam, viris elaboraret suscipiantur ad mei, prompta alterum ocurreret sit ei. Sed ex melius dolorem" },
                new Zadatak { ZadatakNaziv = "Obnova fasade", ProjekatID = 2, ZadatakDatumPocetka = DateTime.Now.AddDays(-2).Date, ZadatakDatumZavrsetka = DateTime.Today.AddDays(20).Date, PrioritetID = 1, StatusID = 2, ZadatakOpis = "Vel ei praesent ullamcorper. Ut vis dolore ceteros, voluptua aliquando complectitur ne vix. Mei movet fabellas eu, per debet legimus pertinacia ei. Facete nominavi quaerendum ut nec. Modo perpetua rationibus usu te, eum eu fastidii repudiandae." },
                new Zadatak { ZadatakNaziv = "Završni radovi", ProjekatID = 2, ZadatakDatumPocetka = DateTime.Now.AddDays(18).Date, ZadatakDatumZavrsetka = DateTime.Today.AddDays(21).Date, PrioritetID = 4, StatusID = 1, ZadatakOpis = "Dicat debet insolens qui in, omnis nostro prompta ad vim, ut choro delenit fastidii duo. Brute justo essent mel ne, sed id virtute vivendum. Vidisse fabellas cotidieque ne nam, munere convenire per ad, illum latine qualisque ei ius. Dictas everti propriae eos at, eos dico virtute civibus an, eu mei eius utroque." },
                new Zadatak { ZadatakNaziv = "Skidanje skele", ProjekatID = 2, ZadatakDatumPocetka = DateTime.Now.AddDays(21).Date, ZadatakDatumZavrsetka = DateTime.Today.AddDays(23).Date, PrioritetID = 5, StatusID = 1, ZadatakOpis = "Iriure molestiae ad sea. Ex alii repudiare per. Ne nec agam regione, cum sonet putent option ei, utroque expetenda pri et. Ea duo primis bonorum. Usu mucius complectitur ei. Dolore invenire mandamus in sed." },
                new Zadatak { ZadatakNaziv = "Rašèišæavanje terena", ProjekatID = 3, ZadatakDatumPocetka = DateTime.Now.AddDays(-15).Date, ZadatakDatumZavrsetka = DateTime.Today.AddDays(-12).Date, PrioritetID = 4, StatusID = 3, ZadatakOpis = "Cu mei causae vivendum. Quo ea meis comprehensam. Libris consectetuer ne usu, ne cum suscipit explicari reformidans. Et principes sententiae eos, petentium repudiandae in mel. Sumo minimum voluptaria cu eum, eos duis novum nominati no." },
                new Zadatak { ZadatakNaziv = "Kopanje", ProjekatID = 3, ZadatakDatumPocetka = DateTime.Now.AddDays(-13).Date, ZadatakDatumZavrsetka = DateTime.Today.AddDays(-8).Date, PrioritetID = 3, StatusID = 3, ZadatakOpis = "Te nonumes dolorem posidonium his, everti mollis an pro. Tibique partiendo te qui, in sonet officiis scripserit per, mea paulo molestiae consectetuer ut. Ius ad facete dissentiet necessitatibus, pri essent suscipit eu. Eu solet mucius meliore eos, cu illum affert impedit eum." },
                new Zadatak { ZadatakNaziv = "Temelj", ProjekatID = 3, ZadatakDatumPocetka = DateTime.Now.AddDays(-9).Date, ZadatakDatumZavrsetka = DateTime.Today.AddDays(3).Date, PrioritetID = 3, StatusID = 2, ZadatakOpis = "Ne oblique intellegebat nec. Pro at quando verterem honestatis, ad nonumy labores eos. Vocent gubergren his ad, at dicta iudicabit pro, quod platonem mel ei. Quo scribentur delicatissimi in. Nec equidem detracto ne, vivendo neglegentur eum no." },
                new Zadatak { ZadatakNaziv = "Izgradnja stukture", ProjekatID = 3, ZadatakDatumPocetka = DateTime.Now.AddDays(6).Date, ZadatakDatumZavrsetka = DateTime.Today.AddDays(36).Date, PrioritetID = 2, StatusID = 1, ZadatakOpis = "Vim no harum laoreet voluptatum. Ei ceteros dolores ancillae pri, vim id expetenda sadipscing. Melius debitis pertinax ut pri, at vis sumo volutpat. No simul appetere vim. Aeque persequeris efficiantur ei nec. Duo no elitr nemore. His assum tractatos no, utinam iisque fabellas vim an." },
                new Zadatak { ZadatakNaziv = "Završni radovi", ProjekatID = 3, ZadatakDatumPocetka = DateTime.Now.AddDays(30).Date, ZadatakDatumZavrsetka = DateTime.Today.AddDays(37).Date, PrioritetID = 4, StatusID = 1, ZadatakOpis = "Ullum prodesset complectitur in pro. Graece aeterno vidisse cu vix. Sea aeque vituperatoribus an, vim adipisci consequuntur ei. No porro cotidieque ius." }
            );

            context.SaveChanges();

            context.Materijali.AddOrUpdate(
                new Materijal { MaterijalNaziv = "Cement", MaterijalOpis = "metus sit amet imperdiet maximus", MaterijalProizvodjac = "Hipopotamus", MaterijalRaspolozivaKolicina = 90.0f },
                new Materijal { MaterijalNaziv = "Kreè", MaterijalOpis = "Vivamus pharetra rhoncus dolor", MaterijalProizvodjac = "Puma", MaterijalRaspolozivaKolicina = 130.0f },
                new Materijal { MaterijalNaziv = "Farba osnovna", MaterijalOpis = "elementum justo nec", MaterijalProizvodjac = "Moler", MaterijalRaspolozivaKolicina = 180.0f },
                new Materijal { MaterijalNaziv = "Cigla", MaterijalOpis = "vehicula arcu quam", MaterijalProizvodjac = "Zada", MaterijalRaspolozivaKolicina = 100.0f },
                new Materijal { MaterijalNaziv = "Šljunak", MaterijalOpis = "Nullam imperdiet elit", MaterijalProizvodjac = "Zada", MaterijalRaspolozivaKolicina = 300.0f },
                new Materijal { MaterijalNaziv = "Šperploèa", MaterijalOpis = "metus sit amet imperdiet maximus", MaterijalProizvodjac = "Puma", MaterijalRaspolozivaKolicina = 15.0f },
                new Materijal { MaterijalNaziv = "Git", MaterijalOpis = "elementum justo nec", MaterijalProizvodjac = "Hipopotamus", MaterijalRaspolozivaKolicina = 10.0f },
                new Materijal { MaterijalNaziv = "Silikon", MaterijalOpis = "raesent sed vehicula mauris", MaterijalProizvodjac = "Zada", MaterijalRaspolozivaKolicina = 250.0f },
                new Materijal { MaterijalNaziv = "Malter", MaterijalOpis = "Vivamus pharetra rhoncus dolor", MaterijalProizvodjac = "Moler", MaterijalRaspolozivaKolicina = 400.0f },
                new Materijal { MaterijalNaziv = "Gips", MaterijalOpis = "vehicula arcu quam", MaterijalProizvodjac = "Zada", MaterijalRaspolozivaKolicina = 200.0f },
                new Materijal { MaterijalNaziv = "Drvene ploèe 35x15", MaterijalOpis = "metus sit amet imperdiet maximus", MaterijalProizvodjac = "Hipopotamus", MaterijalRaspolozivaKolicina = 85.0f },
                new Materijal { MaterijalNaziv = "Šaraf 3cm", MaterijalOpis = "Nullam imperdiet elit", MaterijalProizvodjac = "Moler", MaterijalRaspolozivaKolicina = 80.0f },
                new Materijal { MaterijalNaziv = "Ekser 5cm", MaterijalOpis = "Vivamus pharetra rhoncus dolor", MaterijalProizvodjac = "Puma", MaterijalRaspolozivaKolicina = 250.0f },
                new Materijal { MaterijalNaziv = "Pur pena", MaterijalOpis = "raesent sed vehicula mauris", MaterijalProizvodjac = "Hipopotamus", MaterijalRaspolozivaKolicina = 60.0f }
            );

            context.SaveChanges();

            context.Struke.AddOrUpdate(
                new Struka { StrukaNaziv = "Moler" },
                new Struka { StrukaNaziv = "Zavarivaè" },
                new Struka { StrukaNaziv = "Bravar" },
                new Struka { StrukaNaziv = "Tesar" },
                new Struka { StrukaNaziv = "Ispomoæ" },
                new Struka { StrukaNaziv = "Zidar" }
            );

            context.SaveChanges();

            context.ProizvodniRadnici.AddOrUpdate(
                new ProizvodniRadnik { ProizRadIme = "Nikola", ProizRadPrezime = "Todoroviæ", ProizRadEMail = "dami@yahoo.com", ProizRadJMBG = "1535353452231", ProizRadAdresa = "", StrukaID = 1 },
                new ProizvodniRadnik { ProizRadIme = "Nenad", ProizRadPrezime = "Todoroviæ", ProizRadEMail = "dami@yahoo.com", ProizRadJMBG = "", ProizRadTelKucni = "0612421419", ProizRadAdresa = "", StrukaID = 1, },
                new ProizvodniRadnik { ProizRadIme = "Branimir", ProizRadPrezime = "Todoroviæ", ProizRadEMail = "dami@yahoo.com", ProizRadJMBG = "", ProizRadTelKucni = "0614253429", ProizRadAdresa = "", StrukaID = 1, },
                new ProizvodniRadnik { ProizRadIme = "Pero", ProizRadPrezime = "Todoroviæ", ProizRadEMail = "dami@yahoo.com", ProizRadJMBG = "1242342525241", ProizRadTelKucni = "0623425659", ProizRadAdresa = "", StrukaID = 1, ProizRadTelMob = "0625252329" },
                new ProizvodniRadnik { ProizRadIme = "Mujo", ProizRadPrezime = "Mujiæ", ProizRadEMail = "dami@yahoo.com", ProizRadJMBG = "", ProizRadTelKucni = "0625235239", ProizRadAdresa = "", StrukaID = 2 },
                new ProizvodniRadnik { ProizRadIme = "Haso", ProizRadPrezime = "Hasiæ", ProizRadEMail = "dami@yahoo.com", ProizRadJMBG = "", ProizRadAdresa = "", StrukaID = 2 },
                new ProizvodniRadnik { ProizRadIme = "Bosanac", ProizRadPrezime = "Bosanèiæ", ProizRadEMail = "dami@yahoo.com", ProizRadJMBG = "", ProizRadAdresa = "", StrukaID = 2 },
                new ProizvodniRadnik { ProizRadIme = "Petar", ProizRadPrezime = "Petroviæ", ProizRadEMail = "dami@yahoo.com", ProizRadJMBG = "1324523512531", ProizRadAdresa = "", StrukaID = 2, ProizRadTelMob = "0634536439" },
                new ProizvodniRadnik { ProizRadIme = "Vedran", ProizRadPrezime = "Vedriæ", ProizRadEMail = "dami@yahoo.com", ProizRadJMBG = "", ProizRadAdresa = "", StrukaID = 3 },
                new ProizvodniRadnik { ProizRadIme = "Savo", ProizRadPrezime = "Oroz", ProizRadEMail = "dami@yahoo.com", ProizRadJMBG = "", ProizRadAdresa = "", StrukaID = 3 },
                new ProizvodniRadnik { ProizRadIme = "Milun", ProizRadPrezime = "Milutinoviæ", ProizRadEMail = "dami@yahoo.com", ProizRadJMBG = "", ProizRadAdresa = "", StrukaID = 3 },
                new ProizvodniRadnik { ProizRadIme = "Vladan", ProizRadPrezime = "Vladanov", ProizRadEMail = "dami@yahoo.com", ProizRadJMBG = "", ProizRadTelKucni = "0623425219", ProizRadAdresa = "", StrukaID = 4, ProizRadTelMob = "0612435239" },
                new ProizvodniRadnik { ProizRadIme = "Žarko", ProizRadPrezime = "Žarkiæ", ProizRadEMail = "dami@yahoo.com", ProizRadJMBG = "", ProizRadAdresa = "", StrukaID = 4 },
                new ProizvodniRadnik { ProizRadIme = "Ognjen", ProizRadPrezime = "Ognjenoviæ", ProizRadEMail = "dami@yahoo.com", ProizRadJMBG = "", ProizRadTelKucni = "0623362222", ProizRadAdresa = "", StrukaID = 4, ProizRadTelMob = "0623452563" },
                new ProizvodniRadnik { ProizRadIme = "Garan", ProizRadPrezime = "Gariæ", ProizRadEMail = "dami@yahoo.com", ProizRadJMBG = "1223445235231", ProizRadAdresa = "", StrukaID = 6, },
                new ProizvodniRadnik { ProizRadIme = "Goran", ProizRadPrezime = "Goriæ", ProizRadEMail = "dami@yahoo.com", ProizRadJMBG = "1263565634531", ProizRadTelKucni = "0365636329", ProizRadAdresa = "", StrukaID = 6, ProizRadTelMob = "0636335329" },
                new ProizvodniRadnik { ProizRadIme = "Zoran", ProizRadPrezime = "Zoriæ", ProizRadEMail = "dami@yahoo.com", ProizRadJMBG = "", ProizRadAdresa = "", StrukaID = 6 },
                new ProizvodniRadnik { ProizRadIme = "Miša", ProizRadPrezime = "Mitroviæ", ProizRadEMail = "dami@yahoo.com", ProizRadJMBG = "", ProizRadAdresa = "", StrukaID = 6 },
                new ProizvodniRadnik { ProizRadIme = "Gliša", ProizRadPrezime = "Glišiæ", ProizRadEMail = "dami@yahoo.com", ProizRadJMBG = "", ProizRadAdresa = "", StrukaID = 5, ProizRadTelMob = "0324532229" }
        );

            context.SaveChanges();

            context.TipoviMasina.AddOrUpdate(
                new TipMasine { TipMasineNaziv = "Bager 500" },
                new TipMasine { TipMasineNaziv = "Bager 250" },
                new TipMasine { TipMasineNaziv = "Mešalica 100" },
                new TipMasine { TipMasineNaziv = "Dizalica" },
                new TipMasine { TipMasineNaziv = "Rovokopaè" },
                new TipMasine { TipMasineNaziv = "Kamion 25" },
                new TipMasine { TipMasineNaziv = "Kamion 50" },
                new TipMasine { TipMasineNaziv = "Mešalica 50" }
            );

            context.SaveChanges();

            context.Masine.AddOrUpdate(
                new Masina { MasinaProizvodjac = "Oktopus", MasinaOpis = "consectetur adipiscing elit", TipMasineID = 1, MasinaDostupnaKolicina = 2 },
                new Masina { MasinaProizvodjac = "Hipopotamus", MasinaOpis = "et bibendum felis justo eu turpis", TipMasineID = 4, MasinaDostupnaKolicina = 3 },
                new Masina { MasinaProizvodjac = "Snajder elektrik", MasinaOpis = "Etiam felis magna", TipMasineID = 5, MasinaDostupnaKolicina = 1 },
                new Masina { MasinaProizvodjac = "Aurora borealis", MasinaOpis = "Donec dui sem", TipMasineID = 3, MasinaDostupnaKolicina = 2 },
                new Masina { MasinaProizvodjac = "Datagram", MasinaOpis = " Donec sit amet hendrerit ipsum", TipMasineID = 3, MasinaDostupnaKolicina = 4 },
                new Masina { MasinaProizvodjac = "Marioneta", MasinaOpis = "Nullam imperdiet elit vel", TipMasineID = 2, MasinaDostupnaKolicina = 1 },
                new Masina { MasinaProizvodjac = "FAP", MasinaOpis = "in finibus massa molestie ", TipMasineID = 6, MasinaDostupnaKolicina = 3 },
                new Masina { MasinaProizvodjac = "Zastava", MasinaOpis = "Vivamus tristique auctor", TipMasineID = 6, MasinaDostupnaKolicina = 3 },
                new Masina { MasinaProizvodjac = "CAT", MasinaOpis = "Ut dolor diam", TipMasineID = 4, MasinaDostupnaKolicina = 2 },
                new Masina { MasinaProizvodjac = "FAP", MasinaOpis = "in finibus massa molestie ", TipMasineID = 7, MasinaDostupnaKolicina = 1 },
                new Masina { MasinaProizvodjac = "Zastava", MasinaOpis = "Vivamus tristique auctor", TipMasineID = 7, MasinaDostupnaKolicina = 3 },
                new Masina { MasinaProizvodjac = "FAP", MasinaOpis = "in finibus massa molestie ", TipMasineID = 7, MasinaDostupnaKolicina = 1 },
                new Masina { MasinaProizvodjac = "Aurora borealis", MasinaOpis = "Donec dui sem", TipMasineID = 8, MasinaDostupnaKolicina = 1 },
                new Masina { MasinaProizvodjac = "Aurora borealis", MasinaOpis = "Donec dui sem", TipMasineID = 8, MasinaDostupnaKolicina = 4 }
            );

            context.SaveChanges();
            */
        }
    }
}
