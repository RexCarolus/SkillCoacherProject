using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Models
{
    public class CourseGrade
    {
        public int UserId { get; set; }
        public int CourserId { get; set; }
        public int Grade { get; set; }
        public Course Course { get; set; }
        public CommonUser User { get; set; }

    }
}
