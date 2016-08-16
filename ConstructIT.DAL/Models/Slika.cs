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
        public String SlikaNaziv { get; set; }


        public virtual Galerija Galerija { get; set; }
    }
}
