using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructIT.DAL.Models
{
    public class TipMasine
    {
        public int TipMasineID { get; set; }

        [Required(ErrorMessage = "'Naziv tipa mašine' ne sme biti prazan!")]
        [StringLength(32, ErrorMessage = "'Naziv tipa mašine' ne sme biti duži od 32 karaktera!")]
        [Display(Name = "Naziv tipa mašine")]
        public string TipMasineNaziv { get; set; }


        public ICollection<Masina> Masine { get; set; }
        public ICollection<PotrebaTipaMasine> PotrebeTipaMasine { get; set; }
    }
}
