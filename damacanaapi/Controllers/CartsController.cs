﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using damacanaapi.Models;

namespace damacanaapi.Controllers
{
    public class CartsController : ApiController
    {
        private damacanaapiContext db = new damacanaapiContext();

        // GET: api/Carts
        public IQueryable<Cart> GetCarts()
        {
  
            return db.Carts;
        }

        // GET: api/Carts/5
        [ResponseType(typeof(CartDTO))]
        public async Task<IHttpActionResult> GetCart(int id)
        {
            var cart = await db.Carts.Include(b => b.Product).Select(b =>
            
                new CartDetailDTO()
                    {
                         Id = b.Id,
  
                         }).SingleOrDefaultAsync(b => b.Id == id);




            return Ok(cart);
        }

        // PUT: api/Carts/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCart(int id, Cart cart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cart.Id)
            {
                return BadRequest();
            }

            db.Entry(cart).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartExists(id))
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

        // POST: api/Carts
        [ResponseType(typeof(Cart))]
        public async Task<IHttpActionResult> PostCart(Cart cart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //cart.Product
            // select
            db.Carts.Add(cart);
            await db.SaveChangesAsync();

            // New code:
            // Load author name
            db.Entry(cart).Reference(x => x.Product).Load();

            var dto = new CartDTO()
            {
                Id =cart.Id,
 
       
                
            };

            return CreatedAtRoute("DefaultApi", new { id = cart.Id }, dto);
        }
        // DELETE: api/Carts/5
        [ResponseType(typeof(Cart))]
        public async Task<IHttpActionResult> DeleteCart(int id)
        {
            Cart cart = await db.Carts.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }

            db.Carts.Remove(cart);
            await db.SaveChangesAsync();

            return Ok(cart);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CartExists(int id)
        {
            return db.Carts.Count(e => e.Id == id) > 0;
        }
    }
}