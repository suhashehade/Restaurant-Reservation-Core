namespace RestaurantReservation.Db.Models;

public class EmployeeDetails
{
    public int EmployeeId  { get; set; } 
    public string FirstName  { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Position   { get; set; } = string.Empty;
    
    public int RestaurantId  { get; set; }
    public string RestaurantName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string OpeningHours { get; set; } = string.Empty;
}