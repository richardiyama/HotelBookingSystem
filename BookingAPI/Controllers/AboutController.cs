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
using BookingAPI.Models;
using System.Threading.Tasks;

namespace BookingAPI.Controllers
{
    public class AboutController : ApiController
    {
        private BookingAPIContextDB db = new BookingAPIContextDB();

        // GET: api/About
        public IQueryable<About> GetAbouts()
        {
            return db.Abouts;
        }

        // GET: api/About/5
        [ResponseType(typeof(About))]
        public IHttpActionResult GetAbout(int id)
        {
            About about = db.Abouts.Find(id);
            if (about == null)
            {
                return NotFound();
            }

            return Ok(about);
        }

        // PUT: api/About/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAbout(int id, About about)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != about.AboutID)
            {
                return BadRequest();
            }

            db.Entry(about).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AboutExists(id))
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

        // POST: api/About
        [ResponseType(typeof(About))]
        public IHttpActionResult PostAbout(About about)
        {

            if (!ModelState.IsValid)
            {
               
                return BadRequest(ModelState);
            }

            db.Abouts.Add(about);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = about.AboutID }, about);
        }

        // DELETE: api/About/5
        [ResponseType(typeof(About))]
        public IHttpActionResult DeleteAbout(int id)
        {
            About about = db.Abouts.Find(id);
            if (about == null)
            {
                return NotFound();
            }

            db.Abouts.Remove(about);
            db.SaveChanges();

            return Ok(about);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AboutExists(int id)
        {
            return db.Abouts.Count(e => e.AboutID == id) > 0;
        }
    }
}