using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructIT.DAL.Models
{
    public class KomentarZadatak
    {
        [Key]
        [ForeignKey("Zadatak")]
        [Column(Order = 0)]
        public int ProjekatID { get; set; }

        [Key]
        [ForeignKey("Zadatak")]
        [Column(Order = 1)]
        public int ZadatakID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KomentarZadatakID { get; set; }

        [Required(ErrorMessage = "'Naslov komentara' ne sme biti neodređen!")]
        [StringLength(32, ErrorMessage = "'Naslov komentara' ne sme biti duži od 32 karaktera!")]
        [Display(Name = "Naslov komentara")]
        public String KomentarZadatakNaslov { get; set; }

        [Required(ErrorMessage = "'Sadržaj komentara' ne sme biti neodređen!")]
        [StringLength(1024, ErrorMessage = "'Sadržaj komentara' ne sme biti duži od 1024 karaktera!")]
        [Display(Name = "Sadržaj komentara")]
        public String KomentarZadatakSadrzaj { get; set; }

        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Vreme postavljanja")]
        [Required]
        public DateTime KomentarZadatakVremePostavljanja { get; set; }

        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Vreme izmene")]
        [Required]
        public DateTime KomentarZadatakVremeIzmene { get; set; }

        [Required]
        [ForeignKey("Korisnik")]
        public int KorisnikID { get; set; }


        public virtual Zadatak Zadatak { get; set; }

        [ForeignKey("KorisnikID")]
        public virtual Korisnik Korisnik { get; set; }
    }
}
