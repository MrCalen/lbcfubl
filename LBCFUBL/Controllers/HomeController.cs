using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LBCFUBL.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ServiceReference1.Service1Client c = new ServiceReference1.Service1Client();
            string test = c.GetData(1);

            ViewBag.Message = test;

            return View();
        }
    }
}