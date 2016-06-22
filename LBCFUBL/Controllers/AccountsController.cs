using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LBCFUBL.BusinessManagement;
using LBCFUBL.Models;
using LBCFUBL.Services;

namespace LBCFUBL.Controllers
{
    [CustomAuthorizeAttribute(Roles = "admin")]
    public class AccountsController : Controller
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "login,argent")] LBCFUBL_WCF.DBO.Account account)
        {
            account.date = DateTime.Now;

            if (ModelState.IsValid)
            {
                Helper.GetAccountClient().CreateAccount(account.login, (float)account.argent, account.date);
                return Redirect(Request.UrlReferrer.ToString());
            }

            ViewBag.login = new SelectList(Helper.GetUserClient().GetUsers(), "login", "password", account.login);
            return View(account);
        }
    }
}
