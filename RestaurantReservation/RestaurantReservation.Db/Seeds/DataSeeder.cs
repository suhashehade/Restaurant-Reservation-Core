using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Seeds;

public static class DataSeeder
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
#pragma warning disable IL2066
        modelBuilder.Entity<Restaurant>().HasData(
#pragma warning restore IL2066
            new Restaurant { RestaurantId = 1, Name = "La Bella Italia", Address = "Downtown St 10", PhoneNumber = "0599111111", OpeningHours = "08:00 AM - 11:00 PM" },
            new Restaurant { RestaurantId = 2, Name = "Sultan Shawarma", Address = "Main Street 45", PhoneNumber = "0599222222", OpeningHours = "10:00 AM - 02:00 AM" },
            new Restaurant { RestaurantId = 3, Name = "Burger Factory", Address = "University Rd 12", PhoneNumber = "0599333333", OpeningHours = "11:00 AM - 12:00 AM" },
            new Restaurant { RestaurantId = 4, Name = "Seafood Haven", Address = "Beach Avenue 5", PhoneNumber = "0599444444", OpeningHours = "01:00 PM - 11:30 PM" },
            new Restaurant { RestaurantId = 5, Name = "Al-Quds Traditional", Address = "Old City 88", PhoneNumber = "0599555555", OpeningHours = "07:00 AM - 10:00 PM" }
        );
        
#pragma warning disable IL2066
        modelBuilder.Entity<Employee>().HasData(
#pragma warning restore IL2066
            new Employee { EmployeeId = 1, RestaurantId = 1, FirstName = "Ahmad", LastName = "Al-Sayed", Position = "Manager" },
            new Employee { EmployeeId = 2, RestaurantId = 1, FirstName = "Sami", LastName = "Shadi", Position = "Waiter" },
            new Employee { EmployeeId = 3, RestaurantId = 2, FirstName = "Omar", LastName = "Nasser", Position = "Manager" },
            new Employee { EmployeeId = 4, RestaurantId = 3, FirstName = "Laila", LastName = "Hassan", Position = "Chef" },
            new Employee { EmployeeId = 5, RestaurantId = 4, FirstName = "Khaled", LastName = "Mansour", Position = "Waiter" }
        );
        
#pragma warning disable IL2066
        modelBuilder.Entity<Customer>().HasData(
#pragma warning restore IL2066
            new Customer { CustomerId = 1, FirstName = "Tariq", LastName = "Ziyad", Email = "tariq@example.com", PhoneNumber = "0569111111" },
            new Customer { CustomerId = 2, FirstName = "Yara", LastName = "Ali", Email = "yara@example.com", PhoneNumber = "0569222222" },
            new Customer { CustomerId = 3, FirstName = "Fadi", LastName = "Saleh", Email = "fadi@example.com", PhoneNumber = "0569333333" },
            new Customer { CustomerId = 4, FirstName = "Mona", LastName = "Ibrahim", Email = "mona@example.com", PhoneNumber = "0569444444" },
            new Customer { CustomerId = 5, FirstName = "Zaid", LastName = "Qasim", Email = "zaid@example.com", PhoneNumber = "0569555555" }
        );
        
#pragma warning disable IL2066
        modelBuilder.Entity<Table>().HasData(
#pragma warning restore IL2066
            new Table { TableId = 1, RestaurantId = 1, Capacity = 4 },
            new Table { TableId = 2, RestaurantId = 1, Capacity = 6 },
            new Table { TableId = 3, RestaurantId = 2, Capacity = 2 },
            new Table { TableId = 4, RestaurantId = 3, Capacity = 8 },
            new Table { TableId = 5, RestaurantId = 4, Capacity = 4 }
        );
        
#pragma warning disable IL2066
        modelBuilder.Entity<MenuItem>().HasData(
#pragma warning restore IL2066
            new MenuItem { ItemId = 1, RestaurantId = 1, Name = "Margherita Pizza", Description = "Classic cheese pizza", Price = 12.50m },
            new MenuItem { ItemId = 2, RestaurantId = 1, Name = "Pasta Carbonara", Description = "Creamy sauce pasta", Price = 15.00m },
            new MenuItem { ItemId = 3, RestaurantId = 2, Name = "Super Shawarma Plate", Description = "Beef shawarma with fries", Price = 10.00m },
            new MenuItem { ItemId = 4, RestaurantId = 3, Name = "Double Cheese Burger", Description = "Beef burger with extra cheese", Price = 11.00m },
            new MenuItem { ItemId = 5, RestaurantId = 4, Name = "Grilled Salmon", Description = "Fresh salmon with lemon butter", Price = 25.00m }
        );
        
#pragma warning disable IL2066
        modelBuilder.Entity<Reservation>().HasData(
#pragma warning restore IL2066
            new Reservation { ReservationId = 1, CustomerId = 1, RestaurantId = 1, TableId = 1, ReservationDate = new DateTime(2026, 8, 15, 19, 0, 0), PartySize = 4 },
            new Reservation { ReservationId = 2, CustomerId = 1, RestaurantId = 1, TableId = 2, ReservationDate = new DateTime(2026, 8, 20, 20, 0, 0), PartySize = 6 },
            new Reservation { ReservationId = 3, CustomerId = 2, RestaurantId = 2, TableId = 3, ReservationDate = new DateTime(2026, 8, 16, 13, 0, 0), PartySize = 2 },
            new Reservation { ReservationId = 4, CustomerId = 3, RestaurantId = 3, TableId = 4, ReservationDate = new DateTime(2026, 8, 18, 18, 30, 0), PartySize = 8 },
            new Reservation { ReservationId = 5, CustomerId = 4, RestaurantId = 4, TableId = 5, ReservationDate = new DateTime(2026, 8, 19, 21, 0, 0), PartySize = 3 }
        );
        
#pragma warning disable IL2066
        modelBuilder.Entity<Order>().HasData(
#pragma warning restore IL2066
            new Order { OrderId = 1, ReservationId = 1, EmployeeId = 1, OrderDate = new DateTime(2026, 8, 15, 19, 15, 0), TotalAmount = 40.00m },
            new Order { OrderId = 2, ReservationId = 1, EmployeeId = 1, OrderDate = new DateTime(2026, 8, 15, 20, 00, 0), TotalAmount = 15.00m },
            new Order { OrderId = 3, ReservationId = 2, EmployeeId = 2, OrderDate = new DateTime(2026, 8, 20, 20, 15, 0), TotalAmount = 60.00m },
            new Order { OrderId = 4, ReservationId = 3, EmployeeId = 3, OrderDate = new DateTime(2026, 8, 16, 13, 20, 0), TotalAmount = 20.00m },
            new Order { OrderId = 5, ReservationId = 4, EmployeeId = 4, OrderDate = new DateTime(2026, 8, 18, 19, 00, 0), TotalAmount = 88.00m }
        );
        
#pragma warning disable IL2066
        modelBuilder.Entity<OrderItem>().HasData(
#pragma warning restore IL2066
            new OrderItem { OrderItemId = 1, OrderId = 1, ItemId = 1, Quantity = 2 },
            new OrderItem { OrderItemId = 2, OrderId = 1, ItemId = 2, Quantity = 1 },
            new OrderItem { OrderItemId = 3, OrderId = 2, ItemId = 2, Quantity = 1 },
            new OrderItem { OrderItemId = 4, OrderId = 3, ItemId = 3, Quantity = 2 },
            new OrderItem { OrderItemId = 5, OrderId = 5, ItemId = 4, Quantity = 8 }
        );
    }
}