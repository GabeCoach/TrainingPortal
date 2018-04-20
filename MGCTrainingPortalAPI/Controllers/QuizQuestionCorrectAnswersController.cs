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

namespace MGCTrainingPortalAPI.Controllers
{
    public class QuizQuestionCorrectAnswersController : ApiController
    {
        private DB_A35BD0_trainingportaldbEntities db = new DB_A35BD0_trainingportaldbEntities();

        // GET: api/QuizQuestionCorrectAnswers
        public IQueryable<QuizQuestionCorrectAnswer> GetQuizQuestionCorrectAnswers()
        {
            return db.QuizQuestionCorrectAnswers;
        }

        // GET: api/QuizQuestionCorrectAnswers/5
        [ResponseType(typeof(QuizQuestionCorrectAnswer))]
        public async Task<IHttpActionResult> GetQuizQuestionCorrectAnswer(int id)
        {
            QuizQuestionCorrectAnswer quizQuestionCorrectAnswer = await db.QuizQuestionCorrectAnswers.FindAsync(id);
            if (quizQuestionCorrectAnswer == null)
            {
                return NotFound();
            }

            return Ok(quizQuestionCorrectAnswer);
        }

        // PUT: api/QuizQuestionCorrectAnswers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutQuizQuestionCorrectAnswer(int id, QuizQuestionCorrectAnswer quizQuestionCorrectAnswer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != quizQuestionCorrectAnswer.Id)
            {
                return BadRequest();
            }

            db.Entry(quizQuestionCorrectAnswer).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuizQuestionCorrectAnswerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/QuizQuestionCorrectAnswers
        [ResponseType(typeof(QuizQuestionCorrectAnswer))]
        public async Task<IHttpActionResult> PostQuizQuestionCorrectAnswer(QuizQuestionCorrectAnswer quizQuestionCorrectAnswer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.QuizQuestionCorrectAnswers.Add(quizQuestionCorrectAnswer);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (QuizQuestionCorrectAnswerExists(quizQuestionCorrectAnswer.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = quizQuestionCorrectAnswer.Id }, quizQuestionCorrectAnswer);
        }

        // DELETE: api/QuizQuestionCorrectAnswers/5
        [ResponseType(typeof(QuizQuestionCorrectAnswer))]
        public async Task<IHttpActionResult> DeleteQuizQuestionCorrectAnswer(int id)
        {
            QuizQuestionCorrectAnswer quizQuestionCorrectAnswer = await db.QuizQuestionCorrectAnswers.FindAsync(id);
            if (quizQuestionCorrectAnswer == null)
            {
                return NotFound();
            }

            db.QuizQuestionCorrectAnswers.Remove(quizQuestionCorrectAnswer);
            await db.SaveChangesAsync();

            return Ok(quizQuestionCorrectAnswer);
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