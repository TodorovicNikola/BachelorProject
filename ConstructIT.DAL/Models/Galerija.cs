using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructIT.DAL.Models
{
    public class Galerija
    {
        [Key]
        [ForeignKey("Projekat")]
        [Column(Order = 0)]
        public int ProjekatID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime GalerijaDatum { get; set; }


        public Projekat Projekat { get; set; }

        public ICollection<KomentarGalerija> KomentariNaGaleriju { get; set; }
        public ICollection<Slika> Slike { get; set; }
    }
}
