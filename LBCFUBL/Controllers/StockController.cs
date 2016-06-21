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
    [CustomAuthorizeAttribute(Roles = "admin,assistant")]
    public class StockController : Controller
    {
        // GET: Stock
        public ActionResult Index()
        {
            Services.ViewUtils.FillViewBag(ViewBag, TempData, User.Identity.Name);
            LBCFUBL_WCF.DBO.Shopping[] shoppings = Helper.GetShoppingClient().GetShoppings();
            ViewBag.Shoppings = shoppings;
            Dictionary<LBCFUBL_WCF.DBO.Shopping, double> shopping_totals = new Dictionary<LBCFUBL_WCF.DBO.Shopping, double>();
            foreach (LBCFUBL_WCF.DBO.Shopping s in shoppings)
            {
                shopping_totals.Add(s, Helper.GetShoppingClient().GetShoppingTotalCost(s.id));
            }
            ViewBag.Shoppings_totals = shopping_totals;

            ViewBag.ActualStock = Helper.GetPurchaseClient().GetStocksForDate(DateTime.Now);
            return View();
        }

        // GET: Stock/Details/5
        public ActionResult Details(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LBCFUBL_WCF.DBO.Shopping_Product[] shopping = null; // Helper.GetShoppingProductClient().GetShopping_ProductsForShoppingId(id);
            if (shopping == null)
            {
                return HttpNotFound();
            }
            return View(shopping);
        }

        // GET: Stock/Create
        public ActionResult Create()
        {
            ViewBag.Products = Helper.GetProductClient().GetAllProducts();
            return View();
        }

        [HttpPost]
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