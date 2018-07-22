using MGCTrainingPortalAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MGCTrainingPortalAPI.Interfaces;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using MGCTrainingPortalAPI.Logger;
using MGCTrainingPortalAPI.Repository.HelperModels;

namespace MGCTrainingPortalAPI.Repository
{
    public class QuizQuestionCorrectAnswerRepository : IRepository<QuizQuestionCorrectAnswer>
    {
        private DB_A35BD0_trainingportaldbEntities db = new DB_A35BD0_trainingportaldbEntities();
        private QuizSheetRepository oQuizSheetRepo = new QuizSheetRepository();
        private QuizQuestionsRepository oQuizQuestionRepo = new QuizQuestionsRepository();
        private QuizQuestionAnswerOptionsRepository oQuizAnsweOptionRepo = new QuizQuestionAnswerOptionsRepository();
        private Logger.Logger oLogger = new Logger.Logger();

        public IQueryable<QuizQuestionCorrectAnswer> SelectAllFromDB()
        {
            try
            {
                IQueryable<QuizQuestionCorrectAnswer> oQuizQuestionCorrectAnswer = from a in db.QuizQuestionCorrectAnswers
                                                                                 select a;

                return oQuizQuestionCorrectAnswer;
            }
            catch (Exception ex)
            {
                oLogger.LogData("METHOD: SelectAllFromDB; REPO: QuizQuestionCorrectAnswer; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException + "; STACKTRACE: " + ex.StackTrace);
                throw new Exception(ex.Message);
            }
        }

        public async Task<QuizQuestionCorrectAnswer> SelectById(int iQuizQuestionAnswerOptionId)
        {
            try
            {
                QuizQuestionCorrectAnswer oQuizQuestionCorrectAnswer = await db.QuizQuestionCorrectAnswers.FindAsync(iQuizQuestionAnswerOptionId);
                return oQuizQuestionCorrectAnswer;
            }
            catch (Exception ex)
            {
                oLogger.LogData("METHOD: SelectById; REPO: QuizQuestionCorrectAnswer; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException + "; STACKTRACE: " + ex.StackTrace);
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<CorrentAnswerOptionHelper>> SelectCorrectAnswersByQuizSheet(int iQuizSheetId)
        {
            try
            {
                List<CorrentAnswerOptionHelper> lstCorrectAnswerOptionHelpers = new List<CorrentAnswerOptionHelper>();
                QuizSheet oQuizSheet = await oQuizSheetRepo.SelectById(iQuizSheetId);
                List<QuizQuestion> lstQuizQuestions = await oQuizQuestionRepo.SelectByCourseModuleQuiz(oQuizSheet.quiz_id.Value);

                foreach(var question in lstQuizQuestions)
                {
                    CorrentAnswerOptionHelper oCorrectAnswerHelper = new CorrentAnswerOptionHelper();
                    QuizQuestionCorrectAnswer oCorrectAnswer = await SelectByQuizQuestion(question.Id);
                    oCorrectAnswerHelper.correct_answer_option_id = oCorrectAnswer.quiz_answer_options_id.Value;
                    oCorrectAnswerHelper.correct_answer_option_content = await oQuizAnsweOptionRepo.SelectContentOnlyById(oCorrectAnswerHelper.correct_answer_option_id);
                    oCorrectAnswerHelper.quiz_question_id = question.Id;
                    lstCorrectAnswerOptionHelpers.Add(oCorrectAnswerHelper);
                }

                return lstCorrectAnswerOptionHelpers;
            }
            catch(Exception ex)
            {
                oLogger.LogData("METHOD: SelectCorrectAnswersByuizSheet; REPO: QuizQuestionCorrectAnswer; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException + "; STACKTRACE: " + ex.StackTrace);
                throw new Exception(ex.Message);
            }
        }

        public async Task<QuizQuestionCorrectAnswer> SelectByQuizQuestion(int iQuizQuestionId)
        {
            try
            {
                QuizQuestionCorrectAnswer oQuizQuestionCorrectAnswer = await (from qqca in db.QuizQuestionCorrectAnswers
                                                                       where qqca.quiz_question_id == iQuizQuestionId
                                                                       select qqca).FirstOrDefaultAsync();

                return oQuizQuestionCorrectAnswer;
            }
            catch(Exception ex)
            {
                oLogger.LogData("METHOD: SelectByuizQuestion; REPO: QuizQuestionCorrectAnswer; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException + "; STACKTRACE: " + ex.StackTrace);
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<QuizQuestionCorrectAnswer>> SaveToDB(List<QuizQuestionCorrectAnswer> lstQuizQuestionCorrectAnswer)
        {
            throw new NotImplementedException();
        }

        public async Task<QuizQuestionCorrectAnswer> SaveToDB(QuizQuestionCorrectAnswer oQuizQuestionCorrectAnswer)
        {
            try
            {
                db.QuizQuestionCorrectAnswers.Add(oQuizQuestionCorrectAnswer);
                await db.SaveChangesAsync();
                return oQuizQuestionCorrectAnswer;
            }
            catch (Exception ex)
            {
                oLogger.LogData("METHOD: SaveToDB; REPO: QuizQuestionCorrectAnswer; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException + "; STACKTRACE: " + ex.StackTrace);
                throw new Exception(ex.Message);
            }
        }

        public async Task<QuizQuestionCorrectAnswer> UpdateToDB(QuizQuestionCorrectAnswer oQuizQuestionCorrectAnswer, int iQuizQuestionCorrectAnswer)
        {
            try
            {
                if (iQuizQuestionCorrectAnswer != oQuizQuestionCorrectAnswer.Id)
                    throw new Exception("Quiz Question Correct Answer don't match");
                if (oQuizQuestionCorrectAnswer == null)
                    throw new Exception("Quiz Question Correct Answer Object is null or empty");

                db.Entry(oQuizQuestionCorrectAnswer).State = EntityState.Modified;

                try
                {
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuizQuestionAnswerOptionExists(iQuizQuestionCorrectAnswer))
                    {
                        throw new Exception("Quiz Question Correct Answer Not Found");
                    }
                    else
                    {
                        throw;
                    }
                }

                return oQuizQuestionCorrectAnswer;
            }
            catch (Exception ex)
            {
                oLogger.LogData("METHOD: UpdateToDB; REPO: QuizQuestionCorrectAnswer; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException + "; STACKTRACE: " + ex.StackTrace);
                throw new Exception(ex.Message);
            }
        }

        public async Task<QuizQuestionCorrectAnswer> DeleteFromDB(int iQuizQuestionCorrectAnswerId)
        {
            try
            {
                QuizQuestionCorrectAnswer oQuizQuestionCorrectAnswer = await db.QuizQuestionCorrectAnswers.FindAsync(iQuizQuestionCorrectAnswerId);
                if (oQuizQuestionCorrectAnswer == null)
                {
                    throw new Exception("Quiz Question Answer Option Not Found");
                }

                db.QuizQuestionCorrectAnswers.Remove(oQuizQuestionCorrectAnswer);
                await db.SaveChangesAsync();

                return oQuizQuestionCorrectAnswer;
            }
            catch (Exception ex)
            {
                oLogger.LogData("METHOD: DeleteFromDB; REPO: QuizQuestionCorrectAnswer; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException + "; STACKTRACE: " + ex.StackTrace);
                throw new Exception(ex.Message);
            }

        }

        private bool QuizQuestionAnswerOptionExists(int id)
        {
            return db.QuizQuestions.Count(e => e.Id == id) > 0;
        }
    }
}