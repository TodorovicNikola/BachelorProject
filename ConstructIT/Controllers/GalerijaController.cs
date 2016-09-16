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
using System.Data.Entity.Infrastructure;
using System.IO;

namespace ConstructIT.Controllers
{
    public class GalerijaController : Controller
    {
        private ConstructITDBContext db = new ConstructITDBContext();

        // GET: Galerija
        public async Task<ActionResult> Index(int projekatID)
        {
            var galerije = db.Galerije.Include(g => g.Projekat).Where(p => p.ProjekatID == projekatID);
            ViewData["projekatID"] = projekatID;
            ViewData["projekatNaziv"] = db.Projekti.Where(p => p.ProjekatID == projekatID).FirstOrDefault().ProjekatNaziv;
            return View(await galerije.ToListAsync());
        }

        // GET: Galerija/Details/5
        public async Task<ActionResult> Details(int projekatID, DateTime datum)
        {

            Galerija galerija = await db.Galerije.Where(g => g.ProjekatID == projekatID && g.GalerijaDatum == datum).Include(g => g.Slike).Include(g => g.Projekat).Include(g => g.KomentariNaGaleriju).FirstOrDefaultAsync();
            if (galerija == null)
            {
                return HttpNotFound();
            }
            return View(galerija);
        }

        // GET: Galerija/Create
        public ActionResult Create(int projekatID)
        {
            Galerija galerija = new Galerija();
            galerija.ProjekatID = projekatID;
            galerija.GalerijaDatum = DateTime.Today;

            try
            {
                db.Galerije.Add(galerija);
                db.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                TempData["Visibility"] = "Visible";
                return RedirectToAction("Index", new { projekatID = projekatID });
            }

            return RedirectToAction("Index", new { projekatID = projekatID });
        }

        // GET: Galerija/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Galerija galerija = await db.Galerije.FindAsync(id);
            if (galerija == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjekatID = new SelectList(db.Projekti, "ProjekatID", "ProjekatNaziv", galerija.ProjekatID);
            return View(galerija);
        }

        // POST: Galerija/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProjekatID,GalerijaDatum")] Galerija galerija)
        {
            if (ModelState.IsValid)
            {
                db.Entry(galerija).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ProjekatID = new SelectList(db.Projekti, "ProjekatID", "ProjekatNaziv", galerija.ProjekatID);
            return View(galerija);
        }

        // GET: Galerija/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Galerija galerija = await db.Galerije.FindAsync(id);
            if (galerija == null)
            {
                return HttpNotFound();
            }
            return View(galerija);
        }

        // POST: Galerija/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Galerija galerija = await db.Galerije.FindAsync(id);
            db.Galerije.Remove(galerija);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Upload(int projekatID, DateTime datum)
        {
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    db.Slike.Add(new Slika { ProjekatID = projekatID, GalerijaDatum = datum });
                    db.SaveChanges();
                    Slika slika = db.Slike.OrderByDescending(s => s.SlikaID).FirstOrDefault();



                    var fileName = Path.GetFileName(file.FileName);

                    slika.SlikaNaziv = slika.SlikaID.ToString() + fileName;

                    var path = Path.Combine(Server.MapPath("~/Content/Images/"), slika.SlikaID.ToString() + fileName);
                    file.SaveAs(path);

                    db.SaveChanges();
                }
            }

            return RedirectToAction("Details", new { projekatID = projekatID, datum = datum});
        }

        public ActionResult AddComment(int projekatID, String GalerijaDatum, String komentarNaslov, String komentarSadrzaj)
        {
            KomentarGalerija kG = new KomentarGalerija();

            kG.GalerijaDatum = DateTime.Parse(GalerijaDatum);
            kG.ProjekatID = projekatID;
            kG.KomentarGalerijaNaslov = komentarNaslov;
            kG.KomentarGalerijaSadrzaj = komentarSadrzaj;

            Korisnik k = (Korisnik)Session["korisnik"];

            kG.KorisnikID = k.KorisnikID;

            kG.KomentarGalerijaVremePostavljanja = DateTime.Now;

            db.KomentariNaGalerije.Add(kG);

            db.SaveChanges();

            return RedirectToAction("Details", new { projekatID = projekatID, datum = kG.GalerijaDatum });
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
