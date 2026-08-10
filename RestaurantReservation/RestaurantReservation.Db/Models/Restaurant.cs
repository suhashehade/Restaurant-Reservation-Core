using System.Collections.Generic;

namespace RestaurantReservation.Db.Models;

public class Restaurant
{
    public int RestaurantId { get; set; }
    public required string Name { get; set; }
    public required string Address { get; set; }
    public required string PhoneNumber { get; set; }
    public required string OpeningHours { get; set; }
    
    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    public ICollection<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
    public ICollection<Table> Tables { get; set; } = new List<Table>();
    public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}