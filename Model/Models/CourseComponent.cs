using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Models
{
    public class CourseComponent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Sort { get; set; }
        public string Discriminator { get; set; }
    }
}
