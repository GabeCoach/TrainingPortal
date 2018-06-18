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

namespace MGCTrainingPortalAPI.Repository
{
    public class TrainingCourseModuleSubSectionRepository
    {
        private DB_A35BD0_trainingportaldbEntities db = new DB_A35BD0_trainingportaldbEntities();
        private Logger.Logger oLogger = new Logger.Logger();

        public IQueryable<TrainingCourseModuleSubSection> SelectAllFromDB()
        {
            try
            {
                IQueryable<TrainingCourseModuleSubSection> oTrainingCourseModuleSubSection = from a in db.TrainingCourseModuleSubSections
                                                                         select a;

                return oTrainingCourseModuleSubSection;
            }
            catch (Exception ex)
            {
                oLogger.LogData("METHOD: SelectAllFromDB; REPO: TrainingCourseModuleSubSection; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException + "; STACKTRACE: " + ex.StackTrace);
                throw new Exception(ex.Message);
            }
        }

        public async Task<TrainingCourseModuleSubSection> SelectById(int iTrainingCourseModuleSectionId)
        {
            try
            {
                TrainingCourseModuleSubSection oTrainingCourseModuleSubSection = await db.TrainingCourseModuleSubSections.FindAsync(iTrainingCourseModuleSectionId);
                return oTrainingCourseModuleSubSection;
            }
            catch (Exception ex)
            {
                oLogger.LogData("METHOD: SelectById; REPO: TrainingCourseModuleSubSection; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException + "; STACKTRACE: " + ex.StackTrace);
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<TrainingCourseModuleSubSection>> SaveToDB(List<TrainingCourseModuleSubSection> lstTrainingCourseModuleSubSections)
        {
            throw new NotImplementedException();
        }

        public async Task<TrainingCourseModuleSubSection> SaveToDB(TrainingCourseModuleSubSection oTrainingCourseModuleSubSection)
        {
            try
            {
                db.TrainingCourseModuleSubSections.Add(oTrainingCourseModuleSubSection);
                await db.SaveChangesAsync();
                return oTrainingCourseModuleSubSection;
            }
            catch (Exception ex)
            {
                oLogger.LogData("METHOD: SaveToDB; REPO: TrainingCourseModuleSubSection; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException + "; STACKTRACE: " + ex.StackTrace);
                throw new Exception(ex.Message);
            }
        }

        public async Task<TrainingCourseModuleSubSection> UpdateToDB(TrainingCourseModuleSubSection oTrainingCourseModuleSubSection, int iTrainingCourseModuleSectionId)
        {
            try
            {
                if (iTrainingCourseModuleSectionId != oTrainingCourseModuleSubSection.Id)
                    throw new Exception("Course ID's don't match");
                if (oTrainingCourseModuleSubSection == null)
                    throw new Exception("Training Course Object is null or empty");

                db.Entry(oTrainingCourseModuleSubSection).State = EntityState.Modified;

                try
                {
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModuleExists(iTrainingCourseModuleSectionId))
                    {
                        throw new Exception("Course Not Found");
                    }
                    else
                    {
                        throw;
                    }
                }

                return oTrainingCourseModuleSubSection;
            }
            catch (Exception ex)
            {
                oLogger.LogData("METHOD: UpdateToDB; REPO: TrainingCourseModuleSubSection; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException + "; STACKTRACE: " + ex.StackTrace);
                throw new Exception(ex.Message);
            }
        }

        public async Task<TrainingCourseModuleSubSection> DeleteFromDB(int iModuleId)
        {
            try
            {
                TrainingCourseModuleSubSection oTrainingCourseModuleSubSection = await db.TrainingCourseModuleSubSections.FindAsync(iModuleId);
                if (oTrainingCourseModuleSubSection == null)
                {
                    throw new Exception("Appointment Not Found");
                }

                db.TrainingCourseModuleSubSections.Remove(oTrainingCourseModuleSubSection);
                await db.SaveChangesAsync();

                return oTrainingCourseModuleSubSection;
            }
            catch (Exception ex)
            {
                oLogger.LogData("METHOD: DeleteFromDB; REPO: TrainingCourseModuleSubSection; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException + "; STACKTRACE: " + ex.StackTrace);
                throw new Exception(ex.Message);
            }

        }

        public async Task<List<TrainingCourseModuleSubSection>> SelectByTrainingCourseModuleSection(int iTrainingCourseModuleSectionId)
        {
            try
            {
                List<TrainingCourseModuleSubSection> lstTrainingCourseModuleSubSections = await
                            (from tcmss in db.TrainingCourseModuleSubSections
                             where tcmss.module_section_id == iTrainingCourseModuleSectionId
                             select tcmss).ToListAsync();

                return lstTrainingCourseModuleSubSections;
            }
            catch (Exception ex)
            {
                oLogger.LogData("METHOD: SelectByTrainingCourseModuleSubSection; REPO: TrainingCourseModuleSubSection; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException + "; STACKTRACE: " + ex.StackTrace);
                throw new Exception(ex.Message);
            }
        }

        private bool ModuleExists(int id)
        {
            return db.TrainingCourseModuleSubSections.Count(e => e.Id == id) > 0;
        }
    }
}
