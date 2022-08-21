using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using eOgren;

namespace eOgren.Controllers
{
    public class SinifController : Controller
    {
        private DataModel db = new DataModel();

        // GET: Sinif
        public ActionResult Index()
        {
            var tblSinif = db.tblSinif.Include(t => t.tblBolum).Include(t => t.tblOkul);
            return View(tblSinif.ToList());
        }

        // GET: Sinif/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSinif tblSinif = db.tblSinif.Find(id);
            if (tblSinif == null)
            {
                return HttpNotFound();
            }
            return View(tblSinif);
        }

        // GET: Sinif/Create
        public ActionResult Create()
        {
            ViewBag.BolumRef = new SelectList(db.tblBolum, "ID", "BolumAd");
            ViewBag.OkulRef = new SelectList(db.tblOkul, "ID", "OkulAd");

            tblSinif sinif = new tblSinif();
            return View(sinif);
        }

        // POST: Sinif/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,OkulRef,BolumRef,SinifAd,Durum")] tblSinif tblSinif)
        {
            if (ModelState.IsValid)
            {
                db.tblSinif.Add(tblSinif);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BolumRef = new SelectList(db.tblBolum, "ID", "BolumAd", tblSinif.BolumRef);
            ViewBag.OkulRef = new SelectList(db.tblOkul, "ID", "OkulAd", tblSinif.OkulRef);
            return View(tblSinif);
        }

        // GET: Sinif/Düzenle/5
        public ActionResult Düzenle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSinif tblSinif = db.tblSinif.Find(id);
            if (tblSinif == null)
            {
                return HttpNotFound();
            }
            ViewBag.BolumRef = new SelectList(db.tblBolum, "ID", "BolumAd", tblSinif.BolumRef);
            ViewBag.OkulRef = new SelectList(db.tblOkul, "ID", "OkulAd", tblSinif.OkulRef);
            return View(tblSinif);
        }

        // POST: Sinif/Düzenle/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Düzenle([Bind(Include = "ID,OkulRef,BolumRef,SinifAd,Durum")] tblSinif tblSinif)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblSinif).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BolumRef = new SelectList(db.tblBolum, "ID", "BolumAd", tblSinif.BolumRef);
            ViewBag.OkulRef = new SelectList(db.tblOkul, "ID", "OkulAd", tblSinif.OkulRef);
            return View(tblSinif);
        }

        // GET: Sinif/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSinif tblSinif = db.tblSinif.Find(id);
            if (tblSinif == null)
            {
                return HttpNotFound();
            }
            return View(tblSinif);
        }

        // POST: Sinif/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblSinif tblSinif = db.tblSinif.Find(id);
            db.tblSinif.Remove(tblSinif);
            db.SaveChanges();
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
