using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillCoacher.Pages.Shared
{
    public class ChapterListModel
    {
        public Course SelectedCourse { get; set; }
        public CommonUser SelectedUser { get; set; }
        public int? LastChapterId { get; set; }
    }
}
