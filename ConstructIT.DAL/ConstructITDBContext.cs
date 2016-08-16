using ConstructIT.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructIT.DAL
{
    public class ConstructITDBContext : DbContext
    {
        public ConstructITDBContext() : base("ConstructIT") { }

        public virtual DbSet<Projekat> Projekti { get; set; }
        public virtual DbSet<Zadatak> Zadaci { get; set; }
        public virtual DbSet<Korisnik> Korisnici { get; set; }
        public virtual DbSet<Galerija> Galerije { get; set; }
        public virtual DbSet<Slika> Slike { get; set; }
        public virtual DbSet<KomentarGalerija> KomentariNaGalerije { get; set; }
        public virtual DbSet<Status> Statusi { get; set; }
        public virtual DbSet<Prioritet> Prioriteti { get; set; }
        public virtual DbSet<PromenaZadatka> PromeneZadataka { get; set; }
        public virtual DbSet<KomentarZadatak> KomentariNaZadatke { get; set; }
        public virtual DbSet<Struka> Struke { get; set; }
        public virtual DbSet<ProizvodniRadnik> ProizvodniRadnici { get; set; }
        public virtual DbSet<PotrebaStruke> PotrebeStruka { get; set; }
        public virtual DbSet<EvidencijaRadnogVremena> EvidencijeRadnihVremena { get; set; }
        public virtual DbSet<TipMasine> TipoviMasina { get; set; }
        public virtual DbSet<Masina> Masine { get; set; }
        public virtual DbSet<PotrebaTipaMasine> PotrebeTipovaMasina { get; set; }
        public virtual DbSet<EvidencijaAngazovanjaMasine> EvidencijeAngazovanjaMasina { get; set; }
        public virtual DbSet<Materijal> Materijali { get; set; }
        public virtual DbSet<PotrebaMaterijala> PotrebeMaterijala { get; set; }
        public virtual DbSet<DodelaMaterijala> DodeleMaterijala { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }
    }
}
