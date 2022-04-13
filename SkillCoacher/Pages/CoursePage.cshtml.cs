using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Model.Context;
using Model.Models;
using SkillCoacher.Pages.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillCoacher.Pages
{
    public class CourseModel : PageModel
    {
        private SkillCoacherContext _db;
        [BindProperty]
        public Course SelectedCourse { get; private set; }
        public CommonUser CurrentUser { get; set; }
        [BindProperty]
        public int Grade { get; set; }
        public double Rating { get; set; }

        public CourseModel(SkillCoacherContext context)
        {
            _db = context;
        }

        public IActionResult OnGet(int id)
        {
            if (_db.Courses.Count(course => course.Id == id) == 1)
            {
                CurrentUser = _db.CommonUsers?.Where(u => u.Login == User.Claims.ToList()[0].Value)?.Include(u => u.CourseGrades)?.
                    Include((f)=> f.FavoriteCourses).FirstOrDefault();
                Grade = 0;
                SelectedCourse = _db.Courses.Where(course => course.Id == id).Include((comp) => comp.Components).
                    Include(grades => grades.CourseGrades).Include(c=>c.OwnerCoacher).First<Course>(course => course.Id == id);
                var courseGrade = CurrentUser.CourseGrades.FirstOrDefault(g => g.CourserId == SelectedCourse.Id);
                if (courseGrade != null)
                    Grade = courseGrade.Grade;
                Rating = 0;
                foreach(var grade in SelectedCourse.CourseGrades)
                {
                    Rating += grade.Grade;
                }
                Rating /= SelectedCourse.CourseGrades.Count();
                return Page();
            }
                return RedirectToPage("/Index");
        }

        public void OnPostAddToFavorite(int courseId)
        {
            SelectedCourse = _db.Courses.Where(course => course.Id == courseId).Include((comp) => comp.Components).
                    Include(grades => grades.CourseGrades).First<Course>(course => course.Id == courseId);
            var user = _db.CommonUsers.Where((user) => user.Login == User.Claims.First().Value).Include((u) => u.FavoriteCourses).First();
            if (user.FavoriteCourses.Count(c => c.Id == courseId) > 0)
                user.FavoriteCourses.RemoveAll(c => c.Id == courseId);
            else
                user.FavoriteCourses.Add(_db.Courses.First((c) => c.Id == courseId));
            _db.SaveChanges();
        }

        public IActionResult OnPostChangeGrade(int courseId)
        {
            CurrentUser = _db.CommonUsers?.Where(u => u.Login == User.Claims.ToList()[0].Value)?.Include(u => u.CourseGrades).FirstOrDefault();
            if (CurrentUser.CourseGrades.Exists(cg => cg.CourserId == courseId))
            {
                var grade = CurrentUser.CourseGrades.FirstOrDefault(cg => cg.CourserId == courseId);
                grade.Grade = Grade;
                _db.SaveChanges();
            }
            else
            {
                CurrentUser.CourseGrades.Add(new CourseGrade { UserId = CurrentUser.Id, CourserId = courseId, Grade = Grade });
                _db.SaveChanges();
            }
            SelectedCourse = _db.Courses.Where(course => course.Id == courseId).
                   Include(grades => grades.CourseGrades).First<Course>(course => course.Id == courseId);
            Rating = 0;
            foreach (var grade in SelectedCourse.CourseGrades)
            {
                Rating += grade.Grade;
            }
            Rating /= SelectedCourse.CourseGrades.Count();

            return new JsonResult(new { rating = Rating });
        }
    }
}
