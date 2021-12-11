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
    public class SubmitChapterModel : PageModel
    {
       
        public void OnGet()
        {
      
        }
    
        //public void OnPost(string name, string description, string content, string[] addTags, string imageName = "aaa.jpg")
        //{
        //    CommonUser u = new Coacher
        //    {
        //        Login = "0",
        //        Rating = 100,
        //        Password = "0",
        //        FavoriteCourses = new Course[] { new Course { Content = "b" }, new Course { Content = "a" } },
        //        OwnnedCourses = new Course[] { new Course { Content = "c", Components = new CourseComponent[]{ new Test { Name ="dd"}, new Chapter { Name ="ss"} } },
        //            new Course { Content = "cc" } }
        //    };
        //    using (var db = new SkillCoacherContext())
        //    {
        //        db.Users.Add(u);
        //        db.SaveChanges();
        //        var a = db.Coachers.First();
        //        int b = a.Rating;
        //    }
        //    using (var db = new SkillCoacherContext())
        //    {
        //        var tagsList = new List<Tag>();
        //        foreach(var addTagName in addTags)
        //        {
        //            var forametedAddTagName = addTagName.Replace(" ", "").ToLower();
        //            if(db.Tags.Count<Tag>(tag => tag.Name == forametedAddTagName) ==0)
        //            {
        //                tagsList.Add(db.Tags.Add(new Tag { Name = forametedAddTagName }).Entity);
        //            }
        //            else 
        //            {
        //                tagsList.Add(db.Tags.First<Tag>(tag => tag.Name == forametedAddTagName));
        //            }

        //        }
        //        db.Courses.Add(new Course { Name = name, Description = description, Content = content, TitleImagePath = imageName, Tags = tagsList });
        //        db.SaveChanges();
        //    }
        //}
    }
}
