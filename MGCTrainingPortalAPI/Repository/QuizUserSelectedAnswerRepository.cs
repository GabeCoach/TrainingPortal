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
using MGCTrainingPortalAPI.QuizDetails.Models;
using MGCTrainingPortalAPI.Repository.HelperModels;

namespace MGCTrainingPortalAPI.Repository
{
    public class QuizUserSelectedAnswerRepository
    {
        private DB_A35BD0_trainingportaldbEntities db = new DB_A35BD0_trainingportaldbEntities();
        private QuizQuestionAnswerOptionsRepository oQuizAnswerOptionRepo = new QuizQuestionAnswerOptionsRepository();
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

        public async Task<List<UserSelectedAnswerOptionHelper>> GetSelectedAnswersByQuizSheet(int iQuizSheetId)
        {
            try
            {
                List<UserSelectedAnswerOptionHelper> lstSelectedAnswerHelper = new List<UserSelectedAnswerOptionHelper>();
                

                List<QuizUserSelectedAnswer> lstUserSelectedAnswers = await (from usa in db.QuizUserSelectedAnswers
                                                                       where usa.quiz_sheet_id == iQuizSheetId
                                                                       select usa).ToListAsync();

                foreach(var selectedAnwser in lstUserSelectedAnswers)
                {
                    UserSelectedAnswerOptionHelper oSeletedOptionsHelper = new UserSelectedAnswerOptionHelper();
                    oSeletedOptionsHelper.user_selected_option_id = selectedAnwser.Id;
                    oSeletedOptionsHelper.quiz_question_id = selectedAnwser.quiz_question_id.Value;

                    QuizQuestionAnswerOption oQuizAnswerOption = await oQuizAnswerOptionRepo.SelectById(oSeletedOptionsHelper.user_selected_option_id);
                    oSeletedOptionsHelper.user_selected_option_content = oQuizAnswerOption.answer_option;

                    lstSelectedAnswerHelper.Add(oSeletedOptionsHelper);
                }

                return lstSelectedAnswerHelper;
            }
            catch(Exception ex)
            {
                oLogger.LogData("METHOD: SelectById; REPO: GetSelectedAnswersByQuizSheet; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException + "; STACKTRACE: " + ex.StackTrace);
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<QuizUserSelectedAnswer>> SaveToDB(List<QuizUserSelectedAnswer> lstQuizUserSelectedAnswers)
        {
            try
            {
                foreach(var answer in lstQuizUserSelectedAnswers)
                {
                    await SaveToDB(answer);
                }

                return lstQuizUserSelectedAnswers;
            }
            catch(Exception ex)
            {
                oLogger.LogData("METHOD: SaveToDB:ListObj; REPO: QuizUserSelectedAnswer; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException + "; STACKTRACE: " + ex.StackTrace);
                throw new Exception(ex.Message);
            }
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