using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model.Models
{
    public class Test : CourseComponent
    {
        public int ScoreToPass { get; set; }
        public IEnumerable<Question> Questions { get; set; }
        [NotMapped]
        public IEnumerable<Answer> ChoosenAnswers { get; set; }
        public int TotalScoreSum()
        {
            var a = ChoosenAnswers as List<Answer>;
            
            int sum = 0;
            foreach(var answer in ChoosenAnswers)
            {
                sum += answer.Score;
            }
            return sum;
        }
        public List<CommonUser> Users { get; set; } = new List<CommonUser>();
        public List<TestsBaseUser> TestsBaseUsers { get; set; } = new List<TestsBaseUser>();
    }
}
