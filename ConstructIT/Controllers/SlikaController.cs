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
    public class SlikaController : Controller
    {
        private ConstructITDBContext db = new ConstructITDBContext();

        // GET: Slika
        public async Task<ActionResult> Index()
        {
            var slike = db.Slike.Include(s => s.Galerija);
            return View(await slike.ToListAsync());
        }

        // GET: Slika/Details/5
        public async Task<ActionResult> Details(String naziv)
        {
            if (naziv == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slika slika = await db.Slike.Where(s => s.SlikaNaziv == naziv).Include(s => s.KomentariNaSliku).FirstOrDefaultAsync();
            if (slika == null)
            {
                return HttpNotFound();
            }
            return View(slika);
        }

        // GET: Slika/Create
        public ActionResult Create()
        {
            ViewBag.ProjekatID = new SelectList(db.Galerije, "ProjekatID", "ProjekatID");
            return View();
        }

        // POST: Slika/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SlikaID,SlikaNaziv,SlikaOpis,ProjekatID,GalerijaDatum")] Slika slika)
        {
            if (ModelState.IsValid)
            {
                db.Slike.Add(slika);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ProjekatID = new SelectList(db.Galerije, "ProjekatID", "ProjekatID", slika.ProjekatID);
            return View(slika);
        }

        // GET: Slika/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slika slika = await db.Slike.FindAsync(id);
            if (slika == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjekatID = new SelectList(db.Galerije, "ProjekatID", "ProjekatID", slika.ProjekatID);
            return View(slika);
        }

        // POST: Slika/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SlikaID,SlikaNaziv,SlikaOpis,ProjekatID,GalerijaDatum")] Slika slika)
        {
            if (ModelState.IsValid)
            {
                db.Entry(slika).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ProjekatID = new SelectList(db.Galerije, "ProjekatID", "ProjekatID", slika.ProjekatID);
            return View(slika);
        }

        // GET: Slika/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slika slika = await db.Slike.FindAsync(id);
            if (slika == null)
            {
                return HttpNotFound();
            }
            return View(slika);
        }

        // POST: Slika/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Slika slika = await db.Slike.FindAsync(id);
            db.Slike.Remove(slika);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public ActionResult AddComment(int slikaID, String komentarNaslov, String komentarSadrzaj)
        {
            KomentarSlika kS = new KomentarSlika();

            kS.SlikaID = slikaID;

            kS.KomentarSlikaNaslov = komentarNaslov;
            kS.KomentarSlikaSadrzaj = komentarSadrzaj;

            Korisnik k = (Korisnik)Session["korisnik"];

            kS.KorisnikID = k.KorisnikID;

            kS.KomentarSlikaVremePostavljanja = DateTime.Now;

            db.KomentariNaSlike.Add(kS);

            db.SaveChanges();

            return RedirectToAction("Details", new { naziv = db.Slike.Where(s => s.SlikaID == slikaID).FirstOrDefault().SlikaNaziv });
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
