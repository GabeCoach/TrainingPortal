using MGCTrainingPortalAPI.Interfaces;
using MGCTrainingPortalAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MGCTrainingPortalAPI.Repository
{
    public class QuizQuestionAnswerOptionsRepository : IRepository<QuizQuestionAnswerOption>
    {
        private DB_A35BD0_trainingportaldbEntities db = new DB_A35BD0_trainingportaldbEntities();

        public IQueryable<QuizQuestionAnswerOption> SelectAllFromDB()
        {
            try
            {
                IQueryable<QuizQuestionAnswerOption> oQuizQuestionAnswerOption = from a in db.QuizQuestionAnswerOptions
                                                         select a;

                return oQuizQuestionAnswerOption;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<QuizQuestionAnswerOption> SelectById(int iQuizQuestionAnswerOptionId)
        {
            try
            {
                QuizQuestionAnswerOption oQuizQuestionAnswerOption = await db.QuizQuestionAnswerOptions.FindAsync(iQuizQuestionAnswerOptionId);
                return oQuizQuestionAnswerOption;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<QuizQuestionAnswerOption>> SaveToDB(List<QuizQuestionAnswerOption> lstQuizQuestionAnswerOptions)
        {
            throw new NotImplementedException();
        }

        public async Task<QuizQuestionAnswerOption> SaveToDB(QuizQuestionAnswerOption oQuizQuestionAnswerOption)
        {
            try
            {
                db.QuizQuestionAnswerOptions.Add(oQuizQuestionAnswerOption);
                await db.SaveChangesAsync();
                return oQuizQuestionAnswerOption;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<QuizQuestionAnswerOption> UpdateToDB(QuizQuestionAnswerOption oQuizQuestionAnswerOption, int iQuizQuestionId)
        {
            try
            {
                if (iQuizQuestionId != oQuizQuestionAnswerOption.Id)
                    throw new Exception("Quiz Question ID's don't match");
                if (oQuizQuestionAnswerOption == null)
                    throw new Exception("Quiz Question Object is null or empty");

                db.Entry(oQuizQuestionAnswerOption).State = EntityState.Modified;

                try
                {
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuizQuestionAnswerOptionExists(iQuizQuestionId))
                    {
                        throw new Exception("Quiz Question Answer Option Not Found");
                    }
                    else
                    {
                        throw;
                    }
                }

                return oQuizQuestionAnswerOption;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<QuizQuestionAnswerOption> DeleteFromDB(int iQuizQuestionAnswerOptionId)
        {
            try
            {
                QuizQuestionAnswerOption oQuizQuestionAnswerOption = await db.QuizQuestionAnswerOptions.FindAsync(iQuizQuestionAnswerOptionId);
                if (oQuizQuestionAnswerOption == null)
                {
                    throw new Exception("Quiz Question Answer Option Not Found");
                }

                db.QuizQuestionAnswerOptions.Remove(oQuizQuestionAnswerOption);
                await db.SaveChangesAsync();

                return oQuizQuestionAnswerOption;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<List<QuizQuestionAnswerOption>> SelectByQuizQuestion(int iQuizQuestionId)
        {
            try
            {
                var query = from qao in db.QuizQuestionAnswerOptions
                            where qao.quiz_question_id == iQuizQuestionId
                            select qao;

                return await query.ToListAsync();
            }
            catch(Exception ex)
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