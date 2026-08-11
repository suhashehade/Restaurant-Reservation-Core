using System.Text.Json;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Services;

public static class RestaurantService
{
    public static async Task GetRestaurantRevenue(int restaurantId, JsonSerializerOptions options)
    {
        decimal revenue = await RestaurantRepository.CalculateRestaurantRevenue(restaurantId);
        Console.WriteLine(JsonSerializer.Serialize(revenue, options));
    }
}