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
    public class SinavController : Controller
    {
        private DataModel db = new DataModel();

        // GET: Sinav
        public ActionResult Index()
        {
            if (Session["Kullanici"] == null) return RedirectToAction("eOgren", "Giris");
            var tblSinavlar = db.tblSinavlar.Include(t => t.tblIcerik).Include(t => t.tblIcerik1).Include(t => t.tblIcerik2).Include(t => t.tblIcerik3).Include(t => t.tblKullanici).Include(t => t.tblSinavSoru);
            return View(tblSinavlar.ToList());
        }

        // GET: Sinav/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["Kullanici"] == null) return RedirectToAction("eOgren", "Giris");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSinavlar tblSinavlar = db.tblSinavlar.Find(id);
            if (tblSinavlar == null)
            {
                return HttpNotFound();
            }
            return View(tblSinavlar);
        }

        // GET: Sinav/Create
        public ActionResult Create()
        {
            if (Session["Kullanici"] == null) return RedirectToAction("eOgren", "Giris");
            ViewBag.OkulRef = new SelectList(db.tblIcerik, "ID", "IcerikBaslik");
            ViewBag.BolumRef = new SelectList(db.tblIcerik, "ID", "IcerikBaslik");
            ViewBag.SinifRef = new SelectList(db.tblIcerik, "ID", "IcerikBaslik");
            ViewBag.DersRef = new SelectList(db.tblIcerik, "ID", "IcerikBaslik");
            ViewBag.OgretmenRef = new SelectList(db.tblKullanici, "ID", "Adi");
            ViewBag.SoruRef = new SelectList(db.tblSinavSoru, "ID", "Soru");

            tblSinavlar sinav = new tblSinavlar();

            return View(sinav);
        }

        // POST: Sinav/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,OkulRef,BolumRef,SinifRef,DersRef,SinavTipi,OgretmenRef,SoruRef,Durum")] tblSinavlar tblSinavlar)
        {
            if (Session["Kullanici"] == null) return RedirectToAction("eOgren", "Giris");
            if (ModelState.IsValid)
            {
                int sonID = db.tblSinavlar.OrderByDescending(u => u.ID).FirstOrDefault().ID+1;

                tblSinavlar.ID = sonID;

                db.tblSinavlar.Add(tblSinavlar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OkulRef = new SelectList(db.tblIcerik, "ID", "IcerikBaslik", tblSinavlar.OkulRef);
            ViewBag.BolumRef = new SelectList(db.tblIcerik, "ID", "IcerikBaslik", tblSinavlar.BolumRef);
            ViewBag.SinifRef = new SelectList(db.tblIcerik, "ID", "IcerikBaslik", tblSinavlar.SinifRef);
            ViewBag.DersRef = new SelectList(db.tblIcerik, "ID", "IcerikBaslik", tblSinavlar.DersRef);
            ViewBag.OgretmenRef = new SelectList(db.tblKullanici, "ID", "Adi", tblSinavlar.OgretmenRef);
            ViewBag.SoruRef = new SelectList(db.tblSinavSoru, "ID", "Soru", tblSinavlar.SoruRef);
            return View(tblSinavlar);
        }

        // GET: Sinav/Düzenle/5
        public ActionResult Düzenle(int? id)
        {
            if (Session["Kullanici"] == null) return RedirectToAction("eOgren", "Giris");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSinavlar tblSinavlar = db.tblSinavlar.Find(id);
            if (tblSinavlar == null)
            {
                return HttpNotFound();
            }
            ViewBag.OkulRef = new SelectList(db.tblIcerik, "ID", "IcerikBaslik", tblSinavlar.OkulRef);
            ViewBag.BolumRef = new SelectList(db.tblIcerik, "ID", "IcerikBaslik", tblSinavlar.BolumRef);
            ViewBag.SinifRef = new SelectList(db.tblIcerik, "ID", "IcerikBaslik", tblSinavlar.SinifRef);
            ViewBag.DersRef = new SelectList(db.tblIcerik, "ID", "IcerikBaslik", tblSinavlar.DersRef);
            ViewBag.OgretmenRef = new SelectList(db.tblKullanici, "ID", "Adi", tblSinavlar.OgretmenRef);
            ViewBag.SoruRef = new SelectList(db.tblSinavSoru, "ID", "Soru", tblSinavlar.SoruRef);
            return View(tblSinavlar);
        }

        // POST: Sinav/Düzenle/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Düzenle([Bind(Include = "ID,OkulRef,BolumRef,SinifRef,DersRef,SinavTipi,OgretmenRef,SoruRef,Durum")] tblSinavlar tblSinavlar)
        {

            if (Session["Kullanici"] == null) return RedirectToAction("eOgren", "Giris");
            if (ModelState.IsValid)
            {
                db.Entry(tblSinavlar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OkulRef = new SelectList(db.tblIcerik, "ID", "IcerikBaslik", tblSinavlar.OkulRef);
            ViewBag.BolumRef = new SelectList(db.tblIcerik, "ID", "IcerikBaslik", tblSinavlar.BolumRef);
            ViewBag.SinifRef = new SelectList(db.tblIcerik, "ID", "IcerikBaslik", tblSinavlar.SinifRef);
            ViewBag.DersRef = new SelectList(db.tblIcerik, "ID", "IcerikBaslik", tblSinavlar.DersRef);
            ViewBag.OgretmenRef = new SelectList(db.tblKullanici, "ID", "Adi", tblSinavlar.OgretmenRef);
            ViewBag.SoruRef = new SelectList(db.tblSinavSoru, "ID", "Soru", tblSinavlar.SoruRef);
            return View(tblSinavlar);
        }

        // GET: Sinav/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["Kullanici"] == null) return RedirectToAction("eOgren", "Giris");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSinavlar tblSinavlar = db.tblSinavlar.Find(id);
            if (tblSinavlar == null)
            {
                return HttpNotFound();
            }
            return View(tblSinavlar);
        }

        // POST: Sinav/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["Kullanici"] == null) return RedirectToAction("eOgren", "Giris");
            tblSinavlar tblSinavlar = db.tblSinavlar.Find(id);
            db.tblSinavlar.Remove(tblSinavlar);
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
