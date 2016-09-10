using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructIT.DAL.Models
{
    public class PotrebaStruke
    {
        public int PotrebaStrukeID { get; set; }

        [Required(ErrorMessage = "'Od Datuma' ne sme biti neodređeno!")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Od datuma")]
        public DateTime PotrebaStrukeOdDatuma { get; set; }

        [Required(ErrorMessage = "'Do Datuma' ne sme biti neodređeno!")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Do datuma")]
        public DateTime PotrebaStrukeDoDatuma { get; set; }

        [Required(ErrorMessage = "'Potrebna količina' ne sme biti neodređena!")]
        [Display(Name = "Potrebna količina")]
        public int PotrebaStrukeKolicina { get; set; }

        [Required]
        [ForeignKey("Zadatak")]
        [Column(Order = 1)]
        public int ProjekatID { get; set; }

        [Required]
        [ForeignKey("Zadatak")]
        [Column(Order = 2)]
        public int ZadatakID { get; set; }

        [Required(ErrorMessage = "'Struka' ne sme biti neodređena!")]
        [ForeignKey("Struka")]
        public int StrukaID { get; set; }


        public virtual Zadatak Zadatak { get; set; }

        [ForeignKey("StrukaID")]
        public virtual Struka Struka { get; set; }
    }
}
