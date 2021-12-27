using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Model.Context;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillCoacher.Pages
{
    public class CourseModel : PageModel
    {
        public CourseModel(SkillCoacherContext context)
        {
            db = context;
        }
        private SkillCoacherContext db;
        public Course SelectedCourse { get; private set; }
        public IActionResult OnGet(int id)
        {
            if (db.Courses.Count(course => course.Id == id) == 1)
            {
                SelectedCourse = db.Courses.Where(course => course.Id == id).Include((comp) => comp.Components).First<Course>(course => course.Id == id);
                return Page();
            }
            else
                return RedirectToPage("/Index");

        }
        public void OnPostAddToFavorite(int courseId)
        {
            var user = db.CommonUsers.First((user) => user.Login == User.Claims.First().Value);

        }
    }
}
