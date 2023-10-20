using SoftAlliance.Entities;

namespace SoftAlliance.Services;

public interface IMovieService
{
    Response AddMovie(Movie movie);
    Response UpdateMovie(Movie movie);
    Response GetAllMovies();
    Response GetMovieById(string id);
    Response DeleteMovie(string movieId);
}