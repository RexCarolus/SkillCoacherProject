#pragma checksum "C:\Users\Dimab\Desktop\CourseProject\rr\SkillCoacher\Pages\ChapterPage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d904c78fea8a5a9b4d8dee241830f8f5064be0a9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(SkillCoacher.Pages.Pages_ChapterPage), @"mvc.1.0.razor-page", @"/Pages/ChapterPage.cshtml")]
namespace SkillCoacher.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Dimab\Desktop\CourseProject\rr\SkillCoacher\Pages\_ViewImports.cshtml"
using SkillCoacher;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemMetadataAttribute("RouteTemplate", "{id}")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d904c78fea8a5a9b4d8dee241830f8f5064be0a9", @"/Pages/ChapterPage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9ad727454c60c742945e5cb8cc6ecb2186d4d4ca", @"/Pages/_ViewImports.cshtml")]
    public class Pages_ChapterPage : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\Dimab\Desktop\CourseProject\rr\SkillCoacher\Pages\ChapterPage.cshtml"
  
    ViewData["Title"] = "Chapter page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"col-md-8 blog-main\">\r\n    <div class=\"blog-post\">\r\n        <h2 class=\"blog-post-title\">");
#nullable restore
#line 9 "C:\Users\Dimab\Desktop\CourseProject\rr\SkillCoacher\Pages\ChapterPage.cshtml"
                               Write(Model.SelectedCourse.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n        <p class=\"blog-post-meta\">January 1, 2014 by <a href=\"#\">Mark</a></p>\r\n        <hr>\r\n        <div>");
#nullable restore
#line 12 "C:\Users\Dimab\Desktop\CourseProject\rr\SkillCoacher\Pages\ChapterPage.cshtml"
        Write(Html.Raw(Model.SelectedCourse.Content));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n        <hr>\r\n        </div>\r\n</div>\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ChapterPageModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ChapterPageModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ChapterPageModel>)PageContext?.ViewData;
        public ChapterPageModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591