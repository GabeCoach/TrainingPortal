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
using System.Web.Http.Description;
using MGCTrainingPortalAPI.Models;
using MGCTrainingPortalAPI.Repository;

namespace MGCTrainingPortalAPI.Controllers
{
    [Authorize]
    public class QuizQuestionCorrectAnswersController : ApiController
    {
        private DB_A35BD0_trainingportaldbEntities db = new DB_A35BD0_trainingportaldbEntities();
        private QuizQuestionCorrectAnswerRepository oQuizQuestionCorrectAnswerRepo = new QuizQuestionCorrectAnswerRepository();

        // GET: api/QuizQuestionCorrectAnswers
        public IHttpActionResult GetQuizQuestionCorrectAnswers()
        {
            try
            {
                return Json(oQuizQuestionCorrectAnswerRepo.SelectAllFromDB());
            }
            catch(Exception ex)
            {
                return InternalServerError();
            }
        }

        // GET: api/QuizQuestionCorrectAnswers/5
        [ResponseType(typeof(QuizQuestionCorrectAnswer))]
        public async Task<IHttpActionResult> GetQuizQuestionCorrectAnswer(int id)
        {

            try
            {
                QuizQuestionCorrectAnswer quizQuestionCorrectAnswer = await oQuizQuestionCorrectAnswerRepo.SelectById(id);
                if (quizQuestionCorrectAnswer == null)
                {
                    return NotFound();
                }

                return Ok(quizQuestionCorrectAnswer);
            }
            catch(Exception ex)
            {
                return InternalServerError();
            }
            
        }

        // PUT: api/QuizQuestionCorrectAnswers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutQuizQuestionCorrectAnswer(int id, QuizQuestionCorrectAnswer quizQuestionCorrectAnswer)
        {
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

                return StatusCode(HttpStatusCode.NoContent);
            }
            catch(Exception ex)
            {
                return InternalServerError();
            }

           
        }

        // POST: api/QuizQuestionCorrectAnswers
        [ResponseType(typeof(QuizQuestionCorrectAnswer))]
        public async Task<IHttpActionResult> PostQuizQuestionCorrectAnswer(QuizQuestionCorrectAnswer quizQuestionCorrectAnswer)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await oQuizQuestionCorrectAnswerRepo.SaveToDB(quizQuestionCorrectAnswer);

                return CreatedAtRoute("DefaultApi", new { id = quizQuestionCorrectAnswer.Id }, quizQuestionCorrectAnswer);
            }
            catch(Exception ex)
            {
                return InternalServerError();
            }

            
        }

        // DELETE: api/QuizQuestionCorrectAnswers/5
        [ResponseType(typeof(QuizQuestionCorrectAnswer))]
        public async Task<IHttpActionResult> DeleteQuizQuestionCorrectAnswer(int id)
        {
            try
            {
                await oQuizQuestionCorrectAnswerRepo.DeleteFromDB(id);
                return Ok();
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

        private bool QuizQuestionCorrectAnswerExists(int id)
        {
            return db.QuizQuestionCorrectAnswers.Count(e => e.Id == id) > 0;
        }
    }
}