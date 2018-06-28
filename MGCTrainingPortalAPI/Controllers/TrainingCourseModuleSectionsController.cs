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
    public class TrainingCourseModuleSectionsController : ApiController
    {
        private DB_A35BD0_trainingportaldbEntities db = new DB_A35BD0_trainingportaldbEntities();
        private TrainingCourseModuleSectionsRepository oTrainingCourseModuleSectionsRepo = new TrainingCourseModuleSectionsRepository();
        private Logger.Logger oLogger = new Logger.Logger();

        // GET: api/TrainingCourseModuleSections
        public IHttpActionResult GetTrainingCourseModuleSections()
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
            {
                oLogger.LogData("ROUTE: api/TrainingCourseModuleSections; METHOD: GET; IP_ADDRESS: " + sIPAddress);
                return Json(oTrainingCourseModuleSectionsRepo.SelectAllFromDB());
            }
            catch(Exception ex)
            {
                oLogger.LogData("ROUTE: api/TrainingCourseModuleSections; METHOD: GET; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
                return InternalServerError();
            }
            
        }

        // GET: api/TrainingCourseModuleSections/5
        [ResponseType(typeof(TrainingCourseModuleSection))]
        public async Task<IHttpActionResult> GetTrainingCourseModuleSection(int id)
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
            {
                TrainingCourseModuleSection trainingCourseModuleSection = await oTrainingCourseModuleSectionsRepo.SelectById(id);
                if (trainingCourseModuleSection == null)
                {
                    return NotFound();
                }

                oLogger.LogData("ROUTE: api/TrainingCourseModuleSections/{id}; METHOD: GET; IP_ADDRESS: " + sIPAddress);

                return Ok(trainingCourseModuleSection);
            }
            catch(Exception ex)
            {
                oLogger.LogData("ROUTE: api/TrainingCourseModuleSections/{id}; METHOD: GET; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
                return InternalServerError();
            }

        }

        [HttpGet]
        [Route("api/TrainingCourseModuleSections/{iTrainingCourseModuleId}/TrainingCourseModule")]
        public async Task<IHttpActionResult> GetSectionByModule(int iTrainingCourseModuleId)
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
            {
                oLogger.LogData("ROUTE: api/TrainingCourseModuleSections/{iTrainingCourseModuleId}/TrainingCourseModule; METHOD: GET; IP_ADDRESS: " + sIPAddress);
                return Json(await oTrainingCourseModuleSectionsRepo.SelectByTrainingCourseModule(iTrainingCourseModuleId));
            }
            catch(Exception ex)
            {
                oLogger.LogData("ROUTE: api/TrainingCourseModuleSections/{iTrainingCourseModuleId}/TrainingCourseModule; METHOD: GET; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
                return InternalServerError();
            }
        }

        // PUT: api/TrainingCourseModuleSections/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTrainingCourseModuleSection(int id, TrainingCourseModuleSection trainingCourseModuleSection)
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != trainingCourseModuleSection.Id)
                {
                    return BadRequest();
                }

                await oTrainingCourseModuleSectionsRepo.UpdateToDB(trainingCourseModuleSection, id);

                oLogger.LogData("ROUTE: api/TrainingCourseModuleSections/{id}; METHOD: PUT; IP_ADDRESS: " + sIPAddress);

                return StatusCode(HttpStatusCode.NoContent);
            }
            catch(Exception ex)
            {
                oLogger.LogData("ROUTE: api/TrainingCourseModuleSections/{id}; METHOD: PUT; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
                return InternalServerError();
            }

            
        }

        // POST: api/TrainingCourseModuleSections
        [ResponseType(typeof(TrainingCourseModuleSection))]
        public async Task<IHttpActionResult> PostTrainingCourseModuleSection(TrainingCourseModuleSection trainingCourseModuleSection)
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await oTrainingCourseModuleSectionsRepo.SaveToDB(trainingCourseModuleSection);

                oLogger.LogData("ROUTE: api/TrainingCourseModuleSections; METHOD: POST; IP_ADDRESS: " + sIPAddress);

                return CreatedAtRoute("DefaultApi", new { id = trainingCourseModuleSection.Id }, trainingCourseModuleSection);
            }
            catch (Exception ex)
            {
                oLogger.LogData("ROUTE: api/TrainingCourseModuleSections; METHOD: POST; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
                return InternalServerError();
            }
        }

        // DELETE: api/TrainingCourseModuleSections/5
        [ResponseType(typeof(TrainingCourseModuleSection))]
        public async Task<IHttpActionResult> DeleteTrainingCourseModuleSection(int id)
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
            {
                await oTrainingCourseModuleSectionsRepo.DeleteFromDB(id);
                oLogger.LogData("ROUTE: api/TrainingCourseModuleSections; METHOD: DELETE; IP_ADDRESS: " + sIPAddress);
                return Ok();
            }
            catch(Exception ex)
            {
                oLogger.LogData("ROUTE: api/TrainingCourseModuleSections; METHOD: DELETE; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
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

        private bool TrainingCourseModuleSectionExists(int id)
        {
            return db.TrainingCourseModuleSections.Count(e => e.Id == id) > 0;
        }
    }
}