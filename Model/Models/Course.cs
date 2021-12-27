using System;
using System.Collections.Generic;

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
        public int OwnerUserId { get; set; }
        public List<Tag> Tags { get; set; }
        public int Progress { get; set; }
        public List<CommonUser> CommonUsers { get; set; }
        public List<CommonUsersFavoriteCourses> CommonUsersFavoriteCourses { get; set; } = new List<CommonUsersFavoriteCourses>();
    }
}
