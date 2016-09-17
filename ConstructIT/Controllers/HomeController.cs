using ConstructIT.DAL;
using ConstructIT.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace ConstructIT.Controllers
{
    public class HomeController : Controller
    {
        private ConstructITDBContext db = new ConstructITDBContext();

        public ActionResult Index()
        {
            if(Session["korisnik"] != null)
            {
                Korisnik korisnik = (Korisnik)Session["korisnik"];

               if(korisnik.KorisnikTip == "Administrator" || korisnik.KorisnikTip== "Tehn. Osoblje")
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Details", "Projekat", new { id = korisnik.KlijentovProjekatID });
                }

            }
            else
            {
                return RedirectToAction("Login", "Session", null);
            }
            


        }
    }
}