using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MGCTrainingPortalAPI.Repository.HelperModels
{
    public class UserSelectedAnswerOptionHelper
    {
        public int user_selected_option_id { get; set; }
        public string user_selected_option_content { get; set; }
        public int quiz_question_id { get; set; }
    }
}