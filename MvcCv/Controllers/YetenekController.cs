using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class YetenekController : Controller
    {
        BacariqRepositorycs repo = new BacariqRepositorycs();
        // GET: Yetenek
        public ActionResult Index()
        {
            var list = repo.List();
            return View(list);
        }

        [HttpGet]
        public ActionResult YetenekEkle()
        {

            return View();
        }

        [HttpPost]
        public ActionResult YetenekEkle(Tbl_Yetenekler p)
        {
            repo.TblAdd(p);
            return RedirectToAction("Index");
        }

      
        public ActionResult YetenekSil(int id)
        {

            var t = repo.Find(x => x.ID == id);
            repo.TblDelete(t);
            return RedirectToAction("Index");
        }

       


        [HttpGet]
        public ActionResult YetenekDuzenle(int id)
        {
            Tbl_Yetenekler t = repo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult YetenekDuzenle(Tbl_Yetenekler p)
        {
            Tbl_Yetenekler t = repo.Find(x => x.ID == p.ID);
            t.ID = p.ID;
            t.Yetenek = p.Yetenek;
            t.Oran = p.Oran;
            repo.TblUptade(t);
            return RedirectToAction("Index");
        }
    }
}