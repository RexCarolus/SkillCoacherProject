using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillCoacher.Pages.Shared
{
    public class IndexDataModel
    {
        public List<Course> CoursesList { get; set; }
        public CommonUser CurrentUser { get; set; }
    }
}
