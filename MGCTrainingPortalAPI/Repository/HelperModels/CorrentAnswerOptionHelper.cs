using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MGCTrainingPortalAPI.Repository.HelperModels
{
    public class CorrentAnswerOptionHelper
    {
        public int correct_answer_option_id { get; set; }
        public string correct_answer_option_content { get; set; }
        public int quiz_question_id { get; set; }
    }
}