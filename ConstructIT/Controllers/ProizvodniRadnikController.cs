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
    public class ProizvodniRadnikController : Controller
    {
        private ConstructITDBContext db = new ConstructITDBContext();

        // GET: ProizvodniRadnik
        public async Task<ActionResult> Index(String parametarPretrage)
        {
            var proizvodniRadnici = db.ProizvodniRadnici.Include(p => p.Struka);

            if (!String.IsNullOrEmpty(parametarPretrage))
            {
                proizvodniRadnici = proizvodniRadnici.Where(pr => pr.Struka.StrukaNaziv.Contains(parametarPretrage) || pr.ProizRadIme.Contains(parametarPretrage) || pr.ProizRadPrezime.Contains(parametarPretrage) || pr.ProizvodniRadnikID.ToString() == parametarPretrage);
            }

            
            return View(await proizvodniRadnici.ToListAsync());
        }

        // GET: ProizvodniRadnik/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProizvodniRadnik proizvodniRadnik = await db.ProizvodniRadnici.FindAsync(id);
            if (proizvodniRadnik == null)
            {
                return HttpNotFound();
            }
            return View(proizvodniRadnik);
        }

        // GET: ProizvodniRadnik/Create
        public ActionResult Create()
        {
            ViewBag.StrukaID = new SelectList(db.Struke, "StrukaID", "StrukaNaziv");
            return View();
        }

        // POST: ProizvodniRadnik/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ProizvodniRadnikID,ProizRadJMBG,ProizRadIme,ProizRadPrezime,ProizRadEMail,ProizRadAdresa,ProizRadTelMob,StrukaID")] ProizvodniRadnik proizvodniRadnik)
        {
            if (ModelState.IsValid)
            {
                db.ProizvodniRadnici.Add(proizvodniRadnik);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.StrukaID = new SelectList(db.Struke, "StrukaID", "StrukaNaziv", proizvodniRadnik.StrukaID);
            return View(proizvodniRadnik);
        }

        // GET: ProizvodniRadnik/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProizvodniRadnik proizvodniRadnik = await db.ProizvodniRadnici.FindAsync(id);
            if (proizvodniRadnik == null)
            {
                return HttpNotFound();
            }
            ViewBag.StrukaID = new SelectList(db.Struke, "StrukaID", "StrukaNaziv", proizvodniRadnik.StrukaID);
            return View(proizvodniRadnik);
        }

        // POST: ProizvodniRadnik/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProizvodniRadnikID,ProizRadJMBG,ProizRadIme,ProizRadPrezime,ProizRadEMail,ProizRadAdresa,ProizRadTelMob,StrukaID")] ProizvodniRadnik proizvodniRadnik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proizvodniRadnik).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.StrukaID = new SelectList(db.Struke, "StrukaID", "StrukaNaziv", proizvodniRadnik.StrukaID);
            return View(proizvodniRadnik);
        }

        // GET: ProizvodniRadnik/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProizvodniRadnik proizvodniRadnik = await db.ProizvodniRadnici.FindAsync(id);
            if (proizvodniRadnik == null)
            {
                return HttpNotFound();
            }
            return View(proizvodniRadnik);
        }

        // POST: ProizvodniRadnik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ProizvodniRadnik proizvodniRadnik = await db.ProizvodniRadnici.FindAsync(id);
            db.ProizvodniRadnici.Remove(proizvodniRadnik);
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
