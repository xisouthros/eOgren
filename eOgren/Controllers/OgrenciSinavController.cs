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
    public class OgrenciSinavController : Controller
    {
        private DataModel db = new DataModel();

        // GET: OgrenciSinav
        public ActionResult Index()
        {
            var tblOgrenciSinav = db.tblOgrenciSinav.Include(t => t.tblKullanici).Include(t => t.tblSinavSoru);
            return View(tblOgrenciSinav.ToList());
        }

        // GET: OgrenciSinav/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblOgrenciSinav tblOgrenciSinav = db.tblOgrenciSinav.Find(id);
            if (tblOgrenciSinav == null)
            {
                return HttpNotFound();
            }
            return View(tblOgrenciSinav);
        }

        // GET: OgrenciSinav/Create
        public ActionResult Create()
        {
            ViewBag.OgrenciRef = new SelectList(db.tblKullanici, "ID", "Adi");
            ViewBag.SinavRef = new SelectList(db.tblSinavSoru, "ID", "Soru");
            return View();
        }

        // POST: OgrenciSinav/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,OgrenciRef,SinavRef,CevapRef,Durum")] tblOgrenciSinav tblOgrenciSinav)
        {
            if (ModelState.IsValid)
            {
                db.tblOgrenciSinav.Add(tblOgrenciSinav);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OgrenciRef = new SelectList(db.tblKullanici, "ID", "Adi", tblOgrenciSinav.OgrenciRef);
            ViewBag.SinavRef = new SelectList(db.tblSinavSoru, "ID", "Soru", tblOgrenciSinav.SinavRef);
            return View(tblOgrenciSinav);
        }

        // GET: OgrenciSinav/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblOgrenciSinav tblOgrenciSinav = db.tblOgrenciSinav.Find(id);
            if (tblOgrenciSinav == null)
            {
                return HttpNotFound();
            }
            ViewBag.OgrenciRef = new SelectList(db.tblKullanici, "ID", "Adi", tblOgrenciSinav.OgrenciRef);
            ViewBag.SinavRef = new SelectList(db.tblSinavSoru, "ID", "Soru", tblOgrenciSinav.SinavRef);
            return View(tblOgrenciSinav);
        }

        // POST: OgrenciSinav/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,OgrenciRef,SinavRef,CevapRef,Durum")] tblOgrenciSinav tblOgrenciSinav)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblOgrenciSinav).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OgrenciRef = new SelectList(db.tblKullanici, "ID", "Adi", tblOgrenciSinav.OgrenciRef);
            ViewBag.SinavRef = new SelectList(db.tblSinavSoru, "ID", "Soru", tblOgrenciSinav.SinavRef);
            return View(tblOgrenciSinav);
        }

        // GET: OgrenciSinav/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblOgrenciSinav tblOgrenciSinav = db.tblOgrenciSinav.Find(id);
            if (tblOgrenciSinav == null)
            {
                return HttpNotFound();
            }
            return View(tblOgrenciSinav);
        }

        // POST: OgrenciSinav/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblOgrenciSinav tblOgrenciSinav = db.tblOgrenciSinav.Find(id);
            db.tblOgrenciSinav.Remove(tblOgrenciSinav);
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
