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
            var featuredMovies = await _context.Movies
                .Where(m => m.IsFeatured)
                .OrderBy(m => m.Id)  // Add order by to avoid unpredictable results
                .Take(6)
                .AsNoTracking()
                .ToListAsync();

            var recentMovies = await _context.Movies
                .OrderByDescending(m => m.DateAdded ?? DateTime.MinValue)
                .Take(6)
                .AsNoTracking()
                .ToListAsync();

            var featuredTvSeries = await _context.TvSeries
                .Where(t => t.IsFeatured)
                .OrderBy(t => t.Id)  // Add order by to avoid unpredictable results
                .Take(6)
                .AsNoTracking()
                .ToListAsync();

            var recentTvSeries = await _context.TvSeries
                .OrderByDescending(t => t.DateAdded ?? DateTime.MinValue)
                .Take(6)
                .AsNoTracking()
                .ToListAsync();

            ViewData["FeaturedMovies"] = featuredMovies;
            ViewData["RecentMovies"] = recentMovies;
            ViewData["FeaturedTvSeries"] = featuredTvSeries;
            ViewData["RecentTvSeries"] = recentTvSeries;

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