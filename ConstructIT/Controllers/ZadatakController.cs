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
    public class ZadatakController : Controller
    {
        private ConstructITDBContext db = new ConstructITDBContext();

        // GET: Zadatak
        public async Task<ActionResult> Index()
        {
            var zadaci = db.Zadaci.Include(z => z.KorisnikKomJeDodeljen).Include(z => z.Prioritet).Include(z => z.Projekat).Include(z => z.Status).Include(z => z.PromeneZadatka).Include(z => z.KomentariNaZadatak);
            return View(await zadaci.ToListAsync());
        }

        // GET: Zadatak/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zadatak zadatak = await db.Zadaci.Include(z => z.PotrebeMaterijala).Include(z => z.PotrebeStruka).Include(z => z.PotrebeTipovaMasina).Include(z => z.KomentariNaZadatak).Include(z => z.PromeneZadatka).Where(z => z.ZadatakID == id).FirstOrDefaultAsync();
            if (zadatak == null)
            {
                return HttpNotFound();
            }
            return View(zadatak);
        }

        // GET: Zadatak/Create
        public ActionResult Create(int projekatID)
        {
            ViewBag.ProjekatNaziv = db.Projekti.Where(p => p.ProjekatID == projekatID).FirstOrDefault().ProjekatNaziv;
            ViewBag.ProjekatID = projekatID;
            ViewBag.KorisnikID = new SelectList((from k in db.Projekti.Where(pr => pr.ProjekatID == projekatID).Include(pr => pr.Korisnici).FirstOrDefault().Korisnici.Where(k => k.KorisnikTip == "Tehn. Osoblje").ToList() select new { korisnikID = k.KorisnikID, PunoIme = k.KorisnikIme + " " + k.KorisnikPrezime }), "KorisnikID", "PunoIme", null);
            ViewBag.PrioritetID = new SelectList(db.Prioriteti, "PrioritetID", "PrioritetNaziv");
            ViewBag.StatusID = new SelectList(db.Statusi, "StatusID", "StatusNaziv");
            return View();
        }

        // POST: Zadatak/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ProjekatID,ZadatakID,ZadatakNaziv,ZadatakDatumPocetka,ZadatakDatumZavrsetka,ZadatakOpis,StatusID,PrioritetID,KorisnikID")] Zadatak zadatak)
        {
            Zadatak z = db.Zadaci.Where(za => za.ProjekatID == zadatak.ProjekatID && za.ZadatakNaziv == zadatak.ZadatakNaziv).FirstOrDefault();

            if(z != null)
            {
                ModelState.AddModelError("ZadatakNaziv", "U ovom projektu već postoji zadatak sa unetim nazivom!");
            }


            if (ModelState.IsValid)
            {
                db.Zadaci.Add(zadatak);
                await db.SaveChangesAsync();
                return RedirectToAction("Details", "Projekat", new { id = zadatak.ProjekatID });
            }

            ViewBag.ProjekatNaziv = db.Projekti.Where(p => p.ProjekatID == zadatak.ProjekatID).FirstOrDefault().ProjekatNaziv;
            ViewBag.ProjekatID = zadatak.ProjekatID;
            ViewBag.KorisnikID = new SelectList((from k in db.Projekti.Where(pr => pr.ProjekatID == zadatak.ProjekatID).Include(pr => pr.Korisnici).FirstOrDefault().Korisnici.Where(k => k.KorisnikTip == "tehnOsoblje").ToList() select new { korisnikID = k.KorisnikID, PunoIme = k.KorisnikIme + " " + k.KorisnikPrezime }), "KorisnikID", "PunoIme", zadatak.KorisnikID);
            ViewBag.PrioritetID = new SelectList(db.Prioriteti, "PrioritetID", "PrioritetNaziv");
            ViewBag.StatusID = new SelectList(db.Statusi, "StatusID", "StatusNaziv", zadatak.StatusID);
            return View(zadatak);
        }

        // GET: Zadatak/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zadatak zadatak = await db.Zadaci.Where(z => z.ZadatakID == id).FirstOrDefaultAsync();
            if (zadatak == null)
            {
                return HttpNotFound();
            }
            ViewBag.KorisnikID = new SelectList((from k in db.Projekti.Where(pr => pr.ProjekatID == zadatak.ProjekatID).Include(pr => pr.Korisnici).FirstOrDefault().Korisnici.Where(k => k.KorisnikTip == "tehnOsoblje").ToList() select new { korisnikID = k.KorisnikID, PunoIme = k.KorisnikIme + " " + k.KorisnikPrezime }), "KorisnikID", "PunoIme", zadatak.KorisnikID);
            ViewBag.PrioritetID = new SelectList(db.Prioriteti, "PrioritetID", "PrioritetNaziv", zadatak.PrioritetID);
            ViewBag.ProjekatID = new SelectList(db.Projekti, "ProjekatID", "ProjekatNaziv", zadatak.ProjekatID);
            ViewBag.StatusID = new SelectList(db.Statusi, "StatusID", "StatusNaziv", zadatak.StatusID);
            return View(zadatak);
        }

        // POST: Zadatak/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProjekatID,ZadatakID,ZadatakNaziv,ZadatakDatumPocetka,ZadatakDatumZavrsetka,ZadatakOpis,StatusID,PrioritetID,KorisnikID")] Zadatak zadatak)
        {
            Zadatak z = db.Zadaci.Where(za => za.ProjekatID == zadatak.ProjekatID && za.ZadatakID != zadatak.ZadatakID && za.ZadatakNaziv == zadatak.ZadatakNaziv).FirstOrDefault();

            if (z != null)
            {
                ModelState.AddModelError("ZadatakNaziv", "U ovom projektu već postoji zadatak sa unetim nazivom!");
            }

            if (ModelState.IsValid)
            {
                PromenaZadatka _promenaZadatka = new PromenaZadatka();

                Zadatak _zadatakIzBaze = db.Zadaci.Where(zd => zd.ZadatakID == zadatak.ZadatakID).FirstOrDefault();

                bool trulyChanged = false;

                if(_zadatakIzBaze.ZadatakNaziv != zadatak.ZadatakNaziv)
                {
                    _promenaZadatka.PZ_ZadatakNazivStari = _zadatakIzBaze.ZadatakNaziv;
                    _promenaZadatka.PZ_ZadatakNazivNovi = zadatak.ZadatakNaziv;

                    _zadatakIzBaze.ZadatakNaziv = zadatak.ZadatakNaziv;

                    trulyChanged = true;
                }

                if(_zadatakIzBaze.ZadatakOpis != zadatak.ZadatakOpis)
                {
                    _promenaZadatka.PZ_ZadatakOpisStari = _zadatakIzBaze.ZadatakOpis;
                    _promenaZadatka.PZ_ZadatakOpisNovi = zadatak.ZadatakOpis;

                    _zadatakIzBaze.ZadatakOpis = zadatak.ZadatakOpis;

                    trulyChanged = true;
                }

                if(_zadatakIzBaze.ZadatakDatumPocetka != zadatak.ZadatakDatumPocetka)
                {
                    _promenaZadatka.PZ_ZadatakDatumPocetkaStari = _zadatakIzBaze.ZadatakDatumPocetka;
                    _promenaZadatka.PZ_ZadatakDatumPocetkaNovi = zadatak.ZadatakDatumPocetka;

                    _zadatakIzBaze.ZadatakDatumPocetka = zadatak.ZadatakDatumPocetka;

                    trulyChanged = true;
                }

                if(_zadatakIzBaze.ZadatakDatumZavrsetka != zadatak.ZadatakDatumZavrsetka)
                {
                    _promenaZadatka.PZ_ZadatakDatumZavrsetkaStari = _zadatakIzBaze.ZadatakDatumZavrsetka;
                    _promenaZadatka.PZ_ZadatakDatumZavrsetkaNovi = zadatak.ZadatakDatumZavrsetka;

                    _zadatakIzBaze.ZadatakDatumZavrsetka = zadatak.ZadatakDatumZavrsetka;

                    trulyChanged = true;
                }

                if(_zadatakIzBaze.PrioritetID != zadatak.PrioritetID)
                {
                    _promenaZadatka.PZ_PrioritetIDStari = _zadatakIzBaze.PrioritetID;
                    _promenaZadatka.PZ_PrioritetIDNovi = zadatak.PrioritetID;

                    _zadatakIzBaze.PrioritetID = zadatak.PrioritetID;

                    trulyChanged = true;
                }

                if (_zadatakIzBaze.StatusID != zadatak.StatusID)
                {
                    _promenaZadatka.PZ_StatusIDStari = _zadatakIzBaze.StatusID;
                    _promenaZadatka.PZ_StatusIDNovi = zadatak.StatusID;

                    _zadatakIzBaze.StatusID = zadatak.StatusID;

                    trulyChanged = true;
                }

                if (_zadatakIzBaze.KorisnikID != zadatak.KorisnikID)
                {
                    _promenaZadatka.PZ_KorisnikID = (int)zadatak.KorisnikID;

                    _zadatakIzBaze.KorisnikID = zadatak.KorisnikID;

                    trulyChanged = true;
                }

                if (trulyChanged)
                {
                    _promenaZadatka.PZ_VremeIzmene = DateTime.Now;

                    Korisnik _korisnikKojiJeIzmenio = (Korisnik)Session["korisnik"];
                    _promenaZadatka.PZ_KorisnikIzmenioID = _korisnikKojiJeIzmenio.KorisnikID;

                    _promenaZadatka.ZadatakID = zadatak.ZadatakID;
                    _promenaZadatka.ProjekatID = zadatak.ProjekatID;

                    db.PromeneZadataka.Add(_promenaZadatka);
                }

                db.Entry(_zadatakIzBaze).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Details", new { id = _zadatakIzBaze.ZadatakID });
            }
            ViewBag.KorisnikID = new SelectList((from k in db.Projekti.Where(pr => pr.ProjekatID == zadatak.ProjekatID).Include(pr => pr.Korisnici).FirstOrDefault().Korisnici.Where(k => k.KorisnikTip == "Tehn. Osoblje").ToList() select new { korisnikID = k.KorisnikID, PunoIme = k.KorisnikIme + " " + k.KorisnikPrezime }), "KorisnikID", "PunoIme", zadatak.KorisnikID);
            ViewBag.PrioritetID = new SelectList(db.Prioriteti, "PrioritetID", "PrioritetNaziv", zadatak.PrioritetID);
            ViewBag.ProjekatID = new SelectList(db.Projekti, "ProjekatID", "ProjekatNaziv", zadatak.ProjekatID);
            ViewBag.StatusID = new SelectList(db.Statusi, "StatusID", "StatusNaziv", zadatak.StatusID);
            return View(zadatak);
        }

        // GET: Zadatak/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zadatak zadatak = await db.Zadaci.Where(z => z.ZadatakID == id).FirstOrDefaultAsync();

            if (zadatak == null)
            {
                return HttpNotFound();
            }
            return View(zadatak);
        }

        // POST: Zadatak/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Zadatak zadatak = await db.Zadaci.Where(z => z.ZadatakID == id).FirstOrDefaultAsync();
            db.Zadaci.Remove(zadatak);
            await db.SaveChangesAsync();
            return RedirectToAction("Details", "Projekat", new { id = zadatak.ProjekatID });
        }

        public ActionResult AddComment(int projekatID, int zadatakID, String komentarNaslov, String komentarSadrzaj)
        {
            KomentarZadatak kZ = new KomentarZadatak();

            kZ.ZadatakID = zadatakID;
            kZ.ProjekatID = projekatID;
            kZ.KomentarZadatakNaslov = komentarNaslov;
            kZ.KomentarZadatakSadrzaj = komentarSadrzaj;

            Korisnik k = (Korisnik)Session["korisnik"];

            kZ.KorisnikID = k.KorisnikID;

            kZ.KomentarZadatakVremePostavljanja = DateTime.Now;

            db.KomentariNaZadatke.Add(kZ);

            db.SaveChanges();

            return RedirectToAction("Details", new { id = zadatakID });
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
