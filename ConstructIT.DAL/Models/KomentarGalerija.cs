using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructIT.DAL.Models
{
    public class KomentarGalerija
    {
        [Key]
        [ForeignKey("Galerija")]
        [Column(Order = 0)]
        public int ProjekatID { get; set; }

        [Key]
        [ForeignKey("Galerija")]
        [Column(Order = 1)]
        public DateTime GalerijaDatum { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KomentarGalerijaID { get; set; }

        [Required(ErrorMessage = "'Naslov komentara' ne sme biti neodređen!")]
        [StringLength(32, ErrorMessage = "'Naslov komentara' ne sme biti duži od 32 karaktera!")]
        [Display(Name = "Naslov komentara")]
        public String KomentarGalerijaNaslov { get; set; }

        [Required(ErrorMessage = "'Sadržaj komentara' ne sme biti neodređen!")]
        [StringLength(1024, ErrorMessage = "'Sadržaj komentara' ne sme biti duži od 1024 karaktera!")]
        [Display(Name = "Sadržaj komentara")]
        public String KomentarGalerijaSadrzaj { get; set; }

        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Vreme postavljanja")]
        public DateTime? KomentarGalerijaVremePostavljanja { get; set; }

        [Required]
        [ForeignKey("Korisnik")]
        public int KorisnikID { get; set; }


        public virtual Galerija Galerija { get; set; }

        [ForeignKey("KorisnikID")]
        public virtual Korisnik Korisnik { get; set; }
    }
}
