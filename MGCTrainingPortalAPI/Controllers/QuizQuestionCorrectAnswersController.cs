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
    //[EnableCors(origins: "https://www.mgctrainingportal.com,http://localhost:4200,https://www.mgctrainingportal.com", headers: "*", methods: "*")]
    [Authorize]
    public class QuizQuestionCorrectAnswersController : ApiController
    {
        private DB_A35BD0_trainingportaldbEntities db = new DB_A35BD0_trainingportaldbEntities();
        private QuizQuestionCorrectAnswerRepository oQuizQuestionCorrectAnswerRepo = new QuizQuestionCorrectAnswerRepository();
        private Logger.Logger oLogger = new Logger.Logger();

        // GET: api/QuizQuestionCorrectAnswers
        public IHttpActionResult GetQuizQuestionCorrectAnswers()
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
            {
                oLogger.LogData("ROUTE: api/QuizQuestionCorrectAnswers; METHOD: GET; IP_ADDRESS: " + sIPAddress);
                return Json(oQuizQuestionCorrectAnswerRepo.SelectAllFromDB());
            }
            catch(Exception ex)
            {
                oLogger.LogData("ROUTE: api/QuizQuestionCorrectAnswers; METHOD: GET; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
                return InternalServerError();
            }
        }

        // GET: api/QuizQuestionCorrectAnswers/5
        [ResponseType(typeof(QuizQuestionCorrectAnswer))]
        public async Task<IHttpActionResult> GetQuizQuestionCorrectAnswer(int id)
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
            {
                QuizQuestionCorrectAnswer quizQuestionCorrectAnswer = await oQuizQuestionCorrectAnswerRepo.SelectById(id);
                if (quizQuestionCorrectAnswer == null)
                {
                    return NotFound();
                }

                oLogger.LogData("ROUTE: api/QuizQuestionCorrectAnswers; METHOD: GET; IP_ADDRESS: " + sIPAddress);

                return Ok(quizQuestionCorrectAnswer);
            }
            catch(Exception ex)
            {
                oLogger.LogData("ROUTE: api/QuizQuestionCorrectAnswers; METHOD: GET; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
                return InternalServerError();
            }
            
        }

        // PUT: api/QuizQuestionCorrectAnswers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutQuizQuestionCorrectAnswer(int id, QuizQuestionCorrectAnswer quizQuestionCorrectAnswer)
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != quizQuestionCorrectAnswer.Id)
                {
                    return BadRequest();
                }

                await oQuizQuestionCorrectAnswerRepo.UpdateToDB(quizQuestionCorrectAnswer, id);

                oLogger.LogData("ROUTE: api/QuizQuestionCorrectAnswers/{id}; METHOD: GET; IP_ADDRESS: " + sIPAddress);

                return StatusCode(HttpStatusCode.NoContent);
            }
            catch(Exception ex)
            {
                oLogger.LogData("ROUTE: api/QuizQuestionCorrectAnswers/{id}; METHOD: GET; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
                return InternalServerError();
            }

           
        }

        // POST: api/QuizQuestionCorrectAnswers
        [ResponseType(typeof(QuizQuestionCorrectAnswer))]
        public async Task<IHttpActionResult> PostQuizQuestionCorrectAnswer(QuizQuestionCorrectAnswer quizQuestionCorrectAnswer)
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await oQuizQuestionCorrectAnswerRepo.SaveToDB(quizQuestionCorrectAnswer);

                oLogger.LogData("ROUTE: api/QuizQuestionCorrectAnswers/; METHOD: POST; IP_ADDRESS: " + sIPAddress);

                return CreatedAtRoute("DefaultApi", new { id = quizQuestionCorrectAnswer.Id }, quizQuestionCorrectAnswer);
            }
            catch(Exception ex)
            {
                oLogger.LogData("ROUTE: api/QuizQuestionCorrectAnswers/; METHOD: POST; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
                return InternalServerError();
            }

            
        }

        // DELETE: api/QuizQuestionCorrectAnswers/5
        [ResponseType(typeof(QuizQuestionCorrectAnswer))]
        public async Task<IHttpActionResult> DeleteQuizQuestionCorrectAnswer(int id)
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
            {
                await oQuizQuestionCorrectAnswerRepo.DeleteFromDB(id);
                oLogger.LogData("ROUTE: api/QuizQuestionCorrectAnswers/{id}; METHOD: DELETE; IP_ADDRESS: " + sIPAddress);
                return Ok();
            }
            catch(Exception ex)
            {
                oLogger.LogData("ROUTE: api/QuizQuestionCorrectAnswers/{id}; METHOD: DELETE; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
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

        private bool QuizQuestionCorrectAnswerExists(int id)
        {
            return db.QuizQuestionCorrectAnswers.Count(e => e.Id == id) > 0;
        }
    }
}