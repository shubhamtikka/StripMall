#pragma checksum "C:\Users\tshub\source\repos\StripMall\StripMall\Views\Administration\ShowFeedBacks.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "908eddb136a01eb4a05f401479b18fada86f4d0c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Administration_ShowFeedBacks), @"mvc.1.0.view", @"/Views/Administration/ShowFeedBacks.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Administration/ShowFeedBacks.cshtml", typeof(AspNetCore.Views_Administration_ShowFeedBacks))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\tshub\source\repos\StripMall\StripMall\Views\_ViewImports.cshtml"
using StripMall;

#line default
#line hidden
#line 2 "C:\Users\tshub\source\repos\StripMall\StripMall\Views\_ViewImports.cshtml"
using StripMall.Models;

#line default
#line hidden
#line 3 "C:\Users\tshub\source\repos\StripMall\StripMall\Views\_ViewImports.cshtml"
using StripMall.ViewModels;

#line default
#line hidden
#line 4 "C:\Users\tshub\source\repos\StripMall\StripMall\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"908eddb136a01eb4a05f401479b18fada86f4d0c", @"/Views/Administration/ShowFeedBacks.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0b4ade408e34525042623964dc43cf9ddcefbd7d", @"/Views/_ViewImports.cshtml")]
    public class Views_Administration_ShowFeedBacks : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<StripMall.Models.Feedback>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(47, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\tshub\source\repos\StripMall\StripMall\Views\Administration\ShowFeedBacks.cshtml"
  
    ViewData["Title"] = "ShowFeedBacks";

#line default
#line hidden
            BeginContext(98, 320, true);
            WriteLiteral(@"
<h3>FeedBacks</h3>

<table class=""table"">
    <thead class=""thead-light"">
        <tr>
            <th>
               Customer
            </th>
            <th>
                FeedBack
            </th>
            <th>
                Date
            </th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 24 "C:\Users\tshub\source\repos\StripMall\StripMall\Views\Administration\ShowFeedBacks.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
            BeginContext(450, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(499, 45, false);
#line 27 "C:\Users\tshub\source\repos\StripMall\StripMall\Views\Administration\ShowFeedBacks.cshtml"
           Write(Html.DisplayFor(modelItem => item.CustomerId));

#line default
#line hidden
            EndContext();
            BeginContext(544, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(600, 47, false);
#line 30 "C:\Users\tshub\source\repos\StripMall\StripMall\Views\Administration\ShowFeedBacks.cshtml"
           Write(Html.DisplayFor(modelItem => item.FeedBackText));

#line default
#line hidden
            EndContext();
            BeginContext(647, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(703, 44, false);
#line 33 "C:\Users\tshub\source\repos\StripMall\StripMall\Views\Administration\ShowFeedBacks.cshtml"
           Write(Html.DisplayFor(modelItem => item.Date.Date));

#line default
#line hidden
            EndContext();
            BeginContext(747, 38, true);
            WriteLiteral("\r\n            </td>\r\n\r\n        </tr>\r\n");
            EndContext();
#line 37 "C:\Users\tshub\source\repos\StripMall\StripMall\Views\Administration\ShowFeedBacks.cshtml"
}

#line default
#line hidden
            BeginContext(788, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<ApplicationUser> signInManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<StripMall.Models.Feedback>> Html { get; private set; }
    }
}
#pragma warning restore 1591
