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
    public class FitnessCentresController : ApiController
    {
        private Model2 db = new Model2();

        // GET: api/FitnessCentres
        public IQueryable<FitnessCentres> GetFitnessCentres()
        {
            return db.FitnessCentres;
        }

        // GET: api/FitnessCentres/5
        [ResponseType(typeof(FitnessCentres))]
        public IHttpActionResult GetFitnessCentres(long id)
        {
            FitnessCentres fitnessCentres = db.FitnessCentres.Find(id);
            if (fitnessCentres == null)
            {
                return NotFound();
            }

            return Ok(fitnessCentres);
        }

        // PUT: api/FitnessCentres/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFitnessCentres(long id, FitnessCentres fitnessCentres)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fitnessCentres.id)
            {
                return BadRequest();
            }

            db.Entry(fitnessCentres).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FitnessCentresExists(id))
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

        // POST: api/FitnessCentres
        [ResponseType(typeof(FitnessCentres))]
        public IHttpActionResult PostFitnessCentres(FitnessCentres fitnessCentres)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FitnessCentres.Add(fitnessCentres);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (FitnessCentresExists(fitnessCentres.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = fitnessCentres.id }, fitnessCentres);
        }

        // DELETE: api/FitnessCentres/5
        [ResponseType(typeof(FitnessCentres))]
        public IHttpActionResult DeleteFitnessCentres(long id)
        {
            FitnessCentres fitnessCentres = db.FitnessCentres.Find(id);
            if (fitnessCentres == null)
            {
                return NotFound();
            }

            db.FitnessCentres.Remove(fitnessCentres);
            db.SaveChanges();

            return Ok(fitnessCentres);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FitnessCentresExists(long id)
        {
            return db.FitnessCentres.Count(e => e.id == id) > 0;
        }
    }
}