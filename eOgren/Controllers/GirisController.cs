using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eOgren.Controllers
{
    public class GirisController : Controller
    {
        // GET: Giris
        public ActionResult eOgren()
        {
            tblKullanici k = new tblKullanici();

            return View(k);
        }

        public ActionResult Giris(string Kullanici, string Sifre)
        {
            DataModel m = new DataModel();
            var Kullanicilar = from x in m.tblKullanici
                               where x.Mail == Kullanici && x.Sifre == Sifre
                               select x;

            Session["Kullanici"] = Kullanicilar.FirstOrDefault<tblKullanici>();

            return RedirectToAction("eOgrenme", "Main");
        }

        public ActionResult YeniKullanici()
        {
            tblKullanici k = new tblKullanici();

            return View(k);
        }
        [HttpPost]
        public ActionResult YeniKullanici(FormCollection collection)
        {
            tblKullanici k = new tblKullanici();

            return View(k);
        }
    }
}