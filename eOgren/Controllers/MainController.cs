using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eOgren.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        DataModel dataModel = new DataModel();
        public ActionResult eOgrenme()
        {
            if (Session["Kullanici"] == null) return RedirectToAction("eOgren", "Giris");

            return View();
        }

        public ActionResult icerik(string Ders)
        {
            if (Session["Kullanici"] == null) return RedirectToAction("eOgren", "Giris");
            var icerik = from i in dataModel.tblIcerik
                         select i;

            return View(icerik);
        }


        public ActionResult icerikDetay(string id)
        {

            if (Session["Kullanici"] == null) return RedirectToAction("eOgren", "Giris");

            var icerikDetay = from detay in dataModel.tblIcerik
                              where detay.ID.ToString() == id
                              select detay;

            return View(icerikDetay);
        }


  
    }
}