﻿using System;
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
    public class ShoppingsController : Controller
    {
        private lbcfublEntities db = new lbcfublEntities();

        // GET: Shoppings
        public ActionResult Index()
        {
            return View(db.Shopping.ToList());
        }

        // GET: Shoppings/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shopping shopping = db.Shopping.Find(id);
            if (shopping == null)
            {
                return HttpNotFound();
            }
            return View(shopping);
        }

        // GET: Shoppings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Shoppings/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,date")] Shopping shopping)
        {
            if (ModelState.IsValid)
            {
                shopping.id = Guid.NewGuid();
                db.Shopping.Add(shopping);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shopping);
        }

        // GET: Shoppings/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shopping shopping = db.Shopping.Find(id);
            if (shopping == null)
            {
                return HttpNotFound();
            }
            return View(shopping);
        }

        // POST: Shoppings/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,date")] Shopping shopping)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shopping).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shopping);
        }

        // GET: Shoppings/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shopping shopping = db.Shopping.Find(id);
            if (shopping == null)
            {
                return HttpNotFound();
            }
            return View(shopping);
        }

        // POST: Shoppings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Shopping shopping = db.Shopping.Find(id);
            db.Shopping.Remove(shopping);
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