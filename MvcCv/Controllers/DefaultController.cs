using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;

namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        DbCvEntities db = new DbCvEntities();
        public ActionResult Index()
        {
            var melumaltar = db.Tbl_Hakkinda.ToList();
            return View(melumaltar);
        }
        public PartialViewResult Deneyimlerim()
        {
            var deneyimler = db.Tbl_Deneyimlerim.ToList();
            return PartialView(deneyimler);
        }

        public PartialViewResult SosyalMedya()
        {
            var sosyal = db.Tbl_SosyalMedya.Where(x=>x.Durum==true).ToList();
            return PartialView(sosyal);
        }
        public PartialViewResult Eğitimlerim()
        {
            var egitimlerim = db.Tbl_Egitim.ToList();
            return PartialView(egitimlerim);
        }
        public PartialViewResult Yeteneklerim()
        {
            var yetenek = db.Tbl_Yetenekler.ToList();
            return PartialView(yetenek);
        }
        public PartialViewResult Hobiler()
        {
            var hobi = db.Tbl_Hobilerim.ToList();
            return PartialView(hobi);
        }

        public PartialViewResult Sertifikat()
        {
            var diplom= db.Tbl_Sertifikalarim.ToList();
            return PartialView(diplom);
        }
        public PartialViewResult Port()
        {
            var port = db.Tbl_Port.ToList();
            return PartialView(port);
        }

        [HttpGet]
        public PartialViewResult Contact()
        {
           
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult Contact(Tbl_Iletisim t)
        {
            t.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Tbl_Iletisim.Add(t);
            db.SaveChanges();
            return PartialView();
        }

        public ActionResult elaqe()
        {
            return View();
        }

    }
}