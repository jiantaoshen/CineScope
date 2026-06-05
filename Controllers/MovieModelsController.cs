
using CineScope.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class MovieModelsController : Controller
{
    private readonly CineScopeContext _context;

    public MovieModelsController(CineScopeContext context)
    {
        _context = context;
    }

    // GET: MOVIEMODELS
    public async Task<IActionResult> Index(string searchString, string genre, int page = 1)
    {
        int pageSize = 10;

        var moviesQuery = _context.MovieModel.AsQueryable();

        // SEARCH by title
        if (!string.IsNullOrEmpty(searchString))
        {
            moviesQuery = moviesQuery
                .Where(m => m.Title.Contains(searchString));
        }

        // FILTER by genre
        if (!string.IsNullOrEmpty(genre))
        {
            moviesQuery = moviesQuery
                .Where(m => m.Genre == genre);
        }

        // Get all genres for dropdown
        ViewBag.Genres = await _context.MovieModel
            .Select(m => m.Genre)
            .Distinct()
            .ToListAsync();

        int totalMovies = await moviesQuery.CountAsync();

        var movies = await moviesQuery
            .OrderBy(m => m.Title)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        ViewBag.Page = page;
        ViewBag.TotalPages = (int)Math.Ceiling(totalMovies / (double)pageSize);

        ViewBag.SearchString = searchString;
        ViewBag.SelectedGenre = genre;

        return View(movies);
    }



    // GET: MOVIEMODELS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var moviemodel = await _context.MovieModel
            .FirstOrDefaultAsync(m => m.Id == id);
        if (moviemodel == null)
        {
            return NotFound();
        }

        return View(moviemodel);
    }

    // GET: MOVIEMODELS/Create
    [Authorize(Roles = "Admin")]
    public IActionResult Create()
    {
        return View();
    }

    // POST: MOVIEMODELS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create([Bind("Id,Title,Genre,Description,ReleaseYear,Rating,Duration,PosterUrl")] MovieModel moviemodel)
    {
        if (ModelState.IsValid)
        {
            _context.Add(moviemodel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(moviemodel);
    }

    // GET: MOVIEMODELS/Edit/5
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var moviemodel = await _context.MovieModel.FindAsync(id);
        if (moviemodel == null)
        {
            return NotFound();
        }
        return View(moviemodel);
    }

    // POST: MOVIEMODELS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Title,Genre,Description,ReleaseYear,Rating,Duration,PosterUrl")] MovieModel moviemodel)
    {
        if (id != moviemodel.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(moviemodel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieModelExists(moviemodel.Id))
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
        return View(moviemodel);
    }

    // GET: MOVIEMODELS/Delete/5
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var moviemodel = await _context.MovieModel
            .FirstOrDefaultAsync(m => m.Id == id);
        if (moviemodel == null)
        {
            return NotFound();
        }

        return View(moviemodel);
    }

    // POST: MOVIEMODELS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var moviemodel = await _context.MovieModel.FindAsync(id);
        if (moviemodel != null)
        {
            _context.MovieModel.Remove(moviemodel);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool MovieModelExists(int? id)
    {
        return _context.MovieModel.Any(e => e.Id == id);
    }
}
