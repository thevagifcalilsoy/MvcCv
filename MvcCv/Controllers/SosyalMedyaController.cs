using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Repositories;
using MvcCv.Models.Entity;

namespace MvcCv.Controllers
{
    public class SosyalMedyaController : Controller
    {
        // GET: SosyalMedya
        GenericRepositories<Tbl_SosyalMedya> repo = new GenericRepositories<Tbl_SosyalMedya>();
        public ActionResult Index()
        {
            var deger = repo.List();
            return View(deger);

        }

        [HttpGet]
        public ActionResult Ekle()
        {
            var deger = repo.List();
            return View(deger);
        }
        [HttpPost]
        public ActionResult Ekle(Tbl_SosyalMedya p)
        {
             repo.TblAdd(p);
            return RedirectToAction("Index");
           
        }


        [HttpGet]
        public ActionResult Duzenle(int id)
        {
           var t = repo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult Duzenle(Tbl_SosyalMedya p)
        {
           
            Tbl_SosyalMedya t = repo.Find(x => x.ID == p.ID);
            t.Ad = p.Ad;
            t.Durum = true;
            t.Link = p.Link;
            t.Ikon = p.Ikon;
            repo.TblUptade(t);
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var hesab = repo.Find(x => x.ID == id);
                hesab.Durum = false;
            repo.TblUptade(hesab);
            return RedirectToAction("Index");
        }
    }
}