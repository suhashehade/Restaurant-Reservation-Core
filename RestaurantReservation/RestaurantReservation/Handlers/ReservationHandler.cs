using System.Text.Json;
using RestaurantReservation.Services;

namespace RestaurantReservation.Handlers;

public static class ReservationHandler
{
    public static async Task GetReservationsByCustomerId(int customerId, JsonSerializerOptions options)
    {
        Console.WriteLine($"Get Reservations By CustomerId: {customerId}");
        var reservations = await ReservationService.GetReservationsByCustomerId(customerId);
        foreach (var reservation in reservations)
        {
            Console.WriteLine(JsonSerializer.Serialize(reservation, options));
        }
        Console.WriteLine("------------------------------------");
    }
    
    public static async Task ListOrdersAndMenuItems(int reservationId, JsonSerializerOptions options)
    {
        Console.WriteLine($"Lists the orders placed on that specific reservation {reservationId} along with the associated menu items.");
        var orders = await ReservationService.ListOrdersAndMenuItems(reservationId);
        foreach (var order in orders)
        {
            Console.WriteLine(JsonSerializer.Serialize(order, options));
        }
        Console.WriteLine("------------------------------------");
    }
    
    public static async Task ListOrderedAndMenuItems(int reservationId, JsonSerializerOptions options)
    {
        Console.WriteLine($"Find the menu items ordered in that specific reservation {reservationId} along with the associated menu items.");
        var menuItems = await ReservationService.ListOrderedAndMenuItems(reservationId);
        foreach (var menuItem in menuItems)
        {
            Console.WriteLine(JsonSerializer.Serialize(menuItem, options));
        }
        Console.WriteLine("------------------------------------");
    }
    
    public static async Task GetReservationDetails()
    {
        Console.WriteLine($"View that lists all the reservations with their associated customer and restaurant information");
        var reservations = await ReservationService.GetReservationDetails();
        foreach (var reservation in reservations)
        {
            Console.WriteLine(
                $"Reservation: {reservation.ReservationId}, " +
                $"Customer: {reservation.CustomerName}, " +
                $"Restaurant: {reservation.RestaurantName}"
            );
        }
        Console.WriteLine("------------------------------------");
    }
}