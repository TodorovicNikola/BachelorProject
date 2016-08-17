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
    public class MaterijalController : Controller
    {
        private ConstructITDBContext db = new ConstructITDBContext();

        // GET: Materijal
        public async Task<ActionResult> Index()
        {
            return View(await db.Materijali.ToListAsync());
        }

        // GET: Materijal/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Materijal materijal = await db.Materijali.FindAsync(id);
            if (materijal == null)
            {
                return HttpNotFound();
            }
            return View(materijal);
        }

        // GET: Materijal/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Materijal/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MaterijalID,MaterijalNaziv,MaterijalProizvodjac,MaterijalOpis,MaterijalRaspolozivaKolicina")] Materijal materijal)
        {
            if (ModelState.IsValid)
            {
                db.Materijali.Add(materijal);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(materijal);
        }

        // GET: Materijal/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Materijal materijal = await db.Materijali.FindAsync(id);
            if (materijal == null)
            {
                return HttpNotFound();
            }
            return View(materijal);
        }

        // POST: Materijal/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MaterijalID,MaterijalNaziv,MaterijalProizvodjac,MaterijalOpis,MaterijalRaspolozivaKolicina")] Materijal materijal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(materijal).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(materijal);
        }

        // GET: Materijal/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Materijal materijal = await db.Materijali.FindAsync(id);
            if (materijal == null)
            {
                return HttpNotFound();
            }
            return View(materijal);
        }

        // POST: Materijal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Materijal materijal = await db.Materijali.FindAsync(id);
            db.Materijali.Remove(materijal);
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
