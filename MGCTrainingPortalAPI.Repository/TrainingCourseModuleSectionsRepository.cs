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
    public class TrainingCourseModuleSectionsRepository : IRepository<TrainingCourseModuleSection>
    {
        private DB_A35BD0_trainingportaldbEntities db = new DB_A35BD0_trainingportaldbEntities();

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
                throw new Exception(ex.Message);
            }

        }

        private bool SectionExists(int id)
        {
            return db.TrainingCourseModuleSections.Count(e => e.Id == id) > 0;
        }
    }
}