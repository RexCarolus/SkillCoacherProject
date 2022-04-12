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
        private SkillCoacherContext _db;
        public List<Course> FavoriteCourses { get; set; }

        public FavoritesModel(SkillCoacherContext context)
        {
            FavoriteCourses = new List<Course>();
            _db = context;
        }

        public void OnGet()
        {
            var user = _db.CommonUsers.Where(u => u.Login == User.Claims.ToList()[0].Value).Include(u => u.FavoriteCourses).FirstOrDefault();
            FavoriteCourses = user.FavoriteCourses;
        }
    }
}
