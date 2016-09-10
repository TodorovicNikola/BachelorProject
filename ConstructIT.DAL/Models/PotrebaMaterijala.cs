using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructIT.DAL.Models
{
    public class PotrebaMaterijala
    {
        public int PotrebaMaterijalaID { get; set; }

        [ForeignKey("Zadatak")]
        [Column(Order = 0)]
        public int ProjekatID { get; set; }

        [ForeignKey("Zadatak")]
        [Column(Order = 1)]
        public int ZadatakID { get; set; }

        [ForeignKey("Materijal")]
        [Column(Order = 2)]
        public int MaterijalID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Od datuma")]
        public DateTime PotrMatOdDatuma { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Do datuma")]
        public DateTime PotrMatDoDatuma { get; set; }

        [Required(ErrorMessage = "'Potrebna količina' ne sme biti neodređena!")]
        [Display(Name = "Potrebna količina")]
        public double PotrMatKolicina { get; set; }


        public virtual Zadatak Zadatak { get; set; }
        public virtual Materijal Materijal { get; set; }

        public ICollection<DodelaMaterijala> DodeleMaterijala { get; set; }

    }
}
