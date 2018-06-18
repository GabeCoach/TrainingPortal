using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MGCTrainingPortalAPI.Models;
using MGCTrainingPortalAPI.Interfaces;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using MGCTrainingPortalAPI.Logger;

namespace MGCTrainingPortalAPI.Repository
{
    public class QuizSheetRepository : IRepository<QuizSheet>
    {
        private DB_A35BD0_trainingportaldbEntities db = new DB_A35BD0_trainingportaldbEntities();
        private Logger.Logger oLogger = new Logger.Logger();

        public IQueryable<QuizSheet> SelectAllFromDB()
        {
            try
            {
                IQueryable<QuizSheet> oQuizSheet = from a in db.QuizSheets
                                                         select a;

                return oQuizSheet;
            }
            catch (Exception ex)
            {
                oLogger.LogData("METHOD: SelectAllFromDB; REPO: QuizSheet; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException + "; STACKTRACE: " + ex.StackTrace);
                throw new Exception(ex.Message);
            }
        }

        public async Task<QuizSheet> SelectById(int iQuizSheetId)
        {
            try
            {
                QuizSheet oQuizSheet = await db.QuizSheets.FindAsync(iQuizSheetId);
                return oQuizSheet;
            }
            catch (Exception ex)
            {
                oLogger.LogData("METHOD: SelectById; REPO: QuizSheet; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException + "; STACKTRACE: " + ex.StackTrace);
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<QuizSheet>> SaveToDB(List<QuizSheet> lstQuizSheet)
        {
            throw new NotImplementedException();
        }

        public async Task<QuizSheet> SaveToDB(QuizSheet oQuizSheet)
        {
            try
            {
                db.QuizSheets.Add(oQuizSheet);
                await db.SaveChangesAsync();
                return oQuizSheet;
            }
            catch (Exception ex)
            {
                oLogger.LogData("METHOD: SaveToDB; REPO: QuizSheet; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException + "; STACKTRACE: " + ex.StackTrace);
                throw new Exception(ex.Message);
            }
        }

        public async Task<QuizSheet> UpdateToDB(QuizSheet oQuizSheet, int iQuizSheetId)
        {
            try
            {
                if (iQuizSheetId != oQuizSheet.Id)
                    throw new Exception("Quiz Question ID's don't match");
                if (oQuizSheet == null)
                    throw new Exception("Quiz Question Object is null or empty");

                db.Entry(oQuizSheet).State = EntityState.Modified;

                try
                {
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuizSheetExists(iQuizSheetId))
                    {
                        throw new Exception("Quiz Question Not Found");
                    }
                    else
                    {
                        throw;
                    }
                }

                return oQuizSheet;
            }
            catch (Exception ex)
            {
                oLogger.LogData("METHOD: UpdateToDB; REPO: QuizSheet; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException + "; STACKTRACE: " + ex.StackTrace);
                throw new Exception(ex.Message);
            }
        }

        public async Task<QuizSheet> DeleteFromDB(int iQuizSheetId)
        {
            try
            {
                QuizSheet oQuizSheet = await db.QuizSheets.FindAsync(iQuizSheetId);
                if (oQuizSheet == null)
                {
                    throw new Exception("Quiz Question Not Found");
                }

                db.QuizSheets.Remove(oQuizSheet);
                await db.SaveChangesAsync();

                return oQuizSheet;
            }
            catch (Exception ex)
            {
                oLogger.LogData("METHOD: DeleteFromDB; REPO: QuizSheet; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException + "; STACKTRACE: " + ex.StackTrace);
                throw new Exception(ex.Message);
            }

        }

        public async Task<List<QuizSheet>> SelectByCourseModuleQuiz(int iCourseModuleQuizId)
        {
            try
            {
                var query = from qq in db.QuizSheets
                            where qq.quiz_id == iCourseModuleQuizId
                            select qq;

                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                oLogger.LogData("METHOD: SelectByCourseModuleQuiz; REPO: QuizSheet; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException + "; STACKTRACE: " + ex.StackTrace);
                throw new Exception(ex.Message);
            }
        }

        private bool QuizSheetExists(int id)
        {
            return db.QuizSheets.Count(e => e.Id == id) > 0;
        }
    }
}