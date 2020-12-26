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
        private Model5 db = new Model5();

        // GET: api/ClothingShops
        public IQueryable<ClothingShop> GetClothingShops()
        {
            return db.ClothingShops;
        }

        // GET: api/ClothingShops/5
        [ResponseType(typeof(ClothingShop))]
        public IHttpActionResult GetClothingShop(long id)
        {
            ClothingShop clothingShop = db.ClothingShops.Find(id);
            if (clothingShop == null)
            {
                return NotFound();
            }

            return Ok(clothingShop);
        }

        // PUT: api/ClothingShops/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClothingShop(long id, ClothingShop clothingShop)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clothingShop.id)
            {
                return BadRequest();
            }

            db.Entry(clothingShop).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClothingShopExists(id))
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
        [ResponseType(typeof(ClothingShop))]
        public IHttpActionResult PostClothingShop(ClothingShop clothingShop)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ClothingShops.Add(clothingShop);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ClothingShopExists(clothingShop.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = clothingShop.id }, clothingShop);
        }

        // DELETE: api/ClothingShops/5
        [ResponseType(typeof(ClothingShop))]
        public IHttpActionResult DeleteClothingShop(long id)
        {
            ClothingShop clothingShop = db.ClothingShops.Find(id);
            if (clothingShop == null)
            {
                return NotFound();
            }

            db.ClothingShops.Remove(clothingShop);
            db.SaveChanges();

            return Ok(clothingShop);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClothingShopExists(long id)
        {
            return db.ClothingShops.Count(e => e.id == id) > 0;
        }
    }
}