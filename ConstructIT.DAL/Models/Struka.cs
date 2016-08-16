using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructIT.DAL.Models
{
    public class Struka
    {
        public int StrukaID { get; set; }

        [StringLength(64, ErrorMessage = "'Naziv Struke' ne sme biti duži od 64 karaktera!"), Required(ErrorMessage = "'Naziv Struke' ne sme biti prazan!")]
        [Display(Name = "Naziv struke")]
        public String StrukaNaziv { get; set; }


        public ICollection<ProizvodniRadnik> ProizvodniRadnici { get; set; }
        public ICollection<PotrebaStruke> PotrebeStruke { get; set; }
    }
}
