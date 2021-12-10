using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Models
{
    public class CommonUser : BaseUser
    {
        public IEnumerable<Course> FavoriteCourses { get; set; }
        public List<TestsBaseUser> TestsBaseUsers { get; set; } = new List<TestsBaseUser>();
        public List<Test> Tests { get; set; } = new List<Test>();
    }
}
