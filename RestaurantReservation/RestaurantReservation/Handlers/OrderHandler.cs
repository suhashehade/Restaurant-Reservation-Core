using System.Text.Json;
using RestaurantReservation.Services;

namespace RestaurantReservation.Handlers;

public static class OrderHandler
{
    public static async Task ListOrdersAndMenuItems(int reservationId, JsonSerializerOptions options)
    {
        Console.WriteLine($"Lists the orders placed on that specific reservation {reservationId} along with the associated menu items.");
        var orders = await OrderService.ListOrdersAndMenuItems(reservationId);
        foreach (var order in orders)
        {
            Console.WriteLine(JsonSerializer.Serialize(order, options));
        }
        Console.WriteLine("------------------------------------");
    }
}