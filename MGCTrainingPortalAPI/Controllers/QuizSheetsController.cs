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
using MGCTrainingPortalAPI.Logger;

namespace MGCTrainingPortalAPI.Controllers
{
    public class QuizSheetsController : ApiController
    {
        private DB_A35BD0_trainingportaldbEntities db = new DB_A35BD0_trainingportaldbEntities();
        private QuizSheetRepository oQuizSheetRepository = new QuizSheetRepository();
        private Logger.Logger oLogger = new Logger.Logger();

        // GET: api/QuizSheets
        public IHttpActionResult GetQuizSheets()
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
            {
                oLogger.LogData("ROUTE: api/QuizSheets; METHOD: GET; IP_ADDRESS: " + sIPAddress);
                return Json(oQuizSheetRepository.SelectAllFromDB());
            }
            catch(Exception ex)
            {
                oLogger.LogData("ROUTE: api/QuizSheets; METHOD: GET; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
                return InternalServerError();
            }
            
        }

        // GET: api/QuizSheets/5
        [ResponseType(typeof(QuizSheet))]
        public async Task<IHttpActionResult> GetQuizSheet(int id)
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
            {
                oLogger.LogData("ROUTE: api/QuizSheets/{id}; METHOD: GET; IP_ADDRESS: " + sIPAddress);
                return Json(oQuizSheetRepository.SelectById(id));
            }
            catch(Exception ex)
            {
                oLogger.LogData("ROUTE: api/QuizSheets/{id}; METHOD: GET; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
                return InternalServerError();
            }
            
        }

        // PUT: api/QuizSheets/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutQuizSheet(int id, QuizSheet quizSheet)
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

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

                oLogger.LogData("ROUTE: api/QuizSheets/{id}; METHOD: PUT; IP_ADDRESS: " + sIPAddress);

                return StatusCode(HttpStatusCode.NoContent);
            }
            catch( Exception ex)
            {
                oLogger.LogData("ROUTE: api/QuizSheets/{id}; METHOD: PUT; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
                return InternalServerError();
            }
           
        }

        // POST: api/QuizSheets
        [ResponseType(typeof(QuizSheet))]
        public async Task<IHttpActionResult> PostQuizSheet(QuizSheet quizSheet)
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await oQuizSheetRepository.SaveToDB(quizSheet);

                oLogger.LogData("ROUTE: api/QuizSheets; METHOD: POST; IP_ADDRESS: " + sIPAddress);

                return CreatedAtRoute("DefaultApi", new { id = quizSheet.Id }, quizSheet);
            }
            catch(Exception ex)
            {
                oLogger.LogData("ROUTE: api/QuizSheets; METHOD: POST; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
                return InternalServerError();
            }
            
        }

        // DELETE: api/QuizSheets/5
        [ResponseType(typeof(QuizSheet))]
        public async Task<IHttpActionResult> DeleteQuizSheet(int id)
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
            {
                oLogger.LogData("ROUTE: api/QuizSheets/{id}; METHOD: DELETE; IP_ADDRESS: " + sIPAddress);
                return Ok(await oQuizSheetRepository.DeleteFromDB(id));
            }
            catch(Exception ex)
            {
                oLogger.LogData("ROUTE: api/QuizSheets/{id}; METHOD: DELETE; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
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