
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASPNET_Core_MVC.Data;
using ASPNET_Core_MVC.Models;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace ASPNET_Core_MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly MovieDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminController(MovieDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Admin
        public async Task<IActionResult> Index()
        {
            return View(await _context.Movies.ToListAsync());
        }

        // GET: Admin/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description,Director,Genre,ReleaseYear,ImageUrl,VideoUrl,IsFeatured")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                movie.DateAdded = DateTime.Now;
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Admin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Director,Genre,ReleaseYear,ImageUrl,VideoUrl,IsFeatured,DateAdded")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Admin/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }

        // TV Series Management
        // GET: Admin/TvSeries
        public async Task<IActionResult> TvSeries()
        {
            return View(await _context.TvSeries.ToListAsync());
        }

        // GET: Admin/CreateTvSeries
        public IActionResult CreateTvSeries()
        {
            return View();
        }

        // POST: Admin/CreateTvSeries
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTvSeries([Bind("Title,Description,Creator,Genre,StartYear,EndYear,ImageUrl,IsFeatured")] TvSeries tvSeries)
        {
            if (ModelState.IsValid)
            {
                tvSeries.DateAdded = DateTime.Now;
                _context.Add(tvSeries);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(TvSeries));
            }
            return View(tvSeries);
        }

        // GET: Admin/EditTvSeries/5
        public async Task<IActionResult> EditTvSeries(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tvSeries = await _context.TvSeries.FindAsync(id);
            if (tvSeries == null)
            {
                return NotFound();
            }
            return View(tvSeries);
        }

        // POST: Admin/EditTvSeries/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTvSeries(int id, [Bind("Id,Title,Description,Creator,Genre,StartYear,EndYear,ImageUrl,IsFeatured,DateAdded")] TvSeries tvSeries)
        {
            if (id != tvSeries.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tvSeries);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TvSeriesExists(tvSeries.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(TvSeries));
            }
            return View(tvSeries);
        }

        // GET: Admin/DeleteTvSeries/5
        public async Task<IActionResult> DeleteTvSeries(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tvSeries = await _context.TvSeries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tvSeries == null)
            {
                return NotFound();
            }

            return View(tvSeries);
        }

        // POST: Admin/DeleteTvSeries/5
        [HttpPost, ActionName("DeleteTvSeries")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteTvSeriesConfirmed(int id)
        {
            var tvSeries = await _context.TvSeries.FindAsync(id);
            _context.TvSeries.Remove(tvSeries);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(TvSeries));
        }

        private bool TvSeriesExists(int id)
        {
            return _context.TvSeries.Any(e => e.Id == id);
        }
    }
}
