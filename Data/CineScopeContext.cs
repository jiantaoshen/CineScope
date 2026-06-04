using CineScope.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class CineScopeContext: IdentityDbContext<ApplicationUser>
{
    public CineScopeContext(DbContextOptions<CineScopeContext> options): base(options)
    {
    }

    public DbSet<CineScope.Models.MovieModel> MovieModel { get; set; } = default!;
}
