using System.Text.Json;
using RestaurantReservation.Services;

namespace RestaurantReservation.Handlers;

public static class CustomerHandler
{
    public static async Task FindCustomersByPartySize(int partySize, JsonSerializerOptions options)
    {
        Console.WriteLine($"Finding all customers who have made reservations with a party size greater than a certain value {partySize}");
        var customers = await CustomerService.FindCustomersByPartySize(partySize);
        foreach (var customer in customers)
        {
            Console.WriteLine(JsonSerializer.Serialize(customer, options));
        }
        
        Console.WriteLine("------------------------------------");
    }

}