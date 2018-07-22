using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MGCTrainingPortalAPI.QuizDetails.Models
{
    public class QuizDetailsModel
    {
        public int quiz_question_id { get; set; }
        public string quiz_question_content { get; set; }
        public int quiz_user_selected_answer_id { get; set; }
        public string selected_answer_content { get; set; }
        public int correct_answer_id { get; set; }
        public string correct_answer_content { get; set; }
    }
}