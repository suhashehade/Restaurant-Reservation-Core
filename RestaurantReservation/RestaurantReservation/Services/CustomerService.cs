using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Services;

public static class CustomerService
{
    public static async Task<List<CustomerReservationResult>> FindCustomersByPartySize(int partySize)
    {
        return await CustomerRepository.FindCustomersByPartySize(partySize);
    }
}