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

        [Display(Name = "Vreme od")]
        public int EvRadnVrVremeOd { get; set; }

        [Display(Name = "Vreme do")]
        public int EvRadnVrVremeDo { get; set; }

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
