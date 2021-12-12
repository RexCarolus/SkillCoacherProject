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
       [BindProperty]
       public Chapter CurrentChapter { get; set; }
        public void OnGet(int id)
        {
            using(var db = new SkillCoacherContext())
            {
                if(db.Chapters.Count(c=> c.Id == id) == 0)
                {
                    
                }
                else
                {
                    CurrentChapter = db.Chapters.First(c => c.Id == id);
                }


            }
        }

        public IActionResult OnPost(int id, string name, string content, string[] addTags, string imageName = "aaa.jpg")
        {
           
         
            using (var db = new SkillCoacherContext())
            {
                var tagsList = new List<Tag>();
                foreach (var addTagName in addTags)
                {
                    var forametedAddTagName = addTagName.Replace(" ", "").ToLower();
                    if (db.Tags.Count<Tag>(tag => tag.Name == forametedAddTagName) == 0)
                    {
                        tagsList.Add(db.Tags.Add(new Tag { Name = forametedAddTagName }).Entity);
                    }
                    else
                    {
                        tagsList.Add(db.Tags.First<Tag>(tag => tag.Name == forametedAddTagName));
                    }

                }
                var updatedChapter = db.Chapters.First(c=>c.Id == id);
                updatedChapter.Name = CurrentChapter.Name;
                updatedChapter.HtmlContent = CurrentChapter.HtmlContent;
                db.SaveChanges();
            }
            return Redirect($"SubmitChapter?id={CurrentChapter.Id}");
        }
    }
}
