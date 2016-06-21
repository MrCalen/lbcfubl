using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LBCFUBL.Services;

namespace LBCFUBL.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewUtils.FillViewBag(ViewBag, TempData, User.Identity.Name);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Report()
        {
            try
            {
                GlobalReport report = GlobalReport.CreateReport();
                return File(report.FilePath, report.MimeType, report.FileName);
            }
            catch (ArgumentException)
            {
                return HttpNotFound();
            }
        }
    }
}
