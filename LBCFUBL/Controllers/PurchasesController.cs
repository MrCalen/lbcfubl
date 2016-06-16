using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LBCFUBL.Models;

namespace LBCFUBL.Controllers
{
    public class PurchasesController : Controller
    {
        private lbcfublEntities db = new lbcfublEntities();

        // GET: Purchases
        public ActionResult Index()
        {
            var purchase = db.Purchase.Include(p => p.Product).Include(p => p.User);
            return View(purchase.ToList());
        }

        // GET: Purchases/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase purchase = db.Purchase.Find(id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            return View(purchase);
        }

        // GET: Purchases/Create
        public ActionResult Create()
        {
            ViewBag.id_prod = new SelectList(db.Product, "id", "name");
            ViewBag.login = new SelectList(db.User, "login", "password");
            return View();
        }

        // POST: Purchases/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "login,date,id_prod")] Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                db.Purchase.Add(purchase);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_prod = new SelectList(db.Product, "id", "name", purchase.id_prod);
            ViewBag.login = new SelectList(db.User, "login", "password", purchase.login);
            return View(purchase);
        }

        // GET: Purchases/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase purchase = db.Purchase.Find(id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_prod = new SelectList(db.Product, "id", "name", purchase.id_prod);
            ViewBag.login = new SelectList(db.User, "login", "password", purchase.login);
            return View(purchase);
        }

        // POST: Purchases/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "login,date,id_prod")] Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchase).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_prod = new SelectList(db.Product, "id", "name", purchase.id_prod);
            ViewBag.login = new SelectList(db.User, "login", "password", purchase.login);
            return View(purchase);
        }

        // GET: Purchases/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase purchase = db.Purchase.Find(id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            return View(purchase);
        }

        // POST: Purchases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Purchase purchase = db.Purchase.Find(id);
            db.Purchase.Remove(purchase);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
