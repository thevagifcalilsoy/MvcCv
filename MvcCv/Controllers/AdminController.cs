using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        GenericRepositories<Tbl_Admin> repo = new GenericRepositories<Tbl_Admin>();
        public ActionResult Index()
        {
            var liste = repo.List();
            return View(liste);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Tbl_Admin p)
        {
            repo.TblAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            Tbl_Admin t = repo.Find(x => x.ID == id);
            repo.TblDelete(t);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Duzenle(int id)
        {
            Tbl_Admin t = repo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult Duzenle(Tbl_Admin p)
        {
            Tbl_Admin t = repo.Find(x => x.ID == p.ID);
            t.KullaniciAdi = p.KullaniciAdi;
            t.Sifre = p.Sifre;
            repo.TblUptade(t);
            return RedirectToAction("Index");
        }

    }
}