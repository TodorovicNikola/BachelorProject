using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructIT.DAL.Models
{
    public class EvidencijaAngazovanjaMasine
    {
        public int EvidencijaAngazovanjaMasineID { get; set; }

        [Required]
        [ForeignKey("Zadatak")]
        [Column(Order = 1)]
        public int ProjekatID { get; set; }

        [Required]
        [ForeignKey("Zadatak")]
        [Column(Order = 2)]
        public int ZadatakID { get; set; }

        [Required]
        [ForeignKey("Masina")]
        public int MasinaID { get; set; }

        [Required(ErrorMessage = "'Datum' ne sme biti neodređen!")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Datum")]
        public DateTime EvidAngMasDatum { get; set; }

        [Required(ErrorMessage = "'Vreme od' ne sme biti neodređeno!")]
        [Display(Name = "Vreme od")]
        public int EvidAngMasVremeOd { get; set; }

        [Required(ErrorMessage = "'Vreme do' ne sme biti neodređeno!")]
        [Display(Name = "Vreme do")]
        public int EvidAngMasVremeDo { get; set; }


        public virtual Zadatak Zadatak { get; set; }
        public virtual Masina Masina { get; set; }
    }
}
