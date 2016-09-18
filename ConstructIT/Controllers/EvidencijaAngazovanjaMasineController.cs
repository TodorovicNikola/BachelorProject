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
using ConstructIT.Models;

namespace ConstructIT.Controllers
{
    public class EvidencijaAngazovanjaMasineController : Controller
    {
        private ConstructITDBContext db = new ConstructITDBContext();

        // GET: EvidencijaAngazovanjaMasine
        public async Task<ActionResult> Index()
        {
            DateTime today = DateTime.Today;

            ViewData["projekti"] = db.Projekti.Include(p => p.Zadaci).ToList();
            ViewData["zadaciPrvogProjekta"] = db.Zadaci.Where(z => z.ProjekatID == db.Projekti.OrderBy(p => p.ProjekatID).FirstOrDefault().ProjekatID).ToList();
            ViewData["masine"] = db.Masine.Include(m => m.TipMasine).ToList();

            var evidencijeAngazovanjaMasina = db.EvidencijeAngazovanjaMasina.Where(e => DbFunctions.TruncateTime(e.EvidAngMasDatum) == today).Include(e => e.Masina).Include(e => e.Zadatak);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int masinaID, int projekatID, int zadatakID, int odVreme, int doVreme)
        {
            if (db.EvidencijeAngazovanjaMasina.Where(e => DbFunctions.TruncateTime(e.EvidAngMasDatum) == DateTime.Today && e.MasinaID == masinaID).Count() > 0)
            {

                if (db.EvidencijeAngazovanjaMasina.Where(e => DbFunctions.TruncateTime(e.EvidAngMasDatum) == DateTime.Today && e.MasinaID == masinaID &&
                ((e.EvidAngMasVremeOd >= odVreme && e.EvidAngMasVremeOd < doVreme) || (e.EvidAngMasVremeDo > odVreme && e.EvidAngMasVremeDo <= doVreme) || (e.EvidAngMasVremeOd <= odVreme && e.EvidAngMasVremeDo >= doVreme))
                ).Count() >= db.Masine.Find(masinaID).MasinaDostupnaKolicina)
                {
                    return RedirectToAction("Error", "Home", new { error = "Uneseno vreme je u konfliktu sa nekom od stavki iz evidencije!" });
                }
                else
                {
                    db.EvidencijeAngazovanjaMasina.Add(new EvidencijaAngazovanjaMasine { MasinaID = masinaID, ProjekatID = projekatID, ZadatakID = zadatakID, EvidAngMasDatum = DateTime.Today, EvidAngMasVremeOd = odVreme, EvidAngMasVremeDo = doVreme });
                }
            }
            else
            {
                db.EvidencijeAngazovanjaMasina.Add(new EvidencijaAngazovanjaMasine { MasinaID = masinaID, ProjekatID = projekatID, ZadatakID = zadatakID, EvidAngMasDatum = DateTime.Today, EvidAngMasVremeOd = odVreme, EvidAngMasVremeDo = doVreme });
            }

            db.SaveChanges();

            return RedirectToAction("Index");
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
            Masina m = db.Masine.Find(evidencijaAngazovanjaMasine.MasinaID);

            ViewData["vremeOd"] = evidencijaAngazovanjaMasine.EvidAngMasVremeOd;
            ViewData["vremeDo"] = evidencijaAngazovanjaMasine.EvidAngMasVremeDo;
            ViewBag.ProizvodniRadnik = m.TipMasine.TipMasineNaziv + ": " + m.MasinaProizvodjac;
            ViewBag.ProjekatNaziv = db.Projekti.Find(evidencijaAngazovanjaMasine.ProjekatID).ProjekatNaziv;
            ViewBag.ZadatakNaziv = db.Zadaci.Where(z => z.ProjekatID == evidencijaAngazovanjaMasine.ProjekatID && z.ZadatakID == evidencijaAngazovanjaMasine.ZadatakID).FirstOrDefault().ZadatakNaziv;
            return View(evidencijaAngazovanjaMasine);
        }

        // POST: EvidencijaAngazovanjaMasine/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "EvidencijaAngazovanjaMasineID,ProjekatID,ZadatakID,MasinaID,EvidAngMasDatum,EvidAngMasVremeOd,EvidAngMasVremeDo")] EvidencijaAngazovanjaMasine evidencijaAngazovanjaMasine)
        {
            evidencijaAngazovanjaMasine.EvidAngMasDatum = DateTime.Today;

            if (db.EvidencijeAngazovanjaMasina.Where(e => DbFunctions.TruncateTime(e.EvidAngMasDatum) == DateTime.Today && e.MasinaID == evidencijaAngazovanjaMasine.MasinaID && e.EvidencijaAngazovanjaMasineID != evidencijaAngazovanjaMasine.EvidencijaAngazovanjaMasineID &&
                ((e.EvidAngMasVremeOd >= evidencijaAngazovanjaMasine.EvidAngMasVremeOd && e.EvidAngMasVremeOd < evidencijaAngazovanjaMasine.EvidAngMasVremeDo) || (e.EvidAngMasVremeDo > evidencijaAngazovanjaMasine.EvidAngMasVremeOd && e.EvidAngMasVremeDo <= evidencijaAngazovanjaMasine.EvidAngMasVremeDo) || (e.EvidAngMasVremeOd <= evidencijaAngazovanjaMasine.EvidAngMasVremeOd && e.EvidAngMasVremeDo >= evidencijaAngazovanjaMasine.EvidAngMasVremeDo))
                ).Count() >= db.Masine.Find(evidencijaAngazovanjaMasine.MasinaID).MasinaDostupnaKolicina)
            {
                ModelState.AddModelError("EvidAngMasVremeOd", "Unesena vremena su u kofliktom sa nekom od postojećih stavki!");
                ModelState.AddModelError("EvidAngMasVremeDo", "Unesena vremena su u kofliktom sa nekom od postojećih stavki!");
            }

            if (ModelState.IsValid)
            {
                db.Entry(evidencijaAngazovanjaMasine).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            Masina m = db.Masine.Find(evidencijaAngazovanjaMasine.MasinaID);

            ViewData["vremeOd"] = evidencijaAngazovanjaMasine.EvidAngMasVremeOd;
            ViewData["vremeDo"] = evidencijaAngazovanjaMasine.EvidAngMasVremeDo;
            ViewBag.ProizvodniRadnik = m.TipMasine.TipMasineNaziv + ": " + m.MasinaProizvodjac;
            ViewBag.ProjekatNaziv = db.Projekti.Find(evidencijaAngazovanjaMasine.ProjekatID).ProjekatNaziv;
            ViewBag.ZadatakNaziv = db.Zadaci.Where(z => z.ProjekatID == evidencijaAngazovanjaMasine.ProjekatID && z.ZadatakID == evidencijaAngazovanjaMasine.ZadatakID).FirstOrDefault().ZadatakNaziv;
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

        [HttpPost]
        public JsonResult GetTasksForProject(int projekatID)
        {
            List<ZadatakDTO> zadaci = new List<ZadatakDTO>();

            foreach (var zadatak in db.Zadaci.Where(z => z.ProjekatID == projekatID).ToList())
            {
                zadaci.Add(new ZadatakDTO(zadatak));
            }

            return Json(zadaci);
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
