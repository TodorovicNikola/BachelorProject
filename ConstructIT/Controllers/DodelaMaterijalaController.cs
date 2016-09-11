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
        public ActionResult Create()
        {
            ViewBag.PotrebaMaterijalaID = new SelectList(db.PotrebeMaterijala, "PotrebaMaterijalaID", "PotrebaMaterijalaID");
            return View();
        }

        // POST: DodelaMaterijala/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "DodelaMaterijalaID,PotrebaMaterijalaID,DodMatDatumDodele,DodMatKolicina")] DodelaMaterijala dodelaMaterijala)
        {
            if (ModelState.IsValid)
            {
                db.DodeleMaterijala.Add(dodelaMaterijala);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.PotrebaMaterijalaID = new SelectList(db.PotrebeMaterijala, "PotrebaMaterijalaID", "PotrebaMaterijalaID", dodelaMaterijala.PotrebaMaterijalaID);
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
            ViewBag.PotrebaMaterijalaID = new SelectList(db.PotrebeMaterijala, "PotrebaMaterijalaID", "PotrebaMaterijalaID", dodelaMaterijala.PotrebaMaterijalaID);
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
                db.Entry(dodelaMaterijala).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PotrebaMaterijalaID = new SelectList(db.PotrebeMaterijala, "PotrebaMaterijalaID", "PotrebaMaterijalaID", dodelaMaterijala.PotrebaMaterijalaID);
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
