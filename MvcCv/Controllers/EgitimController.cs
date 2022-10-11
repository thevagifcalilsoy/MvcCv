using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class EgitimController : Controller
    {
        // GET: Egitim

        TehsilRepositorycs repo = new TehsilRepositorycs();
        public ActionResult Index()
        {
            var deger = repo.List();
            return View(deger);
        }

        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EgitimEkle(Tbl_Egitim p)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimEkle");
            }
            repo.TblAdd(p);
            return RedirectToAction("Index");
        }


        public ActionResult EgitimSil(int id)
        {
            var t = repo.Find(x => x.ID == id);
            repo.TblDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EgitimDuzenle(int id)
        {
            Tbl_Egitim t = repo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult EgitimDuzenle(Tbl_Egitim p)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimEkle");
            }
            Tbl_Egitim t = repo.Find(x => x.ID == p.ID);
            t.AltBaslik1 = p.AltBaslik1;
            t.AltBaslik2 = p.AltBaslik2;
            t.GNO = p.GNO;
            t.Tarih = p.Tarih;
            repo.TblUptade(t);
            return RedirectToAction("Index");
        }
    }
}