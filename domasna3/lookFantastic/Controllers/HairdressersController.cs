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
    public class HairDressersController : Controller
    {
        private Model5 db = new Model5();

        // GET: HairDressers
        public ActionResult Index()
        {
            return View(db.HairDressers.ToList());
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
