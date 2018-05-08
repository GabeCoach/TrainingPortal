using MGCTrainingPortalAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using MGCTrainingPortalAPI.Interfaces;

namespace MGCTrainingPortalAPI.Repository
{
    public class TrainingCourseQuizScoreQuizScoresRepository: IRepository<TrainingCourseQuizScore>
    {
        private DB_A35BD0_trainingportaldbEntities db = new DB_A35BD0_trainingportaldbEntities();

        public IQueryable<TrainingCourseQuizScore> SelectAllFromDB()
        {
            try
            {
                IQueryable<TrainingCourseQuizScore> oTrainingCourseQuizScore = from a in db.TrainingCourseQuizScores
                                                             select a;

                return oTrainingCourseQuizScore;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TrainingCourseQuizScore> SelectById(int iTrainingCourseQuizId)
        {
            try
            {
                TrainingCourseQuizScore oTrainingCourseQuizScore = await db.TrainingCourseQuizScores.FindAsync(iTrainingCourseQuizId);
                return oTrainingCourseQuizScore;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<TrainingCourseQuizScore>> SaveToDB(List<TrainingCourseQuizScore> lstPatientInformation)
        {
            throw new NotImplementedException();
        }

        public async Task<TrainingCourseQuizScore> SaveToDB(TrainingCourseQuizScore oTrainingCourseQuizScore)
        {
            try
            {
                db.TrainingCourseQuizScores.Add(oTrainingCourseQuizScore);
                await db.SaveChangesAsync();
                return oTrainingCourseQuizScore;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TrainingCourseQuizScore> UpdateToDB(TrainingCourseQuizScore oTrainingCourseQuizScore, int iTrainingCourseQuizId)
        {
            try
            {
                if (iTrainingCourseQuizId != oTrainingCourseQuizScore.Id)
                    throw new Exception("Quiz ID's don't match");
                if (oTrainingCourseQuizScore == null)
                    throw new Exception("Training Course Quiz Scores Object is null or empty");

                db.Entry(oTrainingCourseQuizScore).State = EntityState.Modified;

                try
                {
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(iTrainingCourseQuizId))
                    {
                        throw new Exception("Quiz Scores Not Found");
                    }
                    else
                    {
                        throw;
                    }
                }

                return oTrainingCourseQuizScore;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TrainingCourseQuizScore> DeleteFromDB(int iTrainingCourseQuizId)
        {
            try
            {
                TrainingCourseQuizScore oTrainingCourseQuizScore = await db.TrainingCourseQuizScores.FindAsync(iTrainingCourseQuizId);
                if (oTrainingCourseQuizScore == null)
                {
                    throw new Exception("Quiz Scores Not Found");
                }

                db.TrainingCourseQuizScores.Remove(oTrainingCourseQuizScore);
                await db.SaveChangesAsync();

                return oTrainingCourseQuizScore;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        private bool CourseExists(int id)
        {
            return db.TrainingCourseQuizScores.Count(e => e.Id == id) > 0;
        }
    }
}