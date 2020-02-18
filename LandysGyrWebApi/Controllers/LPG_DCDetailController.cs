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
using LandysGyrWebApi.EntityFramework;
using System.Web.Http.Cors;

namespace LandysGyrWebApi.Controllers
{

    [EnableCors(origins: "https://localhost:44364", headers: "*", methods: "*")]
    public class LPG_DCDetailController : ApiController
    {
        private LandysGyrDBEntities1 db = new LandysGyrDBEntities1();

        // GET: api/LPG_DCDetail
        public IQueryable<LPG_DCDetail> GetLPG_DCDetail()
        {
            return db.LPG_DCDetail;
        }

        // GET: api/LPG_DCDetail/5
        [ResponseType(typeof(LPG_DCDetail))]
        public IHttpActionResult GetLPG_DCDetail(int id)
        {
            LPG_DCDetail lPG_DCDetail = db.LPG_DCDetail.Find(id);
            if (lPG_DCDetail == null)
            {
                return NotFound();
            }

            return Ok(lPG_DCDetail);
        }

        // PUT: api/LPG_DCDetail/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLPG_DCDetail(int id, LPG_DCDetail lPG_DCDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lPG_DCDetail.DCSerial)
            {
                return BadRequest();
            }

            db.Entry(lPG_DCDetail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LPG_DCDetailExists(id))
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

        // POST: api/LPG_DCDetail
        [ResponseType(typeof(LPG_DCDetail))]
        public IHttpActionResult PostLPG_DCDetail(LPG_DCDetail lPG_DCDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LPG_DCDetail.Add(lPG_DCDetail);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (LPG_DCDetailExists(lPG_DCDetail.DCSerial))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = lPG_DCDetail.DCSerial }, lPG_DCDetail);
        }

        // DELETE: api/LPG_DCDetail/5
        [ResponseType(typeof(LPG_DCDetail))]
        public IHttpActionResult DeleteLPG_DCDetail(int id)
        {
            LPG_DCDetail lPG_DCDetail = db.LPG_DCDetail.Find(id);
            if (lPG_DCDetail == null)
            {
                return NotFound();
            }

            db.LPG_DCDetail.Remove(lPG_DCDetail);
            db.SaveChanges();

            return Ok(lPG_DCDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LPG_DCDetailExists(int id)
        {
            return db.LPG_DCDetail.Count(e => e.DCSerial == id) > 0;
        }
    }
}