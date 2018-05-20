using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using MGCTrainingPortalAPI.Interfaces;
using MGCTrainingPortalAPI.Models;

namespace MGCTrainingPortalAPI.Repository
{
    public class TrainingCourseModuleRepository: IRepository<TrainingCourseModule>
    {
        private DB_A35BD0_trainingportaldbEntities db = new DB_A35BD0_trainingportaldbEntities();

        public IQueryable<TrainingCourseModule> SelectAllFromDB()
        {
            try
            {
                IQueryable<TrainingCourseModule> oTrainingCourseModule = from a in db.TrainingCourseModules
                                                             select a;

                return oTrainingCourseModule;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TrainingCourseModule> SelectById(int iCourseId)
        {
            try
            {
                TrainingCourseModule oTrainingCourseModule = await db.TrainingCourseModules.FindAsync(iCourseId);
                return oTrainingCourseModule;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<TrainingCourseModule>> SaveToDB(List<TrainingCourseModule> lstTrainingCourseModules)
        {
            throw new NotImplementedException();
        }

        public async Task<TrainingCourseModule> SaveToDB(TrainingCourseModule oTrainingCourseModule)
        {
            try
            {
                db.TrainingCourseModules.Add(oTrainingCourseModule);
                await db.SaveChangesAsync();
                return oTrainingCourseModule;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TrainingCourseModule> UpdateToDB(TrainingCourseModule oTrainingCourseModule, int iModuleId)
        {
            try
            {
                if (iModuleId != oTrainingCourseModule.Id)
                    throw new Exception("Course ID's don't match");
                if (oTrainingCourseModule == null)
                    throw new Exception("Training Course Object is null or empty");

                db.Entry(oTrainingCourseModule).State = EntityState.Modified;

                try
                {
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModuleExists(iModuleId))
                    {
                        throw new Exception("Course Not Found");
                    }
                    else
                    {
                        throw;
                    }
                }

                return oTrainingCourseModule;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TrainingCourseModule> DeleteFromDB(int iModuleId)
        {
            try
            {
                TrainingCourseModule oTrainingCourseModule = await db.TrainingCourseModules.FindAsync(iModuleId);
                if (oTrainingCourseModule == null)
                {
                    throw new Exception("Appointment Not Found");
                }

                db.TrainingCourseModules.Remove(oTrainingCourseModule);
                await db.SaveChangesAsync();

                return oTrainingCourseModule;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<List<TrainingCourseModule>> SelectByTrainingCourse(int iTrainingCourseId)
        {
            try
            {

                var query = from t in db.TrainingCourseModules
                            where t.training_course_id == iTrainingCourseId
                            select t;

                return await query.ToListAsync();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private bool ModuleExists(int id)
        {
            return db.TrainingCourseModules.Count(e => e.Id == id) > 0;
        }
    }
}