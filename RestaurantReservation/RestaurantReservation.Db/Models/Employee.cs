namespace RestaurantReservation.Db.Models;

public class Employee
{
    public int EmployeeId { get; set; }
    public int RestaurantId { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Position { get; set; }
    
    public Restaurant? Restaurant { get; set; }
    
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}