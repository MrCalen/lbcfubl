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
            ViewBag.Money = Math.Round(Helper.GetUserClient().GetUserMoney(User.Identity.Name), 2);
            ViewBag.Products = Helper.GetProductClient().GetAllProducts();
            ViewBag.Users = Helper.GetUserClient().GetUsers();
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
    }
}
