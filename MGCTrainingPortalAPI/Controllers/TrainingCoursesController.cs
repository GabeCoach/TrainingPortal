using System;
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
using MGCTrainingPortalAPI.Models;

namespace MGCTrainingPortalAPI.Controllers
{
    public class TrainingCoursesController : ApiController
    {
        private DB_A35BD0_trainingportaldbEntities db = new DB_A35BD0_trainingportaldbEntities();

        // GET: api/TrainingCourses
        public IQueryable<TrainingCourse> GetTrainingCourses()
        {
            return db.TrainingCourses;
        }

        // GET: api/TrainingCourses/5
        [ResponseType(typeof(TrainingCourse))]
        public async Task<IHttpActionResult> GetTrainingCourse(int id)
        {
            TrainingCourse trainingCourse = await db.TrainingCourses.FindAsync(id);
            if (trainingCourse == null)
            {
                return NotFound();
            }

            return Ok(trainingCourse);
        }

        // PUT: api/TrainingCourses/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTrainingCourse(int id, TrainingCourse trainingCourse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != trainingCourse.Id)
            {
                return BadRequest();
            }

            db.Entry(trainingCourse).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainingCourseExists(id))
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

        // POST: api/TrainingCourses
        [ResponseType(typeof(TrainingCourse))]
        public async Task<IHttpActionResult> PostTrainingCourse(TrainingCourse trainingCourse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TrainingCourses.Add(trainingCourse);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = trainingCourse.Id }, trainingCourse);
        }

        // DELETE: api/TrainingCourses/5
        [ResponseType(typeof(TrainingCourse))]
        public async Task<IHttpActionResult> DeleteTrainingCourse(int id)
        {
            TrainingCourse trainingCourse = await db.TrainingCourses.FindAsync(id);
            if (trainingCourse == null)
            {
                return NotFound();
            }

            db.TrainingCourses.Remove(trainingCourse);
            await db.SaveChangesAsync();

            return Ok(trainingCourse);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TrainingCourseExists(int id)
        {
            return db.TrainingCourses.Count(e => e.Id == id) > 0;
        }
    }
}