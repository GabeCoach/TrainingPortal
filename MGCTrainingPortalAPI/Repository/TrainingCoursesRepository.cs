using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MGCTrainingPortalAPI.Interfaces;
using MGCTrainingPortalAPI.Models;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace MGCTrainingPortalAPI.Repository
{
    public class TrainingCoursesRepository : IRepository<TrainingCourse>
    {
        private DB_A35BD0_trainingportaldbEntities db = new DB_A35BD0_trainingportaldbEntities();

        public IQueryable<TrainingCourse> SelectAllFromDB()
        {
            try
            {
                IQueryable<TrainingCourse> oTrainingCourse = from a in db.TrainingCourses
                                                      select a;

                return oTrainingCourse;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TrainingCourse> SelectById(int iCourseId)
        {
            try
            {
                TrainingCourse oTrainingCourse = await db.TrainingCourses.FindAsync(iCourseId);
                return oTrainingCourse;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<TrainingCourse>> SaveToDB(List<TrainingCourse> lstPatientInformation)
        {
            throw new NotImplementedException();
        }

        public async Task<TrainingCourse> SaveToDB(TrainingCourse oTrainingCourse)
        {
            try
            {
                db.TrainingCourses.Add(oTrainingCourse);
                await db.SaveChangesAsync();
                return oTrainingCourse;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TrainingCourse> UpdateToDB(TrainingCourse oTrainingCourse, int iCourseId)
        {
            try
            {
                if (iCourseId != oTrainingCourse.Id)
                    throw new Exception("Course ID's don't match");
                if (oTrainingCourse == null)
                    throw new Exception("Training Course Object is null or empty");

                db.Entry(oTrainingCourse).State = EntityState.Modified;

                try
                {
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(iCourseId))
                    {
                        throw new Exception("Course Not Found");
                    }
                    else
                    {
                        throw;
                    }
                }

                return oTrainingCourse;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TrainingCourse> DeleteFromDB(int iCourseId)
        {
            try
            {
                TrainingCourse oTrainingCourse = await db.TrainingCourses.FindAsync(iCourseId);
                if (oTrainingCourse == null)
                {
                    throw new Exception("Appointment Not Found");
                }

                db.TrainingCourses.Remove(oTrainingCourse);
                await db.SaveChangesAsync();

                return oTrainingCourse;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        private bool CourseExists(int id)
        {
            return db.TrainingCourses.Count(e => e.Id == id) > 0;
        }
    }
}