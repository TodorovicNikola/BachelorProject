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
    public class MasinaController : Controller
    {
        private ConstructITDBContext db = new ConstructITDBContext();

        // GET: Masina
        public async Task<ActionResult> Index(String parametarPretrage)
        {
            IOrderedQueryable<Masina> masine = null;

            if (!String.IsNullOrEmpty(parametarPretrage))
            {
                masine = db.Masine.Include(m => m.TipMasine).Where(m => m.TipMasine.TipMasineNaziv.Contains(parametarPretrage) || m.MasinaProizvodjac.Contains(parametarPretrage)).OrderBy(m => m.TipMasine.TipMasineNaziv);
            }
            else
            {
                masine = db.Masine.Include(m => m.TipMasine).OrderBy(m => m.TipMasine.TipMasineNaziv);
            }


                return View(await masine.ToListAsync());
        }

        // GET: Masina/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Masina masina = await db.Masine.FindAsync(id);
            if (masina == null)
            {
                return HttpNotFound();
            }
            return View(masina);
        }

        // GET: Masina/Create
        public ActionResult Create()
        {
            ViewBag.TipMasineID = new SelectList(db.TipoviMasina, "TipMasineID", "TipMasineNaziv");
            return View();
        }

        // POST: Masina/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MasinaID,MasinaProizvodjac,MasinaOpis,TipMasineID,MasinaDostupnaKolicina")] Masina masina)
        {
            if (ModelState.IsValid)
            {
                db.Masine.Add(masina);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.TipMasineID = new SelectList(db.TipoviMasina, "TipMasineID", "TipMasineNaziv", masina.TipMasineID);
            return View(masina);
        }

        // GET: Masina/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Masina masina = await db.Masine.FindAsync(id);
            if (masina == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipMasineID = new SelectList(db.TipoviMasina, "TipMasineID", "TipMasineNaziv", masina.TipMasineID);
            return View(masina);
        }

        // POST: Masina/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MasinaID,MasinaProizvodjac,MasinaOpis,TipMasineID,MasinaDostupnaKolicina")] Masina masina)
        {
            if (ModelState.IsValid)
            {
                db.Entry(masina).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.TipMasineID = new SelectList(db.TipoviMasina, "TipMasineID", "TipMasineNaziv", masina.TipMasineID);
            return View(masina);
        }

        // GET: Masina/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Masina masina = await db.Masine.FindAsync(id);
            if (masina == null)
            {
                return HttpNotFound();
            }
            return View(masina);
        }

        // POST: Masina/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Masina masina = await db.Masine.FindAsync(id);
            db.Masine.Remove(masina);
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
