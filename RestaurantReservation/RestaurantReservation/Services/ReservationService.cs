using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Services;

public static class ReservationService
{
    public static async Task<List<Reservation>> GetReservationsByCustomerId(int customerId)
    {
        return await ReservationRepository.GetReservationsByCustomer(customerId);
    }
    
    public static async Task<List<ReservationDetails>> GetReservationDetails()
    {
        return await ReservationDetailsRepository.View_ReservationDetails();
    }
}