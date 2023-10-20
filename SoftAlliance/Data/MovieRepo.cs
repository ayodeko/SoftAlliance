using Microsoft.EntityFrameworkCore;
using SoftAlliance.Entities;
using SoftAlliance.Utilities;

namespace SoftAlliance.Data;

public class MovieRepo : IMovieRepository
{
    private MovieContext context;

    public MovieRepo(MovieContext dbcontext)
    {
        context = dbcontext;
    }
    public void Add(Movie movie)
    {
        context.Movies.Add(movie);
        context.SaveChanges();
    }

    public void Update(Movie movie)
    {
        var existingMovie = context.Movies.FirstOrDefault(x => x.Id == movie.Id);
        if (existingMovie == null) throw new Exception("Movie not found");
        context.Movies.Update(movie);
        context.SaveChanges();
    }

    public void Delete(string movieId)
    {
        var existingMovie = context.Movies.FirstOrDefault(x => x.Id == movieId);
        if (existingMovie == null) throw new Exception("Movie not found");
        context.Movies.Remove(existingMovie);
        context.SaveChanges();
    }

    public Movie GetById(string movieId)
    {
        var movie = context.Movies.FirstOrDefault(x => x.Id == movieId);
        if (movie == null) throw new Exception("Movie not found");
        return movie;
    }

    public List<Movie>? GetAllMovies()
    {
        return context.Movies.ToList();
    }
}