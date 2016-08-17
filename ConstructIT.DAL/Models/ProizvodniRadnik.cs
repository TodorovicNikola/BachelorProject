using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructIT.DAL.Models
{
    public class ProizvodniRadnik
    {
        [Display(Name = "MBR")]
        public int ProizvodniRadnikID { get; set; }

        [StringLength(13, ErrorMessage = "'JMBG' mora biti tačno 13 karaktera!"), RegularExpression(@"^[0-9]{13}$", ErrorMessage = "Uneseni JMBG ne zadovoljava formu standardnog JMBG-a!")]
        [Display(Name = "JMBG")]
        public String ProizRadJMBG { get; set; }

        [StringLength(64, ErrorMessage = "'Ime' ne sme biti duže od 64 karaktera!"), Required(ErrorMessage = "'Ime' ne sme biti prazno!")]
        [Display(Name = "Ime")]
        public String ProizRadIme { get; set; }

        [StringLength(64, ErrorMessage = "'Prezime' ne sme biti duže od 64 karaktera!"), Required(ErrorMessage = "'Prezime' ne sme biti prazno!")]
        [Display(Name = "Prezime")]
        public String ProizRadPrezime { get; set; }

        [RegularExpression(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                + "@"
                + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$", ErrorMessage = "Nepravilan unos za 'E-Mail'!")]
        [StringLength(64, ErrorMessage = "'E-Mail' ne sme biti duži od 64 karaktera!")]
        [Display(Name = "E-Mail")]
        public String ProizRadEMail { get; set; }

        [StringLength(64, ErrorMessage = "'Adresa' ne sme biti duža od 64 karaktera!")]
        [Display(Name = "Adresa")]
        public String ProizRadAdresa { get; set; }

        [RegularExpression(@"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$", ErrorMessage = "Nepravilan unos za 'Telefon-kućni'!")]
        [StringLength(32, ErrorMessage = "'Telefon-kućni' ne sme biti duži od 32 karaktera!")]
        [Display(Name = "Telefon-kućni")]
        public String ProizRadTelKucni { get; set; }

        [RegularExpression(@"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$", ErrorMessage = "Nepravilan unos za 'Telefon-mobilni'!")]
        [StringLength(32, ErrorMessage = "'Telefon-mobilni' ne sme biti duži od 32 karaktera!")]
        [Display(Name = "Telefon-mobilni")]
        public String ProizRadTelMob { get; set; }

        [ForeignKey("Struka")]
        [Required(ErrorMessage = "'Struka' ne sme biti prazna!")]
        public int StrukaID { get; set; }


        [ForeignKey("StrukaID")]
        public virtual Struka Struka { get; set; }


        public ICollection<EvidencijaRadnogVremena> EvidencijeRadnihVremena { get; set; }
    }
}
