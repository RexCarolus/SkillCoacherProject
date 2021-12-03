using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
        private readonly ILogger<IndexModel> _logger;

        public CourseModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
      public Course SelectedCourse { get; private set; }
        public IActionResult OnGet(int id)
        {
            using (SkillCoacherContext db = new SkillCoacherContext())
            {
                if (db.Courses.Count(course => course.Id == id) == 1)
                {
                    SelectedCourse = db.Courses.First<Course>(course => course.Id == id);
                    return Page();
                }
                else
                    return RedirectToPage("/Index");

            }
        }
    }
}
