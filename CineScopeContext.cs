using Microsoft.EntityFrameworkCore;

public class CineScopeContext(DbContextOptions<CineScopeContext> options) : DbContext(options)
{
    public DbSet<CineScope.Models.MovieModel> MovieModel { get; set; } = default!;
}
