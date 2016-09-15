using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructIT.DAL.Models
{
    public class Slika
    {
        public int SlikaID { get; set; }

        public String SlikaNaziv { get; set; }

        public String SlikaOpis { get; set; }

        [ForeignKey("Galerija")]
        [Column(Order = 1)]
        public int ProjekatID { get; set; }

        [ForeignKey("Galerija")]
        [Column(Order = 2)]
        public DateTime GalerijaDatum { get; set; }


        public virtual Galerija Galerija { get; set; }

        public ICollection<KomentarSlika> KomentariNaSliku { get; set; }
    }
}
