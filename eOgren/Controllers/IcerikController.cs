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
    public class IcerikController : Controller
    {
        private DataModel db = new DataModel();

        // GET: Icerik
        public ActionResult Index()
        {
            var tblIcerik = db.tblIcerik.Include(t => t.tblBolum).Include(t => t.tblDers).Include(t => t.tblOkul).Include(t => t.tblSinif);
            return View(tblIcerik.ToList());
        }

        // GET: Icerik/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblIcerik tblIcerik = db.tblIcerik.Find(id);
            if (tblIcerik == null)
            {
                return HttpNotFound();
            }
            return View(tblIcerik);
        }

        // GET: Icerik/Create
        public ActionResult Create()
        {
            ViewBag.BolumRef = new SelectList(db.tblBolum, "ID", "BolumAd");
            ViewBag.DersRef = new SelectList(db.tblDers, "ID", "DersAd");
            ViewBag.OkulRef = new SelectList(db.tblOkul, "ID", "OkulAd");
            ViewBag.SinifRef = new SelectList(db.tblSinif, "ID", "SinifAd");

            tblIcerik i = new tblIcerik();
            
            return View(i);
        }

        // POST: Icerik/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,OkulRef,BolumRef,SinifRef,DersRef,IcerikBaslik,IcerikMetin,IcerikLink,IcerikAciklama,IcerikZaman,Durum")] tblIcerik tblIcerik)
        {
            if (ModelState.IsValid)
            {
                db.tblIcerik.Add(tblIcerik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BolumRef = new SelectList(db.tblBolum, "ID", "BolumAd", tblIcerik.BolumRef);
            ViewBag.DersRef = new SelectList(db.tblDers, "ID", "DersAd", tblIcerik.DersRef);
            ViewBag.OkulRef = new SelectList(db.tblOkul, "ID", "OkulAd", tblIcerik.OkulRef);
            ViewBag.SinifRef = new SelectList(db.tblSinif, "ID", "SinifAd", tblIcerik.SinifRef);
            return View(tblIcerik);
        }

        // GET: Icerik/Düzenle/5
        public ActionResult Düzenle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblIcerik tblIcerik = db.tblIcerik.Find(id);
            if (tblIcerik == null)
            {
                return HttpNotFound();
            }
            ViewBag.BolumRef = new SelectList(db.tblBolum, "ID", "BolumAd", tblIcerik.BolumRef);
            ViewBag.DersRef = new SelectList(db.tblDers, "ID", "DersAd", tblIcerik.DersRef);
            ViewBag.OkulRef = new SelectList(db.tblOkul, "ID", "OkulAd", tblIcerik.OkulRef);
            ViewBag.SinifRef = new SelectList(db.tblSinif, "ID", "SinifAd", tblIcerik.SinifRef);
            return View(tblIcerik);
        }

        // POST: Icerik/Düzenle/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Düzenle([Bind(Include = "ID,OkulRef,BolumRef,SinifRef,DersRef,IcerikBaslik,IcerikMetin,IcerikLink,IcerikAciklama,IcerikZaman,Durum")] tblIcerik tblIcerik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblIcerik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BolumRef = new SelectList(db.tblBolum, "ID", "BolumAd", tblIcerik.BolumRef);
            ViewBag.DersRef = new SelectList(db.tblDers, "ID", "DersAd", tblIcerik.DersRef);
            ViewBag.OkulRef = new SelectList(db.tblOkul, "ID", "OkulAd", tblIcerik.OkulRef);
            ViewBag.SinifRef = new SelectList(db.tblSinif, "ID", "SinifAd", tblIcerik.SinifRef);
            return View(tblIcerik);
        }

        // GET: Icerik/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblIcerik tblIcerik = db.tblIcerik.Find(id);
            if (tblIcerik == null)
            {
                return HttpNotFound();
            }
            return View(tblIcerik);
        }

        // POST: Icerik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblIcerik tblIcerik = db.tblIcerik.Find(id);
            db.tblIcerik.Remove(tblIcerik);
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
