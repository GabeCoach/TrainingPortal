using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MGCTrainingPortalAPI.Models;

namespace MGCTrainingPortalAPI.QuizGrader
{
    public class QuizGrader
    {
        public QuizSheet quiz_sheet { get; set; }
        public List<QuizUserSelectedAnswer> selected_answers { get; set; }
    }
}