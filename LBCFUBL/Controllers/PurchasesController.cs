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
            ViewBag.UserMoney = Math.Round(Helper.GetUserClient().GetUserMoney(id), 2);

            ViewBag.Purchases = Helper.GetPurchaseClient().GetPurchasesForLogin(id);
            ViewBag.Accounts = Helper.GetAccountClient().GetAccountsForLogin(id);
            ViewBag.User = Helper.GetUserClient().GetUserFromLogin(id);
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

        // POST: Purchases/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "login,id_prod")] LBCFUBL_WCF.DBO.Purchase purchase)
        {
            purchase.date = DateTime.Now;
            int quantity = Int32.Parse(Request.Form["quantity"]);
            if (ModelState.IsValid)
            {
                var user = Helper.GetUserClient().GetUserFromLogin(purchase.login);
                if (user.is_blocked == 1)
                {
                    TempData["Error"] = "L'utilisateur est bloqué.";
                    return Redirect(Request.UrlReferrer.ToString());
                }
                purchase.added_by = User.Identity.Name;
                for (int i = 0; i < quantity; i++)
                {
                    if (user.login == "lab")
                        Helper.GetAccountClient().CreateAccount(user.login, (float)Helper.GetProductClient().GetProductFromId(purchase.id_prod).cost_with_margin, purchase.date);
                    else
                        Helper.GetPurchaseClient().CreatePurchase(purchase.login, purchase.date, purchase.id_prod, purchase.added_by);
                }
                // Check that the user is not blocked by adding a new purchase
                double money = Math.Round(Helper.GetUserClient().GetUserMoney(purchase.login), 2);
                if (money < -20)
                    Helper.GetUserClient().Block(purchase.login, true);
                return Redirect(Request.UrlReferrer.ToString());
            }
            return Redirect(Request.UrlReferrer.ToString());
        }

    }
}
