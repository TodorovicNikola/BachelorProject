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
    public class PotrebaStrukeController : Controller
    {
        private ConstructITDBContext db = new ConstructITDBContext();

        // GET: PotrebaStruke
        public async Task<ActionResult> Index()
        {
            var potrebeStruka = db.PotrebeStruka.Include(p => p.Struka).Include(p => p.Zadatak);
            return View(await potrebeStruka.ToListAsync());
        }

        // GET: PotrebaStruke/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PotrebaStruke potrebaStruke = await db.PotrebeStruka.FindAsync(id);
            if (potrebaStruke == null)
            {
                return HttpNotFound();
            }
            return View(potrebaStruke);
        }

        // GET: PotrebaStruke/Create
        public ActionResult Create(int projekatID, int zadatakID)
        {
            ViewBag.StrukaID = new SelectList(db.Struke, "StrukaID", "StrukaNaziv");
            ViewBag.ProjekatNaziv = db.Projekti.Where(p => p.ProjekatID == projekatID).FirstOrDefault().ProjekatNaziv;
            ViewBag.ZadatakNaziv = db.Zadaci.Where(z => z.ZadatakID == zadatakID).FirstOrDefault().ZadatakNaziv;
            ViewBag.ProjekatID = projekatID;
            ViewBag.ZadatakID = zadatakID;
            return View();
        }

        // POST: PotrebaStruke/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PotrebaStrukeID,PotrebaStrukeOdDatuma,PotrebaStrukeDoDatuma,PotrebaStrukeKolicina,ProjekatID,ZadatakID,StrukaID")] PotrebaStruke potrebaStruke)
        {
            if (ModelState.IsValid)
            {
                db.PotrebeStruka.Add(potrebaStruke);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.StrukaID = new SelectList(db.Struke, "StrukaID", "StrukaNaziv", potrebaStruke.StrukaID);
            ViewBag.ProjekatNaziv = db.Projekti.Where(p => p.ProjekatID == potrebaStruke.ProjekatID).FirstOrDefault().ProjekatNaziv;
            ViewBag.ZadatakNaziv = db.Zadaci.Where(z => z.ZadatakID == potrebaStruke.ZadatakID).FirstOrDefault().ZadatakNaziv;
            ViewBag.ProjekatID = potrebaStruke.ProjekatID;
            ViewBag.ZadatakID = potrebaStruke.ZadatakID;
            return View(potrebaStruke);
        }

        // GET: PotrebaStruke/Edit/5
        public async Task<ActionResult> Edit(int? potrebaStrukeID)
        {
            if (potrebaStrukeID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PotrebaStruke potrebaStruke = await db.PotrebeStruka.FindAsync(potrebaStrukeID);
            if (potrebaStruke == null)
            {
                return HttpNotFound();
            }

            ViewBag.StrukaNaziv = db.Struke.Where(s => s.StrukaID == potrebaStruke.StrukaID).FirstOrDefault().StrukaNaziv;
            ViewBag.ProjekatNaziv = db.Projekti.Where(p => p.ProjekatID == potrebaStruke.ProjekatID).FirstOrDefault().ProjekatNaziv;
            ViewBag.ZadatakNaziv = db.Zadaci.Where(z => z.ZadatakID == potrebaStruke.ZadatakID).FirstOrDefault().ZadatakNaziv;

            return View(potrebaStruke);
        }

        // POST: PotrebaStruke/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PotrebaStrukeID,PotrebaStrukeOdDatuma,PotrebaStrukeDoDatuma,PotrebaStrukeKolicina,ProjekatID,ZadatakID,StrukaID")] PotrebaStruke potrebaStruke)
        {
            if (ModelState.IsValid)
            {
                db.Entry(potrebaStruke).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.StrukaNaziv = db.Struke.Where(s => s.StrukaID == potrebaStruke.StrukaID).FirstOrDefault().StrukaNaziv;
            ViewBag.ProjekatNaziv = db.Projekti.Where(p => p.ProjekatID == potrebaStruke.ProjekatID).FirstOrDefault().ProjekatNaziv;
            ViewBag.ZadatakNaziv = db.Zadaci.Where(z => z.ZadatakID == potrebaStruke.ZadatakID).FirstOrDefault().ZadatakNaziv;
            return View(potrebaStruke);
        }

        // GET: PotrebaStruke/Delete/5
        public async Task<ActionResult> Delete(int? potrebaStrukeID)
        {
            if (potrebaStrukeID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PotrebaStruke potrebaStruke = await db.PotrebeStruka.FindAsync(potrebaStrukeID);
            if (potrebaStruke == null)
            {
                return HttpNotFound();
            }
            return View(potrebaStruke);
        }

        // POST: PotrebaStruke/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PotrebaStruke potrebaStruke = await db.PotrebeStruka.FindAsync(id);
            db.PotrebeStruka.Remove(potrebaStruke);
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
