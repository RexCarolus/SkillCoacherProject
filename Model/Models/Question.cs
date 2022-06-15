using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Test OwnerTest { get; set; }
        public int OwnerTestId { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
