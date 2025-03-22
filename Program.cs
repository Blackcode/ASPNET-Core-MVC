
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using ASPNET_Core_MVC.Data;
using Microsoft.EntityFrameworkCore;

namespace ASPNET_Core_MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<MovieDbContext>();
                    
                    // Ensure database exists and is created using EF Core's migration system
                    // Create database and apply migrations if they exist
                    if (context.Database.GetPendingMigrations().Any())
                    {
                        context.Database.Migrate();
                    }
                    else
                    {
                        context.Database.EnsureCreated();
                    }
                    
                    try
                    {
                        // Check if there are any users, if not, seed the database
                        if (!context.Users.Any())
                        {
                            // Add admin user
                            context.Users.Add(new Models.User
                            {
                                Username = "admin",
                                PasswordHash = "AQAAAAEAACcQAAAAEKXG5dqDuBMy0f+3xLm0ngxkGtGE6ZFZi99Qj1SgCaKkVY6AUGPgUKrm6BdnRZZ13w==",
                                Role = "Admin",
                                DateCreated = DateTime.Now
                            });

                            // Add sample movies
                            context.Movies.Add(new Models.Movie
                            {
                                Title = "Sample Movie 1",
                                Description = "This is a sample movie description.",
                                Director = "Director Name",
                                Genre = "Action",
                                ReleaseYear = 2021,
                                ImageUrl = "/images/sample1.jpg",
                                VideoUrl = "https://sample-videos.com/video123/mp4/720/big_buck_bunny_720p_1mb.mp4",
                                IsFeatured = true,
                                DateAdded = DateTime.Now
                            });

                            context.Movies.Add(new Models.Movie
                            {
                                Title = "Sample Movie 2",
                                Description = "Another sample movie description.",
                                Director = "Another Director",
                                Genre = "Comedy",
                                ReleaseYear = 2020,
                                ImageUrl = "/images/sample2.jpg",
                                VideoUrl = "https://sample-videos.com/video123/mp4/720/big_buck_bunny_720p_1mb.mp4",
                                IsFeatured = false,
                                DateAdded = DateTime.Now
                            });

                            // Save changes to the database
                            context.SaveChanges();
                        }
                    }
                    catch (Exception ex)
                    {
                        var logger = services.GetRequiredService<ILogger<Program>>();
                        logger.LogError(ex, "An error occurred while creating the database tables.");
                    }
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while migrating the database.");
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
