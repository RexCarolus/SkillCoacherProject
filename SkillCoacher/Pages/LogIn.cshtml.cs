using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.Models;
using Model.Context;
namespace SkillCoacher.Pages
{
    public class LogInModel : PageModel
    {
        private readonly ILogger<SignUpModel> _logger;

        public LogInModel(ILogger<SignUpModel> logger)
        {
            _logger = logger;
            LogInUser = new User();
        }
        public User LogInUser { get;  set; }
        public void OnGet()
        {
   
        }
        public IActionResult OnPost(User logInUser)
        {
            using(var db = new SkillCoacherContext())
            {
                
                if (db.Users.Count<User>(user => (user.Login == logInUser.Login))<1)
                {
                    return Page();
                }
                else if(db.Users.First<User>(user => (user.Login == logInUser.Login)).Password != logInUser.Password)
                {
                    return Page();
                }
                return RedirectToPage("/Index");
            }
        }
    }
}
