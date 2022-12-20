﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EntityFramework.Models;

namespace EntityFramework.Controllers
{
    public class ProductDescriptionsController : Controller
    {
        private AdventureWorksLT2019Entities1 db = new AdventureWorksLT2019Entities1();

        // GET: ProductDescriptions
        public ActionResult Index()
        {
            return View(db.ProductDescriptions.ToList());
        }

        // GET: ProductDescriptions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductDescription productDescription = db.ProductDescriptions.Find(id);
            if (productDescription == null)
            {
                return HttpNotFound();
            }
            return View(productDescription);
        }

        // GET: ProductDescriptions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductDescriptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductDescriptionID,Description,rowguid,ModifiedDate")] ProductDescription productDescription)
        {
            if (ModelState.IsValid)
            {
                db.ProductDescriptions.Add(productDescription);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productDescription);
        }

        // GET: ProductDescriptions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductDescription productDescription = db.ProductDescriptions.Find(id);
            if (productDescription == null)
            {
                return HttpNotFound();
            }
            return View(productDescription);
        }

        // POST: ProductDescriptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductDescriptionID,Description,rowguid,ModifiedDate")] ProductDescription productDescription)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productDescription).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productDescription);
        }

        // GET: ProductDescriptions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductDescription productDescription = db.ProductDescriptions.Find(id);
            if (productDescription == null)
            {
                return HttpNotFound();
            }
            return View(productDescription);
        }

        // POST: ProductDescriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductDescription productDescription = db.ProductDescriptions.Find(id);
            db.ProductDescriptions.Remove(productDescription);
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
