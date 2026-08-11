using System.Text.Json;
using System.Text.Json.Serialization;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Services;

public static class OrderService
{
    public static async Task ListOrdersAndMenuItems(int reservationId, JsonSerializerOptions options)
    {
        var orders = await OrderRepository.ListOrdersAndMenuItems(reservationId);
        foreach (var order in orders)
        {
            Console.WriteLine(JsonSerializer.Serialize(order, options));
        }
    }
    
    public static async Task ListOrderedAndMenuItems(int reservationId, JsonSerializerOptions options)
    {
        var orders = await OrderRepository.ListOrderedAndMenuItems(reservationId);
        foreach (var order in orders)
        {
            Console.WriteLine(JsonSerializer.Serialize(order, options));
        }
    }
}