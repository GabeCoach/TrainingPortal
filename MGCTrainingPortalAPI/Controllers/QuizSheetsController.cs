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
    public class QuizSheetsController : ApiController
    {
        private DB_A35BD0_trainingportaldbEntities db = new DB_A35BD0_trainingportaldbEntities();
        private QuizSheetRepository oQuizSheetRepository = new QuizSheetRepository();

        // GET: api/QuizSheets
        public IHttpActionResult GetQuizSheets()
        {
            try
            {
                return Json(oQuizSheetRepository.SelectAllFromDB());
            }
            catch(Exception ex)
            {
                return InternalServerError();
            }
            
        }

        // GET: api/QuizSheets/5
        [ResponseType(typeof(QuizSheet))]
        public async Task<IHttpActionResult> GetQuizSheet(int id)
        {
            try
            {
                return Json(oQuizSheetRepository.SelectById(id));
            }
            catch(Exception ex)
            {
                return InternalServerError();
            }
            
        }

        // PUT: api/QuizSheets/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutQuizSheet(int id, QuizSheet quizSheet)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != quizSheet.Id)
                {
                    return BadRequest();
                }

                await oQuizSheetRepository.UpdateToDB(quizSheet, id);

                return StatusCode(HttpStatusCode.NoContent);
            }
            catch( Exception ex)
            {
                return InternalServerError();
            }
           
        }

        // POST: api/QuizSheets
        [ResponseType(typeof(QuizSheet))]
        public async Task<IHttpActionResult> PostQuizSheet(QuizSheet quizSheet)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await oQuizSheetRepository.SaveToDB(quizSheet);

                return CreatedAtRoute("DefaultApi", new { id = quizSheet.Id }, quizSheet);
            }
            catch(Exception ex)
            {
                return InternalServerError();
            }
            
        }

        // DELETE: api/QuizSheets/5
        [ResponseType(typeof(QuizSheet))]
        public async Task<IHttpActionResult> DeleteQuizSheet(int id)
        {
            try
            {
                return Ok(await oQuizSheetRepository.DeleteFromDB(id));
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

        private bool QuizSheetExists(int id)
        {
            return db.QuizSheets.Count(e => e.Id == id) > 0;
        }
    }
}