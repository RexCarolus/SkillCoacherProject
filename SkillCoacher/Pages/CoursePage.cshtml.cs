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
        public ChapterListModel PartialChapterList { get; set; }
        public int? LastChapterId { get; set; }

        public CourseModel(SkillCoacherContext context)
        {
            _db = context;
            PartialChapterList = new ChapterListModel();
        }

        public IActionResult OnGet(int id)
        {
            if (_db.Courses.Count(course => course.Id == id) == 1)
            {
                FillUserAndCourse(id);
                Grade = 0;
               
                var courseGrade = CurrentUser.CourseGrades.FirstOrDefault(g => g.CourserId == SelectedCourse.Id);
                if (courseGrade != null)
                    Grade = courseGrade.Grade;
                Rating = 0;
                foreach(var grade in SelectedCourse.CourseGrades)
                {
                    Rating += grade.Grade;
                }
                Rating /= SelectedCourse.CourseGrades.Count();
                PartialChapterList.SelectedCourse = SelectedCourse;
                PartialChapterList.SelectedUser = CurrentUser;
                try
                {
                PartialChapterList.LastChapterId = _db.CommonUsersFavoriteCourses.First(p => p.FavoriteCourseId == SelectedCourse.Id
                && p.User.Login == CurrentUser.Login)
                .LastComponentId;
                }
                catch
                {

                }
                return Page();
            }
                return RedirectToPage("/Index");
        }

        public IActionResult OnPostAddToFavorite(int courseId)
        {
            FillUserAndCourse(courseId);
            if (CurrentUser.FavoriteCourses.Count(c => c.Id == courseId) > 0)
                CurrentUser.FavoriteCourses.RemoveAll(c => c.Id == courseId);
            else
                CurrentUser.FavoriteCourses.Add(_db.Courses.First((c) => c.Id == courseId));
            _db.SaveChanges();
            PartialChapterList.SelectedUser = CurrentUser;
            PartialChapterList.SelectedCourse = SelectedCourse;
            try
            {
                PartialChapterList.LastChapterId = _db.CommonUsersFavoriteCourses.First(p => p.FavoriteCourseId == SelectedCourse.Id
                && p.User.Login == CurrentUser.Login)
                .LastComponentId;
            }
            catch
            {

            }
            return  Partial ("_PartialChapterList", PartialChapterList);
        }

        public IActionResult OnPostChangeGrade(int courseId)
        {
            FillUserAndCourse(courseId);
            if (CurrentUser.CourseGrades.Exists(cg => cg.CourserId == courseId))
            {
                var grade = CurrentUser.CourseGrades.FirstOrDefault(cg => cg.CourserId == courseId);
                grade.Grade = Grade;
                _db.SaveChanges();
            }
            else
            {
                CurrentUser.CourseGrades.Add(
                    new CourseGrade { UserId = CurrentUser.Id, CourserId = courseId, Grade = Grade }
                    );
                _db.SaveChanges();
            }
           
            Rating = 0;
            foreach (var grade in SelectedCourse.CourseGrades)
            {
                Rating += grade.Grade;
            }
            Rating /= SelectedCourse.CourseGrades.Count();

            return new JsonResult(new { rating = Rating });
        }
        public void FillUserAndCourse(int id)
        {
            CurrentUser = _db.CommonUsers?.Where(u => u.Login == User.Claims.ToList()[0].Value)?
                    .Include(u => u.CourseGrades)?.
                    Include((f) => f.FavoriteCourses).FirstOrDefault();
            SelectedCourse = _db.Courses.Where(course => course.Id == id).Include((comp) => comp.Components).
                   Include(grades => grades.CourseGrades).Include(c => c.OwnerCoacher).First<Course>(course => course.Id == id);

        }
    }
}
