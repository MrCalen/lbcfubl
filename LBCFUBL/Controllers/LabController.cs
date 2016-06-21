using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using LBCFUBL.Services;

namespace LBCFUBL.Controllers
{
    public class LabController : Controller
    {
        // GET: Lab
        public ActionResult Index()
        {
            ViewUtils.FillViewBag(ViewBag, TempData, User.Identity.Name);
            var users = new List<LBCFUBL_WCF.DBO.User>(Helper.GetUserClient().GetUsers());
            var blockedUsers = users.Where(elt => elt.is_blocked == 1);
            var deptUsers = new List<LBCFUBL_WCF.DBO.User>();
            foreach (var user in users)
            {
                Helper.GetUserClient().GetUserMoney(user.login);
            }
            ViewBag.BlockedUsers = blockedUsers;
            return View();
        }
    }
}