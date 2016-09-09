using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ConstructIT.DAL;
using ConstructIT.DAL.Models;

namespace ConstructIT.Controllers
{
    public class KomentarZadatakController : Controller
    {
        private ConstructITDBContext db = new ConstructITDBContext();

        // GET: KomentarZadatak
        public async Task<ActionResult> Index()
        {
            var komentariNaZadatke = db.KomentariNaZadatke.Include(k => k.Korisnik).Include(k => k.Zadatak);
            return View(await komentariNaZadatke.ToListAsync());
        }

        // GET: KomentarZadatak/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KomentarZadatak komentarZadatak = await db.KomentariNaZadatke.FindAsync(id);
            if (komentarZadatak == null)
            {
                return HttpNotFound();
            }
            return View(komentarZadatak);
        }

        // GET: KomentarZadatak/Create
        public ActionResult Create()
        {
            ViewBag.KorisnikID = new SelectList(db.Korisnici, "KorisnikID", "KorisnikLozinka");
            ViewBag.ProjekatID = new SelectList(db.Zadaci, "ProjekatID", "ZadatakNaziv");
            return View();
        }

        // POST: KomentarZadatak/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ProjekatID,ZadatakID,KomentarZadatakID,KomentarZadatakNaslov,KomentarZadatakSadrzaj,KomentarZadatakVremePostavljanja,KomentarZadatakVremeIzmene,KorisnikID")] KomentarZadatak komentarZadatak)
        {
            if (ModelState.IsValid)
            {
                db.KomentariNaZadatke.Add(komentarZadatak);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.KorisnikID = new SelectList(db.Korisnici, "KorisnikID", "KorisnikLozinka", komentarZadatak.KorisnikID);
            ViewBag.ProjekatID = new SelectList(db.Zadaci, "ProjekatID", "ZadatakNaziv", komentarZadatak.ProjekatID);
            return View(komentarZadatak);
        }

        // GET: KomentarZadatak/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KomentarZadatak komentarZadatak = await db.KomentariNaZadatke.FindAsync(id);
            if (komentarZadatak == null)
            {
                return HttpNotFound();
            }
            ViewBag.KorisnikID = new SelectList(db.Korisnici, "KorisnikID", "KorisnikLozinka", komentarZadatak.KorisnikID);
            ViewBag.ProjekatID = new SelectList(db.Zadaci, "ProjekatID", "ZadatakNaziv", komentarZadatak.ProjekatID);
            return View(komentarZadatak);
        }

        // POST: KomentarZadatak/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProjekatID,ZadatakID,KomentarZadatakID,KomentarZadatakNaslov,KomentarZadatakSadrzaj,KomentarZadatakVremePostavljanja,KomentarZadatakVremeIzmene,KorisnikID")] KomentarZadatak komentarZadatak)
        {
            if (ModelState.IsValid)
            {
                db.Entry(komentarZadatak).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.KorisnikID = new SelectList(db.Korisnici, "KorisnikID", "KorisnikLozinka", komentarZadatak.KorisnikID);
            ViewBag.ProjekatID = new SelectList(db.Zadaci, "ProjekatID", "ZadatakNaziv", komentarZadatak.ProjekatID);
            return View(komentarZadatak);
        }

        // GET: KomentarZadatak/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KomentarZadatak komentarZadatak = await db.KomentariNaZadatke.FindAsync(id);
            if (komentarZadatak == null)
            {
                return HttpNotFound();
            }
            return View(komentarZadatak);
        }

        // POST: KomentarZadatak/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            KomentarZadatak komentarZadatak = await db.KomentariNaZadatke.FindAsync(id);
            db.KomentariNaZadatke.Remove(komentarZadatak);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
