using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Services;

public static class OrderService
{
    public static async Task<List<Order>> ListOrdersAndMenuItems(int reservationId)
    {
        return  await OrderRepository.ListOrdersAndMenuItems(reservationId);
    }
}