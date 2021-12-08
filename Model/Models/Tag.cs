using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Course> Courses { get; set; }
    }
}
