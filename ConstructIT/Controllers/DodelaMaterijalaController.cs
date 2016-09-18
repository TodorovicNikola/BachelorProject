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
    public class DodelaMaterijalaController : Controller
    {
        private ConstructITDBContext db = new ConstructITDBContext();

        // GET: DodelaMaterijala
        public async Task<ActionResult> Index()
        {
            var dodeleMaterijala = db.DodeleMaterijala.Include(d => d.PotrebaMaterijala);
            return View(await dodeleMaterijala.ToListAsync());
        }

        // GET: DodelaMaterijala/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DodelaMaterijala dodelaMaterijala = await db.DodeleMaterijala.FindAsync(id);
            if (dodelaMaterijala == null)
            {
                return HttpNotFound();
            }
            return View(dodelaMaterijala);
        }

        // GET: DodelaMaterijala/Create
        public ActionResult Create(int potrebaMaterijalaID)
        {
            PotrebaMaterijala pm = db.PotrebeMaterijala.Find(potrebaMaterijalaID);

            ViewData["projekatNaziv"] = pm.Zadatak.Projekat.ProjekatNaziv;
            ViewData["potrebnaKolicina"] = pm.PotrMatKolicina;
            ViewData["zadatakNaziv"] = pm.Zadatak.ZadatakNaziv;
            ViewData["materijalNaziv"] = pm.Materijal.MaterijalNaziv;
            ViewData["potrebaMaterijalaID"] = pm.PotrebaMaterijalaID;

            int materijalID = db.PotrebeMaterijala.Find(pm.PotrebaMaterijalaID).MaterijalID;
            ViewData["postojecaKolicinaMaterijala"] = db.Materijali.Where(m => m.MaterijalID == materijalID).FirstOrDefault().MaterijalRaspolozivaKolicina;
            return View();
        }

        // POST: DodelaMaterijala/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "DodelaMaterijalaID,PotrebaMaterijalaID,DodMatDatumDodele,DodMatKolicina")] DodelaMaterijala dodelaMaterijala)
        {
            PotrebaMaterijala pm = db.PotrebeMaterijala.Find(dodelaMaterijala.PotrebaMaterijalaID);
            int materijalID = pm.MaterijalID;

            if (dodelaMaterijala.DodMatKolicina > db.Materijali.Where(m => m.MaterijalID == materijalID).FirstOrDefault().MaterijalRaspolozivaKolicina)
            {
                ModelState.AddModelError("DodMatKolicina", "Dodeljena količina prevazilazi postojeću količinu materijala!");
            }

            if(dodelaMaterijala.DodMatKolicina > pm.PotrMatKolicina)
            {
                ModelState.AddModelError("DodMatKolicina", "Dodeljena količina prevazilazi potrebnu količinu materijala!");
            }

            if (dodelaMaterijala.DodMatKolicina <= 0)
            {
                ModelState.AddModelError("DodMatKolicina", "Dodeljena količina mora biti pozitivan broj!");
            }

            if (ModelState.IsValid)
            {
                dodelaMaterijala.DodMatDatumDodele = DateTime.Today;

                db.DodeleMaterijala.Add(dodelaMaterijala);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }



            ViewData["projekatNaziv"] = pm.Zadatak.Projekat.ProjekatNaziv;
            ViewData["potrebnaKolicina"] = pm.PotrMatKolicina;
            ViewData["zadatakNaziv"] = pm.Zadatak.ZadatakNaziv;
            ViewData["materijalNaziv"] = pm.Materijal.MaterijalNaziv;
            ViewData["potrebaMaterijalaID"] = pm.PotrebaMaterijalaID;

            ViewData["postojecaKolicinaMaterijala"] = db.Materijali.Where(m => m.MaterijalID == materijalID).FirstOrDefault().MaterijalRaspolozivaKolicina;
            return View(dodelaMaterijala);
        }

        // GET: DodelaMaterijala/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DodelaMaterijala dodelaMaterijala = await db.DodeleMaterijala.FindAsync(id);
            if (dodelaMaterijala == null)
            {
                return HttpNotFound();
            }

            PotrebaMaterijala pm = db.PotrebeMaterijala.Find(dodelaMaterijala.PotrebaMaterijalaID);
            int materijalID = pm.MaterijalID;

            ViewData["projekatNaziv"] = pm.Zadatak.Projekat.ProjekatNaziv;
            ViewData["potrebnaKolicina"] = pm.PotrMatKolicina;
            ViewData["zadatakNaziv"] = pm.Zadatak.ZadatakNaziv;
            ViewData["materijalNaziv"] = pm.Materijal.MaterijalNaziv;
            ViewData["potrebaMaterijalaID"] = pm.PotrebaMaterijalaID;

            ViewData["postojecaKolicinaMaterijala"] = db.Materijali.Where(m => m.MaterijalID == materijalID).FirstOrDefault().MaterijalRaspolozivaKolicina;
            return View(dodelaMaterijala);
        }

        // POST: DodelaMaterijala/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "DodelaMaterijalaID,PotrebaMaterijalaID,DodMatDatumDodele,DodMatKolicina")] DodelaMaterijala dodelaMaterijala)
        {
            if (ModelState.IsValid)
            {
                dodelaMaterijala.DodMatDatumDodele = DateTime.Today;

                db.Entry(dodelaMaterijala).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            PotrebaMaterijala pm = db.PotrebeMaterijala.Find(dodelaMaterijala.PotrebaMaterijalaID);
            int materijalID = pm.MaterijalID;

            ViewData["projekatNaziv"] = pm.Zadatak.Projekat.ProjekatNaziv;
            ViewData["potrebnaKolicina"] = pm.PotrMatKolicina;
            ViewData["zadatakNaziv"] = pm.Zadatak.ZadatakNaziv;
            ViewData["materijalNaziv"] = pm.Materijal.MaterijalNaziv;
            ViewData["potrebaMaterijalaID"] = pm.PotrebaMaterijalaID;

            ViewData["postojecaKolicinaMaterijala"] = db.Materijali.Where(m => m.MaterijalID == materijalID).FirstOrDefault().MaterijalRaspolozivaKolicina;
            return View(dodelaMaterijala);
        }

        // GET: DodelaMaterijala/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DodelaMaterijala dodelaMaterijala = await db.DodeleMaterijala.FindAsync(id);
            if (dodelaMaterijala == null)
            {
                return HttpNotFound();
            }

            PotrebaMaterijala pm = db.PotrebeMaterijala.Find(dodelaMaterijala.PotrebaMaterijalaID);
            int materijalID = pm.MaterijalID;

            ViewData["projekatNaziv"] = pm.Zadatak.Projekat.ProjekatNaziv;
            ViewData["zadatakNaziv"] = pm.Zadatak.ZadatakNaziv;
            ViewData["materijalNaziv"] = pm.Materijal.MaterijalNaziv;

            return View(dodelaMaterijala);
        }

        // POST: DodelaMaterijala/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            DodelaMaterijala dodelaMaterijala = await db.DodeleMaterijala.FindAsync(id);
            db.DodeleMaterijala.Remove(dodelaMaterijala);
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
