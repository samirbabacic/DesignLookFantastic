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
        private Model2 db = new Model2();

        // GET: FitnessCentres
        public ActionResult Index()
        {
            List<FitnessCentres> list = new List<FitnessCentres>();
            foreach (var model in db.FitnessCentres.ToList())
            {
                if (model.name != null && model.addr_street != null)
                {
                    list.Add(model);
                }
            }
            return View(list.ToList());
        }

        // GET: FitnessCentres/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FitnessCentres fitnessCentre = db.FitnessCentres.Find(id);
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
        public ActionResult Create([Bind(Include = "Id,lon,lat,Name,ReviewGrade,NumberGrades")] FitnessCentres fitnessCentre)
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
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FitnessCentres fitnessCentre = db.FitnessCentres.Find(id);
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
        public ActionResult Edit([Bind(Include = "Id,lon,lat,Name,ReviewGrade,NumberGrades")] FitnessCentres fitnessCentre)
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
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FitnessCentres fitnessCentre = db.FitnessCentres.Find(id);
            if (fitnessCentre == null)
            {
                return HttpNotFound();
            }
            return View(fitnessCentre);
        }

        // POST: FitnessCentres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FitnessCentres fitnessCentre = db.FitnessCentres.Find(id);
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
