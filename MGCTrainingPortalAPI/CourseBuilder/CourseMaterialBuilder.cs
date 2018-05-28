using System;
using System.Collections.Generic;
using System.Text;
using MGCTrainingPortalAPI.Repository;
using MGCTrainingPortalAPI.Models;
using System.Threading.Tasks;
using System.Data.Entity;


namespace MGCTrainingPortalAPI.CourseBuilder
{
    public class CourseMaterialBuilder
    {
        private TrainingCoursesRepository oTrainingCourseRepo = new TrainingCoursesRepository();
        private FullTrainingCourse oFullTrainingCourse = new FullTrainingCourse();
        private TrainingCourseModuleRepository oTrainingCourseModuleRepo = new TrainingCourseModuleRepository();
        private TrainingCourseModuleQuizsRepository oTrainingCourseModuleQuizRepo = new TrainingCourseModuleQuizsRepository();
        private QuizQuestionsRepository oQuizQuestionRepo = new QuizQuestionsRepository();
        private QuizQuestionAnswerOptionsRepository oQuizQuestionAnswerOptionRepo = new QuizQuestionAnswerOptionsRepository();

        //public async Task<FullTrainingCourse> GetFullTrainingCourse(int iTrainingCourseId)
        //{
        //    //TrainingCourse oTrainingCourse = await oTrainingCourseRepo.SelectById(iTrainingCourseId);
        //    //oFullTrainingCourse.training_course_information = oTrainingCourse;

        //    ////Dictionary<int, TrainingCourseModule> dctTrainingCourseModules = await oTrainingCourseModuleRepo.SelectByTrainingCourse(oTrainingCourse.Id);
        //    ////oFullTrainingCourse.training_course_modules = dctTrainingCourseModules;

        //    ////Add Training Course Module Ids from dctTrainingCourseModules to a List of integers
        //    ////List<int> lstTrainingCourseModuleIds = new List<int>();

        //    ////foreach (KeyValuePair<int, TrainingCourseModule> module in dctTrainingCourseModules)
        //    ////{
        //    ////    lstTrainingCourseModuleIds.Add(module.Value.Id);
        //    ////}

        //    ////Retrieve TrainingCourseModule Quizs and Add them to a dictionary
        //    //Dictionary<int, TrainingCourseModuleQuiz> dctTrainingCourseModuleQuizs = new Dictionary<int, TrainingCourseModuleQuiz>();

        //    //foreach (int iModuleId in lstTrainingCourseModuleIds)
        //    //{
        //    //    dctTrainingCourseModuleQuizs.Add(iModuleId, await oTrainingCourseModuleQuizRepo.SelectById(iModuleId));
        //    //}

        //    //oFullTrainingCourse.training_course_module_quizs = dctTrainingCourseModuleQuizs;

        //    //List<int> lstTrainingCourseModuleQuizIds = new List<int>();

        //    //foreach (KeyValuePair<int, TrainingCourseModuleQuiz> quiz in dctTrainingCourseModuleQuizs)
        //    //{
        //    //    lstTrainingCourseModuleQuizIds.Add(quiz.Value.Id);
        //    //}

        //    //Dictionary<int, QuizQuestion> dctQuizQuestions = new Dictionary<int, QuizQuestion>();

        //    //foreach (int iQuizId in lstTrainingCourseModuleQuizIds)
        //    //{
        //    //    List<QuizQuestion> lstQuizQuestions = await oQuizQuestionRepo.SelectByCourseModuleQuiz(iQuizId);

        //    //    foreach (var QuizQuestion in lstQuizQuestions)
        //    //    {
        //    //        dctQuizQuestions.Add(iQuizId, QuizQuestion);
        //    //    }
        //    //}

        //    //oFullTrainingCourse.quiz_questions = dctQuizQuestions;

        //    //List<int> lstQuizQuestionIds = new List<int>();

        //    //foreach (KeyValuePair<int, QuizQuestion> quizQuestions in dctQuizQuestions)
        //    //{
        //    //    lstQuizQuestionIds.Add(quizQuestions.Value.Id);
        //    //}

        //    //Dictionary<int, QuizQuestionAnswerOption> dctQuizQuestionAnswerOptions = new Dictionary<int, QuizQuestionAnswerOption>();

        //    //foreach (int iQuizQuestionId in lstQuizQuestionIds)
        //    //{
        //    //    List<QuizQuestionAnswerOption> lstQuizQuestionAnswerOption = await oQuizQuestionAnswerOptionRepo.SelectByQuizQuestion(iQuizQuestionId);

        //    //    foreach (QuizQuestionAnswerOption oQuizQuestionAnswerOption in lstQuizQuestionAnswerOption)
        //    //    {
        //    //        dctQuizQuestionAnswerOptions.Add(iQuizQuestionId, oQuizQuestionAnswerOption);
        //    //    }
        //    //}

        //    //oFullTrainingCourse.quiz_answer_options = dctQuizQuestionAnswerOptions;

        //    //return oFullTrainingCourse;
        //}


        #region Helper Methods

        #endregion
    }
}
