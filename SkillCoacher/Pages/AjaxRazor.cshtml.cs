using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace SkillCoacher.Pages
{
    public class AjaxRazorModel : PageModel
    {
        private readonly ILogger<AjaxRazorModel> _logger;
        [BindProperty]
        public string Title { get; set; }

        public AjaxRazorModel(ILogger<AjaxRazorModel> logger)
        {
            _logger = logger;
            Title = "Hello";
        }

        public void OnGet()
        {
           
            
        }
        public void OnPost()
        {

        }
        public void OnPostAdd(string info)
        {

        }
    }
}
