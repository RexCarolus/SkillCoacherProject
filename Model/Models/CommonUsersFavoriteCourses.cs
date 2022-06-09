using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Models
{
    public class CommonUsersFavoriteCourses
    {
        public int UserId { get; set; }
        public CommonUser User { get; set; }
        public int FavoriteCourseId { get; set; }
        public Course FavoriteCourse { get; set; }
        public int LastComponentId { get; set; }
    }
}
