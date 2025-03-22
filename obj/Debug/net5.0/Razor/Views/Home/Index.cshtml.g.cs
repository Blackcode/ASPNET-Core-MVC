#pragma checksum "/home/runner/workspace/Views/Home/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bf96c6b73833bbea731630ebf4c3e6db1763c491"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bf96c6b73833bbea731630ebf4c3e6db1763c491", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"edb54da60f17bf16a0c046da4d7a03e6da5f015f", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 2 "/home/runner/workspace/Views/Home/Index.cshtml"
  
    ViewData["Title"] = "Home Page";
    
    var featuredMovies = ViewData["FeaturedMovies"] as List<ASPNET_Core_MVC.Models.Movie> ?? new List<ASPNET_Core_MVC.Models.Movie>();
    var recentMovies = ViewData["RecentMovies"] as List<ASPNET_Core_MVC.Models.Movie> ?? new List<ASPNET_Core_MVC.Models.Movie>();
    var featuredTvSeries = ViewData["FeaturedTvSeries"] as List<ASPNET_Core_MVC.Models.TvSeries> ?? new List<ASPNET_Core_MVC.Models.TvSeries>();
    var recentTvSeries = ViewData["RecentTvSeries"] as List<ASPNET_Core_MVC.Models.TvSeries> ?? new List<ASPNET_Core_MVC.Models.TvSeries>();

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<div class=\"container\">\n    <h2 class=\"section-title\">Featured Movies</h2>\n    <div class=\"row\">\n");
#nullable restore
#line 14 "/home/runner/workspace/Views/Home/Index.cshtml"
         if (featuredMovies.Any())
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "/home/runner/workspace/Views/Home/Index.cshtml"
             foreach (var movie in featuredMovies)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col-md-2 mb-4\">\n                    <div class=\"card h-100\">\n                        <img");
            BeginWriteAttribute("src", " src=\"", 925, "\"", 1019, 1);
#nullable restore
#line 20 "/home/runner/workspace/Views/Home/Index.cshtml"
WriteAttributeValue("", 931, string.IsNullOrEmpty(movie.PosterUrl) ? "/images/default-movie.jpg" : movie.PosterUrl, 931, 88, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"card-img-top\"");
            BeginWriteAttribute("alt", " alt=\"", 1041, "\"", 1059, 1);
#nullable restore
#line 20 "/home/runner/workspace/Views/Home/Index.cshtml"
WriteAttributeValue("", 1047, movie.Title, 1047, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                        <div class=\"card-body\">\n                            <h5 class=\"card-title\">");
#nullable restore
#line 22 "/home/runner/workspace/Views/Home/Index.cshtml"
                                              Write(movie.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\n                            <p class=\"card-text\">");
#nullable restore
#line 23 "/home/runner/workspace/Views/Home/Index.cshtml"
                                            Write(movie.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n                            <a");
            BeginWriteAttribute("href", " href=\"", 1274, "\"", 1306, 2);
            WriteAttributeValue("", 1281, "/Movies/Details/", 1281, 16, true);
#nullable restore
#line 24 "/home/runner/workspace/Views/Home/Index.cshtml"
WriteAttributeValue("", 1297, movie.Id, 1297, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary\">View Details</a>\n                        </div>\n                    </div>\n                </div>\n");
#nullable restore
#line 28 "/home/runner/workspace/Views/Home/Index.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 28 "/home/runner/workspace/Views/Home/Index.cshtml"
             
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col-12\">\n                <p>No featured movies available.</p>\n            </div>\n");
#nullable restore
#line 35 "/home/runner/workspace/Views/Home/Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\n    \n    <h2 class=\"section-title\">Recent Movies</h2>\n    <div class=\"row\">\n");
#nullable restore
#line 40 "/home/runner/workspace/Views/Home/Index.cshtml"
         if (recentMovies.Any())
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 42 "/home/runner/workspace/Views/Home/Index.cshtml"
             foreach (var movie in recentMovies)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col-md-2 mb-4\">\n                    <div class=\"card h-100\">\n                        <img");
            BeginWriteAttribute("src", " src=\"", 1902, "\"", 1996, 1);
#nullable restore
#line 46 "/home/runner/workspace/Views/Home/Index.cshtml"
WriteAttributeValue("", 1908, string.IsNullOrEmpty(movie.PosterUrl) ? "/images/default-movie.jpg" : movie.PosterUrl, 1908, 88, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"card-img-top\"");
            BeginWriteAttribute("alt", " alt=\"", 2018, "\"", 2036, 1);
#nullable restore
#line 46 "/home/runner/workspace/Views/Home/Index.cshtml"
WriteAttributeValue("", 2024, movie.Title, 2024, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                        <div class=\"card-body\">\n                            <h5 class=\"card-title\">");
#nullable restore
#line 48 "/home/runner/workspace/Views/Home/Index.cshtml"
                                              Write(movie.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\n                            <p class=\"card-text\">");
#nullable restore
#line 49 "/home/runner/workspace/Views/Home/Index.cshtml"
                                            Write(movie.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n                            <a");
            BeginWriteAttribute("href", " href=\"", 2251, "\"", 2283, 2);
            WriteAttributeValue("", 2258, "/Movies/Details/", 2258, 16, true);
#nullable restore
#line 50 "/home/runner/workspace/Views/Home/Index.cshtml"
WriteAttributeValue("", 2274, movie.Id, 2274, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary\">View Details</a>\n                        </div>\n                    </div>\n                </div>\n");
#nullable restore
#line 54 "/home/runner/workspace/Views/Home/Index.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 54 "/home/runner/workspace/Views/Home/Index.cshtml"
             
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col-12\">\n                <p>No recent movies available.</p>\n            </div>\n");
#nullable restore
#line 61 "/home/runner/workspace/Views/Home/Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\n    \n    <h2 class=\"section-title\">Featured TV Series</h2>\n    <div class=\"row\">\n");
#nullable restore
#line 66 "/home/runner/workspace/Views/Home/Index.cshtml"
         if (featuredTvSeries.Any())
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 68 "/home/runner/workspace/Views/Home/Index.cshtml"
             foreach (var series in featuredTvSeries)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col-md-2 mb-4\">\n                    <div class=\"card h-100\">\n                        <img");
            BeginWriteAttribute("src", " src=\"", 2891, "\"", 2988, 1);
#nullable restore
#line 72 "/home/runner/workspace/Views/Home/Index.cshtml"
WriteAttributeValue("", 2897, string.IsNullOrEmpty(series.PosterUrl) ? "/images/default-series.jpg" : series.PosterUrl, 2897, 91, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"card-img-top\"");
            BeginWriteAttribute("alt", " alt=\"", 3010, "\"", 3029, 1);
#nullable restore
#line 72 "/home/runner/workspace/Views/Home/Index.cshtml"
WriteAttributeValue("", 3016, series.Title, 3016, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                        <div class=\"card-body\">\n                            <h5 class=\"card-title\">");
#nullable restore
#line 74 "/home/runner/workspace/Views/Home/Index.cshtml"
                                              Write(series.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\n                            <p class=\"card-text\">");
#nullable restore
#line 75 "/home/runner/workspace/Views/Home/Index.cshtml"
                                            Write(series.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n                            <a");
            BeginWriteAttribute("href", " href=\"", 3246, "\"", 3281, 2);
            WriteAttributeValue("", 3253, "/TvSeries/Details/", 3253, 18, true);
#nullable restore
#line 76 "/home/runner/workspace/Views/Home/Index.cshtml"
WriteAttributeValue("", 3271, series.Id, 3271, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary\">View Details</a>\n                        </div>\n                    </div>\n                </div>\n");
#nullable restore
#line 80 "/home/runner/workspace/Views/Home/Index.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 80 "/home/runner/workspace/Views/Home/Index.cshtml"
             
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col-12\">\n                <p>No featured TV series available.</p>\n            </div>\n");
#nullable restore
#line 87 "/home/runner/workspace/Views/Home/Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\n    \n    <h2 class=\"section-title\">Recent TV Series</h2>\n    <div class=\"row\">\n");
#nullable restore
#line 92 "/home/runner/workspace/Views/Home/Index.cshtml"
         if (recentTvSeries.Any())
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 94 "/home/runner/workspace/Views/Home/Index.cshtml"
             foreach (var series in recentTvSeries)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col-md-2 mb-4\">\n                    <div class=\"card h-100\">\n                        <img");
            BeginWriteAttribute("src", " src=\"", 3888, "\"", 3985, 1);
#nullable restore
#line 98 "/home/runner/workspace/Views/Home/Index.cshtml"
WriteAttributeValue("", 3894, string.IsNullOrEmpty(series.PosterUrl) ? "/images/default-series.jpg" : series.PosterUrl, 3894, 91, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"card-img-top\"");
            BeginWriteAttribute("alt", " alt=\"", 4007, "\"", 4026, 1);
#nullable restore
#line 98 "/home/runner/workspace/Views/Home/Index.cshtml"
WriteAttributeValue("", 4013, series.Title, 4013, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                        <div class=\"card-body\">\n                            <h5 class=\"card-title\">");
#nullable restore
#line 100 "/home/runner/workspace/Views/Home/Index.cshtml"
                                              Write(series.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\n                            <p class=\"card-text\">");
#nullable restore
#line 101 "/home/runner/workspace/Views/Home/Index.cshtml"
                                            Write(series.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n                            <a");
            BeginWriteAttribute("href", " href=\"", 4243, "\"", 4278, 2);
            WriteAttributeValue("", 4250, "/TvSeries/Details/", 4250, 18, true);
#nullable restore
#line 102 "/home/runner/workspace/Views/Home/Index.cshtml"
WriteAttributeValue("", 4268, series.Id, 4268, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary\">View Details</a>\n                        </div>\n                    </div>\n                </div>\n");
#nullable restore
#line 106 "/home/runner/workspace/Views/Home/Index.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 106 "/home/runner/workspace/Views/Home/Index.cshtml"
             
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col-12\">\n                <p>No recent TV series available.</p>\n            </div>\n");
#nullable restore
#line 113 "/home/runner/workspace/Views/Home/Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\n</div>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
