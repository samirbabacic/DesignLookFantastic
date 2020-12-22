using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using lookFantastic.Models;

namespace lookFantastic.Controllers.Api
{
    public class BeautySalonsController : ApiController
    {
        private Model2 db = new Model2();

        // GET: api/BeautySalons
        public IQueryable<BeautySalons> GetBeautySalons()
        {
            return db.BeautySalons;
        }

        // GET: api/BeautySalons/5
        [ResponseType(typeof(BeautySalons))]
        public IHttpActionResult GetBeautySalons(long id)
        {
            BeautySalons beautySalons = db.BeautySalons.Find(id);
            if (beautySalons == null)
            {
                return NotFound();
            }

            return Ok(beautySalons);
        }

        // PUT: api/BeautySalons/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBeautySalons(long id, BeautySalons beautySalons)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != beautySalons.id)
            {
                return BadRequest();
            }

            db.Entry(beautySalons).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BeautySalonsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/BeautySalons
        [ResponseType(typeof(BeautySalons))]
        public IHttpActionResult PostBeautySalons(BeautySalons beautySalons)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BeautySalons.Add(beautySalons);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (BeautySalonsExists(beautySalons.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = beautySalons.id }, beautySalons);
        }

        // DELETE: api/BeautySalons/5
        [ResponseType(typeof(BeautySalons))]
        public IHttpActionResult DeleteBeautySalons(long id)
        {
            BeautySalons beautySalons = db.BeautySalons.Find(id);
            if (beautySalons == null)
            {
                return NotFound();
            }

            db.BeautySalons.Remove(beautySalons);
            db.SaveChanges();

            return Ok(beautySalons);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BeautySalonsExists(long id)
        {
            return db.BeautySalons.Count(e => e.id == id) > 0;
        }
    }
}