#pragma checksum "/home/runner/workspace/Views/Admin/Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ed9a40082fc38a23c81351f5f70e7af84be59be9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Create), @"mvc.1.0.view", @"/Views/Admin/Create.cshtml")]
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
#line 4 "/home/runner/workspace/Views/_ViewImports.cshtml"
using ASPNET_Core_MVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/home/runner/workspace/Views/_ViewImports.cshtml"
using ASPNET_Core_MVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ed9a40082fc38a23c81351f5f70e7af84be59be9", @"/Views/Admin/Create.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"edb54da60f17bf16a0c046da4d7a03e6da5f015f", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ASPNET_Core_MVC.Models.Movie>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
            WriteLiteral("\n");
#nullable restore
#line 4 "/home/runner/workspace/Views/Admin/Create.cshtml"
  
    ViewData["Title"] = "Add Movie";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Add New Movie</h1>

<div class=""row"">
    <div class=""col-md-8"">
        <form asp-action=""Create"">
            <div asp-validation-summary=""ModelOnly"" class=""text-danger""></div>
            <div class=""form-group"">
                <label asp-for=""Title"" class=""control-label""></label>
                <input asp-for=""Title"" class=""form-control"" />
                <span asp-validation-for=""Title"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""Description"" class=""control-label""></label>
                <textarea asp-for=""Description"" class=""form-control"" rows=""3""></textarea>
                <span asp-validation-for=""Description"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""Director"" class=""control-label""></label>
                <input asp-for=""Director"" class=""form-control"" />
                <span asp-validation-for=""Director"" class=""text-danger""></span>
            <");
            WriteLiteral(@"/div>
            <div class=""form-group"">
                <label asp-for=""Genre"" class=""control-label""></label>
                <select asp-for=""Genre"" class=""form-control"">
                    <option value=""Action"">Action</option>
                    <option value=""Comedy"">Comedy</option>
                    <option value=""Drama"">Drama</option>
                    <option value=""Horror"">Horror</option>
                    <option value=""Romance"">Romance</option>
                    <option value=""Sci-Fi"">Sci-Fi</option>
                    <option value=""Thriller"">Thriller</option>
                </select>
                <span asp-validation-for=""Genre"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""ReleaseYear"" class=""control-label""></label>
                <input asp-for=""ReleaseYear"" class=""form-control"" />
                <span asp-validation-for=""ReleaseYear"" class=""text-danger""></span>
            </div>
            <div class=""fo");
            WriteLiteral(@"rm-group"">
                <label asp-for=""ImageUrl"" class=""control-label""></label>
                <input asp-for=""ImageUrl"" class=""form-control"" />
                <span asp-validation-for=""ImageUrl"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""VideoUrl"" class=""control-label""></label>
                <input asp-for=""VideoUrl"" class=""form-control"" />
                <span asp-validation-for=""VideoUrl"" class=""text-danger""></span>
            </div>
            <div class=""form-group form-check"">
                <label class=""form-check-label"">
                    <input class=""form-check-input"" asp-for=""IsFeatured"" /> ");
#nullable restore
#line 59 "/home/runner/workspace/Views/Admin/Create.cshtml"
                                                                       Write(Html.DisplayNameFor(model => model.IsFeatured));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </label>
            </div>
            <div class=""form-group"">
                <input type=""submit"" value=""Create"" class=""btn btn-primary"" />
                <a asp-action=""Index"" class=""btn btn-secondary"">Back to List</a>
            </div>
        </form>
    </div>
</div>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ASPNET_Core_MVC.Models.Movie> Html { get; private set; }
    }
}
#pragma warning restore 1591
