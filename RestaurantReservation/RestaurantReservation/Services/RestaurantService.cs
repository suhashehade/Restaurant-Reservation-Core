using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Services;

public static class RestaurantService
{
    public static async Task<decimal?> GetRestaurantRevenue(int restaurantId)
    {
        return await RestaurantRepository.CalculateRestaurantRevenue(restaurantId);
    }
}