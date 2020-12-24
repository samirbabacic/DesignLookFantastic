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
    public class ClothingShopsController : ApiController
    {
        private Model3 db = new Model3();

        // GET: api/ClothingShops
        public IQueryable<ClothingShops> GetClothingShops()
        {
            return db.ClothingShops;
        }

        // GET: api/ClothingShops/5
        [ResponseType(typeof(ClothingShops))]
        public IHttpActionResult GetClothingShops(long id)
        {
            ClothingShops clothingShops = db.ClothingShops.Find(id);
            if (clothingShops == null)
            {
                return NotFound();
            }

            return Ok(clothingShops);
        }

        // PUT: api/ClothingShops/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClothingShops(long id, ClothingShops clothingShops)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clothingShops.id)
            {
                return BadRequest();
            }

            db.Entry(clothingShops).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClothingShopsExists(id))
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

        // POST: api/ClothingShops
        [ResponseType(typeof(ClothingShops))]
        public IHttpActionResult PostClothingShops(ClothingShops clothingShops)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ClothingShops.Add(clothingShops);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ClothingShopsExists(clothingShops.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = clothingShops.id }, clothingShops);
        }

        // DELETE: api/ClothingShops/5
        [ResponseType(typeof(ClothingShops))]
        public IHttpActionResult DeleteClothingShops(long id)
        {
            ClothingShops clothingShops = db.ClothingShops.Find(id);
            if (clothingShops == null)
            {
                return NotFound();
            }

            db.ClothingShops.Remove(clothingShops);
            db.SaveChanges();

            return Ok(clothingShops);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClothingShopsExists(long id)
        {
            return db.ClothingShops.Count(e => e.id == id) > 0;
        }
    }
}