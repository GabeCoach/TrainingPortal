using System;
using System.Collections.Generic;
using System.Text;
using MGCTrainingPortalAPI;

namespace MGCTrainingPortalAPI.CourseBuilder
{
    public class FullTrainingCourse
    {
        public TrainingCourse training_course_information { get; set; }
        public Dictionary<int, TrainingCourseModule> training_course_modules { get; set; }
        public Dictionary<int, TrainingCourseModuleQuiz> training_course_module_quizs { get; set; }
        public Dictionary<int, TrainingCourseModuleSection> training_course_module_sub_sections { get; set; }
        public Dictionary<int, TrainingCourseModuleSection> training_course_module_sections { get; set; }
        public Dictionary<int, TrainingCourseQuizScore> training_course_quiz_scores { get; set; }
        public Dictionary<int, QuizQuestion> quiz_questions { get; set; }
        public Dictionary<int, QuizQuestionAnswerOption> quiz_answer_options { get; set; }
        public Dictionary<int, QuizQuestionCorrectAnswer> quiz_question_correct_answers { get; set; }
    }
}
