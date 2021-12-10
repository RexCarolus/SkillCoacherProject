using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Models
{
    public  class BaseUser
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
