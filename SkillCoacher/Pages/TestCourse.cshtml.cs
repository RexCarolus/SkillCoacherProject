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
using SkillCoacher.Services;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace SkillCoacher.Pages
{
    public class TestCourseModel : PageModel
    {
       
        private ICourseService _courseService;
        public Course Course { get; set; }
        public TestCourseModel(ICourseService courseService)
        {
            _courseService = courseService;
        }
        public void OnGet()
        {
        }
        public PartialViewResult OnPostCoursePartial(int id)
        {
            Course = _courseService.GetCourse(1);
            return Partial("_PartialCourse", Course);
        }


    }
}