using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructIT.DAL.Models
{
    public class DodelaMaterijala
    {
        [Key]
        [ForeignKey("PotrebaMaterijala")]
        [Column(Order = 0)]
        public int ProjekatID { get; set; }

        [Key]
        [ForeignKey("PotrebaMaterijala")]
        [Column(Order = 1)]
        public int ZadatakID { get; set; }

        [Key]
        [ForeignKey("PotrebaMaterijala")]
        [Column(Order = 2)]
        public int MaterijalID { get; set; }

        [Key]
        [ForeignKey("PotrebaMaterijala")]
        [Column(Order = 3)]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Od datuma")]
        public DateTime PotrMatOdDatuma { get; set; }

        [Key]
        [ForeignKey("PotrebaMaterijala")]
        [Column(Order = 4)]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Do datuma")]
        public DateTime PotrMatDoDatuma { get; set; }

        [Key, Column(Order = 5)]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Datum dodele")]
        public DateTime DodMatDatumDodele { get; set; }

        [Required(ErrorMessage = "'Dodeljena količina' ne sme biti neodređena!")]
        [Display(Name = "Dodeljena količina")]
        public float DodMatKolicina { get; set; }


        public virtual PotrebaMaterijala PotrebaMaterijala { get; set; }
    }
}
