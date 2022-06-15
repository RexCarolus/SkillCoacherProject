using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Models
{
    public class CourseComponent
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int Sort { get; set; }
        public string Discriminator { get; set; }
        public int OwnerCourseId { get; set; }
        public  Course OwnerCourse { get; set; }
        public CommonUsersFavoriteCourses CommonUsersFavoriteCourse { get; set; }
    }
    public static class CourseCollectionExtension
    {
    public static List<CourseComponent> SortByParameter(this List<CourseComponent> arr)
        {
            arr.Sort(new CourseComparer());
            return arr;
        }
    }

    class CourseComparer : IComparer<CourseComponent>
    {
        int IComparer<CourseComponent>.Compare(CourseComponent x, CourseComponent y)
        {
            if (x.Sort < y.Sort)
                return -1;
            if (x.Sort == y.Sort)
                return 0;
            else
                return 1;
        }
    }
}
