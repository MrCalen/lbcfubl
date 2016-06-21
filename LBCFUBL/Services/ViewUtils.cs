using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LBCFUBL.Services
{
    public class ViewUtils
    {
        public static void FillViewBag(dynamic ViewBag, dynamic TempData, string UserLogin, Boolean isfull = false)
        {
            if (TempData["Error"] != null)
                ViewBag.Error = TempData["Error"];
            ViewBag.Money = Math.Round(Helper.GetUserClient().GetUserMoney(UserLogin), 2);
            ViewBag.Products = Helper.GetProductClient().GetAllProducts();
            ViewBag.Users = Helper.GetUserClient().GetUsers();
            ViewBag.User = Helper.GetUserClient().GetUserFromLogin(UserLogin);
            var History = Helper.GetPurchaseClient().GetPurchasesForLogin(UserLogin).Reverse();
            ViewBag.History = isfull ? History : History.Take(10);
        }
    }
}