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
    public class BeautySalonsController : Controller
    {
        private Model3 db = new Model3();

        // GET: BeautySalons
        public ActionResult Index()
        {
            List<BeautySalons> list = new List<BeautySalons>();
            foreach (var model in db.BeautySalons.ToList())
            {
                if (model.name != null && model.addr_street != null)
                {
                    list.Add(model);
                }
            }
            return View(list.ToList());
        }

        // GET: BeautySalons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BeautySalons beautySalon = db.BeautySalons.Find(id);
            if (beautySalon == null)
            {
                return HttpNotFound();
            }
            return View(beautySalon);
        }

        // GET: BeautySalons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BeautySalons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,lon,lat,Name,ReviewGrade,NumberGrades")] BeautySalons beautySalon)
        {
            if (ModelState.IsValid)
            {
                db.BeautySalons.Add(beautySalon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(beautySalon);
        }

        // GET: BeautySalons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BeautySalons beautySalon = db.BeautySalons.Find(id);
            if (beautySalon == null)
            {
                return HttpNotFound();
            }
            return View(beautySalon);
        }

        // POST: BeautySalons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,lon,lat,Name,ReviewGrade,NumberGrades")] BeautySalons beautySalon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(beautySalon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(beautySalon);
        }

        // GET: BeautySalons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BeautySalons beautySalon = db.BeautySalons.Find(id);
            if (beautySalon == null)
            {
                return HttpNotFound();
            }
            return View(beautySalon);
        }

        // POST: BeautySalons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BeautySalons beautySalon = db.BeautySalons.Find(id);
            db.BeautySalons.Remove(beautySalon);
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
