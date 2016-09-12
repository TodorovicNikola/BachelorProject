using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructIT.DAL.Models
{
    public class PromenaZadatka
    {
        [Key]
        [ForeignKey("Zadatak")]
        [Column(Order = 0)]
        public int ProjekatID { get; set; }

        [Key]
        [ForeignKey("Zadatak")]
        [Column(Order = 1)]
        public int ZadatakID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PromenaZadatkaID { get; set; }

        [Display(Name = "Naziv zadatka")]
        public String PZ_ZadatakNazivStari { get; set; }

        public String PZ_ZadatakNazivNovi { get; set; }

        [Display(Name = "Opis zadatka")]
        public String PZ_ZadatakOpisStari { get; set; }

        public String PZ_ZadatakOpisNovi { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Datum Početka")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? PZ_ZadatakDatumPocetkaStari { get; set; }

        public DateTime? PZ_ZadatakDatumPocetkaNovi { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Datum Završetka")]
        public DateTime? PZ_ZadatakDatumZavrsetkaStari { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? PZ_ZadatakDatumZavrsetkaNovi { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Vreme izmene")]
        public DateTime PZ_VremeIzmene { get; set; }

        [ForeignKey("StatusStari")]
        public int? PZ_StatusIDStari { get; set; }

        [ForeignKey("StatusNovi")]
        public int? PZ_StatusIDNovi { get; set; }

        [ForeignKey("PrioritetStari")]
        public int? PZ_PrioritetIDStari { get; set; }

        [ForeignKey("PrioritetNovi")]
        public int? PZ_PrioritetIDNovi { get; set; }

        [Required]
        [ForeignKey("KorisnikKojiJeIzmenio")]
        public int PZ_KorisnikIzmenioID { get; set; }

        [ForeignKey("KorisnikKojiJeUklonjen")]
        public int? PZ_KorisnikID { get; set; }


        public virtual Zadatak Zadatak { get; set; }

        [ForeignKey("PZ_StatusIDStari")]
        public virtual Status StatusStari { get; set; }

        [ForeignKey("PZ_StatusIDNovi")]
        public virtual Status StatusNovi { get; set; }

        [ForeignKey("PZ_PrioritetIDStari")]
        public virtual Prioritet PrioritetStari { get; set; }

        [ForeignKey("PZ_PrioritetIDNovi")]
        public virtual Prioritet PrioritetNovi { get; set; }

        [ForeignKey("PZ_KorisnikIzmenioID")]
        public virtual Korisnik KorisnikKojiJeIzmenio { get; set; }

        public virtual Korisnik KorisnikKojiJeUklonjen { get; set; }
    }
}
