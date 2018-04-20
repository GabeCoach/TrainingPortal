using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MGCTrainingPortalAPI.Interfaces;
using MGCTrainingPortalAPI.Models;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;

namespace MGCTrainingPortalAPI.Repository
{
    public class TrainingCourseModuleQuizsRepository : IRepository<TrainingCourseModuleQuiz>
    {
        private DB_A35BD0_trainingportaldbEntities db = new DB_A35BD0_trainingportaldbEntities();

        public IQueryable<TrainingCourseModuleQuiz> SelectAllFromDB()
        {
            try
            {
                IQueryable<TrainingCourseModuleQuiz> oTrainingCourseModuleQuiz = from a in db.TrainingCourseModuleQuizs
                                                                                       select a;

                return oTrainingCourseModuleQuiz;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TrainingCourseModuleQuiz> SelectById(int iModuleQuizId)
        {
            try
            {
                TrainingCourseModuleQuiz oTrainingCourseModuleQuiz = await db.TrainingCourseModuleQuizs.FindAsync(iModuleQuizId);
                return oTrainingCourseModuleQuiz;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<TrainingCourseModuleQuiz>> SaveToDB(List<TrainingCourseModuleQuiz> lstTrainingCourseModuleQuizs)
        {
            throw new NotImplementedException();
        }

        public async Task<TrainingCourseModuleQuiz> SaveToDB(TrainingCourseModuleQuiz oTrainingCourseModuleQuiz)
        {
            try
            {
                db.TrainingCourseModuleQuizs.Add(oTrainingCourseModuleQuiz);
                await db.SaveChangesAsync();
                return oTrainingCourseModuleQuiz;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TrainingCourseModuleQuiz> UpdateToDB(TrainingCourseModuleQuiz oTrainingCourseModuleQuiz, int iModuleQuizId)
        {
            try
            {
                if (iModuleQuizId != oTrainingCourseModuleQuiz.Id)
                    throw new Exception("Quiz ID's don't match");
                if (oTrainingCourseModuleQuiz == null)
                    throw new Exception("Quiz Object is null or empty");

                db.Entry(oTrainingCourseModuleQuiz).State = EntityState.Modified;

                try
                {
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuizExists(iModuleQuizId))
                    {
                        throw new Exception("Module Section Not Found");
                    }
                    else
                    {
                        throw;
                    }
                }

                return oTrainingCourseModuleQuiz;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TrainingCourseModuleQuiz> DeleteFromDB(int iModuleQuizId)
        {
            try
            {
                TrainingCourseModuleQuiz oTrainingCourseModuleQuiz = await db.TrainingCourseModuleQuizs.FindAsync(iModuleQuizId);
                if (oTrainingCourseModuleQuiz == null)
                {
                    throw new Exception("Appointment Not Found");
                }

                db.TrainingCourseModuleQuizs.Remove(oTrainingCourseModuleQuiz);
                await db.SaveChangesAsync();

                return oTrainingCourseModuleQuiz;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        private bool QuizExists(int id)
        {
            return db.TrainingCourseModuleQuizs.Count(e => e.Id == id) > 0;
        }
    }
}