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
    [EnableCors(origins: "https://www.mgctrainingportal.com,http://localhost:4200,https://www.mgctrainingportal.com", headers: "*", methods: "*")]
    [Authorize]
    public class QuizQuestionsController : ApiController
    {
        private DB_A35BD0_trainingportaldbEntities db = new DB_A35BD0_trainingportaldbEntities();
        private QuizQuestionsRepository oQuizQuestionRepo = new QuizQuestionsRepository();
        private Logger.Logger oLogger = new Logger.Logger();

        // GET: api/QuizQuestions
        public IHttpActionResult GetQuizQuestions()
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
            {
                oLogger.LogData("ROUTE: api/QuizQuestions; METHOD: GET; IP_ADDRESS: " + sIPAddress);
                return Json(oQuizQuestionRepo.SelectAllFromDB());
            }
            catch(Exception ex)
            {
                oLogger.LogData("ROUTE: api/QuizQuestions; METHOD: GET; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
                return InternalServerError();
            }
        }

        // GET: api/QuizQuestions/5
        [ResponseType(typeof(QuizQuestion))]
        public async Task<IHttpActionResult> GetQuizQuestion(int id)
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
            {
                QuizQuestion quizQuestion = await oQuizQuestionRepo.SelectById(id);
                if (quizQuestion == null)
                {
                    return NotFound();
                }

                oLogger.LogData("ROUTE: api/QuizQuestions/{id}; METHOD: GET; IP_ADDRESS: " + sIPAddress);

                return Ok(quizQuestion);
            }
            catch(Exception ex)
            {
                oLogger.LogData("ROUTE: api/QuizQuestions/{id}; METHOD: GET; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
                return InternalServerError();
            }
           
        }

        [HttpGet]
        [Route("api/QuizQuestions/{iModuleQuizId}/TrainingCourseModuleQuiz")]
        public async Task<IHttpActionResult> GetQuizQuestionsByQuizId(int iModuleQuizId)
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
            {
                oLogger.LogData("ROUTE: api/QuizQuestions/{iModuleQuizId}/TrainingCourseModuleQuiz; METHOD: GET; IP_ADDRESS: " + sIPAddress);
                return Json(await oQuizQuestionRepo.SelectByCourseModuleQuiz(iModuleQuizId));
            }
            catch(Exception ex)
            {
                oLogger.LogData("ROUTE: api/QuizQuestions/{iModuleQuizId}/TrainingCourseModuleQuiz; METHOD: GET; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
                return InternalServerError();
            }
        }

        // PUT: api/QuizQuestions/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutQuizQuestion(int id, QuizQuestion quizQuestion)
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != quizQuestion.Id)
                {
                    return BadRequest();
                }

                await oQuizQuestionRepo.UpdateToDB(quizQuestion, id);

                oLogger.LogData("ROUTE: api/QuizQuestions/{id}; METHOD: PUT; IP_ADDRESS: " + sIPAddress);

                return StatusCode(HttpStatusCode.NoContent);
            }
            catch(Exception ex)
            {
                oLogger.LogData("ROUTE: api/QuizQuestions/{id}; METHOD: PUT; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
                return InternalServerError();
            }
            
        }

        // POST: api/QuizQuestions
        [ResponseType(typeof(QuizQuestion))]
        public async Task<IHttpActionResult> PostQuizQuestion(QuizQuestion quizQuestion)
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await oQuizQuestionRepo.SaveToDB(quizQuestion);

                oLogger.LogData("ROUTE: api/QuizQuestions/{id}; METHOD: PUT; IP_ADDRESS: " + sIPAddress);

                return CreatedAtRoute("DefaultApi", new { id = quizQuestion.Id }, quizQuestion);
            }
            catch(Exception ex)
            {
                oLogger.LogData("ROUTE: api/QuizQuestions/; METHOD: POST; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
                return InternalServerError();
            }
            
        }

        // DELETE: api/QuizQuestions/5
        [ResponseType(typeof(QuizQuestion))]
        public async Task<IHttpActionResult> DeleteQuizQuestion(int id)
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
            {
                QuizQuestion quizQuestion = await db.QuizQuestions.FindAsync(id);
                if (quizQuestion == null)
                {
                    return NotFound();
                }

                await oQuizQuestionRepo.DeleteFromDB(id);

                oLogger.LogData("ROUTE: api/QuizQuestions/{id}; METHOD: DELETE; IP_ADDRESS: " + sIPAddress);

                return Ok(quizQuestion);
            }
            catch(Exception ex)
            {
                oLogger.LogData("ROUTE: api/QuizQuestions/{id}; METHOD: DELETE; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
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

        private bool QuizQuestionExists(int id)
        {
            return db.QuizQuestions.Count(e => e.Id == id) > 0;
        }
    }
}