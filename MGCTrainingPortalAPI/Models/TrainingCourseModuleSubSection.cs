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
    
    public partial class TrainingCourseModuleSubSection
    {
        public int Id { get; set; }
        public Nullable<int> module_section_id { get; set; }
        public string module_sub_section_number { get; set; }
        public string module_sub_section_name { get; set; }
        public string module_sub_section_content { get; set; }
        public System.DateTime date_added { get; set; }
        public Nullable<System.DateTime> date_updated { get; set; }
    }
}