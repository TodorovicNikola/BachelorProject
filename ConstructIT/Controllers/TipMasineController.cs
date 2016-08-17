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
    public class TipMasineController : Controller
    {
        private ConstructITDBContext db = new ConstructITDBContext();

        // GET: TipMasine
        public async Task<ActionResult> Index()
        {
            return View(await db.TipoviMasina.ToListAsync());
        }

        // GET: TipMasine/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipMasine tipMasine = await db.TipoviMasina.FindAsync(id);
            if (tipMasine == null)
            {
                return HttpNotFound();
            }
            return View(tipMasine);
        }

        // GET: TipMasine/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipMasine/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TipMasineID,TipMasineNaziv")] TipMasine tipMasine)
        {
            if (ModelState.IsValid)
            {
                db.TipoviMasina.Add(tipMasine);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tipMasine);
        }

        // GET: TipMasine/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipMasine tipMasine = await db.TipoviMasina.FindAsync(id);
            if (tipMasine == null)
            {
                return HttpNotFound();
            }
            return View(tipMasine);
        }

        // POST: TipMasine/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TipMasineID,TipMasineNaziv")] TipMasine tipMasine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipMasine).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tipMasine);
        }

        // GET: TipMasine/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipMasine tipMasine = await db.TipoviMasina.FindAsync(id);
            if (tipMasine == null)
            {
                return HttpNotFound();
            }
            return View(tipMasine);
        }

        // POST: TipMasine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TipMasine tipMasine = await db.TipoviMasina.FindAsync(id);
            db.TipoviMasina.Remove(tipMasine);
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
