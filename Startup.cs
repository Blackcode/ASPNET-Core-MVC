using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using ASPNET_Core_MVC.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Microsoft.Extensions.Logging;

namespace ASPNET_Core_MVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Configure SQLite with a larger command timeout
            services.AddDbContext<MovieDbContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("MovieDbContext"), 
                    sqliteOptions => sqliteOptions.CommandTimeout(60)));

            // Add memory cache
            services.AddMemoryCache();
            
            // Add response caching
            services.AddResponseCaching();
            
            // Add response compression
            services.AddResponseCompression(options =>
            {
                options.Providers.Add<Microsoft.AspNetCore.ResponseCompression.BrotliCompressionProvider>();
                options.Providers.Add<Microsoft.AspNetCore.ResponseCompression.GzipCompressionProvider>();
                options.EnableForHttps = true;
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Account/Login";
                    options.AccessDeniedPath = "/Account/AccessDenied";
                    options.Cookie.HttpOnly = true;
                    options.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
                    options.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest;
                });

            services.AddControllersWithViews(options =>
            {
                // Add automatic model state validation
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            // Add global exception handling
            app.Use(async (context, next) =>
            {
                try
                {
                    await next();
                }
                catch (Exception ex)
                {
                    var logger = context.RequestServices.GetRequiredService<ILogger<Startup>>();
                    logger.LogError(ex, "Unhandled exception occurred");
                    
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "text/html";
                    
                    var errorMessage = System.Text.Encoding.UTF8.GetBytes(
                        $"<html><body><h1>Server Error</h1><p>An error occurred: {ex.Message}</p></body></html>");
                    
                    await context.Response.Body.WriteAsync(errorMessage, 0, errorMessage.Length);
                }
            });
            
            // Enable response compression
            app.UseResponseCompression();
            
            // Add response caching
            app.UseResponseCaching();
            
            app.UseHttpsRedirection();
            
            // Configure static files with caching
            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = ctx =>
                {
                    // Cache static files for 7 days
                    ctx.Context.Response.Headers[HeaderNames.CacheControl] = "public,max-age=604800";
                }
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}