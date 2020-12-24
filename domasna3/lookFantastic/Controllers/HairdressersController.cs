using System;
using System.Collections;
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
    public class HairdressersController : Controller
    {
        private Model3 db = new Model3();

        // GET: Hairdressers
        public ActionResult Index()
        {
            List<HairDressers> list = new List<HairDressers>();
            foreach(var model in db.HairDressers.ToList())
            {
                if(model.name != null && model.addr_street != null)
                {
                    list.Add(model);
                }
            }
            return View(list.ToList());
        }

        // GET: Hairdressers/Details/5
        

        // GET: Hairdressers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hairdressers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        
        

        // GET: Hairdressers/Edit/5
        

        // POST: Hairdressers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,lon,lat,Name,ReviewGrade,NumberGrades")] Hairdresser hairdresser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hairdresser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hairdresser);
        }

        // GET: Hairdressers/Delete/5
        

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
