
using Microsoft.EntityFrameworkCore;
using ASPNET_Core_MVC.Models;

namespace ASPNET_Core_MVC.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed admin user
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "admin",
                    PasswordHash = "AQAAAAEAACcQAAAAEKXG5dqDuBMy0f+3xLm0ngxkGtGE6ZFZi99Qj1SgCaKkVY6AUGPgUKrm6BdnRZZ13w==", // "admin123"
                    Role = "Admin"
                }
            );

            // Seed sample movies
            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 1,
                    Title = "Sample Movie 1",
                    Description = "This is a sample movie description.",
                    Director = "Director Name",
                    Genre = "Action",
                    ReleaseYear = 2021,
                    ImageUrl = "https://via.placeholder.com/300x450/343a40/ffffff?text=Movie+1",
                    VideoUrl = "https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4",
                    IsFeatured = true
                },
                new Movie
                {
                    Id = 2,
                    Title = "Sample Movie 2",
                    Description = "Another sample movie description.",
                    Director = "Another Director",
                    Genre = "Comedy",
                    ReleaseYear = 2020,
                    ImageUrl = "https://via.placeholder.com/300x450/1a237e/ffffff?text=Movie+2",
                    VideoUrl = "https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ElephantsDream.mp4"
                }
            );
        }
    }
}
