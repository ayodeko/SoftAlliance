using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftAlliance.Data;
using SoftAlliance.Entities;
using SoftAlliance.Services;

namespace SoftAlliance.Utilities;

public static class BaseSetups
{
    public static IServiceCollection ConfigureBaseServices(this IServiceCollection services)
    {
        services.AddDbContext<MovieContext>(opt => opt.UseInMemoryDatabase("InMemory"));;
        services.AddScoped<IMovieRepository, MovieRepo>();
        services.AddScoped<IMovieService, MovieServices>();
        return services;
    }

    public static WebApplication ConfigureEndPoints(this WebApplication app)
    {
        app.MapPost("api/Movies/Add",
            ([FromServices] IMovieService movieService, Movie movie) => movieService.AddMovie(movie));
        app.MapPost("api/Movies/Update",
            ([FromServices] IMovieService movieService, Movie movie) => movieService.UpdateMovie(movie));
        app.MapPost("api/Movies/Delete",
            ([FromServices] IMovieService movieService, string id) => movieService.DeleteMovie(id));
        app.MapGet("api/Movies/GetById",
            ([FromServices] IMovieService movieService, string id) => movieService.GetMovieById(id));
        app.MapGet("api/Movies/GetAllMovies",
            ([FromServices] IMovieService movieService) => movieService.GetAllMovies());


        return app;
    }
}

public class MovieContext : DbContext{
    public MovieContext(DbContextOptions<MovieContext> context) : base(context)
    {
        
    }

    public DbSet<Movie> Movies { get; set; }
}