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
            var potrebeMaterijala = db.PotrebeMaterijala.Include(p => p.Materijal).Include(p => p.Zadatak);
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
        public ActionResult Create()
        {
            ViewBag.MaterijalID = new SelectList(db.Materijali, "MaterijalID", "MaterijalNaziv");
            ViewBag.ProjekatID = new SelectList(db.Zadaci, "ProjekatID", "ZadatakNaziv");
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
                return RedirectToAction("Index");
            }

            ViewBag.MaterijalID = new SelectList(db.Materijali, "MaterijalID", "MaterijalNaziv", potrebaMaterijala.MaterijalID);
            ViewBag.ProjekatID = new SelectList(db.Zadaci, "ProjekatID", "ZadatakNaziv", potrebaMaterijala.ProjekatID);
            return View(potrebaMaterijala);
        }

        // GET: PotrebaMaterijala/Edit/5
        public async Task<ActionResult> Edit(int? id)
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
            ViewBag.MaterijalID = new SelectList(db.Materijali, "MaterijalID", "MaterijalNaziv", potrebaMaterijala.MaterijalID);
            ViewBag.ProjekatID = new SelectList(db.Zadaci, "ProjekatID", "ZadatakNaziv", potrebaMaterijala.ProjekatID);
            return View(potrebaMaterijala);
        }

        // POST: PotrebaMaterijala/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProjekatID,ZadatakID,MaterijalID,PotrMatOdDatuma,PotrMatDoDatuma,PotrMatKolicina")] PotrebaMaterijala potrebaMaterijala)
        {
            if (ModelState.IsValid)
            {
                db.Entry(potrebaMaterijala).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.MaterijalID = new SelectList(db.Materijali, "MaterijalID", "MaterijalNaziv", potrebaMaterijala.MaterijalID);
            ViewBag.ProjekatID = new SelectList(db.Zadaci, "ProjekatID", "ZadatakNaziv", potrebaMaterijala.ProjekatID);
            return View(potrebaMaterijala);
        }

        // GET: PotrebaMaterijala/Delete/5
        public async Task<ActionResult> Delete(int? id)
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

        // POST: PotrebaMaterijala/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PotrebaMaterijala potrebaMaterijala = await db.PotrebeMaterijala.FindAsync(id);
            db.PotrebeMaterijala.Remove(potrebaMaterijala);
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
