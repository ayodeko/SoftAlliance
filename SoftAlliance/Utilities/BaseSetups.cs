using Microsoft.EntityFrameworkCore;
using SoftAlliance.Entities;

namespace SoftAlliance.Utilities;

public static class BaseSetups
{
    public static IServiceCollection ConfigureBaseServices(this IServiceCollection services)
    {
        services.AddDbContext<MovieContext>();
        return services;
    }
}

public class MovieContext : DbContext{
    public MovieContext(DbContextOptions<MovieContext> context) : base(context)
    {
        
    }

    public DbSet<Movie> Movies { get; set; }
}