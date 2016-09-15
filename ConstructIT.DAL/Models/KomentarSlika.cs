using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructIT.DAL.Models
{
    public class KomentarSlika
    {
        [Key]
        [ForeignKey("Slika")]
        [Column(Order = 0)]
        public int SlikaID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KomentarSlikaID { get; set; }

        [Required(ErrorMessage = "'Naslov komentara' ne sme biti neodređen!")]
        [StringLength(32, ErrorMessage = "'Naslov komentara' ne sme biti duži od 32 karaktera!")]
        [Display(Name = "Naslov komentara")]
        public String KomentarSlikaNaslov { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "'Sadržaj komentara' ne sme biti neodređen!")]
        [StringLength(1024, ErrorMessage = "'Sadržaj komentara' ne sme biti duži od 1024 karaktera!")]
        [Display(Name = "Sadržaj komentara")]
        public String KomentarSlikaSadrzaj { get; set; }

        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Vreme postavljanja")]
        [Required]
        public DateTime KomentarSlikaVremePostavljanja { get; set; }

        [Required]
        [ForeignKey("Korisnik")]
        public int KorisnikID { get; set; }


        [ForeignKey("SlikaID")]
        public virtual Slika Slika { get; set; }

        [ForeignKey("KorisnikID")]
        public virtual Korisnik Korisnik { get; set; }

    }
}
