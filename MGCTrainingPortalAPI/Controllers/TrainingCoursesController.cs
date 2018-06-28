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
    //[EnableCors(origins: "http://www.mgctrainingportal.com,http://localhost:4200,https://www.mgctrainingportal.com", headers: "*", methods: "*")]
    [Authorize]
    public class TrainingCoursesController : ApiController
    {
        private DB_A35BD0_trainingportaldbEntities db = new DB_A35BD0_trainingportaldbEntities();
        private TrainingCoursesRepository oTrainingCourseRepo = new TrainingCoursesRepository();
        private Logger.Logger oLogger = new Logger.Logger();

        // GET: api/TrainingCourses
        public IHttpActionResult GetTrainingCourses()
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
            {
                oLogger.LogData("ROUTE: api/TrainingCourses; METHOD: GET; IP_ADDRESS: " + sIPAddress);
                return Json(oTrainingCourseRepo.SelectAllFromDB());
            }
            catch(Exception ex)
            {
                oLogger.LogData("ROUTE: api/TrainingCourses; METHOD: GET; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
                return InternalServerError();
            }
            
        }

        // GET: api/TrainingCourses/5
        [ResponseType(typeof(TrainingCourse))]
        public async Task<IHttpActionResult> GetTrainingCourse(int id)
        {

            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
            {
                TrainingCourse trainingCourse = await oTrainingCourseRepo.SelectById(id);
                if (trainingCourse == null)
                {
                    return NotFound();
                }

                oLogger.LogData("ROUTE: api/TrainingCourses/{id}; METHOD: GET; IP_ADDRESS: " + sIPAddress);

                return Ok(trainingCourse);
            }
            catch(Exception ex)
            {
                oLogger.LogData("ROUTE: api/TrainingCourses/{id}; METHOD: GET; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
                return InternalServerError();
            }
           
        }

        // PUT: api/TrainingCourses/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTrainingCourse(int id, TrainingCourse trainingCourse)
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
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

                oLogger.LogData("ROUTE: api/TrainingCourses/{id}; METHOD: PUT; IP_ADDRESS: " + sIPAddress);

                return StatusCode(HttpStatusCode.NoContent);
            }
            catch(Exception ex)
            {
                oLogger.LogData("ROUTE: api/TrainingCourses/{id}; METHOD: PUT; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
                return InternalServerError();
            }
        }

        // POST: api/TrainingCourses
        [ResponseType(typeof(TrainingCourse))]
        public async Task<IHttpActionResult> PostTrainingCourse(TrainingCourse trainingCourse)
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await oTrainingCourseRepo.SaveToDB(trainingCourse);

                oLogger.LogData("ROUTE: api/TrainingCourses; METHOD: POST; IP_ADDRESS: " + sIPAddress);

                return CreatedAtRoute("DefaultApi", new { id = trainingCourse.Id }, trainingCourse);
            }
            catch(Exception ex)
            {
                oLogger.LogData("ROUTE: api/TrainingCourses; METHOD: POST; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
                return InternalServerError();
            }

        }

        // DELETE: api/TrainingCourses/5
        [ResponseType(typeof(TrainingCourse))]
        public async Task<IHttpActionResult> DeleteTrainingCourse(int id)
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
            {
                TrainingCourse trainingCourse = await oTrainingCourseRepo.DeleteFromDB(id);
                oLogger.LogData("ROUTE: api/TrainingCourses; METHOD: DELETE; IP_ADDRESS: " + sIPAddress);
                return Ok(trainingCourse);
            }
            catch(Exception ex)
            {
                oLogger.LogData("ROUTE: api/TrainingCourses; METHOD: DELETE; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
                return InternalServerError();
            }

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