using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using Model.Models;

namespace Model.Context
{
    public class SkillCoacherContext : DbContext 
    {
        public SkillCoacherContext()
        {
            Database.EnsureCreated(); 
        }
        public SkillCoacherContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<CommonUser> CommonUsers { get; set; }
        public DbSet<Coacher> Coachers { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<CommonUsersFavoriteCourses> CommonUsersFavoriteCourses { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseComponent> CourseComponents { get; set; }
        public DbSet<CommonUsersFavoriteCourses> UsersFavoriteCourses { get; set; }
        public DbSet<CourseGrade> CourseGrades { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CommonUsersFavoriteCourses>().Property(p => p.LastComponentId).HasDefaultValue(0);
            modelBuilder.Entity<CommonUsersFavoriteCourses>()
                .HasOne(p => p.FavoriteCourse)
                .WithMany(p => p.CommonUsersFavoriteCourses)
                .HasForeignKey(k => k.FavoriteCourseId);
            modelBuilder.Entity<CommonUsersFavoriteCourses>()
         .HasOne(p => p.User)
         .WithMany(p => p.CommonUsersFavoriteCourses)
         .HasForeignKey(k => k.UserId);

            

            modelBuilder
                .Entity<Test>()
                .HasMany(t => t.Users)
                .WithMany(u => u.Tests)
                .UsingEntity<TestsCommonUsers>(
                   j => j
                    .HasOne(pt => pt.User)
                    .WithMany(t => t.TestsBaseUsers)
                    .HasForeignKey(pt => pt.CommonUserId),
                j => j
                    .HasOne(pt => pt.Test)
                    .WithMany(p => p.TestsBaseUsers)
                    .HasForeignKey(pt => pt.TestId),
                j =>
                {
                    j.Property(pt => pt.IsTestPassed);
                    j.Property(pt => pt.Score).HasDefaultValue(0);
                    j.HasKey(t => new { t.CommonUserId, t.TestId });
                    j.ToTable("TestsUsers");
                });

            modelBuilder
               .Entity<Course>()
               .HasMany(c => c.CommonUsers)
               .WithMany(u => u.FavoriteCourses)
               .UsingEntity<CommonUsersFavoriteCourses>(
                  j => j
                   .HasOne(pt => pt.User)
                   .WithMany(t => t.CommonUsersFavoriteCourses)
                   .HasForeignKey(pt => pt.UserId),
               j => j
                   .HasOne(pt => pt.FavoriteCourse)
                   .WithMany(p => p.CommonUsersFavoriteCourses)
                   .HasForeignKey(pt => pt.FavoriteCourseId),
               j =>
               {
                   j.HasKey(t => new { t.UserId, t.FavoriteCourseId });
                   j.ToTable("CommonUsersFavoriteCourses");
               });
            modelBuilder
              .Entity<Course>()
              .HasMany(c => c.GradeUsers)
              .WithMany(u => u.GradeCourses)
              .UsingEntity<CourseGrade>(
                 j => j
                  .HasOne(pt => pt.User)
                  .WithMany(t => t.CourseGrades)
                  .HasForeignKey(pt => pt.UserId),
              j => j
                  .HasOne(cg => cg.Course)
                  .WithMany(p => p.CourseGrades)
                  .HasForeignKey(cg => cg.CourserId),
              j =>
              {
                  j.HasKey(t => new { t.UserId, t.CourserId });
                  j.Property(pt => pt.Grade);
                  j.ToTable("CourseGrades");
              });
            modelBuilder
              .Entity<Coacher>()
              .HasMany(c => c.OwnnedCourses)
              .WithOne(u => u.OwnerCoacher);
        }
    }
  
}