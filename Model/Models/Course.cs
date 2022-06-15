using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<CourseComponent> Components { get; set; }
        public string Content { get; set; }
        public string TitleImagePath { get; set; }
        [NotMapped]
        public Coacher OwnerCoacher { get; set; }
        public List<Tag> Tags { get; set; }
        public int Progress { get; set; }
        public List<CommonUser> CommonUsers { get; set; }
        public List<CommonUsersFavoriteCourses> CommonUsersFavoriteCourses { get; set; } = new List<CommonUsersFavoriteCourses>();
        public List<CommonUser> GradeUsers { get; set; }
        public List<CourseGrade> CourseGrades { get; set; } = new List<CourseGrade>();
        public List<CoursesTags> CoursesTags { get; set; }
        public DateTime DateOfPublication { get; set; }
    }
}
