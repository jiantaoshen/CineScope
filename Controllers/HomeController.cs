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

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Movies()
        {
            var movies = await _context.MovieModel.ToListAsync();

            return View(movies);
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
