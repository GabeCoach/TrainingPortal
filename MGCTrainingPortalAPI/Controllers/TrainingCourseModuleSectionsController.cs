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
    [EnableCors(origins: "https://www.mgctrainingportal.com, http://localhost:4200", headers: "*", methods: "*")]
    [Authorize]
    public class TrainingCourseModuleSectionsController : ApiController
    {
        private DB_A35BD0_trainingportaldbEntities db = new DB_A35BD0_trainingportaldbEntities();
        private TrainingCourseModuleSectionsRepository oTrainingCourseModuleSectionsRepo = new TrainingCourseModuleSectionsRepository();

        // GET: api/TrainingCourseModuleSections
        public IHttpActionResult GetTrainingCourseModuleSections()
        {
            return Json(oTrainingCourseModuleSectionsRepo.SelectAllFromDB());
        }

        // GET: api/TrainingCourseModuleSections/5
        [ResponseType(typeof(TrainingCourseModuleSection))]
        public async Task<IHttpActionResult> GetTrainingCourseModuleSection(int id)
        {
            TrainingCourseModuleSection trainingCourseModuleSection = await oTrainingCourseModuleSectionsRepo.SelectById(id);
            if (trainingCourseModuleSection == null)
            {
                return NotFound();
            }

            return Ok(trainingCourseModuleSection);
        }

        [HttpGet]
        [Route("api/TrainingCourseModuleSections/{iTrainingCourseModuleId}/TrainingCourseModule")]
        public async Task<IHttpActionResult> GetSectionByModule(int iTrainingCourseModuleId)
        {
            try
            {
                return Json(await oTrainingCourseModuleSectionsRepo.SelectByTrainingCourseModule(iTrainingCourseModuleId));
            }
            catch(Exception ex)
            {
                return InternalServerError();
            }
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

            await oTrainingCourseModuleSectionsRepo.UpdateToDB(trainingCourseModuleSection, id);

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

            await oTrainingCourseModuleSectionsRepo.SaveToDB(trainingCourseModuleSection);

            return CreatedAtRoute("DefaultApi", new { id = trainingCourseModuleSection.Id }, trainingCourseModuleSection);
        }

        // DELETE: api/TrainingCourseModuleSections/5
        [ResponseType(typeof(TrainingCourseModuleSection))]
        public async Task<IHttpActionResult> DeleteTrainingCourseModuleSection(int id)
        {
            await oTrainingCourseModuleSectionsRepo.DeleteFromDB(id);
            return Ok();
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