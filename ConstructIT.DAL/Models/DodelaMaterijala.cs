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
        public int DodelaMaterijalaID { get; set; }

        [ForeignKey("PotrebaMaterijala")]
        public int PotrebaMaterijalaID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Datum dodele")]
        public DateTime DodMatDatumDodele { get; set; }

        [Required(ErrorMessage = "'Količina za dodelu' ne sme biti neodređena!")]
        [Display(Name = "Količina za dodelu")]
        public double DodMatKolicina { get; set; }


        [ForeignKey("PotrebaMaterijalaID")]
        public virtual PotrebaMaterijala PotrebaMaterijala { get; set; }
    }
}
