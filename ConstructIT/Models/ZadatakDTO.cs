using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConstructIT.DAL.Models;

namespace ConstructIT.Models
{
    public class ZadatakDTO
    {
        public int ZadatakID { get; set; }
        public String ZadatakNaziv { get; set; }

        public ZadatakDTO(Zadatak zadatakOriginal)
        {
            ZadatakID = zadatakOriginal.ZadatakID;
            ZadatakNaziv = zadatakOriginal.ZadatakNaziv;
        }
    }
}