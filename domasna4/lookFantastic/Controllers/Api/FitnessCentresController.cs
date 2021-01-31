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
        private Model5 db = new Model5();

        // GET: api/FitnessCentres
        public IQueryable<FitnessCentre> GetFitnessCentres()
        {
            return db.FitnessCentres;
        }

        // GET: api/FitnessCentres/5
        [ResponseType(typeof(FitnessCentre))]
        public IHttpActionResult GetFitnessCentre(long id)
        {
            FitnessCentre fitnessCentre = db.FitnessCentres.Find(id);
            if (fitnessCentre == null)
            {
                return NotFound();
            }

            return Ok(fitnessCentre);
        }

        // PUT: api/FitnessCentres/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFitnessCentre(long id, FitnessCentre fitnessCentre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fitnessCentre.id)
            {
                return BadRequest();
            }

            db.Entry(fitnessCentre).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FitnessCentreExists(id))
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
        [ResponseType(typeof(FitnessCentre))]
        public IHttpActionResult PostFitnessCentre(FitnessCentre fitnessCentre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FitnessCentres.Add(fitnessCentre);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (FitnessCentreExists(fitnessCentre.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = fitnessCentre.id }, fitnessCentre);
        }

        // DELETE: api/FitnessCentres/5
        [ResponseType(typeof(FitnessCentre))]
        public IHttpActionResult DeleteFitnessCentre(long id)
        {
            FitnessCentre fitnessCentre = db.FitnessCentres.Find(id);
            if (fitnessCentre == null)
            {
                return NotFound();
            }

            db.FitnessCentres.Remove(fitnessCentre);
            db.SaveChanges();

            return Ok(fitnessCentre);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FitnessCentreExists(long id)
        {
            return db.FitnessCentres.Count(e => e.id == id) > 0;
        }
    }
}