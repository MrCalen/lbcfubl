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
    [CustomAuthorizeAttribute(Roles="admin")]
    public class AccountsController : Controller
    {
        // GET: Accounts
        public ActionResult Index()
        {
            var lol = Helper.GetAccountClient().GetAccounts().ToList();
            return View(lol);
        }

        // GET: Accounts/Details/5
        public ActionResult Details(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LBCFUBL_WCF.DBO.Account account = Helper.GetAccountClient().GetAccountForId(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // GET: Accounts/Create
        public ActionResult Create()
        {
            ViewData["login"] = new SelectList(Helper.GetUserClient().GetUsers().ToList().Select(x => x.login), "user");
            return View();
        }

        // POST: Accounts/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "login,argent,date")] LBCFUBL_WCF.DBO.Account account)
        {
            if (ModelState.IsValid)
            {
                Helper.GetAccountClient().CreateAccount(account.login, (float)account.argent, account.date);
                return RedirectToAction("Index");
            }

            ViewBag.login = new SelectList(Helper.GetUserClient().GetUsers(), "login", "password", account.login);
            return View(account);
        }

        // GET: Accounts/Edit/5
        public ActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LBCFUBL_WCF.DBO.Account account = Helper.GetAccountClient().GetAccountForId(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            ViewBag.login = new SelectList(Helper.GetUserClient().GetUsers(), "login", "password", account.login);
            return View(account);
        }

        // POST: Accounts/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "login,argent,date")] LBCFUBL_WCF.DBO.Account account)
        {
            if (ModelState.IsValid)
            {
                /* TODO
                db.Entry(account).State = EntityState.Modified;
                db.SaveChanges();*/
                return RedirectToAction("Index");
            }
            ViewBag.login = new SelectList(Helper.GetUserClient().GetUsers(), "login", "password", account.login);
            return View(account);
        }

        // GET: Accounts/Delete/5
        public ActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LBCFUBL_WCF.DBO.Account account = Helper.GetAccountClient().GetAccountForId(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            LBCFUBL_WCF.DBO.Account account = Helper.GetAccountClient().GetAccountForId(id);
            Helper.GetAccountClient().DeleteAccountForId(id);
            return RedirectToAction("Index");
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
