using System.Text.Json;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Services;

public static class MenuItemService
{
    public static async Task ListOrderedAndMenuItems(int reservationId, JsonSerializerOptions options)
    {
        var menuItems = await OrderRepository.ListOrderedAndMenuItems(reservationId);
        foreach (var menuItem in menuItems)
        {
            Console.WriteLine(JsonSerializer.Serialize(menuItem, options));
        }
    }
}