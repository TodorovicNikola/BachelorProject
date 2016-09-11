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
    public class EvidencijaRadnogVremenaController : Controller
    {
        private ConstructITDBContext db = new ConstructITDBContext();

        // GET: EvidencijaRadnogVremena
        public async Task<ActionResult> Index()
        {
            var evidencijeRadnihVremena = db.EvidencijeRadnihVremena.Include(e => e.ProizvodniRadnik).Include(e => e.Zadatak);
            return View(await evidencijeRadnihVremena.ToListAsync());
        }

        // GET: EvidencijaRadnogVremena/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EvidencijaRadnogVremena evidencijaRadnogVremena = await db.EvidencijeRadnihVremena.FindAsync(id);
            if (evidencijaRadnogVremena == null)
            {
                return HttpNotFound();
            }
            return View(evidencijaRadnogVremena);
        }

        // GET: EvidencijaRadnogVremena/Create
        public ActionResult Create()
        {
            ViewBag.ProizvodniRadnikID = new SelectList(db.ProizvodniRadnici, "ProizvodniRadnikID", "ProizRadJMBG");
            ViewBag.ProjekatID = new SelectList(db.Zadaci, "ProjekatID", "ZadatakNaziv");
            return View();
        }

        // POST: EvidencijaRadnogVremena/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "EvidencijaRadnogVremenaID,EvRadnVrDatum,EvRadnVrVremeOd,EvRadnVrVremeDo,ProjekatID,ZadatakID,ProizvodniRadnikID")] EvidencijaRadnogVremena evidencijaRadnogVremena)
        {
            if (ModelState.IsValid)
            {
                db.EvidencijeRadnihVremena.Add(evidencijaRadnogVremena);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ProizvodniRadnikID = new SelectList(db.ProizvodniRadnici, "ProizvodniRadnikID", "ProizRadJMBG", evidencijaRadnogVremena.ProizvodniRadnikID);
            ViewBag.ProjekatID = new SelectList(db.Zadaci, "ProjekatID", "ZadatakNaziv", evidencijaRadnogVremena.ProjekatID);
            return View(evidencijaRadnogVremena);
        }

        // GET: EvidencijaRadnogVremena/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EvidencijaRadnogVremena evidencijaRadnogVremena = await db.EvidencijeRadnihVremena.FindAsync(id);
            if (evidencijaRadnogVremena == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProizvodniRadnikID = new SelectList(db.ProizvodniRadnici, "ProizvodniRadnikID", "ProizRadJMBG", evidencijaRadnogVremena.ProizvodniRadnikID);
            ViewBag.ProjekatID = new SelectList(db.Zadaci, "ProjekatID", "ZadatakNaziv", evidencijaRadnogVremena.ProjekatID);
            return View(evidencijaRadnogVremena);
        }

        // POST: EvidencijaRadnogVremena/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "EvidencijaRadnogVremenaID,EvRadnVrDatum,EvRadnVrVremeOd,EvRadnVrVremeDo,ProjekatID,ZadatakID,ProizvodniRadnikID")] EvidencijaRadnogVremena evidencijaRadnogVremena)
        {
            if (ModelState.IsValid)
            {
                db.Entry(evidencijaRadnogVremena).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ProizvodniRadnikID = new SelectList(db.ProizvodniRadnici, "ProizvodniRadnikID", "ProizRadJMBG", evidencijaRadnogVremena.ProizvodniRadnikID);
            ViewBag.ProjekatID = new SelectList(db.Zadaci, "ProjekatID", "ZadatakNaziv", evidencijaRadnogVremena.ProjekatID);
            return View(evidencijaRadnogVremena);
        }

        // GET: EvidencijaRadnogVremena/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EvidencijaRadnogVremena evidencijaRadnogVremena = await db.EvidencijeRadnihVremena.FindAsync(id);
            if (evidencijaRadnogVremena == null)
            {
                return HttpNotFound();
            }
            return View(evidencijaRadnogVremena);
        }

        // POST: EvidencijaRadnogVremena/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            EvidencijaRadnogVremena evidencijaRadnogVremena = await db.EvidencijeRadnihVremena.FindAsync(id);
            db.EvidencijeRadnihVremena.Remove(evidencijaRadnogVremena);
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
