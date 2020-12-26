using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using lookFantastic.Models;

namespace lookFantastic.Controllers
{
    public class ClothingShopsController : Controller
    {
        private Model5 db = new Model5();

        // GET: ClothingShops
        public ActionResult Index()
        {
            return View(db.ClothingShops.ToList());
        }

        // GET: ClothingShops/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClothingShop clothingShop = db.ClothingShops.Find(id);
            if (clothingShop == null)
            {
                return HttpNotFound();
            }
            return View(clothingShop);
        }

        // GET: ClothingShops/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClothingShops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,lon,lat,name,opening_hours,website,addr_street,numbergrades,averagegrade,Tip")] ClothingShop clothingShop)
        {
            if (ModelState.IsValid)
            {
                db.ClothingShops.Add(clothingShop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clothingShop);
        }

        // GET: ClothingShops/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClothingShop clothingShop = db.ClothingShops.Find(id);
            if (clothingShop == null)
            {
                return HttpNotFound();
            }
            return View(clothingShop);
        }

        // POST: ClothingShops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,lon,lat,name,opening_hours,website,addr_street,numbergrades,averagegrade,Tip")] ClothingShop clothingShop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clothingShop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clothingShop);
        }

        // GET: ClothingShops/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClothingShop clothingShop = db.ClothingShops.Find(id);
            if (clothingShop == null)
            {
                return HttpNotFound();
            }
            return View(clothingShop);
        }

        // POST: ClothingShops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ClothingShop clothingShop = db.ClothingShops.Find(id);
            db.ClothingShops.Remove(clothingShop);
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
