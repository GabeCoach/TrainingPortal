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
    
    public partial class QuizQuestionAnswerOption
    {
        public int Id { get; set; }
        public Nullable<int> quiz_question_id { get; set; }
        public string answer_option { get; set; }
        public Nullable<System.DateTime> date_added { get; set; }
        public Nullable<System.DateTime> date_updated { get; set; }
    }
}