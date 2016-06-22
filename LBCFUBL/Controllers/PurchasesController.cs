using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LBCFUBL.Models;
using LBCFUBL.Services;

namespace LBCFUBL.Controllers
{
    [Authorize]
    public class PurchasesController : Controller
    {
        public class Data {
            public double first { get; set; }
            public double second { get; set; }
            public bool third { get; set; }

            public Data(double first, double second, bool third)
            {
                this.first = first;
                this.second = second;
                this.third = third;
            }
        }

        // GET: Purchases
        public ActionResult Index(string id)
        {
            if (id == null)
                id = User.Identity.Name;
            if (id != User.Identity.Name && !User.IsInRole("admin"))
            {
                TempData["Error"] = "Vous n'êtes pas autorisé à voir cette resource";
                return Redirect("/Purchases");
            }

            ViewUtils.FillViewBag(ViewBag, TempData, User.Identity.Name, true);
            ViewBag.Purchases = Helper.GetPurchaseClient().GetPurchasesForLogin(id);
            ViewBag.Accounts = Helper.GetAccountClient().GetAccountsForLogin(id);

            ViewBag.MonthMap = GetMonthHistory(id);
            ViewBag.DayMap = GetDayHistory(id);
            return View("Index");
        }

        private SortedList<DateTime, Data> GetMonthHistory(string login)
        {
            var purchaseHistory = Helper.GetUserClient().GetUserPurchaseHistoryResult(login);
            var accountHistory = Helper.GetUserClient().GetUserAccountHistoryResult(login);

            var map = new SortedList<DateTime, Data>(); // Monthly purchase (account - purchase) , total this month
            foreach (var account in accountHistory)
            {
                int year = (int)account.year;
                int month = (int)account.month;
                DateTime date = new DateTime((int)account.year, (int)account.month, 1);
                map[date] = new Data((double)account.month_account, account.total_account, false);
            }
            foreach (var purchase in purchaseHistory)
            {
                DateTime date = new DateTime((int)purchase.year, (int)purchase.month, 1);
                Data tuple = null;
                if (map.ContainsKey(date))
                    tuple = map[date];
                else
                {
                    tuple = new Data(0, 0, true);
                }
                map[date] = new Data(tuple.first - purchase.month_purchase, tuple.second - purchase.total_purchase, tuple.third);
            }

            Data last = null;
            foreach (var element in map)
            {
                // First Element, do nothing
                if (last == null)
                {
                    last = element.Value;
                    continue;
                }

                if (element.Value.third)
                {
                    // We got a purchase, get the last 
                    element.Value.second += last.second;
                }
                last = element.Value;
            }
            return map;
        }

        private SortedList<DateTime, Data> GetDayHistory(string login)
        {
            var purchaseHistory = Helper.GetUserClient().GetUserPurchaseDayHistory(login);
            var accountHistory = Helper.GetUserClient().GetUserAccountDayHistory(login);

            var map = new SortedList<DateTime, Data>(); // Monthly purchase (account - purchase) , total this month
            foreach (var account in accountHistory)
            {
                int year = (int)account.year;
                int month = (int)account.month;
                DateTime date = new DateTime((int)account.year, (int)account.month, (int)account.day);
                map[date] = new Data(0, account.total_account, false);
            }
            foreach (var purchase in purchaseHistory)
            {
                DateTime date = new DateTime((int)purchase.year, (int)purchase.month, (int)purchase.day);
                Data tuple = null;
                if (map.ContainsKey(date))
                    tuple = map[date];
                else
                {
                    tuple = new Data(0, 0, true);
                }
                map[date] = new Data(purchase.day_purchase, tuple.second - purchase.total_purchase, tuple.third);
            }

            Data last = null;
            foreach (var element in map)
            {
                // First Element, do nothing
                if (last == null)
                {
                    last = element.Value;
                    continue;
                }

                if (element.Value.third)
                {
                    // We got a purchase, get the last 
                    element.Value.second += last.second;
                }
                last = element.Value;
            }
            return map;
        }

        // GET: Purchases/Details/5
        public ActionResult Details(string id)
        {
            throw new Exception();
        }

        // GET: Purchases/Create
        public ActionResult Create()
        {
            /*TODO
            ViewBag.id_prod = new SelectList(db.Product, "id", "name");
            ViewBag.login = new SelectList(db.User, "login", "password");
            */
            return View();
        }

        // POST: Purchases/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "login,id_prod")] LBCFUBL_WCF.DBO.Purchase purchase)
        {
            purchase.date = DateTime.Now;
            int quantity = Int32.Parse(Request.Form["quantity"]);
            if (ModelState.IsValid)
            {
                purchase.added_by = User.Identity.Name;
                for (int i = 0; i < quantity; i++)
                    Helper.GetPurchaseClient().CreatePurchase(purchase.login, purchase.date, purchase.id_prod, purchase.added_by);

                // Check that the user is not blocked by adding a new purchase
                double money = Math.Round(Helper.GetUserClient().GetUserMoney(purchase.login), 2);
                if (money < -20)
                    Helper.GetUserClient().Block(purchase.login, true);
                return Redirect(Request.UrlReferrer.ToString());
            }
            /*
            ViewBag.id_prod = new SelectList(db.Product, "id", "name", purchase.id_prod);
            ViewBag.login = new SelectList(db.User, "login", "password", purchase.login);

            return View(purchase);
            */
            return Redirect(Request.UrlReferrer.ToString());
        }

        // GET: Purchases/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            /*TODO
            Purchase purchase = db.Purchase.Find(id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_prod = new SelectList(db.Product, "id", "name", purchase.id_prod);
            ViewBag.login = new SelectList(db.User, "login", "password", purchase.login);
            return View(purchase);
            */
            return View();
        }

        // POST: Purchases/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "login,date,id_prod")] LBCFUBL_WCF.DBO.Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                /*TODO
                db.Entry(purchase).State = EntityState.Modified;
                db.SaveChanges();
                */
                return RedirectToAction("Index");
            }
            /*TODO
            ViewBag.id_prod = new SelectList(db.Product, "id", "name", purchase.id_prod);
            ViewBag.login = new SelectList(db.User, "login", "password", purchase.login);
            return View(purchase);
            */
            return View();
        }

        // GET: Purchases/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            /* TODO
            Purchase purchase = db.Purchase.Find(id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            return View(purchase);
            */
            return View();
        }

        // POST: Purchases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            /*TODO
            Purchase purchase = db.Purchase.Find(id);
            db.Purchase.Remove(purchase);
            db.SaveChanges();
            */
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
