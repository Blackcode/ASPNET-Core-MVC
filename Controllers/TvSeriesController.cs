
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
    public class TvSeriesController : Controller
    {
        private readonly MovieDbContext _context;
        private readonly ILogger<TvSeriesController> _logger;

        public TvSeriesController(MovieDbContext context, ILogger<TvSeriesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: TvSeries
        public async Task<IActionResult> Index()
        {
            return View(await _context.TvSeries.AsNoTracking().OrderBy(t => t.Id).ToListAsync());
        }

        // GET: TvSeries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                // First check if the series exists
                var tvSeries = await _context.TvSeries
                    .AsNoTracking()
                    .FirstOrDefaultAsync(m => m.Id == id.Value);

                if (tvSeries == null)
                {
                    return NotFound();
                }

                // Then load episodes in a separate query for better performance
                var episodes = await _context.Episodes
                    .Where(e => e.TvSeriesId == id.Value)
                    .OrderBy(e => e.SeasonNumber)
                    .ThenBy(e => e.EpisodeNumber)
                    .AsNoTracking()
                    .ToListAsync();
                
                tvSeries.Episodes = episodes;

                return View(tvSeries);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving TV series with ID {id}");
                return StatusCode(500, "An error occurred while retrieving TV series details");
            }
        }

        // GET: TvSeries/Watch/5 (Episode ID)
        public async Task<IActionResult> Watch(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var episode = await _context.Episodes
                .Include(e => e.TvSeries)
                .FirstOrDefaultAsync(e => e.Id == id);
                
            if (episode == null)
            {
                return NotFound();
            }

            // Get next episode if available
            var nextEpisode = await _context.Episodes
                .Where(e => e.TvSeriesId == episode.TvSeriesId && 
                           ((e.SeasonNumber == episode.SeasonNumber && e.EpisodeNumber > episode.EpisodeNumber) ||
                            (e.SeasonNumber > episode.SeasonNumber)))
                .OrderBy(e => e.SeasonNumber)
                .ThenBy(e => e.EpisodeNumber)
                .FirstOrDefaultAsync();

            ViewData["NextEpisodeId"] = nextEpisode?.Id;

            return View(episode);
        }

        // GET: TvSeries/Season/5?season=1
        public async Task<IActionResult> Season(int? id, int season)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tvSeries = await _context.TvSeries
                .Include(t => t.Episodes.Where(e => e.SeasonNumber == season)
                               .OrderBy(e => e.EpisodeNumber))
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id.Value);

            if (tvSeries == null)
            {
                return NotFound();
            }

            ViewData["SeasonNumber"] = season;
            return View(tvSeries);
        }

        // GET: TvSeries/Genre/Drama
        public async Task<IActionResult> Genre(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction(nameof(Index));
            }

            var tvSeries = await _context.TvSeries
                .Where(t => t.Genre == id)
                .ToListAsync();

            ViewData["GenreName"] = id;
            return View(tvSeries);
        }
    }
}
