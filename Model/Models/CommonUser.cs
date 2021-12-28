using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Models
{
    public class CommonUser
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Discriminator { get; set; }
        public List<Course> FavoriteCourses { get; set; }
        public List<CommonUsersFavoriteCourses> CommonUsersFavoriteCourses { get; set; } = new List<CommonUsersFavoriteCourses>();
        public List<TestsCommonUsers> TestsBaseUsers { get; set; } = new List<TestsCommonUsers>();
        public List<Test> Tests { get; set; } = new List<Test>();
        public List<Course> GradeCourses { get; set; }
        public List<CourseGrade> CourseGrades { get; set; } = new List<CourseGrade>();
    }
}
