using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ASPNET_Core_MVC.Data;
using ASPNET_Core_MVC.Models;

namespace ASPNET_Core_MVC.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieDbContext _context;
        private readonly ILogger<MoviesController> _logger;

        public MoviesController(MovieDbContext context, ILogger<MoviesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            // Add caching if movies don't change frequently
            return View(await _context.Movies.AsNoTracking().OrderBy(m => m.Id).ToListAsync());
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var movie = await _context.Movies
                    .AsNoTracking() // Use AsNoTracking for read-only operations
                    .FirstOrDefaultAsync(m => m.Id == id.Value);

                if (movie == null)
                {
                    return NotFound();
                }

                return View(movie);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, $"Error retrieving movie with ID {id}");
                return StatusCode(500, "An error occurred while retrieving the movie details");
            }
        }

        // GET: Movies/Watch/5
        public async Task<IActionResult> Watch(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }
    }
}