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
    public class HairDressersController : ApiController
    {
        private Model2 db = new Model2();

        // GET: api/HairDressers
        public IQueryable<HairDressers> GetHairDressers()
        {
            return db.HairDressers;
        }

        // GET: api/HairDressers/5
        [ResponseType(typeof(HairDressers))]
        public IHttpActionResult GetHairDressers(long id)
        {
            HairDressers hairDressers = db.HairDressers.Find(id);
            if (hairDressers == null)
            {
                return NotFound();
            }

            return Ok(hairDressers);
        }

        // PUT: api/HairDressers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHairDressers(long id, HairDressers hairDressers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hairDressers.id)
            {
                return BadRequest();
            }

            db.Entry(hairDressers).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HairDressersExists(id))
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

        // POST: api/HairDressers
        [ResponseType(typeof(HairDressers))]
        public IHttpActionResult PostHairDressers(HairDressers hairDressers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HairDressers.Add(hairDressers);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (HairDressersExists(hairDressers.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = hairDressers.id }, hairDressers);
        }

        // DELETE: api/HairDressers/5
        [ResponseType(typeof(HairDressers))]
        public IHttpActionResult DeleteHairDressers(long id)
        {
            HairDressers hairDressers = db.HairDressers.Find(id);
            if (hairDressers == null)
            {
                return NotFound();
            }

            db.HairDressers.Remove(hairDressers);
            db.SaveChanges();

            return Ok(hairDressers);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HairDressersExists(long id)
        {
            return db.HairDressers.Count(e => e.id == id) > 0;
        }
    }
}