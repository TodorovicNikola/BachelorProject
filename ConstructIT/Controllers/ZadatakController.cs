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
            var zadaci = db.Zadaci.Include(z => z.KorisnikKomJeDodeljen).Include(z => z.Prioritet).Include(z => z.Projekat).Include(z => z.Status);
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
        public ActionResult Create()
        {
            ViewBag.KorisnikID = new SelectList(db.Korisnici, "KorisnikID", "KorisnikLozinka");
            ViewBag.PrioritetID = new SelectList(db.Prioriteti, "PrioritetID", "PrioritetNaziv");
            ViewBag.ProjekatID = new SelectList(db.Projekti, "ProjekatID", "ProjekatNaziv");
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
            if (ModelState.IsValid)
            {
                db.Zadaci.Add(zadatak);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.KorisnikID = new SelectList(db.Korisnici, "KorisnikID", "KorisnikLozinka", zadatak.KorisnikID);
            ViewBag.PrioritetID = new SelectList(db.Prioriteti, "PrioritetID", "PrioritetNaziv", zadatak.PrioritetID);
            ViewBag.ProjekatID = new SelectList(db.Projekti, "ProjekatID", "ProjekatNaziv", zadatak.ProjekatID);
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
            Zadatak zadatak = await db.Zadaci.FindAsync(id);
            if (zadatak == null)
            {
                return HttpNotFound();
            }
            ViewBag.KorisnikID = new SelectList(db.Korisnici, "KorisnikID", "KorisnikLozinka", zadatak.KorisnikID);
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
            if (ModelState.IsValid)
            {
                db.Entry(zadatak).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.KorisnikID = new SelectList(db.Korisnici, "KorisnikID", "KorisnikLozinka", zadatak.KorisnikID);
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
            Zadatak zadatak = await db.Zadaci.FindAsync(id);
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
            Zadatak zadatak = await db.Zadaci.FindAsync(id);
            db.Zadaci.Remove(zadatak);
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
