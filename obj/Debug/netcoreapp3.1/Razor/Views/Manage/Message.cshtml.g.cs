#pragma checksum "E:\Projects\Piano Store\PianoStoreProject\PianoStoreProject\Views\Manage\Message.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d4949d578763b525d6e9727a162b7cf4c1d30c97"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Manage_Message), @"mvc.1.0.view", @"/Views/Manage/Message.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d4949d578763b525d6e9727a162b7cf4c1d30c97", @"/Views/Manage/Message.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"da0d3adaa56299f5e30d9db2d9ae10389c104928", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Manage_Message : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PianoStoreProject.Models.ContactViewModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "E:\Projects\Piano Store\PianoStoreProject\PianoStoreProject\Views\Manage\Message.cshtml"
  
    ViewData["Title"] = "Message";
    Layout = "~/Views/Shared/_LayoutDashboard.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-md-12 ml-auto mr-auto\">\r\n        <div class=\"card\">\r\n            <div class=\"card-header\">\r\n                <h4 class=\"card-title\">Subject: ");
#nullable restore
#line 11 "E:\Projects\Piano Store\PianoStoreProject\PianoStoreProject\Views\Manage\Message.cshtml"
                                           Write(Model.Subject);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4><hr />\r\n            </div>\r\n            <div class=\"card-body\">\r\n                <div class=\"row\">\r\n                    <div class=\"col-md-12 mt-1\">\r\n                        <p class=\"card-text\">\r\n                            ");
#nullable restore
#line 17 "E:\Projects\Piano Store\PianoStoreProject\PianoStoreProject\Views\Manage\Message.cshtml"
                       Write(Model.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            <br /><br />\r\n                            <b>Name: ");
#nullable restore
#line 19 "E:\Projects\Piano Store\PianoStoreProject\PianoStoreProject\Views\Manage\Message.cshtml"
                                Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b><br />\r\n                            <b>Email: ");
#nullable restore
#line 20 "E:\Projects\Piano Store\PianoStoreProject\PianoStoreProject\Views\Manage\Message.cshtml"
                                 Write(Model.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b><br />\r\n                            <b>Contact: ");
#nullable restore
#line 21 "E:\Projects\Piano Store\PianoStoreProject\PianoStoreProject\Views\Manage\Message.cshtml"
                                   Write(Model.PhoneNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b><br />\r\n                            <b>Dated: ");
#nullable restore
#line 22 "E:\Projects\Piano Store\PianoStoreProject\PianoStoreProject\Views\Manage\Message.cshtml"
                                 Write(Model.Datetime);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</b>
                        </p>
                    </div>
                </div>
                <div class=""row"">
                    <div class=""col-md-12"">
                        <a href=""/Manage/Emails"" class=""btn btn-default btn-round"">Back</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PianoStoreProject.Models.ContactViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
