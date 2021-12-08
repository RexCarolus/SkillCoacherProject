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
       
        public void OnGet()
        {
      
        }
    
        public void OnPost(string name, string description, string content, string[] addTags, string imageName = "aaa.jpg")
        {
            using(var db = new SkillCoacherContext())
            {
                var tagsList = new List<Tag>();
                foreach(var addTagName in addTags)
                {
                    if(db.Tags.Count<Tag>(tag => tag.Name == addTagName)==0)
                    {
                        tagsList.Add(db.Tags.Add(new Tag { Name = addTagName }).Entity);
                    }
                    else 
                    {
                        tagsList.Add(db.Tags.First<Tag>(tag => tag.Name == addTagName));
                    }

                }
                db.Courses.Add(new Course { Name = name, Description = description, Content = content, TitleImagePath = imageName, Tags = tagsList });
                db.SaveChanges();
            }
        }
    }
}
