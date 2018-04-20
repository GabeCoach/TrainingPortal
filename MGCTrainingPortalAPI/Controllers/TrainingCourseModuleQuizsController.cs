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
    public class TrainingCourseModuleQuizsController : ApiController
    {
        private DB_A35BD0_trainingportaldbEntities db = new DB_A35BD0_trainingportaldbEntities();

        // GET: api/TrainingCourseModuleQuizs
        public IQueryable<TrainingCourseModuleQuiz> GetTrainingCourseModuleQuizs()
        {
            return db.TrainingCourseModuleQuizs;
        }

        // GET: api/TrainingCourseModuleQuizs/5
        [ResponseType(typeof(TrainingCourseModuleQuiz))]
        public async Task<IHttpActionResult> GetTrainingCourseModuleQuiz(int id)
        {
            TrainingCourseModuleQuiz trainingCourseModuleQuiz = await db.TrainingCourseModuleQuizs.FindAsync(id);
            if (trainingCourseModuleQuiz == null)
            {
                return NotFound();
            }

            return Ok(trainingCourseModuleQuiz);
        }

        // PUT: api/TrainingCourseModuleQuizs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTrainingCourseModuleQuiz(int id, TrainingCourseModuleQuiz trainingCourseModuleQuiz)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != trainingCourseModuleQuiz.Id)
            {
                return BadRequest();
            }

            db.Entry(trainingCourseModuleQuiz).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainingCourseModuleQuizExists(id))
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

        // POST: api/TrainingCourseModuleQuizs
        [ResponseType(typeof(TrainingCourseModuleQuiz))]
        public async Task<IHttpActionResult> PostTrainingCourseModuleQuiz(TrainingCourseModuleQuiz trainingCourseModuleQuiz)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TrainingCourseModuleQuizs.Add(trainingCourseModuleQuiz);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = trainingCourseModuleQuiz.Id }, trainingCourseModuleQuiz);
        }

        // DELETE: api/TrainingCourseModuleQuizs/5
        [ResponseType(typeof(TrainingCourseModuleQuiz))]
        public async Task<IHttpActionResult> DeleteTrainingCourseModuleQuiz(int id)
        {
            TrainingCourseModuleQuiz trainingCourseModuleQuiz = await db.TrainingCourseModuleQuizs.FindAsync(id);
            if (trainingCourseModuleQuiz == null)
            {
                return NotFound();
            }

            db.TrainingCourseModuleQuizs.Remove(trainingCourseModuleQuiz);
            await db.SaveChangesAsync();

            return Ok(trainingCourseModuleQuiz);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TrainingCourseModuleQuizExists(int id)
        {
            return db.TrainingCourseModuleQuizs.Count(e => e.Id == id) > 0;
        }
    }
}