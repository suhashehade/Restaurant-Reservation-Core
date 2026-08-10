using System.Text.Json;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Services;

public static class ReservationService
{
    public static async Task GetReservationsByCustomerId(int customerId)
    {
        var reservations = await ReservationRepository.GetReservationsByCustomer(customerId);
        foreach (var reservation in reservations)
        {
            Console.WriteLine(JsonSerializer.Serialize(reservation, new JsonSerializerOptions { WriteIndented = true }));
        }
    }
}