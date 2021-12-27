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
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace SkillCoacher.Pages
{
    public class SignUpModel : PageModel
    {
        public SignUpModel(SkillCoacherContext context)
        {
            db = context;
        }
        private SkillCoacherContext db;
        public BaseUser NewUser { get;  set; }
        public void OnGet()
        {
   
        }
        public async Task<IActionResult> OnPost(CommonUser newUser)
        {
            var user = db.CommonUsers.Where(user => (user.Login == newUser.Login));
            if (user == null)
            {
                return Page();
            }
            else
            db.CommonUsers.Add(newUser);
            db.SaveChanges();
            await Authenticate(newUser.Login);
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
