namespace CleanMovie.Domain;

 public class Rental
    {
        public int rentalId { get; set; }
        public DateTime? rentalDate { get; set;}
        public DateTime? rentalExpiry { get; set; }
        public decimal? rentalPrice { get; set;}

        //One to many Relationship
        public ICollection<Member> Members { get; set; }
        public IList<MovieRental> movieRentals { get; set; }
        public bool isDeleted { get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }

       
    }