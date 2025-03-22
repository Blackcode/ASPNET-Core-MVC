
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ASPNET_Core_MVC.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Director = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Genre = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    ReleaseYear = table.Column<int>(type: "INTEGER", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: true),
                    VideoUrl = table.Column<string>(type: "TEXT", nullable: true),
                    IsFeatured = table.Column<bool>(type: "INTEGER", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            // Seed admin user
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Username", "PasswordHash", "Role" },
                values: new object[] { 1, "admin", "AQAAAAEAACcQAAAAEKXG5dqDuBMy0f+3xLm0ngxkGtGE6ZFZi99Qj1SgCaKkVY6AUGPgUKrm6BdnRZZ13w==", "Admin" });

            // Seed sample movies
            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Title", "Description", "Director", "Genre", "ReleaseYear", "ImageUrl", "VideoUrl", "IsFeatured", "DateAdded" },
                values: new object[] { 1, "Sample Movie 1", "This is a sample movie description.", "Director Name", "Action", 2021, "/images/sample1.jpg", "https://sample-videos.com/video123/mp4/720/big_buck_bunny_720p_1mb.mp4", true, DateTime.Now });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Title", "Description", "Director", "Genre", "ReleaseYear", "ImageUrl", "VideoUrl", "IsFeatured", "DateAdded" },
                values: new object[] { 2, "Sample Movie 2", "Another sample movie description.", "Another Director", "Comedy", 2020, "/images/sample2.jpg", "https://sample-videos.com/video123/mp4/720/big_buck_bunny_720p_1mb.mp4", false, DateTime.Now });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
                
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
