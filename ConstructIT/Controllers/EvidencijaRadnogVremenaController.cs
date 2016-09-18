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
using ConstructIT.Models;

namespace ConstructIT.Controllers
{
    public class EvidencijaRadnogVremenaController : Controller
    {
        private ConstructITDBContext db = new ConstructITDBContext();

        // GET: EvidencijaRadnogVremena
        public async Task<ActionResult> Index()
        {
            DateTime today = DateTime.Today;

            var evidencijeRadnihVremena = db.EvidencijeRadnihVremena.Where(e => DbFunctions.TruncateTime(e.EvRadnVrDatum) == today).OrderBy(e => e.ProizvodniRadnikID).Include(e => e.ProizvodniRadnik).Include(e => e.Zadatak);

            ViewData["projekti"] = db.Projekti.Include(p => p.Zadaci).ToList();
            ViewData["zadaciPrvogProjekta"] = db.Zadaci.Where(z => z.ProjekatID == db.Projekti.OrderBy(p => p.ProjekatID).FirstOrDefault().ProjekatID).ToList();
            ViewData["proizvodniRadnici"] = db.ProizvodniRadnici.Include(pr => pr.Struka).ToList();

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
            return RedirectToAction("Index");
        }

        // POST: EvidencijaRadnogVremena/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int proizvodniRadnikID, int projekatID, int zadatakID, int odVreme, int doVreme)
        {
            if(db.EvidencijeRadnihVremena.Where(e => DbFunctions.TruncateTime(e.EvRadnVrDatum) == DateTime.Today && e.ProizvodniRadnikID == proizvodniRadnikID).Count() > 0)
            {
                
                if (db.EvidencijeRadnihVremena.Where(e => DbFunctions.TruncateTime(e.EvRadnVrDatum) == DateTime.Today && e.ProizvodniRadnikID == proizvodniRadnikID &&
                ((e.EvRadnVrVremeOd >= odVreme && e.EvRadnVrVremeOd < doVreme) || (e.EvRadnVrVremeDo > odVreme && e.EvRadnVrVremeDo <= doVreme) || (e.EvRadnVrVremeOd <= odVreme && e.EvRadnVrVremeDo >= doVreme))
                ).Count()>0)
                {
                    return RedirectToAction("Error", "Home", new { error = "Uneseno vreme je u konfliktu sa nekom od stavki iz evidencije!" });
                }
                else
                {
                    db.EvidencijeRadnihVremena.Add(new EvidencijaRadnogVremena { ProizvodniRadnikID = proizvodniRadnikID, ProjekatID = projekatID, ZadatakID = zadatakID, EvRadnVrDatum = DateTime.Today, EvRadnVrVremeOd = odVreme, EvRadnVrVremeDo = doVreme });
                }
            }
            else
            {
                db.EvidencijeRadnihVremena.Add(new EvidencijaRadnogVremena { ProizvodniRadnikID = proizvodniRadnikID, ProjekatID = projekatID, ZadatakID = zadatakID, EvRadnVrDatum = DateTime.Today, EvRadnVrVremeOd = odVreme, EvRadnVrVremeDo = doVreme });
            }

            db.SaveChanges();

            return RedirectToAction("Index");
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
            ProizvodniRadnik pr = db.ProizvodniRadnici.Find(evidencijaRadnogVremena.ProizvodniRadnikID);

            ViewData["vremeOd"] = evidencijaRadnogVremena.EvRadnVrVremeOd;
            ViewData["vremeDo"] = evidencijaRadnogVremena.EvRadnVrVremeDo;
            ViewBag.ProizvodniRadnik = pr.ProizvodniRadnikID + " - " + pr.ProizRadIme + " " + pr.ProizRadPrezime;
            ViewBag.ProjekatNaziv = db.Projekti.Find(evidencijaRadnogVremena.ProjekatID).ProjekatNaziv;
            ViewBag.ZadatakNaziv = db.Zadaci.Where(z => z.ProjekatID == evidencijaRadnogVremena.ProjekatID && z.ZadatakID == evidencijaRadnogVremena.ZadatakID).FirstOrDefault().ZadatakNaziv;
            return View(evidencijaRadnogVremena);
        }

        // POST: EvidencijaRadnogVremena/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "EvidencijaRadnogVremenaID,EvRadnVrDatum,EvRadnVrVremeOd,EvRadnVrVremeDo,ProjekatID,ZadatakID,ProizvodniRadnikID")] EvidencijaRadnogVremena evidencijaRadnogVremena)
        {
            evidencijaRadnogVremena.EvRadnVrDatum = DateTime.Today;

            if (db.EvidencijeRadnihVremena.Where(e => DbFunctions.TruncateTime(e.EvRadnVrDatum) == DateTime.Today && e.ProizvodniRadnikID == evidencijaRadnogVremena.ProizvodniRadnikID && e.EvidencijaRadnogVremenaID != evidencijaRadnogVremena.EvidencijaRadnogVremenaID &&
                ((e.EvRadnVrVremeOd >= evidencijaRadnogVremena.EvRadnVrVremeOd && e.EvRadnVrVremeOd < evidencijaRadnogVremena.EvRadnVrVremeDo) || (e.EvRadnVrVremeDo > evidencijaRadnogVremena.EvRadnVrVremeOd && e.EvRadnVrVremeDo <= evidencijaRadnogVremena.EvRadnVrVremeDo) || (e.EvRadnVrVremeOd <= evidencijaRadnogVremena.EvRadnVrVremeOd && e.EvRadnVrVremeDo >= evidencijaRadnogVremena.EvRadnVrVremeDo))
                ).Count() > 0)
            {
                ModelState.AddModelError("EvRadnVrVremeOd", "Unesena vremena su u kofliktom sa nekom od postojećih stavki!");
                ModelState.AddModelError("EvRadnVrVremeDo", "Unesena vremena su u kofliktom sa nekom od postojećih stavki!");
            }


                if (ModelState.IsValid)
            {
                db.Entry(evidencijaRadnogVremena).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ProizvodniRadnik pr = db.ProizvodniRadnici.Find(evidencijaRadnogVremena.ProizvodniRadnikID);

            ViewData["vremeOd"] = evidencijaRadnogVremena.EvRadnVrVremeOd;
            ViewData["vremeDo"] = evidencijaRadnogVremena.EvRadnVrVremeDo;
            ViewBag.ProizvodniRadnik = pr.ProizvodniRadnikID + " - " + pr.ProizRadIme + " " + pr.ProizRadPrezime;
            ViewBag.ProjekatNaziv = db.Projekti.Find(evidencijaRadnogVremena.ProjekatID).ProjekatNaziv;
            ViewBag.ZadatakNaziv = db.Zadaci.Where(z => z.ProjekatID == evidencijaRadnogVremena.ProjekatID && z.ZadatakID == evidencijaRadnogVremena.ZadatakID).FirstOrDefault().ZadatakNaziv;
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

        [HttpPost]
        public JsonResult GetTasksForProject(int projekatID)
        {
            List<ZadatakDTO> zadaci = new List<ZadatakDTO>();

            foreach (var zadatak in db.Zadaci.Where(z => z.ProjekatID == projekatID).ToList())
            {
                zadaci.Add(new ZadatakDTO(zadatak));
            }

            return Json(zadaci);
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
