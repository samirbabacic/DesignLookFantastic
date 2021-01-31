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
        private Model5 db = new Model5();

        // GET: api/HairDressers
        public IQueryable<HairDresser> GetHairDressers()
        {
            return db.HairDressers;
        }

        // GET: api/HairDressers/5
        [ResponseType(typeof(HairDresser))]
        public IHttpActionResult GetHairDresser(long id)
        {
            HairDresser hairDresser = db.HairDressers.Find(id);
            if (hairDresser == null)
            {
                return NotFound();
            }

            return Ok(hairDresser);
        }

        // PUT: api/HairDressers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHairDresser(long id, HairDresser hairDresser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hairDresser.id)
            {
                return BadRequest();
            }

            db.Entry(hairDresser).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HairDresserExists(id))
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
        [ResponseType(typeof(HairDresser))]
        public IHttpActionResult PostHairDresser(HairDresser hairDresser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HairDressers.Add(hairDresser);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (HairDresserExists(hairDresser.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = hairDresser.id }, hairDresser);
        }

        // DELETE: api/HairDressers/5
        [ResponseType(typeof(HairDresser))]
        public IHttpActionResult DeleteHairDresser(long id)
        {
            HairDresser hairDresser = db.HairDressers.Find(id);
            if (hairDresser == null)
            {
                return NotFound();
            }

            db.HairDressers.Remove(hairDresser);
            db.SaveChanges();

            return Ok(hairDresser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HairDresserExists(long id)
        {
            return db.HairDressers.Count(e => e.id == id) > 0;
        }
    }
}