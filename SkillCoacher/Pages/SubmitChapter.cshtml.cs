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
        private SkillCoacherContext _db;
       [BindProperty]
        public Chapter CurrentChapter { get; set; }

        public SubmitChapterModel(SkillCoacherContext context)
        {
            _db = context;
        }

        public void OnGet(int id)
        {
            if(_db.Chapters.Count(c=> c.Id == id) == 0)
            {
                
            }
            else
            {
                CurrentChapter = _db.Chapters.First(c => c.Id == id);
            }
        }

        public IActionResult OnPost(int id, string name, string content,  string imageName = "aaa.jpg")
        {
                var updatedChapter = _db.Chapters.First(c=>c.Id == id);
                updatedChapter.Name = name;
                updatedChapter.HtmlContent =content;
                _db.SaveChanges();
            return Redirect($"SubmitChapter?id={CurrentChapter.Id}");
        }
    }
}
