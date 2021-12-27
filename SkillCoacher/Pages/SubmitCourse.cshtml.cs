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

namespace SkillCoacher.Pages
{
    public class SubmitCourseModel : PageModel
    {
        [BindProperty]
        public Course CurrentCourse { get; set; }


        public void OnGet(int id)
        {
            using (var db = new SkillCoacherContext())
            {
                
                if (id == 0|| db.Courses.Count(c=> c.Id ==id)==0)
            {
                CurrentCourse = new Course
                {
                    Id = -1,
                    Name = "Name",
                    Description = "Some decription",
                    Components = new List<CourseComponent> { new Chapter { Name = "Chapter 1", Sort = 1, Discriminator="Chapter" }, new Chapter { Name = "Chapter 2", Sort = 0, Discriminator = "Chapter" } }
                };
            }
            else
            {
                    CurrentCourse = db.Courses.Where(c => c.Id == id).Include(c=>c.Components).ToList().First();
                    ModelState.Clear();
                }
        }


        }
        public IActionResult OnPostDelete(int id, int deleteId)
        {
            if (id < 0)
                return Page();
            using (var db = new SkillCoacherContext())
            {

                var courseComp = new CourseComponent { Id = deleteId };
                db.CourseComponents.Attach(courseComp);
                db.CourseComponents.Remove(courseComp);

                db.SaveChanges();
            }
            

            return Redirect($"SubmitCourse?id={id}");
        }
        public IActionResult OnPostDeleteAjax(int id, int deleteId)
        {
            if (id < 0)
                return Page();
            using (var db = new SkillCoacherContext())
            {

                var courseComp = new CourseComponent { Id = deleteId };
                db.CourseComponents.Attach(courseComp);
                db.CourseComponents.Remove(courseComp);

                db.SaveChanges();
            }


            return new JsonResult(new { id =  deleteId});
        }
        public IActionResult OnPostAddComponent(Course currentCourse)
        {
            if (CurrentCourse.Id < 0)
                return Page();
            using (var db = new SkillCoacherContext())
            {
            
                CurrentCourse = db.Courses.Where(c => c.Id == CurrentCourse.Id).Include(ch=> ch.Components).First(c => c.Id == CurrentCourse.Id);
                
                CurrentCourse.Components.Add(new Chapter { Name = "New chapter" });
                db.SaveChanges();

            }
            return Redirect($"SubmitCourse?id={CurrentCourse.Id}");
        }
        

        public IActionResult OnPostSave(string[] tagsStrings, string imageName = "aaa.jpg")
        {
            
            
                TagFactory tagFactory = new TagFactory();
                var addTags = tagFactory.GetTagList(tagsStrings).ToList();
                if (CurrentCourse.Id < 0)
                {
                Course newCourse;
                using (var db = new SkillCoacherContext())
                {
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
                }
                    return Redirect($"SubmitCourse?id={newCourse.Id}");
                
                }
                else
                {
                    DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder();
                    optionsBuilder.EnableSensitiveDataLogging(true);
                using (var db = new SkillCoacherContext(optionsBuilder.Options))
                {
                   
                    var updatedCourse = db.Courses.Where(c => c.Id == CurrentCourse.Id).Include(ch => ch.Components).First(c => c.Id == CurrentCourse.Id); ;
                    updatedCourse.Name = CurrentCourse.Name;
                    updatedCourse.Description = CurrentCourse.Description;
                    for (int i = 0; i < CurrentCourse.Components.Count; i++)
                    {
                        updatedCourse.Components[i].Name = CurrentCourse.Components[i].Name;
                        updatedCourse.Components[i].Sort = CurrentCourse.Components[i].Sort;
                        updatedCourse.Components[i].Discriminator = CurrentCourse.Components[i].Discriminator;
                    }
                    
                    updatedCourse.Tags = addTags;

                    // CurrentCourse = updatedCourse;
                    db.SaveChanges();
                }
                    return Redirect($"SubmitCourse?id={CurrentCourse.Id}");
                }
            }
        
    }
    
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}