using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MGCTrainingPortalAPI.Interfaces;
using MGCTrainingPortalAPI.Models;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using MGCTrainingPortalAPI.Logger;

namespace MGCTrainingPortalAPI.Repository
{
    public class TrainingCourseModuleSectionsRepository : IRepository<TrainingCourseModuleSection>
    {
        private DB_A35BD0_trainingportaldbEntities db = new DB_A35BD0_trainingportaldbEntities();
        private Logger.Logger oLogger = new Logger.Logger();

        public IQueryable<TrainingCourseModuleSection> SelectAllFromDB()
        {
            try
            {
                IQueryable<TrainingCourseModuleSection> oTrainingCourseModuleSection = from a in db.TrainingCourseModuleSections
                                                                         select a;

                return oTrainingCourseModuleSection;
            }
            catch (Exception ex)
            {
                oLogger.LogData("METHOD: SelectAllFromDB; REPO: TrainingCourseModuleSection; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException + "; STACKTRACE: " + ex.StackTrace);
                throw new Exception(ex.Message);
            }
        }

        public async Task<TrainingCourseModuleSection> SelectById(int iModuleSectionId)
        {
            try
            {
                TrainingCourseModuleSection oTrainingCourseModuleSection = await db.TrainingCourseModuleSections.FindAsync(iModuleSectionId);
                return oTrainingCourseModuleSection;
            }
            catch (Exception ex)
            {
                oLogger.LogData("METHOD: SelectById; REPO: TrainingCourseModuleSection; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException + "; STACKTRACE: " + ex.StackTrace);
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<TrainingCourseModuleSection>> SelectByTrainingCourseModule(int iTrainingCourseModuleId)
        {
            try
            {
                List<TrainingCourseModuleSection> lstTrainingCourseModuleSections = await (from tcms in db.TrainingCourseModuleSections
                                                                                           where tcms.training_course_module_id == iTrainingCourseModuleId
                                                                                           select tcms).ToListAsync();

                return lstTrainingCourseModuleSections;
            }
            catch(Exception ex)
            {
                oLogger.LogData("METHOD: SelectByTrainingCourseModule; REPO: TrainingCourseModuleSection; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException + "; STACKTRACE: " + ex.StackTrace);
                throw new Exception(ex.Message);
            }
            
        }

        public async Task<List<TrainingCourseModuleSection>> SaveToDB(List<TrainingCourseModuleSection> lstTrainingCourseModuleSections)
        {
            throw new NotImplementedException();
        }

        public async Task<TrainingCourseModuleSection> SaveToDB(TrainingCourseModuleSection oTrainingCourseModuleSection)
        {
            try
            {
                db.TrainingCourseModuleSections.Add(oTrainingCourseModuleSection);
                await db.SaveChangesAsync();
                return oTrainingCourseModuleSection;
            }
            catch (Exception ex)
            {
                oLogger.LogData("METHOD: SaveToDB; REPO: TrainingCourseModuleSection; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException + "; STACKTRACE: " + ex.StackTrace);
                throw new Exception(ex.Message);
            }
        }

        public async Task<TrainingCourseModuleSection> UpdateToDB(TrainingCourseModuleSection oTrainingCourseModuleSection, int iModuleSectionId)
        {
            try
            {
                if (iModuleSectionId != oTrainingCourseModuleSection.Id)
                    throw new Exception("Section ID's don't match");
                if (oTrainingCourseModuleSection == null)
                    throw new Exception("Module Section Object is null or empty");

                db.Entry(oTrainingCourseModuleSection).State = EntityState.Modified;

                try
                {
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SectionExists(iModuleSectionId))
                    {
                        throw new Exception("Module Section Not Found");
                    }
                    else
                    {
                        throw;
                    }
                }

                return oTrainingCourseModuleSection;
            }
            catch (Exception ex)
            {
                oLogger.LogData("METHOD: UpdateToDB; REPO: TrainingCourseModuleSection; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException + "; STACKTRACE: " + ex.StackTrace);
                throw new Exception(ex.Message);
            }
        }

        public async Task<TrainingCourseModuleSection> DeleteFromDB(int iModuleId)
        {
            try
            {
                TrainingCourseModuleSection oTrainingCourseModuleSection = await db.TrainingCourseModuleSections.FindAsync(iModuleId);
                if (oTrainingCourseModuleSection == null)
                {
                    throw new Exception("Appointment Not Found");
                }

                db.TrainingCourseModuleSections.Remove(oTrainingCourseModuleSection);
                await db.SaveChangesAsync();

                return oTrainingCourseModuleSection;
            }
            catch (Exception ex)
            {
                oLogger.LogData("METHOD: DeleteFromDB; REPO: TrainingCourseModuleSection; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException + "; STACKTRACE: " + ex.StackTrace);
                throw new Exception(ex.Message);
            }

        }

        private bool SectionExists(int id)
        {
            return db.TrainingCourseModuleSections.Count(e => e.Id == id) > 0;
        }
    }
}