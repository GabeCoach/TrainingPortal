﻿using System;
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
    public class TrainingCourseModuleQuizsRepository : IRepository<TrainingCourseModuleQuiz>
    {
        private DB_A35BD0_trainingportaldbEntities db = new DB_A35BD0_trainingportaldbEntities();
        private Logger.Logger oLogger = new Logger.Logger();

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
                oLogger.LogData("METHOD: SelectAllFromDB; REPO: TrainingCourseModuleQuiz; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException + "; STACKTRACE: " + ex.StackTrace);
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

        public async Task<TrainingCourseModuleQuiz> SelectByTrainingCourseModule(int iTrainingCourseModuleId)
        {
            try
            {
               TrainingCourseModuleQuiz oTrainingCourseModuleQuizs =
                    await (from tcmq in db.TrainingCourseModuleQuizs
                     where tcmq.training_course_module_id == iTrainingCourseModuleId
                     select tcmq).FirstAsync();

                return oTrainingCourseModuleQuizs;
            }
            catch(Exception ex)
            {
                oLogger.LogData("METHOD: SelectByTrainingCourseModule; REPO: TrainingCourseModuleQuiz; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException + "; STACKTRACE: " + ex.StackTrace);
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
                oLogger.LogData("METHOD: SaveToDB; REPO: TrainingCourseModuleQuiz; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException + "; STACKTRACE: " + ex.StackTrace);
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
                oLogger.LogData("METHOD: UpdateToDB; REPO: TrainingCourseModuleQuiz; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException + "; STACKTRACE: " + ex.StackTrace);
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
                oLogger.LogData("METHOD: DeleteFromDB; REPO: TrainingCourseModuleQuiz; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException + "; STACKTRACE: " + ex.StackTrace);
                throw new Exception(ex.Message);
            }

        }

        public async Task<TrainingCourseModuleQuiz> SelectByCourseModule(int iCourseModuleId)
        {
            try
            {
                TrainingCourseModuleQuiz quiz = await (from q in db.TrainingCourseModuleQuizs
                                                where q.training_course_module_id == iCourseModuleId
                                                select q).FirstOrDefaultAsync();

                return quiz;
            }
            catch(Exception ex)
            {
                oLogger.LogData("METHOD: SelectByCourseModule; REPO: TrainingCourseModuleQuiz; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException + "; STACKTRACE: " + ex.StackTrace);
                throw new Exception(ex.Message);
            }

            
        }

        private bool QuizExists(int id)
        {
            return db.TrainingCourseModuleQuizs.Count(e => e.Id == id) > 0;
        }
    }
}