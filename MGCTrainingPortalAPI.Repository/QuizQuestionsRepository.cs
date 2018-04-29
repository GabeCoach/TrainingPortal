using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MGCTrainingPortalAPI.Models;
using MGCTrainingPortalAPI.Interfaces;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace MGCTrainingPortalAPI.Repository
{
    public class QuizQuestionsRepository : IRepository<QuizQuestion>
    {
        private DB_A35BD0_trainingportaldbEntities db = new DB_A35BD0_trainingportaldbEntities();

        public IQueryable<QuizQuestion> SelectAllFromDB()
        {
            try
            {
                IQueryable<QuizQuestion> oQuizQuestion = from a in db.QuizQuestions
                                                         select a;

                return oQuizQuestion;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<QuizQuestion> SelectById(int iQuizQuestionId)
        {
            try
            {
                QuizQuestion oQuizQuestion = await db.QuizQuestions.FindAsync(iQuizQuestionId);
                return oQuizQuestion;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<QuizQuestion>> SaveToDB(List<QuizQuestion> lstQuizQuestion)
        {
            throw new NotImplementedException();
        }

        public async Task<QuizQuestion> SaveToDB(QuizQuestion oQuizQuestion)
        {
            try
            {
                db.QuizQuestions.Add(oQuizQuestion);
                await db.SaveChangesAsync();
                return oQuizQuestion;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<QuizQuestion> UpdateToDB(QuizQuestion oQuizQuestion, int iQuizQuestionId)
        {
            try
            {
                if (iQuizQuestionId != oQuizQuestion.Id)
                    throw new Exception("Quiz Question ID's don't match");
                if (oQuizQuestion == null)
                    throw new Exception("Quiz Question Object is null or empty");

                db.Entry(oQuizQuestion).State = EntityState.Modified;

                try
                {
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuizQuestionExists(iQuizQuestionId))
                    {
                        throw new Exception("Quiz Question Not Found");
                    }
                    else
                    {
                        throw;
                    }
                }

                return oQuizQuestion;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<QuizQuestion> DeleteFromDB(int iQuizQuestionId)
        {
            try
            {
                QuizQuestion oQuizQuestion = await db.QuizQuestions.FindAsync(iQuizQuestionId);
                if (oQuizQuestion == null)
                {
                    throw new Exception("Quiz Question Not Found");
                }

                db.QuizQuestions.Remove(oQuizQuestion);
                await db.SaveChangesAsync();

                return oQuizQuestion;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<List<QuizQuestion>> SelectByCourseModuleQuiz(int iCourseModuleQuizId)
        {
            try
            {
                var query = from qq in db.QuizQuestions
                            where qq.trainining_course_module_quiz_id == iCourseModuleQuizId
                            select qq;

                return await query.ToListAsync();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }           
        }

        private bool QuizQuestionExists(int id)
        {
            return db.QuizQuestions.Count(e => e.Id == id) > 0;
        }
    }
}