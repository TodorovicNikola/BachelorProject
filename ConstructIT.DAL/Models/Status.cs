using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public ICollection<PromenaZadatka> PromeneZadataka { get; set; }
    }
}
