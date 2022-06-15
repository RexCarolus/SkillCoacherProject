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
    public class EditTestModel : PageModel
    {
        private SkillCoacherContext _db;
        [BindProperty]
        public Test CurrentTest { get; set; }
        public EditTestModel(SkillCoacherContext context)
        {
            _db = context;
        }
        public void OnGet(int id)
        {
            if (_db.Tests.Count(c => c.Id == id) == 0)
            {

            }
            else
            {
                CurrentTest = _db.Tests.Where(c => c.Id == id).Include(p=>p.Questions).ThenInclude(p=>p.Answers).First();
            }
        }
        public IActionResult OnPostAddAnswer(int testId, int questionId)
        {
            var test = _db.Tests.Where(t => t.Id == testId).Include(t => t.Questions).ThenInclude(q=>q.Answers).First();
            _db.Tests.Attach(test);
            test.Questions.First(q=>q.Id == questionId).Answers.Add(new Answer { Content = "новый ответ", Score = 0 });
         
            _db.SaveChanges();
            return Partial("_PartialEditableAnswersList", test.Questions.First(q => q.Id == questionId).Answers);
        }
        public IActionResult OnPostAddQuestion()
        {
            var test = _db.Tests.Where(t => t.Id == CurrentTest.Id).Include(t => t.Questions).First();
            _db.Tests.Attach(test);
            test.Questions.
                Add(new Question
                {
                    Name = "новый вопрос",
                    Answers = new List<Answer> {
                        new Answer { Content = "ответ  1", Score = 0 },
                        new Answer { Content = "ответ  2", Score = 0 }
                    }
                });
            _db.SaveChanges();
            return Redirect($"/EditTest?id={CurrentTest.Id}");
        }
    }
}
