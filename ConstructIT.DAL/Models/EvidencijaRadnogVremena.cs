using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructIT.DAL.Models
{
    public class EvidencijaRadnogVremena
    {
        public int EvidencijaRadnogVremenaID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Datum")]
        public DateTime EvRadnVrDatum { get; set; }


        [StringLength(5, ErrorMessage = "Nepravilan unos za 'Vreme Do'"), RegularExpression(@"^(?:[01][0-9]|2[0-3]):[0-5][0-9]$", ErrorMessage = "Nepravilan unos vremena"), Required(ErrorMessage = "'Vreme Od' ne sme biti prazno!")]
        [Display(Name = "Vreme od")]
        public String EvRadnVrVremeOd { get; set; }

        [Display(Name = "Vreme do")]
        [StringLength(5, ErrorMessage = "Nepravilan unos za 'Vreme Od'"), RegularExpression(@"^(?:[01][0-9]|2[0-3]):[0-5][0-9]$", ErrorMessage = "Nepravilan unos vremena"), Required(ErrorMessage = "'Vreme Do' ne sme biti prazno!")]
        public String EvRadnVrVremeDo { get; set; }

        [ForeignKey("Zadatak")]
        [Required]
        [Column(Order = 1)]
        public int ProjekatID { get; set; }

        [ForeignKey("Zadatak")]
        [Required]
        [Column(Order = 2)]
        public int ZadatakID { get; set; }

        [ForeignKey("ProizvodniRadnik")]
        public int ProizvodniRadnikID { get; set; }


        public virtual Zadatak Zadatak { get; set; }

        [ForeignKey("ProizvodniRadnikID")]
        public virtual ProizvodniRadnik ProizvodniRadnik { get; set; }
    }
}
