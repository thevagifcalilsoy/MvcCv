using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact

        ElaqeRepository repo = new ElaqeRepository();
        public ActionResult Index()
        {
            var deger = repo.List();
            return View(deger);
           
        }
    }
}