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
    [EnableCors(origins: "https://www.mgctrainingportal.com,http://localhost:4200", headers: "*", methods: "*")]
    [Authorize]
    public class QuizQuestionAnswerOptionsController : ApiController
    {
        private DB_A35BD0_trainingportaldbEntities db = new DB_A35BD0_trainingportaldbEntities();
        private QuizQuestionAnswerOptionsRepository oQuizAnswerOptionsRepo = new QuizQuestionAnswerOptionsRepository();

        // GET: api/QuizQuestionAnswerOptions
        public IHttpActionResult GetQuizQuestionAnswerOptions()
        {
            return Json(oQuizAnswerOptionsRepo.SelectAllFromDB());
        }

        // GET: api/QuizQuestionAnswerOptions/5
        [ResponseType(typeof(QuizQuestionAnswerOption))]
        public async Task<IHttpActionResult> GetQuizQuestionAnswerOption(int id)
        {
            QuizQuestionAnswerOption quizQuestionAnswerOption = await oQuizAnswerOptionsRepo.SelectById(id);
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

            await oQuizAnswerOptionsRepo.UpdateToDB(quizQuestionAnswerOption, id);

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

            await oQuizAnswerOptionsRepo.SaveToDB(quizQuestionAnswerOption);

            return Ok();
        }

        // DELETE: api/QuizQuestionAnswerOptions/5
        [ResponseType(typeof(QuizQuestionAnswerOption))]
        public async Task<IHttpActionResult> DeleteQuizQuestionAnswerOption(int id)
        {
            QuizQuestionAnswerOption quizQuestionAnswerOption = await oQuizAnswerOptionsRepo.SelectById(id);
            if (quizQuestionAnswerOption == null)
            {
                return NotFound();
            }

            await oQuizAnswerOptionsRepo.DeleteFromDB(id);

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