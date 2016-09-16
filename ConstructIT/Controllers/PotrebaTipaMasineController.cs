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
    public class PotrebaTipaMasineController : Controller
    {
        private ConstructITDBContext db = new ConstructITDBContext();

        // GET: PotrebaTipaMasine
        public async Task<ActionResult> Index()
        {
            DateTime today = DateTime.Today;

            var potrebeTipovaMasina = db.PotrebeTipovaMasina.Include(p => p.TipMasine).Include(p => p.Zadatak).Where(ptm => DbFunctions.TruncateTime(ptm.PotrTipaMasOdDatuma) <= today && DbFunctions.TruncateTime(ptm.PotrTipaMasDoDatuma) >= today);
            return View(await potrebeTipovaMasina.ToListAsync());
        }

        // GET: PotrebaTipaMasine/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PotrebaTipaMasine potrebaTipaMasine = await db.PotrebeTipovaMasina.FindAsync(id);
            if (potrebaTipaMasine == null)
            {
                return HttpNotFound();
            }
            return View(potrebaTipaMasine);
        }

        // GET: PotrebaTipaMasine/Create
        public ActionResult Create(int projekatID, int zadatakID)
        {
            ViewBag.TipMasineID = new SelectList(db.TipoviMasina.OrderBy(tm => tm.TipMasineNaziv), "TipMasineID", "TipMasineNaziv");
            ViewBag.ProjekatNaziv = db.Projekti.Where(p => p.ProjekatID == projekatID).FirstOrDefault().ProjekatNaziv;
            ViewBag.ZadatakNaziv = db.Zadaci.Where(z => z.ZadatakID == zadatakID).FirstOrDefault().ZadatakNaziv;
            ViewBag.ProjekatID = projekatID;
            ViewBag.ZadatakID = zadatakID;
            return View();
        }

        // POST: PotrebaTipaMasine/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PotrebaTipaMasineID,PotrTipaMasOdDatuma,PotrTipaMasDoDatuma,PotrTipaMasKolicina,ProjekatID,ZadatakID,TipMasineID")] PotrebaTipaMasine potrebaTipaMasine)
        {
            if (ModelState.IsValid)
            {
                db.PotrebeTipovaMasina.Add(potrebaTipaMasine);
                await db.SaveChangesAsync();
                return RedirectToAction("Details", "Zadatak", new { id = potrebaTipaMasine.ZadatakID });
            }

            ViewBag.TipMasineID = new SelectList(db.TipoviMasina.OrderBy(tm => tm.TipMasineNaziv), "TipMasineID", "TipMasineNaziv", potrebaTipaMasine.TipMasineID);
            ViewBag.ProjekatNaziv = db.Projekti.Where(p => p.ProjekatID == potrebaTipaMasine.ProjekatID).FirstOrDefault().ProjekatNaziv;
            ViewBag.ZadatakNaziv = db.Zadaci.Where(z => z.ZadatakID == potrebaTipaMasine.ZadatakID).FirstOrDefault().ZadatakNaziv;
            ViewBag.ProjekatID = potrebaTipaMasine.ProjekatID;
            ViewBag.ZadatakID = potrebaTipaMasine.ZadatakID;
            return View(potrebaTipaMasine);
        }

        // GET: PotrebaTipaMasine/Edit/5
        public async Task<ActionResult> Edit(int? potrebaTipaMasineID)
        {
            if (potrebaTipaMasineID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PotrebaTipaMasine potrebaTipaMasine = await db.PotrebeTipovaMasina.FindAsync(potrebaTipaMasineID);
            if (potrebaTipaMasine == null)
            {
                return HttpNotFound();
            }

            ViewBag.TipMasineNaziv = db.TipoviMasina.Where(t => t.TipMasineID == potrebaTipaMasine.TipMasineID).FirstOrDefault().TipMasineNaziv;
            ViewBag.ProjekatNaziv = db.Projekti.Where(p => p.ProjekatID == potrebaTipaMasine.ProjekatID).FirstOrDefault().ProjekatNaziv;
            ViewBag.ZadatakNaziv = db.Zadaci.Where(z => z.ZadatakID == potrebaTipaMasine.ZadatakID).FirstOrDefault().ZadatakNaziv;

            return View(potrebaTipaMasine);
        }

        // POST: PotrebaTipaMasine/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PotrebaTipaMasineID,PotrTipaMasOdDatuma,PotrTipaMasDoDatuma,PotrTipaMasKolicina,ProjekatID,ZadatakID,TipMasineID")] PotrebaTipaMasine potrebaTipaMasine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(potrebaTipaMasine).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Details", "Zadatak", new { id = potrebaTipaMasine.ZadatakID });
            }

            ViewBag.TipMasineNaziv = db.TipoviMasina.Where(t => t.TipMasineID == potrebaTipaMasine.TipMasineID).FirstOrDefault().TipMasineNaziv;
            ViewBag.ProjekatNaziv = db.Projekti.Where(p => p.ProjekatID == potrebaTipaMasine.ProjekatID).FirstOrDefault().ProjekatNaziv;
            ViewBag.ZadatakNaziv = db.Zadaci.Where(z => z.ZadatakID == potrebaTipaMasine.ZadatakID).FirstOrDefault().ZadatakNaziv;

            return View(potrebaTipaMasine);
        }

        // GET: PotrebaTipaMasine/Delete/5
        public async Task<ActionResult> Delete(int? potrebaTipaMasineID)
        {
            if (potrebaTipaMasineID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PotrebaTipaMasine potrebaTipaMasine = await db.PotrebeTipovaMasina.FindAsync(potrebaTipaMasineID);
            if (potrebaTipaMasine == null)
            {
                return HttpNotFound();
            }
            return View(potrebaTipaMasine);
        }

        // POST: PotrebaTipaMasine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int? id)
        {
            PotrebaTipaMasine potrebaTipaMasine = await db.PotrebeTipovaMasina.FindAsync(id);
            db.PotrebeTipovaMasina.Remove(potrebaTipaMasine);
            await db.SaveChangesAsync();
            return RedirectToAction("Details", "Zadatak", new { id = potrebaTipaMasine.ZadatakID });
        }

        public async Task<ActionResult> AutoAssignMachines()
        {
            await db.Database.ExecuteSqlCommandAsync("PR_AUTO_ASSIGN_MACHINES");

            return RedirectToAction("Index", "EvidencijaRadnogVremena");
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
