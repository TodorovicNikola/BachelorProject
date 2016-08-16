using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructIT.DAL.Models
{
    public class Korisnik
    {
        public int KorisnikID { get; set; }

        [StringLength(64, ErrorMessage = "'Lozinka' ne sme biti duža od 64 karaktera!"), Required(ErrorMessage = "'Lozinka' ne sme biti neodređena!")]
        [Display(Name = "Lozinka")]
        public String KorisnikLozinka { get; set; }

        [StringLength(64, ErrorMessage = "'Ime' ne sme biti duže od 64 karaktera!"), Required(ErrorMessage = "'Ime' ne sme biti neodređeno!")]
        [Display(Name = "Ime")]
        public String KorisnikIme { get; set; }

        [StringLength(64, ErrorMessage = "'Prezime' ne sme biti duže od 64 karaktera!"), Required(ErrorMessage = "'Prezime' ne sme biti neodređeno!")]
        [Display(Name = "Prezime")]
        public String KorisnikPrezime { get; set; }

        [Required(ErrorMessage = "'E-Mail' ne sme biti neodređen!")]
        [RegularExpression(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
        + "@"
        + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$", ErrorMessage = "Nepravilan unos za 'E-Mail'!")]
        [StringLength(64, ErrorMessage = "'E-Mail' ne sme biti duži od 64 karaktera!")]
        [Display(Name = "E-Mail")]
        public String KorisnikEMail { get; set; }

        [Required]
        public String KorisnikTip { get; set; }


        public ICollection<Projekat> Projekti { get; set; }
        public ICollection<Zadatak> DodeljeniZadaci { get; set; }
        public ICollection<KomentarZadatak> KomentariNaZadatke { get; set; }
        public ICollection<KomentarGalerija> KomentariNaGalerije { get; set; }
        public ICollection<PromenaZadatka> PromeneKojeJeKorisnikIzvrsio { get; set; }
    }
}
