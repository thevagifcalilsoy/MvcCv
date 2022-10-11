using System;

using System.Collections.Generic;

using System.IO;

using System.Linq;

using System.Web;

using System.Web.Mvc;

using MvcCv.Models.Entity;

using MvcCv.Repositories;

namespace Mvc.Controllers

{

    public class HakkimdaController : Controller

    {

        // GET: Hakkimda

        DbCvEntities db = new DbCvEntities();

        GenericRepositories<Tbl_Hakkinda> repo = new GenericRepositories<Tbl_Hakkinda>();

        [HttpGet]

        public ActionResult Index()

        {

            var hakkimda = repo.List();

            return View(hakkimda);

        }

        [HttpPost]

        public ActionResult Index(Tbl_Hakkinda p)

        {


            if (Request.Files.Count > 0)

            {

                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);

                string uzanti = Path.GetExtension(Request.Files[0].FileName);

                string yol = "~/image/" + dosyaadi + uzanti;

                Request.Files[0].SaveAs(Server.MapPath(yol));

                p.Resim = "/image/" + dosyaadi + uzanti;



            }

            if (!ModelState.IsValid)
            {
                return View("Index");
            }

            var t = repo.Find(x => x.ID == 1);

            t.Ad = p.Ad;

            t.Soyad = p.Soyad;
            t.Adres = p.Adres;

            t.Telefon = p.Telefon;

            t.Mail = p.Mail;

            t.Resim = p.Resim;

            t.Aciklama = p.Aciklama;

            repo.TblUptade(t);

            return RedirectToAction("Index");

        }

    }

}