using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructIT.DAL.Models
{
    public class Masina
    {
        public int MasinaID { get; set; }

        [StringLength(128, ErrorMessage = "'Proizvođač' ne sme biti duže od 128 karaktera!"), Required(ErrorMessage = "'Proizvođač' ne sme biti prazan!")]
        [Display(Name = "Proizvođač")]
        public String MasinaProizvodjac { get; set; }

        [StringLength(1024, ErrorMessage = "'Opis Mašine' ne sme biti duži od 1024 karaktera!")]
        public String MasinaOpis { get; set; }

        [ForeignKey("TipMasine")]
        [Required(ErrorMessage = "'Tip Mašine' ne sme biti prazan!")]
        public int TipMasineID { get; set; }

        [Required(ErrorMessage = "'Dostupna količina' ne sme biti neodređena!")]
        [Display(Name = "Dostupna količina")]
        public int MasinaDostupnaKolicina { get; set; }


        [ForeignKey("TipMasineID")]
        public virtual TipMasine TipMasine { get; set; }

        public ICollection<EvidencijaAngazovanjaMasine> EvidencijeAngazovanjaMasine { get; set; }
    }
}
