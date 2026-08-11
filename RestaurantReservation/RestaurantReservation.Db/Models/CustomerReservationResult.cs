namespace RestaurantReservation.Db.Models;

public class CustomerReservationResult
{
    public int CustomerId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}