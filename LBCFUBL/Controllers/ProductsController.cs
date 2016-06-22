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
    [CustomAuthorizeAttribute]
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            ViewBag.Products = Helper.GetProductClient().GetAllProducts().ToList();
            ViewUtils.FillViewBag(ViewBag, TempData, User.Identity.Name);
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "name,description,cost_without_margin,cost_with_margin")] LBCFUBL_WCF.DBO.Product product)
        {
            if (ModelState.IsValid)
            {
                product.id = Guid.NewGuid();
                Helper.GetProductClient().CreateProduct(product.name, product.description, (float)product.cost_without_margin, (float)product.cost_with_margin);
                return RedirectToAction("Index");
            }

            return View(product);
        }
    }
}
