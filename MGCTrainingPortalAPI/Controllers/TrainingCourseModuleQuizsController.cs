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
using MGCTrainingPortalAPI.Logger;

namespace MGCTrainingPortalAPI.Controllers
{
    [EnableCors(origins: "https://www.mgctrainingportal.com,http://localhost:4200,https://www.mgctrainingportal.com", headers: "*", methods: "*")]
    [Authorize]
    public class TrainingCourseModuleQuizsController : ApiController
    {
        DB_A35BD0_trainingportaldbEntities db = new DB_A35BD0_trainingportaldbEntities();
        private TrainingCourseModuleQuizsRepository oTrainingCourseModuleQuizRepo = new TrainingCourseModuleQuizsRepository();
        private Logger.Logger oLogger = new Logger.Logger();

        // GET: api/TrainingCourseModuleQuizs
        public IHttpActionResult GetTrainingCourseModuleQuizs()
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
            {
                oLogger.LogData("ROUTE: api/TrainingCourseModuleQuizs; METHOD: GET; IP_ADDRESS: " + sIPAddress);
                return Json(oTrainingCourseModuleQuizRepo.SelectAllFromDB());
            }
            catch(Exception ex)
            {
                oLogger.LogData("ROUTE: api/TrainingCourseModuleQuizs; METHOD: GET; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
                return InternalServerError();
            }
            
        }

        // GET: api/TrainingCourseModuleQuizs/5
        [ResponseType(typeof(TrainingCourseModuleQuiz))]
        public async Task<IHttpActionResult> GetTrainingCourseModuleQuiz(int id)
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
            {
                TrainingCourseModuleQuiz trainingCourseModuleQuiz = await oTrainingCourseModuleQuizRepo.SelectById(id);
                if (trainingCourseModuleQuiz == null)
                {
                    return NotFound();
                }

                oLogger.LogData("ROUTE: api/TrainingCourseModuleQuizs/{id}; METHOD: GET; IP_ADDRESS: " + sIPAddress);

                return Ok(trainingCourseModuleQuiz);
            }
            catch(Exception ex)
            {
                oLogger.LogData("ROUTE: api/TrainingCourseModuleQuizs/{id}; METHOD: GET; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
                return InternalServerError();
            }
            
        }

        [HttpGet]
        [Route("api/TrainingCourseModuleQuizs/{iTrainingCourseModuleId}/TrainingCourseModule")]
        public async Task<IHttpActionResult> GetQuizByTrainingCourseModule(int iTrainingCourseModuleId)
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
            {
                oLogger.LogData("ROUTE: api/TrainingCourseModuleQuizs/{iTrainingCourseModuleId}/TrainingCourseModule; METHOD: GET; IP_ADDRESS: " + sIPAddress);
                return Json(await oTrainingCourseModuleQuizRepo.SelectByTrainingCourseModule(iTrainingCourseModuleId));
            }
            catch(Exception ex)
            {
                oLogger.LogData("ROUTE: api/TrainingCourseModuleQuizs/{iTrainingCourseModuleId}/TrainingCourseModule; METHOD: GET; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
                return InternalServerError();
            }
        }

        // PUT: api/TrainingCourseModuleQuizs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTrainingCourseModuleQuiz(int id, TrainingCourseModuleQuiz trainingCourseModuleQuiz)
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != trainingCourseModuleQuiz.Id)
                {
                    return BadRequest();
                }

                await oTrainingCourseModuleQuizRepo.UpdateToDB(trainingCourseModuleQuiz, id);

                oLogger.LogData("ROUTE: api/TrainingCourseModuleQuizs/{id}; METHOD: PUT; IP_ADDRESS: " + sIPAddress);

                return StatusCode(HttpStatusCode.NoContent);
            }
            catch(Exception ex)
            {
                oLogger.LogData("ROUTE: api/TrainingCourseModuleQuizs/{id}; METHOD: PUT; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
                return InternalServerError();
            }
            
        }

        // POST: api/TrainingCourseModuleQuizs
        [ResponseType(typeof(TrainingCourseModuleQuiz))]
        public async Task<IHttpActionResult> PostTrainingCourseModuleQuiz(TrainingCourseModuleQuiz trainingCourseModuleQuiz)
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await oTrainingCourseModuleQuizRepo.SaveToDB(trainingCourseModuleQuiz);

                oLogger.LogData("ROUTE: api/TrainingCourseModuleQuizs; METHOD: POST; IP_ADDRESS: " + sIPAddress);

                return CreatedAtRoute("DefaultApi", new { id = trainingCourseModuleQuiz.Id }, trainingCourseModuleQuiz);
            }
            catch(Exception ex)
            {
                oLogger.LogData("ROUTE: api/TrainingCourseModuleQuizs; METHOD: POST; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
                return InternalServerError();
            }
           
        }

        // DELETE: api/TrainingCourseModuleQuizs/5
        [ResponseType(typeof(TrainingCourseModuleQuiz))]
        public async Task<IHttpActionResult> DeleteTrainingCourseModuleQuiz(int id)
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
            {
                TrainingCourseModuleQuiz trainingCourseModuleQuiz = await oTrainingCourseModuleQuizRepo.DeleteFromDB(id);
                if (trainingCourseModuleQuiz == null)
                {
                    return NotFound();
                }

                oLogger.LogData("ROUTE: api/TrainingCourseModuleQuizs/{id}; METHOD: DELETE; IP_ADDRESS: " + sIPAddress);

                return Ok(trainingCourseModuleQuiz); 
            }
            catch(Exception ex)
            {
                oLogger.LogData("ROUTE: api/TrainingCourseModuleQuizs/{id}; METHOD: DELETE; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
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

        private bool TrainingCourseModuleQuizExists(int id)
        {
            return db.TrainingCourseModuleQuizs.Count(e => e.Id == id) > 0;
        }
    }
}