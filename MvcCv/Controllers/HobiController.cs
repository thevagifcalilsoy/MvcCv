using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class HobiController : Controller
    {
        HobilerimRepositorycs repo = new HobilerimRepositorycs();

        // GET: Hobi
        [HttpGet]
        public ActionResult Index()
        {
            var hobi = repo.List();

            return View(hobi);
        }


        [HttpPost]
        public ActionResult Index(Tbl_Hobilerim p)
        {
            var t = repo.Find(x => x.ID == 1);
            t.Aciklama1 = p.Aciklama1;
            t.Aciklama2 = p.Aciklama2;
            repo.TblUptade(t);
            return RedirectToAction("Index");
        }

        //[HttpGet]
        //public ActionResult Portfilo(Tbl_Port p)
        //{

        //    var rep
        //    return View();
        //}


        //[HttpPost]
        //public ActionResult Portfilo(Tbl_Hobilerim p)
        //{
        //    repo.TblAdd(p);
        //    return RedirectToAction("Index");
        //}


    }
}