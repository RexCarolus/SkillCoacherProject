using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
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
    public class IndexModel : PageModel
    {
        private SkillCoacherContext _db;
        [BindProperty]
        public List<Course> CoursesList { get; set; }
        public CommonUser CurrentUser { get; set; }

        public IndexModel(SkillCoacherContext context)
        {
            _db = context;
        }

        public void OnGet(string query)
        {
            CurrentUser = _db.CommonUsers?.Where(u => u.Login == User.Claims.ToList()[0].Value)?.Include(u => u.FavoriteCourses).FirstOrDefault();
            if(query is null)
            {
            CoursesList = _db.Courses.Include(t => t.Tags).ToList();
            }
            else
            {
                query = query.ToLower().Trim();
                CoursesList = _db.Courses.Include((t) => t.Tags).Where((course) => course.Name.Contains(query)||
                course.Tags.Where((t)=>t.Name.Contains(query)).Count()>0).ToList();
            }           
        }

        public IActionResult OnPostUpdateQuery(string query)
        {
            ModelState.Clear();
            CoursesList = _db.Courses.Where((course) => course.Name.Contains(query)).Include((tag)=>tag.Tags).ToList();
            return Partial("_PartialCourseList", new IndexDataModel { CoursesList = this.CoursesList, CurrentUser = this.CurrentUser});
        }

        public async Task<IActionResult> OnGetLogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("Index");
        }

        public void OnPostAddToFavorite(int userId,int courseId)
        {
            var user = _db.CommonUsers.Where((user) => user.Login == User.Claims.First().Value).Include((u)=>u.FavoriteCourses).First();
            if (user.FavoriteCourses.Count(c => c.Id == courseId) > 0)
                user.FavoriteCourses.RemoveAll(c => c.Id == courseId);
            else 
                user.FavoriteCourses.Add(_db.Courses.First((c) => c.Id == courseId));
            _db.SaveChanges();
        }
    }
}
