#pragma checksum "E:\Projects\Piano Store\PianoStoreProject\PianoStoreProject\Views\Home\Categories.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "44ceb7b3bef5739be300fa65cd17e0bfd3a231c0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Categories), @"mvc.1.0.view", @"/Views/Home/Categories.cshtml")]
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
#nullable restore
#line 1 "E:\Projects\Piano Store\PianoStoreProject\PianoStoreProject\Views\_ViewImports.cshtml"
using PianoStoreProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Projects\Piano Store\PianoStoreProject\PianoStoreProject\Views\_ViewImports.cshtml"
using PianoStoreProject.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "E:\Projects\Piano Store\PianoStoreProject\PianoStoreProject\Views\Home\Categories.cshtml"
using PianoStoreProject.Repositories;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44ceb7b3bef5739be300fa65cd17e0bfd3a231c0", @"/Views/Home/Categories.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"da0d3adaa56299f5e30d9db2d9ae10389c104928", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Categories : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "E:\Projects\Piano Store\PianoStoreProject\PianoStoreProject\Views\Home\Categories.cshtml"
  
	ViewData["Title"] = "Categories";
	Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<main class=\"products\">\r\n");
#nullable restore
#line 9 "E:\Projects\Piano Store\PianoStoreProject\PianoStoreProject\Views\Home\Categories.cshtml"
     foreach (var item in CategoryProvider.GetAllCategories())
	{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t<div class=\"product-1\" id=\"text\">\r\n\t\t\t<img class=\"prod-img-1\"");
            BeginWriteAttribute("src", " src=\"", 329, "\"", 357, 1);
#nullable restore
#line 12 "E:\Projects\Piano Store\PianoStoreProject\PianoStoreProject\Views\Home\Categories.cshtml"
WriteAttributeValue("", 335, item.CategoryImageUrl, 335, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 358, "\"", 382, 1);
#nullable restore
#line 12 "E:\Projects\Piano Store\PianoStoreProject\PianoStoreProject\Views\Home\Categories.cshtml"
WriteAttributeValue("", 364, item.CategoryName, 364, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n\t\t\t<h2>");
#nullable restore
#line 13 "E:\Projects\Piano Store\PianoStoreProject\PianoStoreProject\Views\Home\Categories.cshtml"
           Write(item.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n\t\t\t<a");
            BeginWriteAttribute("href", " href=\"", 423, "\"", 456, 2);
            WriteAttributeValue("", 430, "/Home/Products?Id=", 430, 18, true);
#nullable restore
#line 14 "E:\Projects\Piano Store\PianoStoreProject\PianoStoreProject\Views\Home\Categories.cshtml"
WriteAttributeValue("", 448, item.Id, 448, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn3\">Browse Now &#8594;</a>\r\n\t\t</div>\r\n");
#nullable restore
#line 16 "E:\Projects\Piano Store\PianoStoreProject\PianoStoreProject\Views\Home\Categories.cshtml"
	}

#line default
#line hidden
#nullable disable
            WriteLiteral("</main>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public ICategoryRepository CategoryProvider { get; private set; } = default!;
        #nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591