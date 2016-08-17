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
        public String PZ_ZadatakNaziv { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Datum Početka")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PZ_ZadatakDatumPocetka { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Datum Završetka")]
        public DateTime PZ_ZadatakDatumZavrsetka { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Vreme izmene")]
        public DateTime PZ_VremeIzmene { get; set; }

        [ForeignKey("Status")]
        public int? PZ_StatusID { get; set; }

        [ForeignKey("Prioritet")]
        public int? PZ_PrioritetID { get; set; }

        [Required]
        [ForeignKey("KorisnikKojiJeIzmenio")]
        public int PZ_KorisnikID { get; set; }


        public virtual Zadatak Zadatak { get; set; }

        [ForeignKey("PZ_StatusID")]
        public virtual Status Status { get; set; }

        [ForeignKey("PZ_PrioritetID")]
        public virtual Prioritet Prioritet { get; set; }

        [ForeignKey("PZ_KorisnikID")]
        public virtual Korisnik KorisnikKojiJeIzmenio { get; set; }
    }
}
