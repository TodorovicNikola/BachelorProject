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
    public class EvidencijaAngazovanjaMasineController : Controller
    {
        private ConstructITDBContext db = new ConstructITDBContext();

        // GET: EvidencijaAngazovanjaMasine
        public async Task<ActionResult> Index()
        {
            var evidencijeAngazovanjaMasina = db.EvidencijeAngazovanjaMasina.Include(e => e.Masina).Include(e => e.Zadatak);
            return View(await evidencijeAngazovanjaMasina.ToListAsync());
        }

        // GET: EvidencijaAngazovanjaMasine/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EvidencijaAngazovanjaMasine evidencijaAngazovanjaMasine = await db.EvidencijeAngazovanjaMasina.FindAsync(id);
            if (evidencijaAngazovanjaMasine == null)
            {
                return HttpNotFound();
            }
            return View(evidencijaAngazovanjaMasine);
        }

        // GET: EvidencijaAngazovanjaMasine/Create
        public ActionResult Create()
        {
            ViewBag.MasinaID = new SelectList(db.Masine, "MasinaID", "MasinaProizvodjac");
            ViewBag.ProjekatID = new SelectList(db.Zadaci, "ProjekatID", "ZadatakNaziv");
            return View();
        }

        // POST: EvidencijaAngazovanjaMasine/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "EvidencijaAngazovanjaMasineID,ProjekatID,ZadatakID,MasinaID,EvidAngMasDatum,EvidAngMasVremeOd,EvidAngMasVremeDo")] EvidencijaAngazovanjaMasine evidencijaAngazovanjaMasine)
        {
            if (ModelState.IsValid)
            {
                db.EvidencijeAngazovanjaMasina.Add(evidencijaAngazovanjaMasine);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.MasinaID = new SelectList(db.Masine, "MasinaID", "MasinaProizvodjac", evidencijaAngazovanjaMasine.MasinaID);
            ViewBag.ProjekatID = new SelectList(db.Zadaci, "ProjekatID", "ZadatakNaziv", evidencijaAngazovanjaMasine.ProjekatID);
            return View(evidencijaAngazovanjaMasine);
        }

        // GET: EvidencijaAngazovanjaMasine/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EvidencijaAngazovanjaMasine evidencijaAngazovanjaMasine = await db.EvidencijeAngazovanjaMasina.FindAsync(id);
            if (evidencijaAngazovanjaMasine == null)
            {
                return HttpNotFound();
            }
            ViewBag.MasinaID = new SelectList(db.Masine, "MasinaID", "MasinaProizvodjac", evidencijaAngazovanjaMasine.MasinaID);
            ViewBag.ProjekatID = new SelectList(db.Zadaci, "ProjekatID", "ZadatakNaziv", evidencijaAngazovanjaMasine.ProjekatID);
            return View(evidencijaAngazovanjaMasine);
        }

        // POST: EvidencijaAngazovanjaMasine/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "EvidencijaAngazovanjaMasineID,ProjekatID,ZadatakID,MasinaID,EvidAngMasDatum,EvidAngMasVremeOd,EvidAngMasVremeDo")] EvidencijaAngazovanjaMasine evidencijaAngazovanjaMasine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(evidencijaAngazovanjaMasine).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.MasinaID = new SelectList(db.Masine, "MasinaID", "MasinaProizvodjac", evidencijaAngazovanjaMasine.MasinaID);
            ViewBag.ProjekatID = new SelectList(db.Zadaci, "ProjekatID", "ZadatakNaziv", evidencijaAngazovanjaMasine.ProjekatID);
            return View(evidencijaAngazovanjaMasine);
        }

        // GET: EvidencijaAngazovanjaMasine/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EvidencijaAngazovanjaMasine evidencijaAngazovanjaMasine = await db.EvidencijeAngazovanjaMasina.FindAsync(id);
            if (evidencijaAngazovanjaMasine == null)
            {
                return HttpNotFound();
            }
            return View(evidencijaAngazovanjaMasine);
        }

        // POST: EvidencijaAngazovanjaMasine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            EvidencijaAngazovanjaMasine evidencijaAngazovanjaMasine = await db.EvidencijeAngazovanjaMasina.FindAsync(id);
            db.EvidencijeAngazovanjaMasina.Remove(evidencijaAngazovanjaMasine);
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
