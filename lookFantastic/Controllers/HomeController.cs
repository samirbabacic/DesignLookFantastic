using lookFantastic.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lookFantastic.Controllers
{
    public class HomeController : Controller
    {
        Model2 context;
        
        public HomeController()
        {
            context = new Model2();
        }
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }
        public ActionResult Index()
        {
            Location locations = new Location();
            foreach(var hairdresser in context.HairDressers.ToList())
            {
                locations.HairDressers.Add(hairdresser);
            }
            return View(locations);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}