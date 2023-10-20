using SoftAlliance.Entities;

namespace SoftAlliance.Data;

public interface IMovieRepository
{
    void Add(Movie movie);
    void Update(Movie movie);
    void Delete(string movieId);
    Movie GetById(string movieId);
    List<Movie>? GetAllMovies();
}