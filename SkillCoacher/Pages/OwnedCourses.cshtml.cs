using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Model.Context;
using Model.Models;

namespace SkillCoacher.Pages
{
    public class OwnedCoursesModel : PageModel
    {
        private SkillCoacherContext _db;
        public List<Course> OwnedCourses { get; set; }

        public OwnedCoursesModel(SkillCoacherContext context)
        {
            OwnedCourses = new List<Course>();
            _db = context;
        }

        public void OnGet()
        {
            var user = _db.Coachers.Where(u => u.Login == User.Claims.ToList()[0].Value).Include(u => u.OwnnedCourses).FirstOrDefault();
            OwnedCourses = user?.OwnnedCourses;
        }
    }
}
