using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LBCFUBL.Services
{
    public class ViewUtils
    {
        public static void FillViewBag(dynamic ViewBag, string UserLogin)
        {
            ViewBag.Money = Math.Round(Helper.GetUserClient().GetUserMoney(UserLogin), 2);
            ViewBag.Products = Helper.GetProductClient().GetAllProducts();
            ViewBag.Users = Helper.GetUserClient().GetUsers();
            ViewBag.History = Helper.GetPurchaseClient().GetPurchasesForLogin(UserLogin).Reverse();
        }
    }
}