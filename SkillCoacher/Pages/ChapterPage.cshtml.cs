using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Model.Context;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillCoacher.Pages
{
    public class ChapterPageModel : PageModel
    {
        public ChapterPageModel(SkillCoacherContext context)
        {
            db = context;
        }
        private SkillCoacherContext db;
        public Chapter SelectedChapter { get; private set; }
        public IActionResult OnGet(int id)
        {
                if (db.Chapters.Count(chapter => chapter.Id == id) == 1)
                {
                    SelectedChapter = db.Chapters.First(course => course.Id == id);
                    return Page();
                }
                else
                    return RedirectToPage("/Index");

        }
    }
}
