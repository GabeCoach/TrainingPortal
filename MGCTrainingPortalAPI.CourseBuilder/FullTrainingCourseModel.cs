using System;
using System.Collections.Generic;
using System.Text;
using MGCTrainingPortalAPI.Models;

namespace MGCTrainingPortalAPI.CourseBuilder
{
    class FullTrainingCourse
    {
        public TrainingCourse training_course_information { get; set; }
        public List<TrainingCourseModule> training_course_modules { get; set; }
        public List<TrainingCourseModuleQuiz> training_course_module_quizs { get; set; }
        public List<TrainingCourseModuleSection> training_course_module_sub_sections { get; set; }
        public List<TrainingCourseModuleSection> training_course_module_sections { get; set; }
        public List<TrainingCourseQuizScore> training_course_quiz_scores { get; set; }
        public List<QuizQuestion> quiz_questions { get; set; }
        public List<QuizQuestionAnswerOption> quiz_answer_options { get; set; }
        public List<QuizQuestionCorrectAnswer> quiz_question_correct_answers { get; set; }
    }
}
