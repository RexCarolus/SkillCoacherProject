using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Models
{
    public class CoursesTags
    {
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
