using MGCTrainingPortalAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MGCTrainingPortalAPI.Interfaces;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace MGCTrainingPortalAPI.Repository
{
    public class QuizQuestionCorrectAnswerRepository : IRepository<QuizQuestionCorrectAnswer>
    {
        private DB_A35BD0_trainingportaldbEntities db = new DB_A35BD0_trainingportaldbEntities();

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
                throw new Exception(ex.Message);
            }
        }

        public async Task<QuizQuestionCorrectAnswer> SelectByQuizQuestion(int iQuizQuestionId)
        {
            try
            {
                QuizQuestionCorrectAnswer oQuizQuestionCorrectAnswer = await (from qqca in db.QuizQuestionCorrectAnswers
                                                                       where qqca.quiz_question_id == iQuizQuestionId
                                                                       select qqca).FirstAsync();

                return oQuizQuestionCorrectAnswer;
            }
            catch(Exception ex)
            {
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
                throw new Exception(ex.Message);
            }

        }

        private bool QuizQuestionAnswerOptionExists(int id)
        {
            return db.QuizQuestions.Count(e => e.Id == id) > 0;
        }
    }
}