using MGCTrainingPortalAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MGCTrainingPortalAPI.QuizGrader.Models
{
    public class Quiz
    {
        public QuizSheet quiz_sheet { get; set; }
        public List<QuizUserSelectedAnswer> selected_answers { get; set; }
    }
}