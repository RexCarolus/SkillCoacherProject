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
    public class FavoritesModel : PageModel
    {
        public FavoritesModel(SkillCoacherContext context)
        {
            FavoriteCourses = new List<Course>();
            db = context;
        }
        private SkillCoacherContext db;
        public List<Course> FavoriteCourses { get; set; }
        public void OnGet()
        {
            var user = db.CommonUsers.Where(u => u.Login == User.Claims.ToList()[0].Value).Include(u => u.FavoriteCourses).FirstOrDefault();
            FavoriteCourses = user.FavoriteCourses;
        }
    }
}
