#pragma checksum "C:\Users\Dimab\Desktop\CourseProject\rr\SkillCoacher\Pages\Shared\_PartialSearchBar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ccf0de783beaf8805c68dc257a9acbf5f5da7d99"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(SkillCoacher.Pages.Shared.Pages_Shared__PartialSearchBar), @"mvc.1.0.view", @"/Pages/Shared/_PartialSearchBar.cshtml")]
namespace SkillCoacher.Pages.Shared
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
#nullable restore
#line 1 "C:\Users\Dimab\Desktop\CourseProject\rr\SkillCoacher\Pages\Shared\_PartialSearchBar.cshtml"
using Model.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ccf0de783beaf8805c68dc257a9acbf5f5da7d99", @"/Pages/Shared/_PartialSearchBar.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9ad727454c60c742945e5cb8cc6ecb2186d4d4ca", @"/Pages/_ViewImports.cshtml")]
    #nullable restore
    public class Pages_Shared__PartialSearchBar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<string>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 5 "C:\Users\Dimab\Desktop\CourseProject\rr\SkillCoacher\Pages\Shared\_PartialSearchBar.cshtml"
                 foreach (var suggestion in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li>");
#nullable restore
#line 7 "C:\Users\Dimab\Desktop\CourseProject\rr\SkillCoacher\Pages\Shared\_PartialSearchBar.cshtml"
                   Write(suggestion);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 8 "C:\Users\Dimab\Desktop\CourseProject\rr\SkillCoacher\Pages\Shared\_PartialSearchBar.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("    ");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<string>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
