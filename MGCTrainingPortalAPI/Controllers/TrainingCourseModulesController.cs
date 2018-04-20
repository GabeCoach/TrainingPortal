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
    public class TrainingCourseModulesController : ApiController
    {
        private DB_A35BD0_trainingportaldbEntities db = new DB_A35BD0_trainingportaldbEntities();

        // GET: api/TrainingCourseModules
        public IQueryable<TrainingCourseModule> GetTrainingCourseModules()
        {
            return db.TrainingCourseModules;
        }

        // GET: api/TrainingCourseModules/5
        [ResponseType(typeof(TrainingCourseModule))]
        public async Task<IHttpActionResult> GetTrainingCourseModule(int id)
        {
            TrainingCourseModule trainingCourseModule = await db.TrainingCourseModules.FindAsync(id);
            if (trainingCourseModule == null)
            {
                return NotFound();
            }

            return Ok(trainingCourseModule);
        }

        // PUT: api/TrainingCourseModules/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTrainingCourseModule(int id, TrainingCourseModule trainingCourseModule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != trainingCourseModule.Id)
            {
                return BadRequest();
            }

            db.Entry(trainingCourseModule).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainingCourseModuleExists(id))
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

        // POST: api/TrainingCourseModules
        [ResponseType(typeof(TrainingCourseModule))]
        public async Task<IHttpActionResult> PostTrainingCourseModule(TrainingCourseModule trainingCourseModule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TrainingCourseModules.Add(trainingCourseModule);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = trainingCourseModule.Id }, trainingCourseModule);
        }

        // DELETE: api/TrainingCourseModules/5
        [ResponseType(typeof(TrainingCourseModule))]
        public async Task<IHttpActionResult> DeleteTrainingCourseModule(int id)
        {
            TrainingCourseModule trainingCourseModule = await db.TrainingCourseModules.FindAsync(id);
            if (trainingCourseModule == null)
            {
                return NotFound();
            }

            db.TrainingCourseModules.Remove(trainingCourseModule);
            await db.SaveChangesAsync();

            return Ok(trainingCourseModule);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TrainingCourseModuleExists(int id)
        {
            return db.TrainingCourseModules.Count(e => e.Id == id) > 0;
        }
    }
}