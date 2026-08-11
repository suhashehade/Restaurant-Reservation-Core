namespace RestaurantReservation.Db.Models;

public class ReservationDetails
{
    public int ReservationId { get; set; }
    public DateTime ReservationDate { get; set; }
    public int NumberOfGuests { get; set; }

    public int CustomerId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string CustomerEmail { get; set; } = string.Empty;

    public int RestaurantId { get; set; }
    public string RestaurantName { get; set; } = string.Empty;
}