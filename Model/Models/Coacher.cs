using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Models
{
    public class Coacher : CommonUser
    {
        public int Rating { get; set; }
        public List<Course> OwnnedCourses { get; set; }
    }
}
