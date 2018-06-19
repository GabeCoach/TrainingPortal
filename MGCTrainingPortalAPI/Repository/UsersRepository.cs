using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using MGCTrainingPortalAPI.Interfaces;
using MGCTrainingPortalAPI.Models;
using MGCTrainingPortalAPI.OktaConnector;
using Newtonsoft.Json.Linq;

namespace MGCTrainingPortalAPI.Repository
{
    public class UsersRepository : IRepository<User>
    {
        private DB_A35BD0_trainingportaldbEntities db = new DB_A35BD0_trainingportaldbEntities();
        private Logger.Logger oLogger = new Logger.Logger();
        private OktaUsers oOktaUsers = new OktaUsers();


        public IQueryable<User> SelectAllFromDB()
        {
            try
            {
                IQueryable<User> oUser = from a in db.Users
                                                   select a;

                return oUser;
            }
            catch (Exception ex)
            {
                oLogger.LogData("METHOD: SelectAllFromDB; REPO: User; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException + "; STACKTRACE: " + ex.StackTrace);
                throw new Exception(ex.Message);
            }
        }

        public async Task<Boolean> CheckIfUserExistsInDB(string sOktaId)
        {
            try
            {
                bool blnUserExists = false;

                var query = await (from ou in db.Users
                                   where ou.okta_id.Equals(sOktaId)
                                   select ou).AnyAsync();

                if (query)
                    blnUserExists = true;

                return blnUserExists;
            }
            catch(Exception ex)
            {
                oLogger.LogData("METHOD: CheckIfUserExistsInDB; REPO: User; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException + "; STACKTRACE: " + ex.StackTrace);
                throw new Exception(ex.Message);
            }
        }

        public async Task<User> SelectByOktaId(string sOktaId)
        {
            try
            {
                User oUser = await (from u in db.Users
                                    where u.okta_id.Equals(sOktaId)
                                    select u).FirstOrDefaultAsync();

                return oUser;
            }
            catch(Exception ex)
            {
                oLogger.LogData("METHOD: SelectByOktaId; REPO: User; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException + "; STACKTRACE: " + ex.StackTrace);
                throw new Exception(ex.Message);
            }
        }

        public async Task<User> SelectById(int iUserId)
        {
            try
            {
                User oUser = await db.Users.FindAsync(iUserId);
                return oUser;
            }
            catch (Exception ex)
            {
                oLogger.LogData("METHOD: SelectById; REPO: User; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException + "; STACKTRACE: " + ex.StackTrace);
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<User>> SaveToDB(List<User> lstUser)
        {
            throw new NotImplementedException();
        }

        public async Task<User> SaveToDB(User oUser)
        {
            try
            {
                db.Users.Add(oUser);
                await db.SaveChangesAsync();
                return oUser;
            }
            catch (Exception ex)
            {
                oLogger.LogData("METHOD: SaveToDB; REPO: User; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException + "; STACKTRACE: " + ex.StackTrace);
                throw new Exception(ex.Message);
            }
        }

        public async Task<User> UpdateToDB(User oUser, int iUserId)
        {
            try
            {
                if (iUserId != oUser.Id)
                    throw new Exception("User ID's don't match");
                if (oUser == null)
                    throw new Exception("User Object is null or empty");

                db.Entry(oUser).State = EntityState.Modified;

                try
                {
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(iUserId))
                    {
                        throw new Exception("User Not Found");
                    }
                    else
                    {
                        throw;
                    }
                }

                return oUser;
            }
            catch (Exception ex)
            {
                oLogger.LogData("METHOD: UpdateToDB; REPO: User; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException + "; STACKTRACE: " + ex.StackTrace);
                throw new Exception(ex.Message);
            }
        }

        public async Task<User> CreateUserFromOkta(string sOktaId)
        {
            try
            {
                User oUser = new User();
                dynamic dynOktaUser = await oOktaUsers.GetUserFromOkta(sOktaId);
                oUser.first_name = dynOktaUser.profile.firstName;
                oUser.last_name = dynOktaUser.profile.lastName;
                oUser.mobile_phone = dynOktaUser.profile.mobilePhone;
                oUser.email_address = dynOktaUser.profile.email;
                oUser.okta_id = sOktaId;

                await SaveToDB(oUser);

                return oUser;
            }
            catch(Exception ex)
            {
                throw new Exception();
            }
        }

        public async Task<User> DeleteFromDB(int iUserId)
        {
            try
            {
                User oUser = await db.Users.FindAsync(iUserId);
                if (oUser == null)
                {
                    throw new Exception("User Not Found");
                }

                db.Users.Remove(oUser);
                await db.SaveChangesAsync();

                return oUser;
            }
            catch (Exception ex)
            {
                oLogger.LogData("METHOD: DeleteFromDB; REPO: User; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException + "; STACKTRACE: " + ex.StackTrace);
                throw new Exception(ex.Message);
            }
        }

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.Id == id) > 0;
        }
    }
}