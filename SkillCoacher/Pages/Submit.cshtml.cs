using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using Model.Context;
using Model.Models;
namespace SkillCoacher.Pages
{
    public class SubmitModel : PageModel
    {
        string s;
        public void OnGet()
        {
      
        }
        public void Add()
        {
            int a = 5;
        }
        public void OnPost(string name, string description, string content, string imageName = "aaa.jpg")
        {
            using(var db = new SkillCoacherContext())
            {
                db.Courses.Add(new Course { Name = name, Description = description, Content = content, TitleImagePath = imageName });
                db.SaveChanges();
            }
        }
    }
}
