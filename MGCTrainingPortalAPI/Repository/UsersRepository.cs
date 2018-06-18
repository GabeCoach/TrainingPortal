using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using MGCTrainingPortalAPI.Interfaces;
using MGCTrainingPortalAPI.Models;

namespace MGCTrainingPortalAPI.Repository
{
    public class UsersRepository : IRepository<User>
    {
        private DB_A35BD0_trainingportaldbEntities db = new DB_A35BD0_trainingportaldbEntities();
        private Logger.Logger oLogger = new Logger.Logger();

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