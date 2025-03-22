
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
        public DbSet<TvSeries> TvSeries { get; set; }
        public DbSet<Episode> Episodes { get; set; }

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
                    IsFeatured = true,
                    DateAdded = DateTime.Now
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
                    VideoUrl = "https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ElephantsDream.mp4",
                    DateAdded = DateTime.Now
                }
            );
            
            // Seed sample TV Series
            modelBuilder.Entity<TvSeries>().HasData(
                new TvSeries
                {
                    Id = 1,
                    Title = "Sample TV Series 1",
                    Description = "This is a sample TV series description.",
                    Creator = "Creator Name",
                    Genre = "Drama",
                    StartYear = 2020,
                    EndYear = null, // Still ongoing
                    ImageUrl = "https://via.placeholder.com/300x450/2e7d32/ffffff?text=TV+Series+1",
                    IsFeatured = true,
                    DateAdded = DateTime.Now
                },
                new TvSeries
                {
                    Id = 2,
                    Title = "Sample TV Series 2",
                    Description = "Another sample TV series description.",
                    Creator = "Another Creator",
                    Genre = "Sci-Fi",
                    StartYear = 2018,
                    EndYear = 2022,
                    ImageUrl = "https://via.placeholder.com/300x450/c62828/ffffff?text=TV+Series+2",
                    DateAdded = DateTime.Now
                }
            );
            
            // Seed sample Episodes
            modelBuilder.Entity<Episode>().HasData(
                new Episode
                {
                    Id = 1,
                    Title = "Pilot",
                    Description = "The first episode of the series.",
                    SeasonNumber = 1,
                    EpisodeNumber = 1,
                    VideoUrl = "https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ForBiggerBlazes.mp4",
                    Duration = 45,
                    TvSeriesId = 1
                },
                new Episode
                {
                    Id = 2,
                    Title = "The Journey Begins",
                    Description = "The second episode of the series.",
                    SeasonNumber = 1,
                    EpisodeNumber = 2,
                    VideoUrl = "https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ForBiggerEscapes.mp4",
                    Duration = 42,
                    TvSeriesId = 1
                },
                new Episode
                {
                    Id = 3,
                    Title = "New Beginnings",
                    Description = "The first episode of the second TV series.",
                    SeasonNumber = 1,
                    EpisodeNumber = 1,
                    VideoUrl = "https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ForBiggerFun.mp4",
                    Duration = 48,
                    TvSeriesId = 2
                }
            );
        }
    }
}
