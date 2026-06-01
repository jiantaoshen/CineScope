using CineScope.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CineScope.Controllers
{
    public class HomeController : Controller
    {

        private readonly CineScopeContext _context;

        public HomeController(CineScopeContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var latestMovies = await _context.MovieModel
                .OrderByDescending(m => m.Id) // or use CreatedDate if you have it
                .Take(5)
                .ToListAsync();

            return View(latestMovies);
        }

        public async Task<IActionResult> Movies(string searchString,string genre,int page = 1)
        {
            var query = _context.MovieModel.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(m => m.Title.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(genre))
            {
                query = query.Where(m => m.Genre == genre);
            }

            ViewBag.Genres = await _context.MovieModel
                .Select(m => m.Genre)
                .Distinct()
                .ToListAsync();

            return View(await query.ToListAsync());
        }

        public IActionResult Genres()
        {
            return View();
        }

        public IActionResult TVShows()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
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
