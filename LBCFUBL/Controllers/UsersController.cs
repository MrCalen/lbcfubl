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
using System.IO;
using System.Text;

namespace LBCFUBL.Controllers
{
    [CustomAuthorizeAttribute(Roles = "admin")]
    public class UsersController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            ViewUtils.FillViewBag(ViewBag, TempData, User.Identity.Name);
            ViewBag.Accounts = Helper.GetUserClient().GetUsersMoneys();
            var map = new Dictionary<string, LBCFUBL_WCF.DBO.User>();
            foreach (var account in ViewBag.Accounts)
                map[account.Item1] = Helper.GetUserClient().GetUserFromLogin(account.Item1);
            ViewBag.AccountForUser = map;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Block(FormCollection form)
        {
            if (!User.Identity.IsAuthenticated || !User.IsInRole("admin"))
            {
                TempData["Error"] = "Vous n'êtes pas autorisé à effectuer cette action cette resource";
                return Redirect(Request.UrlReferrer.ToString());
            }
            bool shouldblock = Int32.Parse(form["block"].ToString()) == 1;
            string login = form["login"];
            Helper.GetUserClient().Block(login, shouldblock);
            return Redirect(Request.UrlReferrer.ToString());
        }

        // POST: Users/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "login,password,role")] LBCFUBL_WCF.DBO.User user)
        {
            if (ModelState.IsValid)
            {
                Helper.GetUserClient().CreateUser(user.login, user.password, user.role);
                
                return RedirectToAction("Index");
            }

            return View(user);
        }        

        // GET: Users/Report/5
        public ActionResult Report(string login)
        {
            if (login == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                UserReport report = UserReport.CreateReport(login);
                return File(report.FilePath, report.MimeType, report.FileName);
            } catch (ArgumentException)
            {
                return HttpNotFound();
            }
        }
    }
}
