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
    [CustomAuthorizeAttribute(Roles = "admin,assistant")]
    public class UsersController : Controller
    {
        // GET: Users
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

        // GET: Users/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LBCFUBL_WCF.DBO.User user = Helper.GetUserClient().GetUserFromLogin(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
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

        // GET: Users/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LBCFUBL_WCF.DBO.User user = Helper.GetUserClient().GetUserFromLogin(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "login,password,role")] LBCFUBL_WCF.DBO.User user)
        {
            if (ModelState.IsValid)
            {
                /* TODO
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                */
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LBCFUBL_WCF.DBO.User user = Helper.GetUserClient().GetUserFromLogin(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Helper.GetUserClient().DeleteUser(id);
            return RedirectToAction("Index");
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
            } catch (ArgumentException e)
            {
                return HttpNotFound();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
