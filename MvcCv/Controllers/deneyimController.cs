using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class deneyimController : Controller
    {
        // GET: deneyim
        DeneyimRepository repo = new DeneyimRepository();
        [Authorize]
        public ActionResult Index()
        {
            var deger = repo.List();
            return View(deger);
        }

        [HttpGet]
        public ActionResult DeneyimEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeneyimEkle(Tbl_Deneyimlerim p)
        {
            repo.TblAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeneyimSil(int id)
        {
            Tbl_Deneyimlerim t = repo.Find(x => x.ID == id);
            repo.TblDelete(t);
            return RedirectToAction("Index");
             
        }

        [HttpGet]
        public ActionResult DeneyimGetir(int id )
        {
            Tbl_Deneyimlerim t = repo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult DeneyimGetir(Tbl_Deneyimlerim p)
        {
            Tbl_Deneyimlerim t=repo.Find(x=>x.ID==p.ID);
            t.Baslik = p.Baslik;
            t.AltBaslik = p.AltBaslik;
            t.Tarih = p.Tarih;
            t.Aciklama = p.Aciklama;
            repo.TblUptade(t);
            return RedirectToAction("Index");
        }

        
    }
}