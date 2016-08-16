using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructIT.DAL.Models
{
    public class Prioritet
    {
        public int PrioritetID { get; set; }

        [Required]
        [Display(Name = "Prioritet")]
        public string PrioritetNaziv { get; set; }

        [Required]
        public float PrioritetTezina { get; set; }


        public ICollection<Zadatak> Zadaci { get; set; }
        public ICollection<PromenaZadatka> PromeneZadataka { get; set; }
    }
}
