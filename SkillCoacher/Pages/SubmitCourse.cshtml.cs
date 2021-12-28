using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using Model.Context;
using Model.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Runtime.Serialization.Json;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace SkillCoacher.Pages
{
    public class SubmitCourseModel : PageModel
    {
        public SubmitCourseModel(SkillCoacherContext context)
        {
            db = context;
        }
        private SkillCoacherContext db;
        [BindProperty]
        public Course CurrentCourse { get; set; }
        [BindProperty]
        public string TestString { get; set; }

        public void OnGet(int id)
        {
            if (id == 0|| db.Courses.Count(c=> c.Id ==id)==0)
            {
                CurrentCourse = new Course
                {
                    Id = -1,
                    Name = "Name",
                    Description = "Some decription",
                    Components = new List<CourseComponent> { new Chapter { Name = "Chapter 1", Sort = 1, Discriminator="Chapter" },
                        new Chapter { Name = "Chapter 2", Sort = 0, Discriminator = "Chapter" } }
                };
            }
            else
            {
                    CurrentCourse = db.Courses.Where(c => c.Id == id).Include(c=>c.Components).ToList().First();
                    ModelState.Clear();
            }
        }
     
        public IActionResult OnPostDeleteAjax(int id, int deleteId)
        {
            if (id < 0)
                return Page();
            var courseComp = new CourseComponent { Id = deleteId };
            db.CourseComponents.Attach(courseComp);
            db.CourseComponents.Remove(courseComp);
            
            db.SaveChanges();

            return new JsonResult(new { id =  deleteId});
        }
        public IActionResult OnPostAddComponent(Course currentCourse)
        {
            if (CurrentCourse.Id < 0)
                return Page();
                
            CurrentCourse = db.Courses.Where(c => c.Id == CurrentCourse.Id).Include(ch=> ch.Components).First();
            CurrentCourse.Name = currentCourse.Name;
            CurrentCourse.Tags = currentCourse.Tags;
            CurrentCourse.Description = currentCourse.Description;
            CurrentCourse.Components.Add(new Chapter { Name = "New chapter" });
            db.SaveChanges();
            return Redirect($"SubmitCourse?id={CurrentCourse.Id}");
        }
        

        public IActionResult OnPostSave(string[] tagsStrings, string imageName = "aaa.jpg")
        {
                TagFactory tagFactory = new TagFactory(db);
                var addTags = tagFactory.GetTagList(tagsStrings).ToList();
                if (CurrentCourse.Id < 0)
                {
                    Course newCourse;
                    CurrentCourse.Components.ForEach(c => c.Id = null);
                    newCourse = new Course
                    {
                        Name = CurrentCourse.Name,
                        Description = CurrentCourse.Description,
                        Components = CurrentCourse.Components.ToList(),
                        Tags = addTags,
                        TitleImagePath = imageName
                    };
                    newCourse.Id = db.Courses.Add(newCourse).Entity.Id;
                    db.SaveChanges();
                    return Redirect($"SubmitCourse?id={newCourse.Id}");
                }
                else
                {
                    var updatedCourse = db.Courses.Where(c => c.Id == CurrentCourse.Id).Include(ch => ch.Components).
                    First(c => c.Id == CurrentCourse.Id); 
                    updatedCourse.Name = CurrentCourse.Name;
                    updatedCourse.Description = CurrentCourse.Description;
                    for (int i = 0; i < CurrentCourse.Components.Count; i++)
                    {
                        updatedCourse.Components[i].Name = CurrentCourse.Components[i].Name;
                        updatedCourse.Components[i].Sort = CurrentCourse.Components[i].Sort;
                        updatedCourse.Components[i].Discriminator = "Chapter";
                    }
                    updatedCourse.Tags = addTags;
                    db.SaveChanges();
            return new JsonResult(JsonConvert.SerializeObject(updatedCourse));
                }
                    //return Redirect($"SubmitCourse?id={CurrentCourse.Id}");
            }
        public IActionResult OnPostSaveAjx(string[] tagsStrings, string imageName = "aaa.jpg")
        {
            TagFactory tagFactory = new TagFactory(db);
            var addTags = tagFactory.GetTagList(tagsStrings).ToList();
            if (CurrentCourse.Id < 0)
            {
                Course newCourse;
                CurrentCourse.Components.ForEach(c => c.Discriminator = "Chapter");
                newCourse = new Course
                {
                    Name = CurrentCourse.Name,
                    Description = CurrentCourse.Description,
                    Components = CurrentCourse.Components.ToList(),
                    Tags = addTags,
                    TitleImagePath = imageName
                };
                newCourse.Id = db.Courses.Add(newCourse).Entity.Id;
                db.SaveChanges();
                return new JsonResult(new {IsNew = true, Id = newCourse.Id });
                return Redirect($"SubmitCourse?id={newCourse.Id}");
            }
            else
            {
                var updatedCourse = db.Courses.Where(c => c.Id == CurrentCourse.Id).Include(ch => ch.Components).
                    Include(ch=>ch.Tags).First(c => c.Id == CurrentCourse.Id); ;
                updatedCourse.Name = CurrentCourse.Name;
                updatedCourse.Description = CurrentCourse.Description;
                for (int i = 0; i < CurrentCourse.Components.Count; i++)
                {
                    updatedCourse.Components[i].Name = CurrentCourse.Components[i].Name;
                    updatedCourse.Components[i].Sort = CurrentCourse.Components[i].Sort;
                    updatedCourse.Components[i].Discriminator = "Chapter";
                }
                var newTags = addTags.Except(updatedCourse.Tags);
                updatedCourse.Tags.AddRange(newTags);
                
                db.SaveChanges();
                return new JsonResult(new {IsNew = false });
            }
            //return Redirect($"SubmitCourse?id={CurrentCourse.Id}");
        }
    }
}