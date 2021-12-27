using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
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
    public class IndexModel : PageModel
    {
        public IndexModel(SkillCoacherContext context)
        {
            db = context;
        }
        private SkillCoacherContext db;
        [BindProperty]
        public List<Course> CoursesList { get; set; }

        public void OnGet()
        {
            CoursesList = db.Courses.Include(t => t.Tags).ToList();
        }

        public async Task<IActionResult> OnGetLogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            //CoursesList = db.Courses.Include(t => t.Tags).ToList();
            return Redirect("Index");
        }
        public void OnPostAddToFavorite(int userId,int courseId)
        {
            var user = db.CommonUsers.Where((user) => user.Login == User.Claims.First().Value).Include((u)=>u.FavoriteCourses).First();
            var cr = db.Courses.First((c) => c.Id == courseId);
            user.FavoriteCourses.Add(db.Courses.First((c) => c.Id == courseId));
            db.SaveChanges();
        }
    }
}
