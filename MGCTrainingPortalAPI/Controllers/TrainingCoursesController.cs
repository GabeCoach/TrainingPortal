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
using System.Web.Http.Cors;
using System.Web.Http.Description;
using MGCTrainingPortalAPI.Models;
using MGCTrainingPortalAPI.Repository;

namespace MGCTrainingPortalAPI.Controllers
{
    [EnableCors(origins: "http://www.mgctrainingportal.com,http://localhost:4200,https://www.mgctrainingportal.com", headers: "*", methods: "*")]
    [Authorize]
    public class TrainingCoursesController : ApiController
    {
        private DB_A35BD0_trainingportaldbEntities db = new DB_A35BD0_trainingportaldbEntities();
        private TrainingCoursesRepository oTrainingCourseRepo = new TrainingCoursesRepository();

        // GET: api/TrainingCourses
        public IHttpActionResult GetTrainingCourses()
        {
            return Json(oTrainingCourseRepo.SelectAllFromDB());
        }

        // GET: api/TrainingCourses/5
        [ResponseType(typeof(TrainingCourse))]
        public async Task<IHttpActionResult> GetTrainingCourse(int id)
        {
            TrainingCourse trainingCourse = await oTrainingCourseRepo.SelectById(id);
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

            await oTrainingCourseRepo.UpdateToDB(trainingCourse, id);

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

            await oTrainingCourseRepo.SaveToDB(trainingCourse);

            return CreatedAtRoute("DefaultApi", new { id = trainingCourse.Id }, trainingCourse);
        }

        // DELETE: api/TrainingCourses/5
        [ResponseType(typeof(TrainingCourse))]
        public async Task<IHttpActionResult> DeleteTrainingCourse(int id)
        {
            
            TrainingCourse trainingCourse = await oTrainingCourseRepo.DeleteFromDB(id);
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