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
    public class TrainingCourseModulesController : ApiController
    {
        private DB_A35BD0_trainingportaldbEntities db = new DB_A35BD0_trainingportaldbEntities();
        private TrainingCourseModuleRepository oTrainingCourseModuleRepo = new TrainingCourseModuleRepository();

        // GET: api/TrainingCourseModules
        public IHttpActionResult GetTrainingCourseModules()
        {
            return Json(oTrainingCourseModuleRepo.SelectAllFromDB());
        }

        // GET: api/TrainingCourseModules/5
        [ResponseType(typeof(TrainingCourseModule))]
        public async Task<IHttpActionResult> GetTrainingCourseModule(int id)
        {
            TrainingCourseModule trainingCourseModule = await oTrainingCourseModuleRepo.SelectById(id);
            if (trainingCourseModule == null)
            {
                return NotFound();
            }

            return Ok(trainingCourseModule);
        }

        [HttpGet]
        [Route("api/TrainingCourseModules/{iTrainingCourseId}/Modules")]
        public async Task<IHttpActionResult> GetModulesByTrainingCourse(int iTrainingCourseId)
        {
            try
            {
                return Json(await oTrainingCourseModuleRepo.SelectByTrainingCourse(iTrainingCourseId));
            }
            catch(Exception ex)
            {
                return InternalServerError();
            }
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

            await oTrainingCourseModuleRepo.UpdateToDB(trainingCourseModule, id);

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

            await oTrainingCourseModuleRepo.SaveToDB(trainingCourseModule);

            return CreatedAtRoute("DefaultApi", new { id = trainingCourseModule.Id }, trainingCourseModule);
        }

        // DELETE: api/TrainingCourseModules/5
        [ResponseType(typeof(TrainingCourseModule))]
        public async Task<IHttpActionResult> DeleteTrainingCourseModule(int id)
        {
            TrainingCourseModule trainingCourseModule = await oTrainingCourseModuleRepo.DeleteFromDB(id);
            if (trainingCourseModule == null)
            {
                return NotFound();
            }

            await oTrainingCourseModuleRepo.DeleteFromDB(id);

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