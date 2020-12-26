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
    public class FitnessCentresController : Controller
    {
        private Model5 db = new Model5();

        // GET: FitnessCentres
        public ActionResult Index()
        {
            return View(db.FitnessCentres.ToList());
        }

        // GET: FitnessCentres/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FitnessCentre fitnessCentre = db.FitnessCentres.Find(id);
            if (fitnessCentre == null)
            {
                return HttpNotFound();
            }
            return View(fitnessCentre);
        }

        // GET: FitnessCentres/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FitnessCentres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,lon,lat,name,opening_hours,website,phone,addr_street,numbergrades,averagegrade,Tip")] FitnessCentre fitnessCentre)
        {
            if (ModelState.IsValid)
            {
                db.FitnessCentres.Add(fitnessCentre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fitnessCentre);
        }

        // GET: FitnessCentres/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FitnessCentre fitnessCentre = db.FitnessCentres.Find(id);
            if (fitnessCentre == null)
            {
                return HttpNotFound();
            }
            return View(fitnessCentre);
        }

        // POST: FitnessCentres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,lon,lat,name,opening_hours,website,phone,addr_street,numbergrades,averagegrade,Tip")] FitnessCentre fitnessCentre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fitnessCentre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fitnessCentre);
        }

        // GET: FitnessCentres/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FitnessCentre fitnessCentre = db.FitnessCentres.Find(id);
            if (fitnessCentre == null)
            {
                return HttpNotFound();
            }
            return View(fitnessCentre);
        }

        // POST: FitnessCentres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            FitnessCentre fitnessCentre = db.FitnessCentres.Find(id);
            db.FitnessCentres.Remove(fitnessCentre);
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
