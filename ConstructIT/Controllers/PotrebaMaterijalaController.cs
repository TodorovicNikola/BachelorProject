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
    public class PotrebaMaterijalaController : Controller
    {
        private ConstructITDBContext db = new ConstructITDBContext();

        // GET: PotrebaMaterijala
        public async Task<ActionResult> Index()
        {
            DateTime today = DateTime.Today;

            var potrebeMaterijala = db.PotrebeMaterijala.Where(pm => pm.PotrMatKolicina > 0 && DbFunctions.TruncateTime(pm.PotrMatOdDatuma) <= today && DbFunctions.TruncateTime(pm.PotrMatDoDatuma) >= today).Include(p => p.Materijal).Include(p => p.Zadatak);
            return View(await potrebeMaterijala.ToListAsync());
        }

        // GET: PotrebaMaterijala/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PotrebaMaterijala potrebaMaterijala = await db.PotrebeMaterijala.FindAsync(id);
            if (potrebaMaterijala == null)
            {
                return HttpNotFound();
            }
            return View(potrebaMaterijala);
        }

        // GET: PotrebaMaterijala/Create
        public ActionResult Create(int projekatID, int zadatakID)
        {
            ViewBag.MaterijalID = new SelectList(db.Materijali.OrderBy(m => m.MaterijalNaziv), "MaterijalID", "MaterijalNaziv");
            ViewBag.ProjekatNaziv = db.Projekti.Where(p => p.ProjekatID == projekatID).FirstOrDefault().ProjekatNaziv;
            ViewBag.ZadatakNaziv = db.Zadaci.Where(z => z.ZadatakID == zadatakID).FirstOrDefault().ZadatakNaziv;
            ViewBag.ProjekatID = projekatID;
            ViewBag.ZadatakID = zadatakID;
            return View();
        }

        // POST: PotrebaMaterijala/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ProjekatID,ZadatakID,MaterijalID,PotrMatOdDatuma,PotrMatDoDatuma,PotrMatKolicina")] PotrebaMaterijala potrebaMaterijala)
        {
            if (ModelState.IsValid)
            {
                db.PotrebeMaterijala.Add(potrebaMaterijala);
                await db.SaveChangesAsync();
                return RedirectToAction("Details", "Zadatak", new { id = potrebaMaterijala.ZadatakID });
            }

            ViewBag.MaterijalID = new SelectList(db.Materijali.OrderBy(m => m.MaterijalNaziv), "MaterijalID", "MaterijalNaziv", potrebaMaterijala.MaterijalID);
            ViewBag.ProjekatNaziv = db.Projekti.Where(p => p.ProjekatID == potrebaMaterijala.ProjekatID).FirstOrDefault().ProjekatNaziv;
            ViewBag.ZadatakNaziv = db.Zadaci.Where(z => z.ZadatakID == potrebaMaterijala.ZadatakID).FirstOrDefault().ZadatakNaziv;
            ViewBag.ProjekatID = potrebaMaterijala.ProjekatID;
            ViewBag.ZadatakID = potrebaMaterijala.ZadatakID;
            return View(potrebaMaterijala);
        }

        // GET: PotrebaMaterijala/Edit/5
        public async Task<ActionResult> Edit(int? PotrebaMaterijalaID)
        {
            if (PotrebaMaterijalaID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PotrebaMaterijala potrebaMaterijala = await db.PotrebeMaterijala.FindAsync(PotrebaMaterijalaID);
            if (potrebaMaterijala == null)
            {
                return HttpNotFound();
            }

            ViewBag.MaterijalNaziv = db.Materijali.Where(m => m.MaterijalID == potrebaMaterijala.MaterijalID).FirstOrDefault().MaterijalNaziv;
            ViewBag.ProjekatNaziv = db.Projekti.Where(p => p.ProjekatID == potrebaMaterijala.ProjekatID).FirstOrDefault().ProjekatNaziv;
            ViewBag.ZadatakNaziv = db.Zadaci.Where(z => z.ZadatakID == potrebaMaterijala.ZadatakID).FirstOrDefault().ZadatakNaziv;

            return View(potrebaMaterijala);
        }

        // POST: PotrebaMaterijala/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PotrebaMaterijalaID,ProjekatID,ZadatakID,MaterijalID,PotrMatOdDatuma,PotrMatDoDatuma,PotrMatKolicina")] PotrebaMaterijala potrebaMaterijala)
        {
            if (ModelState.IsValid)
            {
                db.Entry(potrebaMaterijala).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Details", "Zadatak", new { id = potrebaMaterijala.ZadatakID });
            }

            ViewBag.MaterijalNaziv = db.Materijali.Where(m => m.MaterijalID == potrebaMaterijala.MaterijalID).FirstOrDefault().MaterijalNaziv;
            ViewBag.ProjekatNaziv = db.Projekti.Where(p => p.ProjekatID == potrebaMaterijala.ProjekatID).FirstOrDefault().ProjekatNaziv;
            ViewBag.ZadatakNaziv = db.Zadaci.Where(z => z.ZadatakID == potrebaMaterijala.ZadatakID).FirstOrDefault().ZadatakNaziv;

            return View(potrebaMaterijala);
        }

        // GET: PotrebaMaterijala/Delete/5
        public async Task<ActionResult> Delete(int potrebaMaterijalaID)
        {
            PotrebaMaterijala potrebaMaterijala = await db.PotrebeMaterijala.Where(p => p.PotrebaMaterijalaID == potrebaMaterijalaID).FirstOrDefaultAsync();
            if (potrebaMaterijala == null)
            {
                return HttpNotFound();
            }
            return View(potrebaMaterijala);
        }

        // POST: PotrebaMaterijala/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int potrebaTipaMaterijalaID)
        {
            PotrebaMaterijala potrebaMaterijala = await db.PotrebeMaterijala.Where(p => p.PotrebaMaterijalaID == potrebaTipaMaterijalaID).FirstOrDefaultAsync();
            db.PotrebeMaterijala.Remove(potrebaMaterijala);
            await db.SaveChangesAsync();
            return RedirectToAction("Details", "Zadatak", new { id = potrebaMaterijala.ZadatakID });
        }

        public async Task<ActionResult> AutoAssignMaterial()
        {
            await db.Database.ExecuteSqlCommandAsync("PR_AUTO_ASSIGN_MATERIAL");

            return RedirectToAction("Index", "DodelaMaterijala");
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
