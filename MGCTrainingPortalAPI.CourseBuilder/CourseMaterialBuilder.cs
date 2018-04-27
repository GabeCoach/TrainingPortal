using System;
using System.Collections.Generic;
using System.Text;
using MGCTrainingPortalAPI.Repository;
using MGCTrainingPortalAPI.Models;
using System.Threading.Tasks;
using System.Data.Entity;


namespace MGCTrainingPortalAPI.CourseBuilder
{
    class CourseMaterialBuilder
    {
        private TrainingCoursesRepository oTrainingCourseRepo = new TrainingCoursesRepository();
        private FullTrainingCourse oFullTrainingCourse = new FullTrainingCourse();
        private TrainingCourseModuleRepository oTrainingCourseModuleRepo = new TrainingCourseModuleRepository();
        private TrainingCourseModuleQuizsRepository oTrainingCourseModuleQuizRepo = new TrainingCourseModuleQuizsRepository();
        private QuizQuestionsRepository oQuizQuestionRepo = new QuizQuestionsRepository();

        public async Task<FullTrainingCourse> GetFullTrainingCourse(int iTrainingCourseId)
        {
            TrainingCourse oTrainingCourse = await oTrainingCourseRepo.SelectById(iTrainingCourseId);
            oFullTrainingCourse.training_course_information = oTrainingCourse;

            List<TrainingCourseModule> lstTrainingCourseModules = await oTrainingCourseModuleRepo.SelectByTrainingCourse(oTrainingCourse.Id);
            oFullTrainingCourse.training_course_modules = lstTrainingCourseModules;

            List<int> lstTrainingCourseModuleIds = await GetTrainingCourseModulesIds(iTrainingCourseId);
            Dictionary<int, QuizQuestion> lstQuizQuestions = new Dictionary<int, QuizQuestion>();

            foreach(int trainingCourseModuleId in lstTrainingCourseModuleIds)
            {
                    
            }

            oFullTrainingCourse.training_course_module_quizs = lstTrainingCourseModuleQuiz;

            List<QuizQuestion> lstQuizQuestions = await oQuizQuestionRepo.SelectByCourseModuleQuiz();

            
            
            
        }


        #region Helper Methods
        private async Task<List<int>> GetTrainingCourseModulesIds(int iTrainingModuleId)
        {
            try
            {
                List<int> lstTrainingCourseModuleIds = new List<int>();
                List<TrainingCourseModule> lstTrainingCourseModule = await oTrainingCourseModuleRepo.SelectByTrainingCourse(iTrainingModuleId);

                foreach(TrainingCourseModule trainingCourseModule in lstTrainingCourseModule)
                {
                    lstTrainingCourseModuleIds.Add(trainingCourseModule.Id);
                }

                return lstTrainingCourseModuleIds;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }        
        }
        #endregion
    }
}
