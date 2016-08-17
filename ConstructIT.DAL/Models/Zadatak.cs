using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructIT.DAL.Models
{
    public class Zadatak
    {
        [Key]
        [ForeignKey("Projekat")]
        [Column(Order = 0)]
        public int ProjekatID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ZadatakID { get; set; }

        [StringLength(128, ErrorMessage = "'Naziv zadatka' ne sme biti duži od 64 karaktera!"), Required(ErrorMessage = "'Naziv zadatka' ne sme biti prazan!")]
        [Display(Name = "Naziv zadatka")]
        public String ZadatakNaziv { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "'Datum početka' ne sme biti prazan!")]
        [Display(Name = "Datum početka")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ZadatakDatumPocetka { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "'Datum završetka' ne sme biti prazan!")]
        [Display(Name = "Datum završetka")]
        public DateTime ZadatakDatumZavrsetka { get; set; }

        [StringLength(2048, ErrorMessage = "'Opis zadatka' ne sme biti duži od 2048 karaktera!"), Required(ErrorMessage = "'Opis zadatka' ne sme biti prazan!")]
        [Display(Name = "Opis zadatka")]
        public String ZadatakOpis { get; set; }

        [Required]
        [ForeignKey("Status")]
        public int StatusID { get; set; }

        [Required]
        [ForeignKey("Prioritet")]
        public int PrioritetID { get; set; }

        [ForeignKey("KorisnikKomJeDodeljen")]
        public int? KorisnikID { get; set; }


        [ForeignKey("ProjekatID")]
        public virtual Projekat Projekat { get; set; }

        [ForeignKey("StatusID")]
        public virtual Status Status { get; set; }

        [ForeignKey("PrioritetID")]
        public virtual Prioritet Prioritet { get; set; }

        [ForeignKey("KorisnikID")]
        public virtual Korisnik KorisnikKomJeDodeljen { get; set; }

        public ICollection<PotrebaMaterijala> PotrebeMaterijala { get; set; }
        public ICollection<PotrebaTipaMasine> PotrebeTipovaMasina { get; set; }
        public ICollection<PotrebaStruke> PotrebeStruka { get; set; }
        public ICollection<EvidencijaAngazovanjaMasine> EvidencijeAngazovanjaMasina { get; set; }
        public ICollection<EvidencijaRadnogVremena> EvidencijeRadnihVremena { get; set; }
        public ICollection<PromenaZadatka> PromeneZadatka { get; set; }
        public ICollection<KomentarZadatak> KomentariNaZadatak { get; set; }
    }
}
