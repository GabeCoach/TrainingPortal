using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using MGCTrainingPortalAPI.Interfaces;
using MGCTrainingPortalAPI.Models;
using MGCTrainingPortalAPI.Logger;

namespace MGCTrainingPortalAPI.Repository
{
    public class QuizUserSelectedAnswerRepository
    {
        private DB_A35BD0_trainingportaldbEntities db = new DB_A35BD0_trainingportaldbEntities();
        private Logger.Logger oLogger = new Logger.Logger();

        public IQueryable<QuizUserSelectedAnswer> SelectAllFromDB()
        {
            try
            {
                IQueryable<QuizUserSelectedAnswer> oQuizUserSelectedAnswer = from a in db.QuizUserSelectedAnswers
                                                                                 select a;

                return oQuizUserSelectedAnswer;
            }
            catch (Exception ex)
            {
                oLogger.LogData("METHOD: SelectAllFromDB; REPO: QuizUserSelectedAnswer; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException + "; STACKTRACE: " + ex.StackTrace);
                throw new Exception(ex.Message);
            }
        }

        public async Task<QuizUserSelectedAnswer> SelectById(int iQuizUserSelectedAnswerId)
        {
            try
            {
                QuizUserSelectedAnswer oQuizUserSelectedAnswer = await db.QuizUserSelectedAnswers.FindAsync(iQuizUserSelectedAnswerId);
                return oQuizUserSelectedAnswer;
            }
            catch (Exception ex)
            {
                oLogger.LogData("METHOD: SelectById; REPO: QuizUserSelectedAnswer; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException + "; STACKTRACE: " + ex.StackTrace);
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<QuizUserSelectedAnswer>> SaveToDB(List<QuizUserSelectedAnswer> lstQuizUserSelectedAnswers)
        {
            throw new NotImplementedException();
        }

        public async Task<QuizUserSelectedAnswer> SaveToDB(QuizUserSelectedAnswer oQuizUserSelectedAnswer)
        {
            try
            {
                db.QuizUserSelectedAnswers.Add(oQuizUserSelectedAnswer);
                await db.SaveChangesAsync();
                return oQuizUserSelectedAnswer;
            }
            catch (Exception ex)
            {
                oLogger.LogData("METHOD: SaveToDB; REPO: QuizUserSelectedAnswer; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException + "; STACKTRACE: " + ex.StackTrace);
                throw new Exception(ex.Message);
            }
        }

        public async Task<QuizUserSelectedAnswer> UpdateToDB(QuizUserSelectedAnswer oQuizUserSelectedAnswer, int iQuizQuestionId)
        {
            try
            {
                if (iQuizQuestionId != oQuizUserSelectedAnswer.Id)
                    throw new Exception("Quiz Question ID's don't match");
                if (oQuizUserSelectedAnswer == null)
                    throw new Exception("Quiz Question Object is null or empty");

                db.Entry(oQuizUserSelectedAnswer).State = EntityState.Modified;

                try
                {
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuizUserSelectedAnswerExists(iQuizQuestionId))
                    {
                        throw new Exception("User Selected Answer Not Found");
                    }
                    else
                    {
                        throw;
                    }
                }

                return oQuizUserSelectedAnswer;
            }
            catch (Exception ex)
            {
                oLogger.LogData("METHOD: UpdateToDB; REPO: QuizUserSelectedAnswer; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException + "; STACKTRACE: " + ex.StackTrace);
                throw new Exception(ex.Message);
            }
        }

        public async Task<QuizUserSelectedAnswer> DeleteFromDB(int iQuizUserSelectedAnswerId)
        {
            try
            {
                QuizUserSelectedAnswer oQuizUserSelectedAnswer = await db.QuizUserSelectedAnswers.FindAsync(iQuizUserSelectedAnswerId);
                if (oQuizUserSelectedAnswer == null)
                {
                    throw new Exception("User Selected Answer Option Not Found");
                }

                db.QuizUserSelectedAnswers.Remove(oQuizUserSelectedAnswer);
                await db.SaveChangesAsync();

                return oQuizUserSelectedAnswer;
            }
            catch (Exception ex)
            {
                oLogger.LogData("METHOD: DeleteFromDB; REPO: QuizUserSelectedAnswer; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException + "; STACKTRACE: " + ex.StackTrace);
                throw new Exception(ex.Message);
            }

        }

        public async Task<List<QuizUserSelectedAnswer>> SelectByQuizSheet(int iQuizSheetId)
        {
            try
            {
                var query = from qao in db.QuizUserSelectedAnswers
                            where qao.quiz_sheet_id == iQuizSheetId
                            select qao;

                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                oLogger.LogData("METHOD: SelectByQuizSheet; REPO: QuizUserSelectedAnswer; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException + "; STACKTRACE: " + ex.StackTrace);
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<QuizUserSelectedAnswer>> SelectByQuizAnswerOption(int iAnswerOptionId)
        {
            try
            {
                var query = from qusa in db.QuizUserSelectedAnswers
                            where qusa.quiz_answer_option_id == iAnswerOptionId
                            select qusa;

                return await query.ToListAsync();
            }
            catch(Exception ex)
            {
                oLogger.LogData("METHOD: DeleteFromDB; REPO: QuizUserSelectedAnswer; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException + "; STACKTRACE: " + ex.StackTrace);
                throw new Exception(ex.Message);
            }
        }

        private bool QuizUserSelectedAnswerExists(int id)
        {
            return db.QuizQuestions.Count(e => e.Id == id) > 0;
        }
    }
}