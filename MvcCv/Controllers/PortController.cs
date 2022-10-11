using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class PortController : Controller
    {
        // GET: Port
        PortRepository repo = new PortRepository();
        public ActionResult Index()
        {
            var port= repo.List();

            return View(port);
           
        }
    }
}