namespace CleanMovie.Domain;

public class Movie
{
    public int movieId { get; set; } 
    public string movieName { get; set; }=string.Empty;
    public string movieDescription { get; set; } = string.Empty;
    public decimal moviePrice { get; set; }
    public int rentalDuration { get; set; }

    //Many to many Relationship
    public IList<MovieRental> movieRentals { get; set; }
    public bool isDeleted { get; set; }
    public DateTime? createdAt { get; set; }
    public DateTime? updatedAt { get; set; }
}