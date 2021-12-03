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
    public class SignUpModel : PageModel
    {
        private readonly ILogger<SignUpModel> _logger;

        public SignUpModel(ILogger<SignUpModel> logger)
        {
            _logger = logger;
            NewUser = new User();
        }
        public User NewUser { get;  set; }
        public void OnGet()
        {
   
        }
        public IActionResult OnPost(User newUser)
        {
            using(var db = new SkillCoacherContext())
            {
                
                newUser.Role = UserRoles.BasicUser;
                if(db.Users.Count<User>(user =>(user.Login == newUser.Login))>0)
                {
                    return Page();
                }
                else
                db.Users.Add(newUser);
                db.SaveChanges();
                return RedirectToPage("/Index");
            }
        }
    }
}
