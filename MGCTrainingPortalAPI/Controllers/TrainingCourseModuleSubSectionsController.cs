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

        // GET: api/TrainingCourseModuleSubSections
        public IHttpActionResult GetTrainingCourseModuleSubSections()
        {
            try
            {
                return Json(oTrainingCourseModuleSubSectionRepo.SelectAllFromDB());
            }
            catch(Exception ex)
            {
                return InternalServerError();
            }
            
        }

        // GET: api/TrainingCourseModuleSubSections/5
        [ResponseType(typeof(TrainingCourseModuleSubSection))]
        public async Task<IHttpActionResult> GetTrainingCourseModuleSubSection(int id)
        {
            try
            {
                return Json(await oTrainingCourseModuleSubSectionRepo.SelectById(id));
            }
            catch(Exception ex)
            {
                return InternalServerError();
            }
            
        }

        [HttpGet]
        [Route("api/TrainingCourseModuleSubSections/{iModuleSectionId}/TrainingCourseModuleSection")]
        public async Task<IHttpActionResult> getModuleSubSectionByModuleSection(int iModuleSectionId)
        {
            try
            {
                return Json(await oTrainingCourseModuleSubSectionRepo.SelectByTrainingCourseModuleSection(iModuleSectionId));
            }
            catch(Exception ex)
            {
                return InternalServerError();
            }
        }

        // PUT: api/TrainingCourseModuleSubSections/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTrainingCourseModuleSubSection(int id, TrainingCourseModuleSubSection trainingCourseModuleSubSection)
        {
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
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch(Exception ex)
            {
                return InternalServerError();
            }

            
        }

        // POST: api/TrainingCourseModuleSubSections
        [ResponseType(typeof(TrainingCourseModuleSubSection))]
        public async Task<IHttpActionResult> PostTrainingCourseModuleSubSection(TrainingCourseModuleSubSection trainingCourseModuleSubSection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await oTrainingCourseModuleSubSectionRepo.SaveToDB(trainingCourseModuleSubSection);

                return CreatedAtRoute("DefaultApi", new { id = trainingCourseModuleSubSection.Id }, trainingCourseModuleSubSection);
            }
            catch(Exception ex)
            {
                return InternalServerError();
            }

           
        }

        // DELETE: api/TrainingCourseModuleSubSections/5
        [ResponseType(typeof(TrainingCourseModuleSubSection))]
        public async Task<IHttpActionResult> DeleteTrainingCourseModuleSubSection(int id)
        {
            try
            {
                return Ok(await oTrainingCourseModuleSubSectionRepo.DeleteFromDB(id));
            }
            catch (Exception)
            {
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