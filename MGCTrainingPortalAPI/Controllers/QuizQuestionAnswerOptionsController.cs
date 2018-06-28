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
    public class QuizQuestionAnswerOptionsController : ApiController
    {
        private DB_A35BD0_trainingportaldbEntities db = new DB_A35BD0_trainingportaldbEntities();
        private QuizQuestionAnswerOptionsRepository oQuizAnswerOptionsRepo = new QuizQuestionAnswerOptionsRepository();
        private Logger.Logger oLogger = new Logger.Logger();

        // GET: api/QuizQuestionAnswerOptions
        public IHttpActionResult GetQuizQuestionAnswerOptions()
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
            {
                oLogger.LogData("ROUTE: api/QuizQuestionAnswerOptions; METHOD: GET; IP_ADDRESS: " + sIPAddress);
                return Json(oQuizAnswerOptionsRepo.SelectAllFromDB());
            }
            catch(Exception ex)
            {
                oLogger.LogData("ROUTE: api/QuizQuestionAnswerOptions; METHOD: GET; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
                return InternalServerError();
            }
        }

        // GET: api/QuizQuestionAnswerOptions/5
        [ResponseType(typeof(QuizQuestionAnswerOption))]
        public async Task<IHttpActionResult> GetQuizQuestionAnswerOption(int id)
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
            {
                QuizQuestionAnswerOption quizQuestionAnswerOption = await oQuizAnswerOptionsRepo.SelectById(id);
                if (quizQuestionAnswerOption == null)
                {
                    return NotFound();
                }

                oLogger.LogData("ROUTE: api/QuizQuestionAnswerOptions/{id}; METHOD: GET; IP_ADDRESS: " + sIPAddress);

                return Ok(quizQuestionAnswerOption);
            }
            catch(Exception ex)
            {
                oLogger.LogData("ROUTE: api/QuizQuestionAnswerOptions/{id}; METHOD: GET; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
                return InternalServerError();
            }
        }

        // PUT: api/QuizQuestionAnswerOptions/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutQuizQuestionAnswerOption(int id, QuizQuestionAnswerOption quizQuestionAnswerOption)
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
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

                oLogger.LogData("ROUTE: api/QuizQuestionAnswerOptions/{id}; METHOD: PUT; IP_ADDRESS: " + sIPAddress);

                return StatusCode(HttpStatusCode.NoContent);
            }
            catch(Exception ex)
            {
                oLogger.LogData("ROUTE: api/QuizQuestionAnswerOptions/{id}; METHOD: PUT; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
                return InternalServerError();
            }
            
        }

        [HttpGet]
        [Route("api/QuizQuestionAnswerOptions/{iQuizQuestionId}/QuizQuestion")]
        public async Task<IHttpActionResult> GetQuizQuestionAnswerOptionByQuestion(int iQuizQuestionId)
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
            {
                oLogger.LogData("ROUTE: api/QuizQuestionAnswerOptions/{iQuizQuestionId}/QuizQuestion; METHOD: GET; IP_ADDRESS: " + sIPAddress);
                return Json(await oQuizAnswerOptionsRepo.SelectByQuizQuestion(iQuizQuestionId));
            }
            catch(Exception ex)
            {
                oLogger.LogData("ROUTE: api/QuizQuestionAnswerOptions; METHOD: POST; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
                return InternalServerError();
            }
        }

        // POST: api/QuizQuestionAnswerOptions
        [ResponseType(typeof(QuizQuestionAnswerOption))]
        public async Task<IHttpActionResult> PostQuizQuestionAnswerOption(QuizQuestionAnswerOption quizQuestionAnswerOption)
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await oQuizAnswerOptionsRepo.SaveToDB(quizQuestionAnswerOption);

                oLogger.LogData("ROUTE: api/QuizQuestionAnswerOptions; METHOD: POST; IP_ADDRESS: " + sIPAddress);

                return Ok();
            }
            catch(Exception ex)
            {
                oLogger.LogData("ROUTE: api/QuizQuestionAnswerOptions; METHOD: POST; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
                return InternalServerError();
            }
            
        }

        // DELETE: api/QuizQuestionAnswerOptions/5
        [ResponseType(typeof(QuizQuestionAnswerOption))]
        public async Task<IHttpActionResult> DeleteQuizQuestionAnswerOption(int id)
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
            {
                QuizQuestionAnswerOption quizQuestionAnswerOption = await oQuizAnswerOptionsRepo.SelectById(id);
                if (quizQuestionAnswerOption == null)
                {
                    return NotFound();
                }

                await oQuizAnswerOptionsRepo.DeleteFromDB(id);

                oLogger.LogData("ROUTE: api/QuizQuestionAnswerOptions/{id}; DELETE: POST; IP_ADDRESS: " + sIPAddress);

                return Ok(quizQuestionAnswerOption);
            }
            catch(Exception ex)
            {
                oLogger.LogData("ROUTE: api/QuizQuestionAnswerOptions/{id}; METHOD: DELETE; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
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

        private bool QuizQuestionAnswerOptionExists(int id)
        {
            return db.QuizQuestionAnswerOptions.Count(e => e.Id == id) > 0;
        }
    }
}