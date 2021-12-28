using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model.Models
{
    public class Coacher : CommonUser
    {
        public int Rating { get; set; }
        [NotMapped]
        public List<Course> OwnnedCourses { get; set; }
    }
}
