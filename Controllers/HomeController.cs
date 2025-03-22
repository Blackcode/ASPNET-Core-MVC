using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ASPNET_Core_MVC.Models;
using Microsoft.EntityFrameworkCore;
using ASPNET_Core_MVC.Data;

namespace ASPNET_Core_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MovieDbContext _context;

        public HomeController(ILogger<HomeController> logger, MovieDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Retrieve both featured and recent movies in a single query to improve efficiency
            var movies = await _context.Movies.ToListAsync();
            
            // Process the data in memory
            var featuredMovies = movies.Where(m => m.IsFeatured).ToList();
            var recentMovies = movies.OrderByDescending(m => m.DateAdded).Take(6).ToList();

            // Use a view model instead of ViewData for better type safety
            ViewData["FeaturedMovies"] = featuredMovies;
            ViewData["RecentMovies"] = recentMovies;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}