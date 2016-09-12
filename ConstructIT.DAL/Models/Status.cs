using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructIT.DAL.Models
{
    public class Status
    {
        public int StatusID { get; set; }

        [Required]
        [Display(Name = "Status")]
        public string StatusNaziv { get; set; }


        public ICollection<Zadatak> Zadaci { get; set; }

        [InverseProperty("StatusStari")]
        public ICollection<PromenaZadatka> PromeneZadatakaStari { get; set; }

        [InverseProperty("StatusNovi")]
        public ICollection<PromenaZadatka> PromeneZadatakaNovi { get; set; }
    }
}
