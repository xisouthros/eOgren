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
    public class OgrenciDersController : Controller
    {
        private DataModel db = new DataModel();

        // GET: OgrenciDers
        public ActionResult Index()
        {
       

                return View(db.tblOgrenciDers.ToList());
        }
        [HttpPost]
        public ActionResult OgrenciEkle(string _DersRef, string _OgrenciRef)
        {
            tblOgrenciDers d = new tblOgrenciDers()
            {
                DersRef = Convert.ToInt32(_DersRef),
                OgrenciRef = Convert.ToInt32(_OgrenciRef)
            };

                 
            using (var dbb = new DataModel())
            {
                dbb.Entry<tblOgrenciDers>(d).State = d.DersRef == Convert.ToInt32(_DersRef) && d.OgrenciRef == Convert.ToInt32(_OgrenciRef) ?
                                           EntityState.Added :
                                           EntityState.Modified;

                dbb.SaveChanges();
            }
            return View("Index", db.tblOgrenciDers.ToList());
        }
        // GET: OgrenciDers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblOgrenciDers tblOgrenciDers = db.tblOgrenciDers.Find(id);
            if (tblOgrenciDers == null)
            {
                return HttpNotFound();
            }
            return View(tblOgrenciDers);
        }

        // GET: OgrenciDers/Create
        public ActionResult Create(int id)
        {
            tblOgrenciDers OgrenciDers = new tblOgrenciDers();
            OgrenciDers.DersRef = id;

            return View(OgrenciDers);
        }

        // POST: OgrenciDers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,OgrenciRef,DersRef")] tblOgrenciDers tblOgrenciDers)
        {
            if (ModelState.IsValid)
            {
                db.tblOgrenciDers.Add(tblOgrenciDers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblOgrenciDers);
        }

        // GET: OgrenciDers/Düzenle/5
        public ActionResult Düzenle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblOgrenciDers tblOgrenciDers = db.tblOgrenciDers.Find(id);
            if (tblOgrenciDers == null)
            {
                return HttpNotFound();
            }
            return View(tblOgrenciDers);
        }

        // POST: OgrenciDers/Düzenle/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Düzenle([Bind(Include = "ID,OgrenciRef,DersRef")] tblOgrenciDers tblOgrenciDers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblOgrenciDers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblOgrenciDers);
        }

        // GET: OgrenciDers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblOgrenciDers tblOgrenciDers = db.tblOgrenciDers.Find(id);
            if (tblOgrenciDers == null)
            {
                return HttpNotFound();
            }
            return View(tblOgrenciDers);
        }

        // POST: OgrenciDers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblOgrenciDers tblOgrenciDers = db.tblOgrenciDers.Find(id);
            db.tblOgrenciDers.Remove(tblOgrenciDers);
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
