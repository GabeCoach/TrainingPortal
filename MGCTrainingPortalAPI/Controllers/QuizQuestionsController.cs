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
    public class QuizQuestionsController : ApiController
    {
        private DB_A35BD0_trainingportaldbEntities db = new DB_A35BD0_trainingportaldbEntities();
        private QuizQuestionsRepository oQuizQuestionRepo = new QuizQuestionsRepository();

        // GET: api/QuizQuestions
        public IHttpActionResult GetQuizQuestions()
        {
            return Json(oQuizQuestionRepo.SelectAllFromDB());
        }

        // GET: api/QuizQuestions/5
        [ResponseType(typeof(QuizQuestion))]
        public async Task<IHttpActionResult> GetQuizQuestion(int id)
        {
            QuizQuestion quizQuestion = await oQuizQuestionRepo.SelectById(id);
            if (quizQuestion == null)
            {
                return NotFound();
            }

            return Ok(quizQuestion);
        }

        // PUT: api/QuizQuestions/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutQuizQuestion(int id, QuizQuestion quizQuestion)
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

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/QuizQuestions
        [ResponseType(typeof(QuizQuestion))]
        public async Task<IHttpActionResult> PostQuizQuestion(QuizQuestion quizQuestion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await oQuizQuestionRepo.SaveToDB(quizQuestion);

            return CreatedAtRoute("DefaultApi", new { id = quizQuestion.Id }, quizQuestion);
        }

        // DELETE: api/QuizQuestions/5
        [ResponseType(typeof(QuizQuestion))]
        public async Task<IHttpActionResult> DeleteQuizQuestion(int id)
        {
            QuizQuestion quizQuestion = await db.QuizQuestions.FindAsync(id);
            if (quizQuestion == null)
            {
                return NotFound();
            }

            await oQuizQuestionRepo.DeleteFromDB(id);

            return Ok(quizQuestion);
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