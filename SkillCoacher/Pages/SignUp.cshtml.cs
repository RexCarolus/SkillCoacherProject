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
        private SkillCoacherContext _db;
        public BaseUser NewUser { get;  set; }

        public SignUpModel(SkillCoacherContext context)
        {
            _db = context;
        }

        public void OnGet()
        {
   
        }

        public async Task<IActionResult> OnPost(CommonUser newUser)
        {
            var user = _db.CommonUsers.Where(user => (user.Login == newUser.Login));
            if (user == null)
            {
                return Page();
            }
            else
            _db.CommonUsers.Add(newUser);
            _db.SaveChanges();
            await Authenticate(newUser.Login);
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
