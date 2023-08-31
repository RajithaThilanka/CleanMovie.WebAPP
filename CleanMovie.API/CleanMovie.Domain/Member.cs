namespace CleanMovie.Domain;

public class Member
{
    public int memberId { get; set; }
    public string firstName { get; set; }=string.Empty;
    public string lastName { get; set; } = string.Empty;    
    public string email { get; set; } = string.Empty;
    public int rentalId { get; set; }  
    public Rental Rental { get; set; }  
    public bool isDeleted { get; set; }
    public DateTime? createdAt { get; set; }
    public DateTime? updatedAt { get; set; }


}