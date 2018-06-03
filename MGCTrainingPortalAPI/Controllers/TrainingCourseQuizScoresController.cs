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
    public class TrainingCourseQuizScoresController : ApiController
    {
        private DB_A35BD0_trainingportaldbEntities db = new DB_A35BD0_trainingportaldbEntities();
        private TrainingCourseQuizScoreQuizScoresRepository oTrainingCourseQuizScoresRepo = new TrainingCourseQuizScoreQuizScoresRepository();

        // GET: api/TrainingCourseQuizScores
        public IHttpActionResult GetTrainingCourseQuizScores()
        {
            try
            {
                return Json(oTrainingCourseQuizScoresRepo.SelectAllFromDB());
            }
            catch(Exception ex)
            {
                return InternalServerError();
            }
            
        }

        // GET: api/TrainingCourseQuizScores/5
        [ResponseType(typeof(TrainingCourseQuizScore))]
        public async Task<IHttpActionResult> GetTrainingCourseQuizScore(int id)
        {
            try
            {
                return Json(await oTrainingCourseQuizScoresRepo.SelectById(id));
            }
            catch(Exception ex)
            {
                return InternalServerError();
            }
        }

        // PUT: api/TrainingCourseQuizScores/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTrainingCourseQuizScore(int id, TrainingCourseQuizScore trainingCourseQuizScore)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != trainingCourseQuizScore.Id)
                {
                    return BadRequest();
                }

                await oTrainingCourseQuizScoresRepo.UpdateToDB(trainingCourseQuizScore, id);

                return StatusCode(HttpStatusCode.NoContent);
            }
            catch(Exception ex)
            {
                return InternalServerError();
            }
        }

        // POST: api/TrainingCourseQuizScores
        [ResponseType(typeof(TrainingCourseQuizScore))]
        public async Task<IHttpActionResult> PostTrainingCourseQuizScore(TrainingCourseQuizScore trainingCourseQuizScore)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await oTrainingCourseQuizScoresRepo.SaveToDB(trainingCourseQuizScore);

                return CreatedAtRoute("DefaultApi", new { id = trainingCourseQuizScore.Id }, trainingCourseQuizScore);
            }
            catch(Exception ex)
            {
                return InternalServerError();
            }
        }

        // DELETE: api/TrainingCourseQuizScores/5
        [ResponseType(typeof(TrainingCourseQuizScore))]
        public async Task<IHttpActionResult> DeleteTrainingCourseQuizScore(int id)
        {
            try
            {
                return Ok(oTrainingCourseQuizScoresRepo.DeleteFromDB(id));
            }
            catch(Exception ex)
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

        private bool TrainingCourseQuizScoreExists(int id)
        {
            return db.TrainingCourseQuizScores.Count(e => e.Id == id) > 0;
        }
    }
}