using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Models
{
    public class TestsBaseUser
    {
        public int TestId { get; set; }
        public Test Test { get; set; }
        public int CommonUserId { get; set; }
        public CommonUser User { get; set; }
        public bool IsTestPassed { get; set; }
        public int Score { get; set; }
    }
}
