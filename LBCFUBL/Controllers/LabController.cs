using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using LBCFUBL.BusinessManagement;
using System.Linq;
using System.Net;
using LBCFUBL.Services;

namespace LBCFUBL.Controllers
{
    public class LabController : Controller
    {
        // GET: Lab
        [CustomAuthorizeAttribute(Roles = "admin")]
        public ActionResult Index()
        {
            ViewUtils.FillViewBag(ViewBag, TempData, User.Identity.Name);
            var users = new List<LBCFUBL_WCF.DBO.User>(Helper.GetUserClient().GetUsers());
            var blockedUsers = users.Where(elt => elt.is_blocked == 1);
            var deptUsers = new List<LBCFUBL_WCF.DBO.User>();
            var moneyForUser = new Dictionary<string, double>();

            var accountUsers = new List<LBCFUBL_WCF.DBO.User>();

            foreach (var user in users)
            {
                double money = Helper.GetUserClient().GetUserMoney(user.login);
                if (money < 0)
                    deptUsers.Add(user);
                else if (money > 0)
                    accountUsers.Add(user);
                moneyForUser.Add(user.login, Math.Round(money, 2));
            }
            ViewBag.BlockedUsers = blockedUsers;
            ViewBag.DeptUsers = deptUsers;
            ViewBag.MoneyForUser = moneyForUser;
            ViewBag.AccountUsers = accountUsers;


            // Compute Data for Graph

            ViewBag.MonthMap = FetchMonth();
            ViewBag.DayMap = FetchDay();
            return View();
        }


        private SortedList<DateTime, PurchasesController.Data> FetchMonth()
        {

            var accountHistory = Helper.GetUserClient().GetUsersAccountHistoryResult();
            var purchaseHistory = Helper.GetUserClient().GetUsersPurchasesHistoryResult();

            var map = new SortedList<DateTime, PurchasesController.Data>(); // Monthly purchase (account - purchase) , total this month
            foreach (var account in accountHistory)
            {
                int year = (int)account.year;
                int month = (int)account.month;
                DateTime date = new DateTime((int)account.year, (int)account.month, 1);
                map[date] = new PurchasesController.Data(0, account.total_account, false);
            }
            foreach (var purchase in purchaseHistory)
            {
                DateTime date = new DateTime((int)purchase.year, (int)purchase.month, 1);
                PurchasesController.Data tuple = null;
                if (map.ContainsKey(date))
                    tuple = map[date];
                else
                {
                    tuple = new PurchasesController.Data(0, 0, true);
                }
                map[date] = new PurchasesController.Data((double)purchase.month_purchase, tuple.second - purchase.total_purchase, tuple.third);
            }

            PurchasesController.Data last = null;
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


        private SortedList<DateTime, PurchasesController.Data> FetchDay()
        {

            var accountHistory = Helper.GetUserClient().GetAccountsDayHistory();
            var purchaseHistory = Helper.GetUserClient().GetPurchasesDayHistory();

            var map = new SortedList<DateTime, PurchasesController.Data>(); // Monthly purchase (account - purchase) , total this month
            foreach (var account in accountHistory)
            {
                int year = (int)account.year;
                int month = (int)account.month;
                DateTime date = new DateTime((int)account.year, (int)account.month, (int)account.day);
                map[date] = new PurchasesController.Data(0, account.total_account, false);
            }
            foreach (var purchase in purchaseHistory)
            {
                DateTime date = new DateTime((int)purchase.year, (int)purchase.month, (int)purchase.day);
                PurchasesController.Data tuple = null;
                if (map.ContainsKey(date))
                    tuple = map[date];
                else
                {
                    tuple = new PurchasesController.Data(0, 0, true);
                }
                map[date] = new PurchasesController.Data((double)purchase.day_purchase, tuple.second - purchase.total_purchase, tuple.third);
            }

            PurchasesController.Data last = null;
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
    }
}
