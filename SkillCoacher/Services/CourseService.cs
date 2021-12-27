using Microsoft.EntityFrameworkCore;
using Model.Context;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillCoacher.Services
{
    public interface ICourseService
    {
        Course GetCourse(int id);
    }
    public class CourseService : ICourseService
    {
        public Course GetCourse(int id)
        {
            Course course;
            using (var db = new SkillCoacherContext())
            {
                course = db.Courses.Where(c => c.Id == id).Include(c => c.Components).ToList().First();
            }
            
            return course;
        }
    }
}
