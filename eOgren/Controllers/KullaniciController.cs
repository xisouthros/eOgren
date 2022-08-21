using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eOgren.Controllers
{
    public class KullaniciController : Controller
    {
        // GET: Kullanici
            DataModel m = new DataModel();

        public ActionResult Index()
        {

            if (Session["Kullanici"] == null) return RedirectToAction("eOgren", "Giris");
            var Kullanicilar = from x in m.tblKullanici
                               where x.Durum == true
                               select x;
                               
            return View(Kullanicilar);
        }

        // GET: Kullanici/Details/5
        public ActionResult Details(int id)
        {

            if (Session["Kullanici"] == null) return RedirectToAction("eOgren", "Giris");
            var Kullanicilar = from x in m.tblKullanici
                               where x.ID == id
                               select x;
            return View(Kullanicilar.FirstOrDefault());
        }

        // GET: Kullanici/Create
        public ActionResult Create()
        {
            tblKullanici k = new tblKullanici();

            return View(k);
        }

        // POST: Kullanici/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            if (Session["Kullanici"] == null) return RedirectToAction("eOgren", "Giris");
            try
            {
                m.tblKullanici.Add(new tblKullanici()
                {
                    ID = 0,
                    Adi = collection.GetValue("Adi").AttemptedValue,
                    Soyadi = collection.Get("Soyadi"),
                    Unvan = collection.Get("Unvan"),
                    Mail = collection.Get("Mail"),
                    Sifre = collection.Get("Sifre"),
                    Tip = collection.Get("Tip"),
                    Durum = true
                });
                

                m.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Kullanici/Düzenle/5
        public ActionResult Düzenle(int id)
        {

            if (Session["Kullanici"] == null) return RedirectToAction("eOgren", "Giris");
            var Kullanicilar = from x in m.tblKullanici
                               where x.ID == id
                               select x;
            return View(Kullanicilar.FirstOrDefault());
        }

        // POST: Kullanici/Düzenle/5
        [HttpPost]
        public ActionResult Düzenle(int id, FormCollection collection)
        {
            if (Session["Kullanici"] == null) return RedirectToAction("eOgren", "Giris");
            try
            {
              

                using (var db = new DataModel())
                {
                    var result = db.tblKullanici.SingleOrDefault(b => b.ID == id);
                    if (result != null)
                    {
                        result.Adi = collection.Get("Adi");
                        result.Unvan = collection.Get("Unvan");
                        db.SaveChanges();
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Kullanici/Delete/5
        public ActionResult Delete(int id)
        {
            if (Session["Kullanici"] == null) return RedirectToAction("eOgren", "Giris");
            var Kullanicilar = from x in m.tblKullanici
                               where x.ID == id
                               select x;
            return View();
        }

        // POST: Kullanici/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (Session["Kullanici"] == null) return RedirectToAction("eOgren", "Giris");
            try
            {
                using (var db = new DataModel())
                {
                    var result = db.tblKullanici.SingleOrDefault(b => b.ID == id);
                    if (result != null)
                    {
                        result.Durum = true;
                        db.SaveChanges();
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
