using System.Text.Json;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Services;

public static class EmployeeService
{
    public static async Task ListAllManagers(JsonSerializerOptions options)
    {
        var managers = await EmployeeRepository.ListManagers();
        foreach (var manager in managers)
        {
            Console.WriteLine(JsonSerializer.Serialize(manager, options));
        }
    }
    
}