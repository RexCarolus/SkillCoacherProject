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
    public class ChapterPageModel : PageModel
    {
        private SkillCoacherContext _db;
        public Chapter SelectedChapter { get; private set; }
        public Course OwnerCourse { get; set; }
        public int? LeftChapterId { get; set; }
        public int? RightChapterId { get; set; }
        public ChapterPageModel(SkillCoacherContext context)
        {
            _db = context;
        }

        public IActionResult OnGet(int id)
        {
            //var user = _db.CommonUsers.Where((user) => user.Login == User.Claims.First().Value).Include((u) => u.FavoriteCourses).First();
            
                
                if (_db.Chapters.Count(chapter => chapter.Id == id) == 1)
                {
                    SelectedChapter = _db.Chapters.First(course => course.Id == id);
                    
                    OwnerCourse = _db.Courses.Where(p=>p.Components.Contains(SelectedChapter))
                    .Include(p=>p.Components)
                    .First();
                var userCl = User.Claims.First().Value;
                _db.CommonUsersFavoriteCourses.First(p => p.FavoriteCourseId == OwnerCourse.Id && p.User.Login == userCl)
                .LastComponentId = id;
                int leftIndex = SelectedChapter.Sort - 1;
                if(leftIndex >= 0 && leftIndex < OwnerCourse.Components.Count)
                    LeftChapterId = OwnerCourse.Components.Where(p=>p.Sort == leftIndex).First().Id;
                int rightIndex = SelectedChapter.Sort + 1;
                if (rightIndex >= 0 && rightIndex < OwnerCourse.Components.Count)
                    RightChapterId = OwnerCourse.Components.Where(p => p.Sort == rightIndex).First().Id;
                else
                    rightIndex = -1;
                _db.SaveChanges();
                return Page();
                }
                else
                    return RedirectToPage("/Index");
        }
    }
}
