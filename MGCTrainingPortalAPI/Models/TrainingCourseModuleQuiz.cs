//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MGCTrainingPortalAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TrainingCourseModuleQuiz
    {
        public int Id { get; set; }
        public int training_course_module_id { get; set; }
        public string training_course_module_quiz_name { get; set; }
        public string training_course_module_quiz_description { get; set; }
        public System.DateTime date_added { get; set; }
        public Nullable<System.DateTime> date_updated { get; set; }
    }
}