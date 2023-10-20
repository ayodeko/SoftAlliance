using SoftAlliance.Data;
using SoftAlliance.Entities;

namespace SoftAlliance.Services;

public class MovieServices : IMovieService
{
    private readonly IMovieRepository repo;

    public MovieServices(IMovieRepository _repo)
    {
        repo = _repo;
    }
    public Response AddMovie(Movie movie)
    {
        try
        {
            repo.Add(movie);
            return GetResponse();
        }
        catch (Exception ex)
        {
            return GetErrorResponse(ex);
        }
    }

    public Response UpdateMovie(Movie movie)
    {
        try
        {
            repo.Update(movie);
            return GetResponse();
        }
        catch (Exception ex)
        {
            return GetErrorResponse(ex);
        }
    }

    public Response GetAllMovies()
    {
        try
        {
            return GetResponse(repo.GetAllMovies());
        }
        catch (Exception ex)
        {
            return GetErrorResponse(ex);
        }
    }

    public Response GetMovieById(string id)
    {
        try
        {
            return GetResponse(repo.GetById(id));
        }
        catch (Exception ex)
        {
            return GetErrorResponse(ex);
        }
    }

    public Response DeleteMovie(string movieId)
    {
        try
        {
            repo.Delete(movieId);
            return GetResponse();
        }
        catch (Exception ex)
        {
            return GetErrorResponse(ex);
        }
    }

    void Log()
    {
        //Loggin Implementation
    }

    void LogError(Exception ex)
    {
     //Exception Logging implementation   
    }
    Response GetErrorResponse(Exception ex)
    {
        LogError(ex);
        return new Response()
        {
            ResponseCode = "-1",
            ResponseMessage = ex.Message
        };
    }
        Response GetResponse(object? input = null)
        {
            return new Response()
            {
                ResponseCode = "00",
                Data = input
            };
        }
    
    
}
public class Response
{
    public string ResponseCode { get; set; }
    public string ResponseMessage { get; set; }
    public object? Data { get; set; }
}