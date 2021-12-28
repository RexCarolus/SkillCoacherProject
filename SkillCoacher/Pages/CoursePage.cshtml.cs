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
        [BindProperty]
        public Course SelectedCourse { get; private set; }
        public CommonUser CurrentUser { get; set; }
        [BindProperty]
        public int Grade { get; set; }
        public IActionResult OnGet(int id)
        {
            if (db.Courses.Count(course => course.Id == id) == 1)
            {
                CurrentUser = db.CommonUsers?.Where(u => u.Login == User.Claims.ToList()[0].Value)?.Include(u => u.CourseGrades).FirstOrDefault();
                Grade = 0;
                SelectedCourse = db.Courses.Where(course => course.Id == id).Include((comp) => comp.Components).First<Course>(course => course.Id == id);
                
                var courseGrade = CurrentUser.CourseGrades.FirstOrDefault(g => g.CourserId == SelectedCourse.Id);
                if (courseGrade != null)
                    Grade = courseGrade.Grade;
                return Page();
            }
            else
            {

            }
                return RedirectToPage("/Index");

        }
        public void OnPostAddToFavorite(int courseId)
        {
            var user = db.CommonUsers.First((user) => user.Login == User.Claims.First().Value);

        }
        public IActionResult OnPostChangeGrade(int courseId)
        {
            CurrentUser = db.CommonUsers?.Where(u => u.Login == User.Claims.ToList()[0].Value)?.Include(u => u.CourseGrades).FirstOrDefault();
            if (CurrentUser.CourseGrades.Exists(cg => cg.CourserId == courseId))
            {
                var grade = CurrentUser.CourseGrades.FirstOrDefault(cg => cg.CourserId == courseId);
                grade.Grade = Grade;
                db.SaveChanges();
            }
            else
            {
                CurrentUser.CourseGrades.Add(new CourseGrade { UserId = CurrentUser.Id, CourserId = courseId, Grade = Grade });
                db.SaveChanges();
            }
            return Partial("_PartialGradeButtons", Grade);
        }
    }
}
