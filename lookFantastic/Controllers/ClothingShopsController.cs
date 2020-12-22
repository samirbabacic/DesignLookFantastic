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
        private Model2 db = new Model2();

        // GET: ClothingShops
        public ActionResult Index()
        {
            List<ClothingShops> list = new List<ClothingShops>();
            foreach (var model in db.ClothingShops.ToList())
            {
                if (model.name != null && model.addr_street != null)
                {
                    list.Add(model);
                }
            }
            return View(list.ToList());
        }

        // GET: ClothingShops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClothingShops clothingShop = db.ClothingShops.Find(id);
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
        public ActionResult Create([Bind(Include = "Id,lon,lat,Name,ReviewGrade,NumberGrades")] ClothingShops clothingShop)
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
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClothingShops clothingShop = db.ClothingShops.Find(id);
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
        public ActionResult Edit([Bind(Include = "Id,lon,lat,Name,ReviewGrade,NumberGrades")] ClothingShops clothingShop)
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
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClothingShops clothingShop = db.ClothingShops.Find(id);
            if (clothingShop == null)
            {
                return HttpNotFound();
            }
            return View(clothingShop);
        }

        // POST: ClothingShops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClothingShops clothingShop = db.ClothingShops.Find(id);
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
