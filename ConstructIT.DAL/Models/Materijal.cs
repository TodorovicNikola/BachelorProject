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

        [StringLength(64, ErrorMessage = "'Naziv Materijala' ne sme biti duži od 64 karaktera!"), Required(ErrorMessage = "'Naziv Materijala' ne sme biti prazan!")]
        public String MaterijalNaziv { get; set; }

        [StringLength(64, ErrorMessage = "'Naziv Proizvođača' ne sme biti duži od 64 karaktera!"), Required(ErrorMessage = "'Naziv Proizvođača' ne sme biti prazan!")]
        public String MaterijalProizvodjac { get; set; }

        [StringLength(1024, ErrorMessage = "'Opis' ne sme biti duži od 1024 karaktera!")]
        public String MaterijalOpis { get; set; }

        [Display(Name = "Raspoloživa količina")]
        [Required(ErrorMessage = "'Raspoloživa količina' ne sme biti neodređena!")]
        public float MaterijalRaspolozivaKolicina { get; set; }


        public ICollection<PotrebaMaterijala> PotrebeMaterijala { get; set; }
    }
}
