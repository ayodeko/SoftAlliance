using System.ComponentModel.DataAnnotations;

namespace SoftAlliance.Entities;

public class Movie
{
    public Movie()
    {
        Id = Guid.NewGuid().ToString();
        Genres = new List<Genre>();
    }
    public string Id { get; set; }
    [Required()]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public DateTime ReleaseDate { get; set; }
    [Range(1,5, ErrorMessage = "The rating must be between 1 and 5")]
    public int Rating { get; set; }
    [Required]
    public double TicketPrice { get; set; }
    [Required]
    public string Country { get; set; }
    [Required]
    public List<Genre> Genres { get; set; }
    [Required]
    public string Photo { get; set; }

}


public class Genre
{
    public Genre()
    {
        Id = Guid.NewGuid().ToString();
    }
    public string Id { get; set; }
    public string Name { get; set; }
}
