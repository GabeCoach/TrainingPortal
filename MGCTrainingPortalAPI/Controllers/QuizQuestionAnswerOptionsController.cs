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
    public class QuizQuestionAnswerOptionsController : ApiController
    {
        private DB_A35BD0_trainingportaldbEntities db = new DB_A35BD0_trainingportaldbEntities();

        // GET: api/QuizQuestionAnswerOptions
        public IQueryable<QuizQuestionAnswerOption> GetQuizQuestionAnswerOptions()
        {
            return db.QuizQuestionAnswerOptions;
        }

        // GET: api/QuizQuestionAnswerOptions/5
        [ResponseType(typeof(QuizQuestionAnswerOption))]
        public async Task<IHttpActionResult> GetQuizQuestionAnswerOption(int id)
        {
            QuizQuestionAnswerOption quizQuestionAnswerOption = await db.QuizQuestionAnswerOptions.FindAsync(id);
            if (quizQuestionAnswerOption == null)
            {
                return NotFound();
            }

            return Ok(quizQuestionAnswerOption);
        }

        // PUT: api/QuizQuestionAnswerOptions/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutQuizQuestionAnswerOption(int id, QuizQuestionAnswerOption quizQuestionAnswerOption)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != quizQuestionAnswerOption.Id)
            {
                return BadRequest();
            }

            db.Entry(quizQuestionAnswerOption).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuizQuestionAnswerOptionExists(id))
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

        // POST: api/QuizQuestionAnswerOptions
        [ResponseType(typeof(QuizQuestionAnswerOption))]
        public async Task<IHttpActionResult> PostQuizQuestionAnswerOption(QuizQuestionAnswerOption quizQuestionAnswerOption)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.QuizQuestionAnswerOptions.Add(quizQuestionAnswerOption);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = quizQuestionAnswerOption.Id }, quizQuestionAnswerOption);
        }

        // DELETE: api/QuizQuestionAnswerOptions/5
        [ResponseType(typeof(QuizQuestionAnswerOption))]
        public async Task<IHttpActionResult> DeleteQuizQuestionAnswerOption(int id)
        {
            QuizQuestionAnswerOption quizQuestionAnswerOption = await db.QuizQuestionAnswerOptions.FindAsync(id);
            if (quizQuestionAnswerOption == null)
            {
                return NotFound();
            }

            db.QuizQuestionAnswerOptions.Remove(quizQuestionAnswerOption);
            await db.SaveChangesAsync();

            return Ok(quizQuestionAnswerOption);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QuizQuestionAnswerOptionExists(int id)
        {
            return db.QuizQuestionAnswerOptions.Count(e => e.Id == id) > 0;
        }
    }
}