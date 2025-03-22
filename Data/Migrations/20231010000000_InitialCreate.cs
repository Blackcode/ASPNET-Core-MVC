
using System;
using Microsoft.EntityFrameworkCore.Migrations;

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
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Director = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    Genre = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    ReleaseYear = table.Column<int>(type: "INTEGER", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    VideoUrl = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsFeatured = table.Column<bool>(type: "INTEGER", nullable: false)
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
                    PasswordHash = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Role = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "DateAdded", "Description", "Director", "Genre", "ImageUrl", "IsFeatured", "ReleaseYear", "Title", "VideoUrl" },
                values: new object[] { 1, DateTime.Now, "This is a sample movie description.", "Director Name", "Action", "/images/sample1.jpg", true, 2021, "Sample Movie 1", "https://sample-videos.com/video123/mp4/720/big_buck_bunny_720p_1mb.mp4" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "DateAdded", "Description", "Director", "Genre", "ImageUrl", "IsFeatured", "ReleaseYear", "Title", "VideoUrl" },
                values: new object[] { 2, DateTime.Now, "Another sample movie description.", "Another Director", "Comedy", "/images/sample2.jpg", false, 2020, "Sample Movie 2", "https://sample-videos.com/video123/mp4/720/big_buck_bunny_720p_1mb.mp4" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateCreated", "PasswordHash", "Role", "Username" },
                values: new object[] { 1, DateTime.Now, "AQAAAAEAACcQAAAAEKXG5dqDuBMy0f+3xLm0ngxkGtGE6ZFZi99Qj1SgCaKkVY6AUGPgUKrm6BdnRZZ13w==", "Admin", "admin" });
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
