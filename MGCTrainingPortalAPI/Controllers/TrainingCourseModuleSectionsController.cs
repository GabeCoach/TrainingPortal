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
    public class TrainingCourseModuleSectionsController : ApiController
    {
        private DB_A35BD0_trainingportaldbEntities db = new DB_A35BD0_trainingportaldbEntities();

        // GET: api/TrainingCourseModuleSections
        public IQueryable<TrainingCourseModuleSection> GetTrainingCourseModuleSections()
        {
            return db.TrainingCourseModuleSections;
        }

        // GET: api/TrainingCourseModuleSections/5
        [ResponseType(typeof(TrainingCourseModuleSection))]
        public async Task<IHttpActionResult> GetTrainingCourseModuleSection(int id)
        {
            TrainingCourseModuleSection trainingCourseModuleSection = await db.TrainingCourseModuleSections.FindAsync(id);
            if (trainingCourseModuleSection == null)
            {
                return NotFound();
            }

            return Ok(trainingCourseModuleSection);
        }

        // PUT: api/TrainingCourseModuleSections/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTrainingCourseModuleSection(int id, TrainingCourseModuleSection trainingCourseModuleSection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != trainingCourseModuleSection.Id)
            {
                return BadRequest();
            }

            db.Entry(trainingCourseModuleSection).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainingCourseModuleSectionExists(id))
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

        // POST: api/TrainingCourseModuleSections
        [ResponseType(typeof(TrainingCourseModuleSection))]
        public async Task<IHttpActionResult> PostTrainingCourseModuleSection(TrainingCourseModuleSection trainingCourseModuleSection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TrainingCourseModuleSections.Add(trainingCourseModuleSection);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TrainingCourseModuleSectionExists(trainingCourseModuleSection.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = trainingCourseModuleSection.Id }, trainingCourseModuleSection);
        }

        // DELETE: api/TrainingCourseModuleSections/5
        [ResponseType(typeof(TrainingCourseModuleSection))]
        public async Task<IHttpActionResult> DeleteTrainingCourseModuleSection(int id)
        {
            TrainingCourseModuleSection trainingCourseModuleSection = await db.TrainingCourseModuleSections.FindAsync(id);
            if (trainingCourseModuleSection == null)
            {
                return NotFound();
            }

            db.TrainingCourseModuleSections.Remove(trainingCourseModuleSection);
            await db.SaveChangesAsync();

            return Ok(trainingCourseModuleSection);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TrainingCourseModuleSectionExists(int id)
        {
            return db.TrainingCourseModuleSections.Count(e => e.Id == id) > 0;
        }
    }
}