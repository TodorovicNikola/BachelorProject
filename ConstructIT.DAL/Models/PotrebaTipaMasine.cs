using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructIT.DAL.Models
{
    public class PotrebaTipaMasine
    {
        public int PotrebaTipaMasineID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Od datuma")]
        [Required(ErrorMessage = "'Od datuma' ne sme biti neodređeno!")]
        [Index("PTMUniqueness_IDX", 4)]
        public DateTime PotrTipaMasOdDatuma { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Do datuma")]
        [Required(ErrorMessage = "'Do datuma' ne sme biti neodređeno!")]
        [Index("PTMUniqueness_IDX", 5)]
        public DateTime PotrTipaMasDoDatuma { get; set; }

        [Required(ErrorMessage = "'Potrebna Količina' ne sme biti neodređena!")]
        [Display(Name = "Potrebna količina")]
        public int PotrTipaMasKolicina { get; set; }

        [ForeignKey("Zadatak")]
        [Required]
        [Index("PTMUniqueness_IDX", 1)]
        [Column(Order = 1)]
        public int ProjekatID { get; set; }

        [ForeignKey("Zadatak")]
        [Required]
        [Index("PTMUniqueness_IDX", 2)]
        [Column(Order = 2)]
        public int ZadatakID { get; set; }

        [ForeignKey("TipMasine")]
        [Required]
        [Index("PTMUniqueness_IDX", 3)]
        public int TipMasineID { get; set; }


        public virtual TipMasine TipMasine { get; set; }
        public virtual Zadatak Zadatak { get; set; }    
    }
}
