namespace SoftAlliance.DTO;

public class MovieDTO
{
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public DateTime ReleaseDate { get; set; }

    public int Rating
    {
        get;
        set
        {
            if(value < 1 || value > 5)
                throw new ArgumentOutOfRangeException("Rating", "Rating should be between 1 and 5");
            
        }
    }

    public double TicketPrice { get; set; }
    
    public string Country { get; set; }
    
    public List<Genre> Genres { get; set; }
    
    public string Photo { get; set; }
}