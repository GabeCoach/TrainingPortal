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
    [EnableCors(origins: "https://www.mgctrainingportal.com,http://localhost:4200,https://www.mgctrainingportal.com", headers: "*", methods: "*")]
    [Authorize]
    public class TrainingCourseModuleQuizsController : ApiController
    {
        DB_A35BD0_trainingportaldbEntities db = new DB_A35BD0_trainingportaldbEntities();
        private TrainingCourseModuleQuizsRepository oTrainingCourseModuleQuizRepo = new TrainingCourseModuleQuizsRepository();

        // GET: api/TrainingCourseModuleQuizs
        public IHttpActionResult GetTrainingCourseModuleQuizs()
        {
            return Json(oTrainingCourseModuleQuizRepo.SelectAllFromDB());
        }

        // GET: api/TrainingCourseModuleQuizs/5
        [ResponseType(typeof(TrainingCourseModuleQuiz))]
        public async Task<IHttpActionResult> GetTrainingCourseModuleQuiz(int id)
        {
            TrainingCourseModuleQuiz trainingCourseModuleQuiz = await oTrainingCourseModuleQuizRepo.SelectById(id);
            if (trainingCourseModuleQuiz == null)
            {
                return NotFound();
            }

            return Ok(trainingCourseModuleQuiz);
        }

        [HttpGet]
        [Route("api/TrainingCourseModuleQuizs/{iTrainingCourseModuleId}/TrainingCourseModule")]
        public async Task<IHttpActionResult> GetQuizByTrainingCourseModule(int iTrainingCourseModuleId)
        {
            try
            {
                return Json(await oTrainingCourseModuleQuizRepo.SelectByTrainingCourseModule(iTrainingCourseModuleId));
            }
            catch(Exception ex)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("api/TrainingCourseModuleQuizs/{iTrainingCourseModuleId}/TrainingCourseModule")]
        public async Task<IHttpActionResult> GetModuleQuizByModule(int iTrainingCourseModuleId)
        {
            try
            {
                return Json(await oTrainingCourseModuleQuizRepo.SelectByCourseModule(iTrainingCourseModuleId));
            }
            catch(Exception ex)
            {
                return InternalServerError();
            } 
        }

        // PUT: api/TrainingCourseModuleQuizs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTrainingCourseModuleQuiz(int id, TrainingCourseModuleQuiz trainingCourseModuleQuiz)
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

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/TrainingCourseModuleQuizs
        [ResponseType(typeof(TrainingCourseModuleQuiz))]
        public async Task<IHttpActionResult> PostTrainingCourseModuleQuiz(TrainingCourseModuleQuiz trainingCourseModuleQuiz)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await oTrainingCourseModuleQuizRepo.SaveToDB(trainingCourseModuleQuiz);

            return CreatedAtRoute("DefaultApi", new { id = trainingCourseModuleQuiz.Id }, trainingCourseModuleQuiz);
        }

        // DELETE: api/TrainingCourseModuleQuizs/5
        [ResponseType(typeof(TrainingCourseModuleQuiz))]
        public async Task<IHttpActionResult> DeleteTrainingCourseModuleQuiz(int id)
        {
            TrainingCourseModuleQuiz trainingCourseModuleQuiz = await oTrainingCourseModuleQuizRepo.DeleteFromDB(id);
            if (trainingCourseModuleQuiz == null)
            {
                return NotFound();
            }

            return Ok(trainingCourseModuleQuiz);
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