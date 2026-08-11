using System.Text.Json;
using RestaurantReservation.Services;

namespace RestaurantReservation.Handlers;

public static class MenuItemHandler
{
    public static async Task ListOrderedAndMenuItems(int reservationId, JsonSerializerOptions options)
    {
        Console.WriteLine($"Find the menu items ordered in that specific reservation {reservationId} along with the associated menu items.");
        var menuItems = await MenuItemService.ListOrderedAndMenuItems(reservationId);
        foreach (var menuItem in menuItems)
        {
            Console.WriteLine(JsonSerializer.Serialize(menuItem, options));
        }
        Console.WriteLine("------------------------------------");
    }
}