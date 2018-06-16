using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MGCTrainingPortalAPI.Models;
using MGCTrainingPortalAPI.QuizGrader.Models;
using System.Threading.Tasks;
using System.Data.Entity;
using MGCTrainingPortalAPI.Repository;

namespace MGCTrainingPortalAPI.QuizGrader
{
    public class QuizGrader
    {
        private QuizSheetRepository oQuizSheetRepo = new QuizSheetRepository();
        private QuizQuestionCorrectAnswerRepository oQuizCorrectAnswerRepo = new QuizQuestionCorrectAnswerRepository();
        private QuizQuestionsRepository oQuizQuestionRepo = new QuizQuestionsRepository();
        private TrainingCourseQuizScoreQuizScoresRepository oTrainingCourseQuizScoreRepo = new TrainingCourseQuizScoreQuizScoresRepository();
        private QuizUserSelectedAnswerRepository oQuizUserSelectedAnswerRepo = new QuizUserSelectedAnswerRepository();
        private QuizQuestionAnswerOptionsRepository oAnswerOptionRepo = new QuizQuestionAnswerOptionsRepository();

        public async Task<TrainingCourseQuizScore> GradeQuiz(List<QuizUserSelectedAnswer> lstSelectedAnswers)
        {
            try
            {
                TrainingCourseQuizScore oTrainingCourseQuizScore = new TrainingCourseQuizScore();

                int iCorrectAnswerAmount = 0;
                int iWrongAnswerAmount = 0;
                
                List<QuizUserSelectedAnswer> lstWrongAnswers = new List<QuizUserSelectedAnswer>();
                List<QuizUserSelectedAnswer> lstCorrectAnswers = new List<QuizUserSelectedAnswer>();
                int iTotalPossibleAnswers = 0;
                QuizSheet oQuizSheet = null;

                foreach (QuizUserSelectedAnswer answer in lstSelectedAnswers)
                {
                    
                    oQuizSheet = await oQuizSheetRepo.SelectById(answer.quiz_sheet_id.Value);

                    if (oQuizSheet == null)
                    {
                        throw new Exception("Quiz Sheet Doesn't Exist");
                    }

                    var oPossibleAnswers = await oQuizQuestionRepo.SelectByCourseModuleQuiz(oQuizSheet.quiz_id.Value);
                    iTotalPossibleAnswers = oPossibleAnswers.Count;
                    List<QuizUserSelectedAnswer> lstQuestionSelectedAnswers = lstSelectedAnswers;

                    QuizQuestionAnswerOption oSelectedAnswerOption =
                        await oAnswerOptionRepo.SelectById(answer.quiz_answer_option_id.Value);

                    QuizQuestion oCurrentQuizQuestion = await oQuizQuestionRepo.SelectById(oSelectedAnswerOption.quiz_question_id.Value);

                    QuizQuestionCorrectAnswer oQuestionCorrectAnswer = await oQuizCorrectAnswerRepo.SelectByQuizQuestion(oSelectedAnswerOption.quiz_question_id.Value);

                    if (answer.quiz_answer_option_id != oQuestionCorrectAnswer.quiz_answer_options_id)
                    {
                        lstWrongAnswers.Add(answer);
                        iWrongAnswerAmount++;
                    }
                    else if (answer.quiz_answer_option_id == oQuestionCorrectAnswer.quiz_answer_options_id)
                    {
                        lstCorrectAnswers.Add(answer);
                        iCorrectAnswerAmount++;
                    }
                }

                oTrainingCourseQuizScore.quiz_correct_answers = iCorrectAnswerAmount;
                oTrainingCourseQuizScore.quiz_incorrect_answers = iWrongAnswerAmount;
                oTrainingCourseQuizScore.quiz_percentage = (float)iCorrectAnswerAmount / (float)iTotalPossibleAnswers;
                oTrainingCourseQuizScore.quiz_total_answers_possible = iTotalPossibleAnswers;
                oTrainingCourseQuizScore.date_added = DateTime.Now.Date;
                oTrainingCourseQuizScore.quiz_sheet_id = oQuizSheet.Id;

                await oTrainingCourseQuizScoreRepo.SaveToDB(oTrainingCourseQuizScore);

                return oTrainingCourseQuizScore;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}