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
    public class TrainingCourseModulesController : ApiController
    {
        private DB_A35BD0_trainingportaldbEntities db = new DB_A35BD0_trainingportaldbEntities();
        private TrainingCourseModuleRepository oTrainingCourseModuleRepo = new TrainingCourseModuleRepository();
        private Logger.Logger oLogger = new Logger.Logger();

        // GET: api/TrainingCourseModules
        public IHttpActionResult GetTrainingCourseModules()
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
            {
                oLogger.LogData("ROUTE: api/TrainingCourseModules; METHOD: GET; IP_ADDRESS: " + sIPAddress);
                return Json(oTrainingCourseModuleRepo.SelectAllFromDB());
            }
            catch(Exception ex)
            {
                oLogger.LogData("ROUTE: api/TrainingCourseModules; METHOD: GET; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
                return InternalServerError();
            }
            
        }

        // GET: api/TrainingCourseModules/5
        [ResponseType(typeof(TrainingCourseModule))]
        public async Task<IHttpActionResult> GetTrainingCourseModule(int id)
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
            {
                TrainingCourseModule trainingCourseModule = await oTrainingCourseModuleRepo.SelectById(id);
                if (trainingCourseModule == null)
                {
                    return NotFound();
                }

                oLogger.LogData("ROUTE: api/TrainingCourseModules/{id}; METHOD: GET; IP_ADDRESS: " + sIPAddress);

                return Ok(trainingCourseModule);
            }
            catch(Exception ex)
            {
                oLogger.LogData("ROUTE: api/TrainingCourseModules/{id}; METHOD: GET; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
                return InternalServerError();
            }

        }

        [HttpGet]
        [Route("api/TrainingCourseModules/{iTrainingCourseId}/Modules")]
        public async Task<IHttpActionResult> GetModulesByTrainingCourse(int iTrainingCourseId)
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
            {
                oLogger.LogData("ROUTE: api/TrainingCourseModules/{iTrainingCourseId}/Modules; METHOD: GET; IP_ADDRESS: " + sIPAddress);
                return Json(await oTrainingCourseModuleRepo.SelectByTrainingCourse(iTrainingCourseId));
            }
            catch(Exception ex)
            {
                oLogger.LogData("ROUTE: api/TrainingCourseModules/{iTrainingCourseId}/Modules; METHOD: GET; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
                return InternalServerError();
            }
        }

        // PUT: api/TrainingCourseModules/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTrainingCourseModule(int id, TrainingCourseModule trainingCourseModule)
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress; 

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != trainingCourseModule.Id)
                {
                    return BadRequest();
                }

                await oTrainingCourseModuleRepo.UpdateToDB(trainingCourseModule, id);

                oLogger.LogData("ROUTE: api/TrainingCourseModules/{id}; METHOD: PUT; IP_ADDRESS: " + sIPAddress);

                return StatusCode(HttpStatusCode.NoContent);
            }
            catch(Exception ex)
            {
                oLogger.LogData("ROUTE: api/TrainingCourseModules/{id}; METHOD: PUT; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
                return InternalServerError();
            }
        }

        // POST: api/TrainingCourseModules
        [ResponseType(typeof(TrainingCourseModule))]
        public async Task<IHttpActionResult> PostTrainingCourseModule(TrainingCourseModule trainingCourseModule)
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await oTrainingCourseModuleRepo.SaveToDB(trainingCourseModule);

                oLogger.LogData("ROUTE: api/TrainingCourseModules; METHOD: POST; IP_ADDRESS: " + sIPAddress);

                return CreatedAtRoute("DefaultApi", new { id = trainingCourseModule.Id }, trainingCourseModule);
            }
            catch(Exception ex)
            {
                oLogger.LogData("ROUTE: api/TrainingCourseModules; METHOD: POST; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
                return InternalServerError();
            }
        }

        // DELETE: api/TrainingCourseModules/5
        [ResponseType(typeof(TrainingCourseModule))]
        public async Task<IHttpActionResult> DeleteTrainingCourseModule(int id)
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
            {
                TrainingCourseModule trainingCourseModule = await oTrainingCourseModuleRepo.DeleteFromDB(id);
                if (trainingCourseModule == null)
                {
                    return NotFound();
                }

                await oTrainingCourseModuleRepo.DeleteFromDB(id);

                oLogger.LogData("ROUTE: api/TrainingCourseModules/{id}; METHOD: POST; IP_ADDRESS: " + sIPAddress);

                return Ok(trainingCourseModule);
            }
            catch(Exception ex)
            {
                oLogger.LogData("ROUTE: api/TrainingCourseModules/{id}; METHOD: POST; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
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

        private bool TrainingCourseModuleExists(int id)
        {
            return db.TrainingCourseModules.Count(e => e.Id == id) > 0;
        }
    }
}