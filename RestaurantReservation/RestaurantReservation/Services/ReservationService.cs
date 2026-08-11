using System.Text.Json;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Services;

public static class ReservationService
{
    public static async Task GetReservationsByCustomerId(int customerId, JsonSerializerOptions options)
    {
        var reservations = await ReservationRepository.GetReservationsByCustomer(customerId);
        foreach (var reservation in reservations)
        {
            Console.WriteLine(JsonSerializer.Serialize(reservation, options));
        }
    }
    
    public static async Task GetReservationDetails()
    {
        var reservations = await ReservationDetailsRepository.View_ReservationDetails();
        foreach (var reservation in reservations)
        {
            Console.WriteLine(
                $"Reservation: {reservation.ReservationId}, " +
                $"Customer: {reservation.CustomerName}, " +
                $"Restaurant: {reservation.RestaurantName}"
            );
        }
    }
}