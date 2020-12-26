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
        private Model5 db = new Model5();

        // GET: api/BeautySalons
        public IQueryable<BeautySalon> GetBeautySalons()
        {
            return db.BeautySalons;
        }

        // GET: api/BeautySalons/5
        [ResponseType(typeof(BeautySalon))]
        public IHttpActionResult GetBeautySalon(long id)
        {
            BeautySalon beautySalon = db.BeautySalons.Find(id);
            if (beautySalon == null)
            {
                return NotFound();
            }

            return Ok(beautySalon);
        }

        // PUT: api/BeautySalons/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBeautySalon(long id, BeautySalon beautySalon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != beautySalon.id)
            {
                return BadRequest();
            }

            db.Entry(beautySalon).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BeautySalonExists(id))
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
        [ResponseType(typeof(BeautySalon))]
        public IHttpActionResult PostBeautySalon(BeautySalon beautySalon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BeautySalons.Add(beautySalon);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (BeautySalonExists(beautySalon.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = beautySalon.id }, beautySalon);
        }

        // DELETE: api/BeautySalons/5
        [ResponseType(typeof(BeautySalon))]
        public IHttpActionResult DeleteBeautySalon(long id)
        {
            BeautySalon beautySalon = db.BeautySalons.Find(id);
            if (beautySalon == null)
            {
                return NotFound();
            }

            db.BeautySalons.Remove(beautySalon);
            db.SaveChanges();

            return Ok(beautySalon);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BeautySalonExists(long id)
        {
            return db.BeautySalons.Count(e => e.id == id) > 0;
        }
    }
}