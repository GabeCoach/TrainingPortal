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
    public class TrainingCourseModuleSubSectionsController : ApiController
    {
        private DB_A35BD0_trainingportaldbEntities db = new DB_A35BD0_trainingportaldbEntities();
        private TrainingCourseModuleSubSectionRepository oTrainingCourseModuleSubSectionRepo = new TrainingCourseModuleSubSectionRepository();
        private Logger.Logger oLogger = new Logger.Logger();

        // GET: api/TrainingCourseModuleSubSections
        public IHttpActionResult GetTrainingCourseModuleSubSections()
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
            {
                oLogger.LogData("ROUTE: api/TrainingCourseModuleSubSections; METHOD: GET; IP_ADDRESS: " + sIPAddress);
                return Json(oTrainingCourseModuleSubSectionRepo.SelectAllFromDB());
            }
            catch(Exception ex)
            {
                oLogger.LogData("ROUTE: api/TrainingCourseModuleSubSections; METHOD: GET; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
                return InternalServerError();
            }
            
        }

        // GET: api/TrainingCourseModuleSubSections/5
        [ResponseType(typeof(TrainingCourseModuleSubSection))]
        public async Task<IHttpActionResult> GetTrainingCourseModuleSubSection(int id)
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
            {
                oLogger.LogData("ROUTE: api/TrainingCourseModuleSubSections/{id}; METHOD: GET; IP_ADDRESS: " + sIPAddress);
                return Json(await oTrainingCourseModuleSubSectionRepo.SelectById(id));
            }
            catch(Exception ex)
            {
                oLogger.LogData("ROUTE: api/TrainingCourseModuleSubSections/{id}; METHOD: GET; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
                return InternalServerError();
            }
            
        }

        [HttpGet]
        [Route("api/TrainingCourseModuleSubSections/{iModuleSectionId}/TrainingCourseModuleSection")]
        public async Task<IHttpActionResult> getModuleSubSectionByModuleSection(int iModuleSectionId)
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
            {
                oLogger.LogData("ROUTE: api/TrainingCourseModuleSubSections/{iModuleSectionId}/TrainingCourseModuleSection; METHOD: GET; IP_ADDRESS: " + sIPAddress);
                return Json(await oTrainingCourseModuleSubSectionRepo.SelectByTrainingCourseModuleSection(iModuleSectionId));
            }
            catch(Exception ex)
            {
                oLogger.LogData("ROUTE: api/TrainingCourseModuleSubSections/{iModuleSectionId}/TrainingCourseModuleSection; METHOD: GET; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
                return InternalServerError();
            }
        }

        // PUT: api/TrainingCourseModuleSubSections/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTrainingCourseModuleSubSection(int id, TrainingCourseModuleSubSection trainingCourseModuleSubSection)
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != trainingCourseModuleSubSection.Id)
                {
                    return BadRequest();
                }

                await oTrainingCourseModuleSubSectionRepo.UpdateToDB(trainingCourseModuleSubSection, id);
                oLogger.LogData("ROUTE: api/TrainingCourseModuleSubSections/{id}; METHOD: PUT; IP_ADDRESS: " + sIPAddress);
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch(Exception ex)
            {
                oLogger.LogData("ROUTE: api/TrainingCourseModuleSubSections/{id}; METHOD: PUT; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
                return InternalServerError();
            }

            
        }

        // POST: api/TrainingCourseModuleSubSections
        [ResponseType(typeof(TrainingCourseModuleSubSection))]
        public async Task<IHttpActionResult> PostTrainingCourseModuleSubSection(TrainingCourseModuleSubSection trainingCourseModuleSubSection)
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await oTrainingCourseModuleSubSectionRepo.SaveToDB(trainingCourseModuleSubSection);

                oLogger.LogData("ROUTE: api/TrainingCourseModuleSubSections; METHOD: POST; IP_ADDRESS: " + sIPAddress);

                return CreatedAtRoute("DefaultApi", new { id = trainingCourseModuleSubSection.Id }, trainingCourseModuleSubSection);
            }
            catch(Exception ex)
            {
                oLogger.LogData("ROUTE: api/TrainingCourseModuleSubSections; METHOD: POST; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
                return InternalServerError();
            }

           
        }

        // DELETE: api/TrainingCourseModuleSubSections/5
        [ResponseType(typeof(TrainingCourseModuleSubSection))]
        public async Task<IHttpActionResult> DeleteTrainingCourseModuleSubSection(int id)
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
            {
                oLogger.LogData("ROUTE: api/TrainingCourseModuleSubSections; METHOD: DELETE; IP_ADDRESS: " + sIPAddress);
                return Ok(await oTrainingCourseModuleSubSectionRepo.DeleteFromDB(id));
            }
            catch (Exception)
            {
                oLogger.LogData("ROUTE: api/TrainingCourseModuleSubSections; METHOD: DELETE; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
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

        private bool TrainingCourseModuleSubSectionExists(int id)
        {
            return db.TrainingCourseModuleSubSections.Count(e => e.Id == id) > 0;
        }
    }
}