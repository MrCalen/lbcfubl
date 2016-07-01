using LBCFUBL.BusinessManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LBCFUBL.Models;
using LBCFUBL.Services;
using System.Net;

namespace LBCFUBL.Controllers
{
    [CustomAuthorizeAttribute(Roles = "admin,chief")]
    public class StockController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            Services.ViewUtils.FillViewBag(ViewBag, TempData, User.Identity.Name);
            LBCFUBL_WCF.DBO.Shopping[] shoppings = Helper.GetShoppingClient().GetShoppings();
            ViewBag.Shoppings = shoppings;
            Dictionary<LBCFUBL_WCF.DBO.Shopping, double> shopping_totals = new Dictionary<LBCFUBL_WCF.DBO.Shopping, double>();
            foreach (LBCFUBL_WCF.DBO.Shopping s in shoppings)
            {
                shopping_totals.Add(s, Helper.GetShoppingClient().GetShoppingTotalCost(s.id));
                if (s.Shopping_Product.Count == 0)
                    s.Shopping_Product = Helper.GetShoppingProductClient().GetShopping_ProductsForShopping(s).ToList();
            }
            ViewBag.Shoppings_totals = shopping_totals;

            ViewBag.ActualStock = Helper.GetPurchaseClient().GetStocksForDate(DateTime.Now);
            return View();
        }

        [HttpGet]
        [CustomAuthorizeAttribute(Roles = "admin")]
        public ActionResult Create()
        {
            ViewBag.Products = Helper.GetProductClient().GetAllProducts();
            ViewUtils.FillViewBag(ViewBag, TempData, User.Identity.Name);
            return View();
        }

        [HttpPost]
        [CustomAuthorizeAttribute(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "date")] LBCFUBL_WCF.DBO.Shopping shopping)
        {
            if (ModelState.IsValid)
            {

                List<LBCFUBL_WCF.DBO.Product> products = Helper.GetProductClient().GetAllProducts().ToList();
                List<LBCFUBL_WCF.DBO.Shopping_Product> shopping_products = new List<LBCFUBL_WCF.DBO.Shopping_Product>();
                foreach(LBCFUBL_WCF.DBO.Product p in products)
                {
                    string number = "number" + p.id.ToString();
                    shopping_products.Add(new LBCFUBL_WCF.DBO.Shopping_Product() {
                        id_product = p.id,
                        number = int.Parse(Request.Form[number])
                    });
                }

                Helper.GetShoppingClient().CreateShoppingWithProducts(shopping.date, shopping_products.ToArray());
                return RedirectToAction("Index");
            }

            return View(shopping);
        }
    }
}