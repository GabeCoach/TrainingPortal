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
    [EnableCors(origins: "https://www.mgctrainingportal.com,http://localhost:4200,https://www.mgctrainingportal.com", headers: "*", methods: "*")]
    [Authorize]
    public class UsersController : ApiController
    {
        private DB_A35BD0_trainingportaldbEntities db = new DB_A35BD0_trainingportaldbEntities();
        private UsersRepository oUserRepo = new UsersRepository();
        private Logger.Logger oLogger = new Logger.Logger();

        // GET: api/Users
        public IHttpActionResult GetUsers()
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
            {
                oLogger.LogData("ROUTE: api/Users; METHOD: GET; IP_ADDRESS: " + sIPAddress);
                return Json(oUserRepo.SelectAllFromDB());
            }
            catch(Exception ex)
            {
                oLogger.LogData("ROUTE: api/Users; METHOD: GET; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
                return InternalServerError();
            }
            
        }

        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> GetUser(int id)
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
            {
                User user = await oUserRepo.SelectById(id);
                if (user == null)
                {
                    return NotFound();
                }

                oLogger.LogData("ROUTE: api/Users/{id}; METHOD: GET; IP_ADDRESS: " + sIPAddress);

                return Ok(user);
            }
            catch(Exception ex)
            {
                oLogger.LogData("ROUTE: api/Users/{id}; METHOD: GET; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
                return InternalServerError();
            }


        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUser(int id, User user)
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != user.Id)
                {
                    return BadRequest();
                }

                await oUserRepo.UpdateToDB(user, id);

                oLogger.LogData("ROUTE: api/Users/{id}; METHOD: PUT; IP_ADDRESS: " + sIPAddress);
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch(Exception ex)
            {
                oLogger.LogData("ROUTE: api/Users/{id}; METHOD: PUT; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
                return InternalServerError();
            }

            
        }

        [HttpGet]
        [Route("api/Users/{sOktaId}/Check")]
        public async Task<IHttpActionResult> CheckIfUserExists(string sOktaId)
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
            {
                Boolean blnUserExists = false;
                blnUserExists = await oUserRepo.CheckIfUserExistsInDB(sOktaId);
                oLogger.LogData("ROUTE: api/Users/{sOktaId}/Check; METHOD: PUT; IP_ADDRESS: " + sIPAddress);
                return Json(blnUserExists);
            }
            catch(Exception ex)
            {
                oLogger.LogData("ROUTE: api/Users/{sOktaId}/Okta; METHOD: PUT; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("api/Users/{sOktaId}/OktaUser")]
        public async Task<IHttpActionResult> GetUserByOktaId(string sOktaId)
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
            {
                oLogger.LogData("ROUTE: api/Users/{sOktaId}/Okta; METHOD: GET; IP_ADDRESS: " + sIPAddress);
                return Json(await oUserRepo.SelectByOktaId(sOktaId));
            }
            catch(Exception ex)
            {
                oLogger.LogData("ROUTE: api/Users/{sOktaId}/Okta; METHOD: GET; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("api/Users/{sOktaId}/Okta")]
        public async Task<IHttpActionResult> CreateUserFromOkta(string sOktaId)
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
            {
                oLogger.LogData("ROUTE: api/Users/{sOktaId}/Okta; METHOD: POST; IP_ADDRESS: " + sIPAddress);
                return Json(await oUserRepo.CreateUserFromOkta(sOktaId));
            }
            catch(Exception ex)
            {
                oLogger.LogData("ROUTE: api/Users/{sOktaId}/Okta; METHOD: POST; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
                return InternalServerError();
            }
        }

        // POST: api/Users
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> PostUser(User user)
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await oUserRepo.SaveToDB(user);

                oLogger.LogData("ROUTE: api/Users; METHOD: POST; IP_ADDRESS: " + sIPAddress);

                return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
            }
            catch(Exception ex)
            {
                oLogger.LogData("ROUTE: api/Users; METHOD: POST; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
                return InternalServerError();
            }
            
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> DeleteUser(int id)
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
            {
                await oUserRepo.DeleteFromDB(id);

                return Ok();
            }
            catch(Exception ex)
            {
                oLogger.LogData("ROUTE: api/Users/{sOktaId}/Okta; METHOD: POST; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
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

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.Id == id) > 0;
        }
    }
}