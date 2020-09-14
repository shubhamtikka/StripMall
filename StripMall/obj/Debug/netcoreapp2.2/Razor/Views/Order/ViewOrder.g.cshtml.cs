#pragma checksum "C:\Users\tshub\source\repos\StripMall\StripMall\Views\Order\ViewOrder.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1f9b9a2d36393713a3356935131a0846c4c38b94"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_ViewOrder), @"mvc.1.0.view", @"/Views/Order/ViewOrder.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Order/ViewOrder.cshtml", typeof(AspNetCore.Views_Order_ViewOrder))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1f9b9a2d36393713a3356935131a0846c4c38b94", @"/Views/Order/ViewOrder.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0b4ade408e34525042623964dc43cf9ddcefbd7d", @"/Views/_ViewImports.cshtml")]
    public class Views_Order_ViewOrder : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<StripMall.Models.OrderDetails>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(51, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\tshub\source\repos\StripMall\StripMall\Views\Order\ViewOrder.cshtml"
  
    ViewData["Title"] = "ViewOrder";
    var OrderTotal = Model.Sum(Model => Model.ItemTotal);
    var id = Model.Select(Model => Model.OrderId).Distinct().FirstOrDefault();

#line default
#line hidden
            BeginContext(237, 21, true);
            WriteLiteral("<br/>\r\n<h3>OrderId : ");
            EndContext();
            BeginContext(259, 2, false);
#line 9 "C:\Users\tshub\source\repos\StripMall\StripMall\Views\Order\ViewOrder.cshtml"
         Write(id);

#line default
#line hidden
            EndContext();
            BeginContext(261, 204, true);
            WriteLiteral("</h3>\r\n<hr/>\r\n<div class=\"row\">\r\n    <div class=\"col-md-8\">\r\n        <table class=\"table\">\r\n            <thead class=\"thead-dark\">\r\n                <tr>\r\n                    <th>\r\n                        ");
            EndContext();
            BeginContext(466, 44, false);
#line 17 "C:\Users\tshub\source\repos\StripMall\StripMall\Views\Order\ViewOrder.cshtml"
                   Write(Html.DisplayNameFor(model => model.ItemName));

#line default
#line hidden
            EndContext();
            BeginContext(510, 79, true);
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
            EndContext();
            BeginContext(590, 44, false);
#line 20 "C:\Users\tshub\source\repos\StripMall\StripMall\Views\Order\ViewOrder.cshtml"
                   Write(Html.DisplayNameFor(model => model.ShopName));

#line default
#line hidden
            EndContext();
            BeginContext(634, 81, true);
            WriteLiteral("\r\n                    </th>\r\n\r\n                    <th>\r\n                        ");
            EndContext();
            BeginContext(716, 45, false);
#line 24 "C:\Users\tshub\source\repos\StripMall\StripMall\Views\Order\ViewOrder.cshtml"
                   Write(Html.DisplayNameFor(model => model.ItemPrice));

#line default
#line hidden
            EndContext();
            BeginContext(761, 79, true);
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
            EndContext();
            BeginContext(841, 45, false);
#line 27 "C:\Users\tshub\source\repos\StripMall\StripMall\Views\Order\ViewOrder.cshtml"
                   Write(Html.DisplayNameFor(model => model.ItemCount));

#line default
#line hidden
            EndContext();
            BeginContext(886, 79, true);
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
            EndContext();
            BeginContext(966, 45, false);
#line 30 "C:\Users\tshub\source\repos\StripMall\StripMall\Views\Order\ViewOrder.cshtml"
                   Write(Html.DisplayNameFor(model => model.ItemTotal));

#line default
#line hidden
            EndContext();
            BeginContext(1011, 95, true);
            WriteLiteral("\r\n                    </th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
            EndContext();
#line 35 "C:\Users\tshub\source\repos\StripMall\StripMall\Views\Order\ViewOrder.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
            BeginContext(1171, 84, true);
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(1256, 43, false);
#line 39 "C:\Users\tshub\source\repos\StripMall\StripMall\Views\Order\ViewOrder.cshtml"
                       Write(Html.DisplayFor(modelItem => item.ItemName));

#line default
#line hidden
            EndContext();
            BeginContext(1299, 91, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(1391, 43, false);
#line 42 "C:\Users\tshub\source\repos\StripMall\StripMall\Views\Order\ViewOrder.cshtml"
                       Write(Html.DisplayFor(modelItem => item.ShopName));

#line default
#line hidden
            EndContext();
            BeginContext(1434, 93, true);
            WriteLiteral("\r\n                        </td>\r\n\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(1528, 44, false);
#line 46 "C:\Users\tshub\source\repos\StripMall\StripMall\Views\Order\ViewOrder.cshtml"
                       Write(Html.DisplayFor(modelItem => item.ItemPrice));

#line default
#line hidden
            EndContext();
            BeginContext(1572, 91, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(1664, 44, false);
#line 49 "C:\Users\tshub\source\repos\StripMall\StripMall\Views\Order\ViewOrder.cshtml"
                       Write(Html.DisplayFor(modelItem => item.ItemCount));

#line default
#line hidden
            EndContext();
            BeginContext(1708, 91, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(1800, 44, false);
#line 52 "C:\Users\tshub\source\repos\StripMall\StripMall\Views\Order\ViewOrder.cshtml"
                       Write(Html.DisplayFor(modelItem => item.ItemTotal));

#line default
#line hidden
            EndContext();
            BeginContext(1844, 60, true);
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");
            EndContext();
#line 55 "C:\Users\tshub\source\repos\StripMall\StripMall\Views\Order\ViewOrder.cshtml"
                }

#line default
#line hidden
            BeginContext(1923, 91, true);
            WriteLiteral("            </tbody>\r\n        </table>\r\n        <h6 class=\"alert alert-info\">Order Total : ");
            EndContext();
            BeginContext(2015, 10, false);
#line 58 "C:\Users\tshub\source\repos\StripMall\StripMall\Views\Order\ViewOrder.cshtml"
                                              Write(OrderTotal);

#line default
#line hidden
            EndContext();
            BeginContext(2025, 31, true);
            WriteLiteral("</h6>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
            EndContext();
            BeginContext(2056, 65, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1f9b9a2d36393713a3356935131a0846c4c38b9410760", async() => {
                BeginContext(2100, 17, true);
                WriteLiteral("Back to Home page");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<StripMall.Models.OrderDetails>> Html { get; private set; }
    }
}
#pragma warning restore 1591