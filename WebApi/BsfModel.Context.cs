﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApi
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BsfEntities : DbContext
    {
        public BsfEntities()
            : base("name=BsfEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Attedence> Attedences { get; set; }
        public virtual DbSet<bible_book_name> bible_book_name { get; set; }
        public virtual DbSet<bible_context> bible_context { get; set; }
        public virtual DbSet<Lesson> Lessons { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<QuestionsByDay> QuestionsByDays { get; set; }
        public virtual DbSet<user> users { get; set; }
    }
}
