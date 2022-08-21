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
    public class DersController : Controller
    {
        private DataModel db = new DataModel();

        // GET: Ders
        public ActionResult Index()
        {
            var tblDers = db.tblDers.Include(t => t.tblBolum).Include(t => t.tblOkul).Include(t => t.tblSinif);
            return View(tblDers.ToList());
        }
        // GET: Ders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDers tblDers = db.tblDers.Find(id);
            if (tblDers == null)
            {
                return HttpNotFound();
            }
            return View(tblDers);
        }

        // GET: Ders/Create
        [HttpPost]
        public ActionResult Create(int id)
        {
            ViewBag.BolumRef = new SelectList(db.tblBolum, "ID", "BolumAd");
            ViewBag.OkulRef = new SelectList(db.tblOkul, "ID", "OkulAd");
            ViewBag.SinifRef = new SelectList(db.tblSinif, "ID", "SinifAd");

            tblDers ders = new tblDers();

            return View(ders);
        }

        // POST: Ders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,OkulRef,BolumRef,SinifRef,DersAd,Durum")] tblDers tblDers)
        {
            if (ModelState.IsValid)
            {
                db.tblDers.Add(tblDers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BolumRef = new SelectList(db.tblBolum, "ID", "BolumAd", tblDers.BolumRef);
            ViewBag.OkulRef = new SelectList(db.tblOkul, "ID", "OkulAd", tblDers.OkulRef);
            ViewBag.SinifRef = new SelectList(db.tblSinif, "ID", "SinifAd", tblDers.SinifRef);
            return View(tblDers);
        }

        // GET: Ders/Düzenle/5
        public ActionResult Düzenle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDers tblDers = db.tblDers.Find(id);
            if (tblDers == null)
            {
                return HttpNotFound();
            }
            ViewBag.BolumRef = new SelectList(db.tblBolum, "ID", "BolumAd", tblDers.BolumRef);
            ViewBag.OkulRef = new SelectList(db.tblOkul, "ID", "OkulAd", tblDers.OkulRef);
            ViewBag.SinifRef = new SelectList(db.tblSinif, "ID", "SinifAd", tblDers.SinifRef);
            return View(tblDers);
        }

        // POST: Ders/Düzenle/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Düzenle([Bind(Include = "ID,OkulRef,BolumRef,SinifRef,DersAd,Durum")] tblDers tblDers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblDers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BolumRef = new SelectList(db.tblBolum, "ID", "BolumAd", tblDers.BolumRef);
            ViewBag.OkulRef = new SelectList(db.tblOkul, "ID", "OkulAd", tblDers.OkulRef);
            ViewBag.SinifRef = new SelectList(db.tblSinif, "ID", "SinifAd", tblDers.SinifRef);
            return View(tblDers);
        }

        // GET: Ders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDers tblDers = db.tblDers.Find(id);
            if (tblDers == null)
            {
                return HttpNotFound();
            }
            return View(tblDers);
        }

        // POST: Ders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblDers tblDers = db.tblDers.Find(id);
            db.tblDers.Remove(tblDers);
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
