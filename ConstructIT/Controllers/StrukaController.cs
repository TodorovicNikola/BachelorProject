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
    public class StrukaController : Controller
    {
        private ConstructITDBContext db = new ConstructITDBContext();

        // GET: Struka
        public async Task<ActionResult> Index()
        {
            return View(await db.Struke.ToListAsync());
        }

        // GET: Struka/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Struka struka = await db.Struke.FindAsync(id);
            if (struka == null)
            {
                return HttpNotFound();
            }
            return View(struka);
        }

        // GET: Struka/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Struka/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "StrukaID,StrukaNaziv")] Struka struka)
        {
            if (ModelState.IsValid)
            {
                db.Struke.Add(struka);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(struka);
        }

        // GET: Struka/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Struka struka = await db.Struke.FindAsync(id);
            if (struka == null)
            {
                return HttpNotFound();
            }
            return View(struka);
        }

        // POST: Struka/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "StrukaID,StrukaNaziv")] Struka struka)
        {
            if (ModelState.IsValid)
            {
                db.Entry(struka).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(struka);
        }

        // GET: Struka/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Struka struka = await db.Struke.FindAsync(id);
            if (struka == null)
            {
                return HttpNotFound();
            }
            return View(struka);
        }

        // POST: Struka/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Struka struka = await db.Struke.FindAsync(id);
            db.Struke.Remove(struka);
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
