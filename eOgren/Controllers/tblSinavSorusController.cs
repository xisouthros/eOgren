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
    public class tblSinavSorusController : Controller
    {
        private DataModel db = new DataModel();

        // GET: tblSinavSorus
        public ActionResult Index()
        {
            if (Session["Kullanici"] == null) return RedirectToAction("eOgren", "Giris");
            return View(db.tblSinavSoru.ToList());
        }

        // GET: tblSinavSorus/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["Kullanici"] == null) return RedirectToAction("eOgren", "Giris");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSinavSoru tblSinavSoru = db.tblSinavSoru.Find(id);
            if (tblSinavSoru == null)
            {
                return HttpNotFound();
            }
            return View(tblSinavSoru);
        }

        // GET: tblSinavSorus/Create
        public ActionResult Create()
        {
            if (Session["Kullanici"] == null) return RedirectToAction("eOgren", "Giris");
            tblSinavSoru soru = new tblSinavSoru();
            soru.Soru = "";
            soru.Cevap1 = "";
            soru.Cevap2 = "";
            soru.Cevap3 = "";
            soru.Cevap4 = "";
            soru.Cevap5 = "";
            soru.DogruCevap = "";
            soru.Durum = true;
            soru.tblOgrenciSinav.Add(new tblOgrenciSinav());
            soru.tblSinavlar.Add(new tblSinavlar());
            
            return View(soru);
        }

        // POST: tblSinavSorus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Soru,Cevap1,Cevap2,Cevap3,Cevap4,Cevap5,DogruCevap,Durum")] tblSinavSoru tblSinavSoru)
        {
            if (Session["Kullanici"] == null) return RedirectToAction("eOgren", "Giris");
            if (ModelState.IsValid)
            {
                db.tblSinavSoru.Add(tblSinavSoru);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblSinavSoru);
        }

        // GET: tblSinavSorus/Düzenle/5
        public ActionResult Düzenle(int? id)
        {
            if (Session["Kullanici"] == null) return RedirectToAction("eOgren", "Giris");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSinavSoru tblSinavSoru = db.tblSinavSoru.Find(id);
            if (tblSinavSoru == null)
            {
                return HttpNotFound();
            }
            return View(tblSinavSoru);
        }

        // POST: tblSinavSorus/Düzenle/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Düzenle([Bind(Include = "ID,Soru,Cevap1,Cevap2,Cevap3,Cevap4,Cevap5,DogruCevap,Durum")] tblSinavSoru tblSinavSoru)
        {
            if (Session["Kullanici"] == null) return RedirectToAction("eOgren", "Giris");
            if (ModelState.IsValid)
            {
                db.Entry(tblSinavSoru).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblSinavSoru);
        }

        // GET: tblSinavSorus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["Kullanici"] == null) return RedirectToAction("eOgren", "Giris");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSinavSoru tblSinavSoru = db.tblSinavSoru.Find(id);
            if (tblSinavSoru == null)
            {
                return HttpNotFound();
            }
            return View(tblSinavSoru);
        }

        // POST: tblSinavSorus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["Kullanici"] == null) return RedirectToAction("eOgren", "Giris");
            tblSinavSoru tblSinavSoru = db.tblSinavSoru.Find(id);
            db.tblSinavSoru.Remove(tblSinavSoru);
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
