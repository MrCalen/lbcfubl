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

        // GET: Products/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LBCFUBL_WCF.DBO.Product product = Helper.GetProductClient().GetProductFromId(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Products/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LBCFUBL_WCF.DBO.Product product = Helper.GetProductClient().GetProductFromId(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,description,cost_without_margin,cost_with_margin,cost_HT,taxe")] LBCFUBL_WCF.DBO.Product product)
        {
            if (ModelState.IsValid)
            {
                /* TODO
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                */
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LBCFUBL_WCF.DBO.Product product = Helper.GetProductClient().GetProductFromId(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Helper.GetProductClient().DeleteProductFromId(id);
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
