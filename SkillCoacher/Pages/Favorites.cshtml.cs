using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Model.Context;
using Model.Models;
using SkillCoacher.Pages.Shared;

namespace SkillCoacher.Pages
{
    public class FavoritesModel : PageModel
    {
        private SkillCoacherContext _db;
        public List<Course> FavoriteCourses { get; set; }

        public FavoritesModel(SkillCoacherContext context)
        {
            FavoriteCourses = new List<Course>();
            _db = context;
        }

        public void OnGet()
        {
            var user = _db.CommonUsers.Where(u => u.Login == User.Claims.ToList()[0].Value).Include(u => u.FavoriteCourses).
                ThenInclude(f=>f.Tags).FirstOrDefault();
            FavoriteCourses = user.FavoriteCourses;
        }

        public IActionResult OnPostDeleteFromFavorite(int courseId)
        {
            var user = _db.CommonUsers.Where((user) => user.Login == User.Claims.First().Value).Include((u) => u.FavoriteCourses).
                ThenInclude(c=>c.Tags).First();
            if (user.FavoriteCourses.Count(c => c.Id == courseId) > 0)
                user.FavoriteCourses.RemoveAll(c => c.Id == courseId);
            _db.SaveChanges(); 
            return  Partial("_PartialFavoriteCourseList", new IndexDataModel { CoursesList = user.FavoriteCourses});
        }
    }
}
