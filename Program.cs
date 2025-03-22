
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
                    
                    // First ensure the database file exists
                    context.Database.EnsureCreated();
                    
                    try
                    {
                        // Check if tables exist, if not create them
                        context.Database.ExecuteSqlRaw(@"
                            CREATE TABLE IF NOT EXISTS Movies (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                Title TEXT NOT NULL,
                                Description TEXT,
                                Director TEXT,
                                Genre TEXT,
                                ReleaseYear INTEGER NOT NULL,
                                ImageUrl TEXT,
                                VideoUrl TEXT,
                                IsFeatured INTEGER NOT NULL,
                                DateAdded TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP
                            );
                            
                            CREATE TABLE IF NOT EXISTS Users (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                Username TEXT NOT NULL,
                                PasswordHash TEXT NOT NULL,
                                Role TEXT NOT NULL
                            );
                        ");
                        
                        // Check if data exists to avoid duplication
                        var userCount = context.Database.ExecuteSqlRaw("SELECT COUNT(*) FROM Users");
                        if (userCount == 0)
                        {
                            // Insert sample data
                            context.Database.ExecuteSqlRaw(@"
                                -- Insert admin user
                                INSERT INTO Users (Username, PasswordHash, Role)
                                VALUES ('admin', 'AQAAAAEAACcQAAAAEKXG5dqDuBMy0f+3xLm0ngxkGtGE6ZFZi99Qj1SgCaKkVY6AUGPgUKrm6BdnRZZ13w==', 'Admin');
                                
                                -- Insert sample movies
                                INSERT INTO Movies (Title, Description, Director, Genre, ReleaseYear, ImageUrl, VideoUrl, IsFeatured)
                                VALUES ('Sample Movie 1', 'This is a sample movie description.', 'Director Name', 'Action', 2021, '/images/sample1.jpg', 'https://sample-videos.com/video123/mp4/720/big_buck_bunny_720p_1mb.mp4', 1);
                                
                                INSERT INTO Movies (Title, Description, Director, Genre, ReleaseYear, ImageUrl, VideoUrl, IsFeatured)
                                VALUES ('Sample Movie 2', 'Another sample movie description.', 'Another Director', 'Comedy', 2020, '/images/sample2.jpg', 'https://sample-videos.com/video123/mp4/720/big_buck_bunny_720p_1mb.mp4', 0);
                            ");
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
