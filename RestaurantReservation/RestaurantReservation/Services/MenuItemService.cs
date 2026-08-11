using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Services;

public static class MenuItemService
{
    public static async Task<List<MenuItem>> ListOrderedAndMenuItems(int reservationId)
    {
        return await MenuItemRepository.ListOrderedAndMenuItems(reservationId);
    }
}