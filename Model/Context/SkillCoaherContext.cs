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
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=localhost;Database=SkillCoacher;Trusted_Connection=True;");
        }
    }
  
}