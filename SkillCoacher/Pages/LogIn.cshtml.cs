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
        public LogInModel(SkillCoacherContext context)
        {
            db = context;
        }
        private SkillCoacherContext db;
        public BaseUser LogInUser { get;  set; }
        public void OnGet()
        {
   
        }
        public async Task<IActionResult> OnPost(BaseUser logInUser)
        {
            CommonUser user = await db.CommonUsers.FirstOrDefaultAsync(user => (user.Login == logInUser.Login));
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
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
