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

        public async Task<TrainingCourseQuizScore> GradeQuiz(Quiz oQuiz)
        {
            try
            {
                QuizSheet oQuizSheet = await oQuizSheetRepo.SelectById(oQuiz.quiz_sheet.Id);
                TrainingCourseQuizScore oTrainingCourseQuizScore = new TrainingCourseQuizScore();

                if (oQuizSheet == null)
                {
                    throw new Exception("Quiz Sheet Doesn't Exist");
                }

                int iCorrectAnswerAmount = 0;
                int iWrongAnswerAmount = 0;
                int iTotalPossibleAnswers = oQuizQuestionRepo.SelectByCourseModuleQuiz(oQuiz.quiz_sheet.quiz_id.Value).Result.Count;
                List<QuizUserSelectedAnswer> lstWrongAnswers = new List<QuizUserSelectedAnswer>();
                List<QuizUserSelectedAnswer> lstCorrectAnswers = new List<QuizUserSelectedAnswer>();

                List<QuizUserSelectedAnswer> lstQuestionSelectedAnswers = oQuiz.selected_answers;

                foreach (QuizUserSelectedAnswer selectedAnswer in lstQuestionSelectedAnswers)
                {
                    QuizQuestionCorrectAnswer oQuestionCorrectAnswer =
                        await oQuizCorrectAnswerRepo.SelectByQuizQuestion(selectedAnswer.quiz_question_id.Value);

                    if (selectedAnswer.quiz_answer_option_id != oQuestionCorrectAnswer.quiz_answer_options_id)
                    {
                        lstWrongAnswers.Add(selectedAnswer);
                        iWrongAnswerAmount++;
                    }
                    else if (selectedAnswer.quiz_answer_option_id == oQuestionCorrectAnswer.quiz_answer_options_id)
                    {
                        lstCorrectAnswers.Add(selectedAnswer);
                        iCorrectAnswerAmount++;
                    }
                }

                oTrainingCourseQuizScore.quiz_correct_answers = iCorrectAnswerAmount;
                oTrainingCourseQuizScore.quiz_incorrect_answers = iWrongAnswerAmount;
                oTrainingCourseQuizScore.quiz_percentage = iCorrectAnswerAmount / iTotalPossibleAnswers;
                oTrainingCourseQuizScore.quiz_total_answers_possible = iTotalPossibleAnswers;
                oTrainingCourseQuizScore.date_added = DateTime.Now;

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