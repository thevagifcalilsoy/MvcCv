using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class SertifikatController : Controller
    {
        // GET: Sertifikat
        Sertifikatepositorycs repo = new Sertifikatepositorycs();
        public ActionResult Index()
        {
            var deger = repo.List();
            return View(deger);
        }

        [HttpGet]
        public ActionResult Duzenle(int id)
        {
            Tbl_Sertifikalarim t = repo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult Duzenle(Tbl_Sertifikalarim p)
        {
            Tbl_Sertifikalarim t = repo.Find(x => x.ID == p.ID);
            t.Aciklama = p.Aciklama;
            t.Tarih = p.Tarih;
            repo.TblUptade(t);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult SertifikatEKle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SertifikatEKle(Tbl_Sertifikalarim p)
        {
            repo.TblAdd(p);
            return RedirectToAction("Index");
        }

       
        public ActionResult SertifikatSil(int id)
        {
            Tbl_Sertifikalarim t=repo.Find(x => x.ID == id);
            repo.TblDelete(t);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult SertifikatDuzenle(int id)
        {
            Tbl_Sertifikalarim t = repo.Find(x => x.ID == id);
            repo.TblDelete(t);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult SertifikatDuzenle(Tbl_Sertifikalarim p)
        {
           Tbl_Sertifikalarim t= repo.Find(x => x.ID == p.ID);
            t.Aciklama = p.Aciklama;
            t.Tarih = p.Tarih;
            repo.TblUptade(t);
            return RedirectToAction("Index");
        }

    }
}