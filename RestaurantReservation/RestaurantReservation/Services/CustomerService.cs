using System.Text.Json;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Services;

public static class CustomerService
{
    public static async Task FindCustomersByPartySize(int partySize, JsonSerializerOptions options)
    {
        var customers = await CustomerRepository.FindCustomersByPartySize(partySize);
        foreach (var customer in customers)
        {
            Console.WriteLine(JsonSerializer.Serialize(customer, options));
        }
    }
}