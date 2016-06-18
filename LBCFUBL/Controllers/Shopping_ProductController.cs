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
    [Authorize]
    public class Shopping_ProductController : Controller
    {
        private lbcfublEntities db = new lbcfublEntities();

        // GET: Shopping_Product
        public ActionResult Index()
        {
            var shopping_Product = db.Shopping_Product.Include(s => s.Product).Include(s => s.Shopping);
            return View(shopping_Product.ToList());
        }

        // GET: Shopping_Product/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shopping_Product shopping_Product = db.Shopping_Product.Find(id);
            if (shopping_Product == null)
            {
                return HttpNotFound();
            }
            return View(shopping_Product);
        }

        // GET: Shopping_Product/Create
        public ActionResult Create()
        {
            ViewBag.id_product = new SelectList(db.Product, "id", "name");
            ViewBag.id_shopping = new SelectList(db.Shopping, "id", "id");
            return View();
        }

        // POST: Shopping_Product/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_shopping,id_product,number")] Shopping_Product shopping_Product)
        {
            if (ModelState.IsValid)
            {
                shopping_Product.id_shopping = Guid.NewGuid();
                db.Shopping_Product.Add(shopping_Product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_product = new SelectList(db.Product, "id", "name", shopping_Product.id_product);
            ViewBag.id_shopping = new SelectList(db.Shopping, "id", "id", shopping_Product.id_shopping);
            return View(shopping_Product);
        }

        // GET: Shopping_Product/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shopping_Product shopping_Product = db.Shopping_Product.Find(id);
            if (shopping_Product == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_product = new SelectList(db.Product, "id", "name", shopping_Product.id_product);
            ViewBag.id_shopping = new SelectList(db.Shopping, "id", "id", shopping_Product.id_shopping);
            return View(shopping_Product);
        }

        // POST: Shopping_Product/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_shopping,id_product,number")] Shopping_Product shopping_Product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shopping_Product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_product = new SelectList(db.Product, "id", "name", shopping_Product.id_product);
            ViewBag.id_shopping = new SelectList(db.Shopping, "id", "id", shopping_Product.id_shopping);
            return View(shopping_Product);
        }

        // GET: Shopping_Product/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shopping_Product shopping_Product = db.Shopping_Product.Find(id);
            if (shopping_Product == null)
            {
                return HttpNotFound();
            }
            return View(shopping_Product);
        }

        // POST: Shopping_Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Shopping_Product shopping_Product = db.Shopping_Product.Find(id);
            db.Shopping_Product.Remove(shopping_Product);
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
