using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructIT.DAL.Models
{
    public class Materijal
    {
        public int MaterijalID { get; set; }

        [StringLength(64, ErrorMessage = "'Naziv materijala' ne sme biti duži od 64 karaktera!"), Required(ErrorMessage = "'Naziv materijala' ne sme biti prazan!")]
        [Display(Name = "Naziv materijala")]
        public String MaterijalNaziv { get; set; }

        [StringLength(1024, ErrorMessage = "'Opis materijala' ne sme biti duži od 1024 karaktera!")]
        [Display(Name = "Opis materijala")]
        public String MaterijalOpis { get; set; }

        [Display(Name = "Raspoloživa količina materijala")]
        [Required(ErrorMessage = "'Raspoloživa količina materijala' ne sme biti neodređena!")]
        public double MaterijalRaspolozivaKolicina { get; set; }


        public ICollection<PotrebaMaterijala> PotrebeMaterijala { get; set; }
    }
}
