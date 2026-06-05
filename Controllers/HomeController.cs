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
                .OrderByDescending(m => m.ReleaseYear)
                .Take(5)
                .ToListAsync();

            return View(latestMovies);
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
