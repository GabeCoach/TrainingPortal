﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DB_A35BD0_trainingportaldbEntities : DbContext
    {
        public DB_A35BD0_trainingportaldbEntities()
            : base("name=DB_A35BD0_trainingportaldbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<OrganizationTrainingCours> OrganizationTrainingCourses { get; set; }
        public virtual DbSet<QuizQuestionAnswerOption> QuizQuestionAnswerOptions { get; set; }
        public virtual DbSet<QuizQuestionCorrectAnswer> QuizQuestionCorrectAnswers { get; set; }
        public virtual DbSet<QuizQuestion> QuizQuestions { get; set; }
        public virtual DbSet<QuizSheet> QuizSheets { get; set; }
        public virtual DbSet<QuizUserSelectedAnswer> QuizUserSelectedAnswers { get; set; }
        public virtual DbSet<TrainingCourse> TrainingCourses { get; set; }
        public virtual DbSet<TrainingCourseModule> TrainingCourseModules { get; set; }
        public virtual DbSet<TrainingCourseModuleQuiz> TrainingCourseModuleQuizs { get; set; }
        public virtual DbSet<TrainingCourseModuleSection> TrainingCourseModuleSections { get; set; }
        public virtual DbSet<TrainingCourseModuleSubSection> TrainingCourseModuleSubSections { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<TrainingCourseQuizScore> TrainingCourseQuizScores { get; set; }
    }
}
