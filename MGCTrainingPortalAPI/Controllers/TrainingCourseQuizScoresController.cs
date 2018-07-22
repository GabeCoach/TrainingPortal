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
using MGCTrainingPortalAPI.QuizGrader.Models;
using MGCTrainingPortalAPI.Repository;
using MGCTrainingPortalAPI.QuizGrader;

namespace MGCTrainingPortalAPI.Controllers
{
    //[EnableCors(origins: "https://www.mgctrainingportal.com,http://localhost:4200,https://www.mgctrainingportal.com", headers: "*", methods: "*")]
    [Authorize]
    public class TrainingCourseQuizScoresController : ApiController
    {
        private DB_A35BD0_trainingportaldbEntities db = new DB_A35BD0_trainingportaldbEntities();
        private TrainingCourseQuizScoreQuizScoresRepository oTrainingCourseQuizScoresRepo = new TrainingCourseQuizScoreQuizScoresRepository();
        private QuizGrader.QuizGrader oQuizGrader = new QuizGrader.QuizGrader();
        private Logger.Logger oLogger = new Logger.Logger();

        // GET: api/TrainingCourseQuizScores
        public IHttpActionResult GetTrainingCourseQuizScores()
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
            {
                oLogger.LogData("ROUTE: api/TrainingCourseQuizScores; METHOD: GET; IP_ADDRESS: " + sIPAddress);
                return Json(oTrainingCourseQuizScoresRepo.SelectAllFromDB());
            }
            catch(Exception ex)
            {
                oLogger.LogData("ROUTE: api/TrainingCourseQuizScores; METHOD: GET; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
                return InternalServerError();
            }
            
        }

        // GET: api/TrainingCourseQuizScores/5
        [ResponseType(typeof(TrainingCourseQuizScore))]
        public async Task<IHttpActionResult> GetTrainingCourseQuizScore(int id)
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
            {
                oLogger.LogData("ROUTE: api/TrainingCourseQuizScores/{id}; METHOD: GET; IP_ADDRESS: " + sIPAddress);
                return Json(await oTrainingCourseQuizScoresRepo.SelectById(id));
            }
            catch(Exception ex)
            {
                oLogger.LogData("ROUTE: api/TrainingCourseQuizScores/{id}; METHOD: GET; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("api/TrainingCourseQuizScores/{iUserId}/User")]
        public async Task<IHttpActionResult> GetScoresByUser(int iUserId)
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
            {
                oLogger.LogData("ROUTE: api/TrainingCourseQuizScores/{iUserId}/User; METHOD: GET; IP_ADDRESS: " + sIPAddress);
                return Json(await oTrainingCourseQuizScoresRepo.SelectByUserId(iUserId));
            }
            catch(Exception ex)
            {
                oLogger.LogData("ROUTE: api/TrainingCourseQuizScores/{iUserId}/User; METHOD: GET; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
                return InternalServerError();
            }
        }

        // PUT: api/TrainingCourseQuizScores/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTrainingCourseQuizScore(int id, TrainingCourseQuizScore trainingCourseQuizScore)
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

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

                oLogger.LogData("ROUTE: api/TrainingCourseQuizScores/{id}; METHOD: PUT; IP_ADDRESS: " + sIPAddress);

                return StatusCode(HttpStatusCode.NoContent);
            }
            catch(Exception ex)
            {
                oLogger.LogData("ROUTE: api/TrainingCourseQuizScores/{id}; METHOD: PUT; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("api/TrainingCourseQuizScores/QuizGrade")]
        public async Task<IHttpActionResult> GradeTrainingCourseQuiz(List<QuizUserSelectedAnswer> lstSelectedAnswers)
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
            {
                oLogger.LogData("ROUTE: api/TrainingCourseQuizScores/QuizGrade; METHOD: POST; IP_ADDRESS: " + sIPAddress);
                return Json(await oQuizGrader.GradeQuiz(lstSelectedAnswers));
            }
            catch(Exception ex)
            {
                oLogger.LogData("ROUTE: api/TrainingCourseQuizScores/QuizGrade; METHOD: POST; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
                return InternalServerError();
            }
            
        }

        // POST: api/TrainingCourseQuizScores
        [ResponseType(typeof(TrainingCourseQuizScore))]
        public async Task<IHttpActionResult> PostTrainingCourseQuizScore(TrainingCourseQuizScore trainingCourseQuizScore)
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await oTrainingCourseQuizScoresRepo.SaveToDB(trainingCourseQuizScore);

                oLogger.LogData("ROUTE: api/TrainingCourseQuizScores; METHOD: POST; IP_ADDRESS: " + sIPAddress);

                return CreatedAtRoute("DefaultApi", new { id = trainingCourseQuizScore.Id }, trainingCourseQuizScore);
            }
            catch(Exception ex)
            {
                oLogger.LogData("ROUTE: api/TrainingCourseQuizScores; METHOD: POST; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
                return InternalServerError();
            }
        }

        // DELETE: api/TrainingCourseQuizScores/5
        [ResponseType(typeof(TrainingCourseQuizScore))]
        public async Task<IHttpActionResult> DeleteTrainingCourseQuizScore(int id)
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
            {
                oLogger.LogData("ROUTE: api/TrainingCourseQuizScores/{id}; METHOD: DELETE; IP_ADDRESS: " + sIPAddress);
                return Ok(oTrainingCourseQuizScoresRepo.DeleteFromDB(id));
            }
            catch(Exception ex)
            {
                oLogger.LogData("ROUTE: api/TrainingCourseQuizScores/{id}; METHOD: DELETE; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
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