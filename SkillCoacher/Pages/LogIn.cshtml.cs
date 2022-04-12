using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.Models;
using Model.Context;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace SkillCoacher.Pages
{
    public class LogInModel : PageModel
    {
        private SkillCoacherContext _db;
        public BaseUser LogInUser { get;  set; }

        public LogInModel(SkillCoacherContext context)
        {
            _db = context;
        }

        public void OnGet()
        {
   
        }

        public async Task<IActionResult> OnPost(BaseUser logInUser)
        {
            CommonUser user = await _db.CommonUsers.FirstOrDefaultAsync(user => (user.Login == logInUser.Login));
            if (user == null)
            {
                return Page();
            }
            else if(user.Password == logInUser.Password)
            {
                await Authenticate(logInUser.Login);
            }
            return RedirectToPage("/Index");
        }

        private async Task Authenticate(string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
