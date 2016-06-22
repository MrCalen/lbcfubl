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
    public class ShoppingsController : Controller
    {
        // GET: Shoppings
        public ActionResult Index()
        {
            return View(Helper.GetShoppingClient().GetShoppings().ToList());
        }

        // GET: Shoppings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Shoppings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,date")] LBCFUBL_WCF.DBO.Shopping shopping)
        {
            if (ModelState.IsValid)
            {
                Helper.GetShoppingClient().CreateShopping(shopping.date);
                return RedirectToAction("Index");
            }

            return View(shopping);
        }

    }
}
