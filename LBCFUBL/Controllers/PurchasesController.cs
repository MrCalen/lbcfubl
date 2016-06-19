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
        // GET: Purchases
        public ActionResult Index()
        {
            ViewUtils.FillViewBag(ViewBag, User.Identity.Name);
            ViewBag.Purchases = Helper.GetPurchaseClient().GetPurchasesForLogin(User.Identity.Name);
            return View();
        }

        // GET: Purchases/Details/5
        public ActionResult Details(string id)
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
            if (ModelState.IsValid)
            {
                Helper.GetPurchaseClient().CreatePurchase(purchase.login, purchase.date, purchase.id_prod);
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
