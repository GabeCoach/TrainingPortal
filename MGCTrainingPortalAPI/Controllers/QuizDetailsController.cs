using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using MGCTrainingPortalAPI.Repository;
using MGCTrainingPortalAPI.Models;
using MGCTrainingPortalAPI.Repository.HelperModels;
using MGCTrainingPortalAPI.QuizDetails.Models;

namespace MGCTrainingPortalAPI.Controllers
{
    [Authorize]
    public class QuizDetailsController : ApiController
    {
        private QuizUserSelectedAnswerRepository oUserAnswersRepo = new QuizUserSelectedAnswerRepository();
        private QuizQuestionCorrectAnswerRepository oQuizCorrectAnswerRepo = new QuizQuestionCorrectAnswerRepository();
        private QuizQuestionsRepository oQuizQuestionRepo = new QuizQuestionsRepository();
        private QuizQuestionAnswerOptionsRepository oAnswerOptionRepo = new QuizQuestionAnswerOptionsRepository();
        private Logger.Logger oLogger = new Logger.Logger();

        [HttpGet]
        [Route("api/QuizDetails/{iQuizSheetId}")]
        public async Task<IHttpActionResult> GetQuizDetails(int iQuizSheetId)
        {
            string sIPAddress = Request.GetOwinContext().Request.RemoteIpAddress;

            try
            {
                List<UserSelectedAnswerOptionHelper> lstUserAnswers = await oUserAnswersRepo.GetSelectedAnswersByQuizSheet(iQuizSheetId);
                List<CorrentAnswerOptionHelper> lstCorrectAnswers = await oQuizCorrectAnswerRepo.SelectCorrectAnswersByQuizSheet(iQuizSheetId);
                List<QuizQuestion> lstQuizuestions = await oQuizQuestionRepo.SelectByQuizSheet(iQuizSheetId);
                List<QuizDetailsModel> lstQuizDetails = new List<QuizDetailsModel>();
                
                foreach(var question in lstQuizuestions)
                {
                    QuizDetailsModel oQuizDetails = new QuizDetailsModel();
                    oQuizDetails.quiz_question_id = question.Id;
                    oQuizDetails.quiz_question_content = question.question;

                    var oCorrectAnswer = lstCorrectAnswers
                        .Where(x => x.quiz_question_id == question.Id)
                        .Select(x => x)
                        .SingleOrDefault();

                    oQuizDetails.correct_answer_id = oCorrectAnswer.correct_answer_option_id;
                    oQuizDetails.correct_answer_content = await oAnswerOptionRepo.SelectContentOnlyById(oQuizDetails.correct_answer_id);

                    var oSelectedAnswer = lstUserAnswers
                        .Where(x => x.quiz_question_id == question.Id)
                        .Select(x => x)
                        .SingleOrDefault();

                    oQuizDetails.quiz_user_selected_answer_id = oSelectedAnswer.user_selected_option_id;
                    oQuizDetails.selected_answer_content = await oAnswerOptionRepo.SelectContentOnlyById(oQuizDetails.quiz_user_selected_answer_id);

                    lstQuizDetails.Add(oQuizDetails);
                }

                oLogger.LogData("ROUTE: api/TrainingCourseQuizScores; METHOD: GET; IP_ADDRESS: " + sIPAddress);
                return Json(lstQuizDetails);
            }
            catch (Exception ex)
            {
                oLogger.LogData("ROUTE: api/QuizQuestionAnswerOptions; METHOD: GET; IP_ADDRESS: " + sIPAddress + "; EXCEPTION: " + ex.Message + "; INNER EXCEPTION: " + ex.InnerException);
                return InternalServerError();
            }
        }
    }
}
