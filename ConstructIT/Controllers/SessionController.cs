using ConstructIT.DAL;
using ConstructIT.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConstructIT.Controllers
{
    public class SessionController : Controller
    {
        private ConstructITDBContext db = new ConstructITDBContext();

        [HttpGet]
        public ActionResult Login()
        {
            ViewData["Visibility"] = "hidden";

            return View();
        }
        
        [HttpPost]
        public ActionResult Login(String email, String lozinka)
        {
            Korisnik _korisnik = db.Korisnici.Where(k => k.KorisnikEMail == email && k.KorisnikLozinka == lozinka).FirstOrDefault();

            if(_korisnik == null)
            {
                ViewData["Visibility"] = "visible";
                return View();
            }
            else
            {
                ViewData["Visibility"] = "hidden";
                Session["korisnik"] = _korisnik;
            }

            return RedirectToAction("Index", "Home");
        }
        
        public ActionResult Logout()
        {
            Session["korisnik"] = null;
            return RedirectToAction("Login", "Login");
        }
    }
}