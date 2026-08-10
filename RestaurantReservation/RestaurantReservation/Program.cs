using System.Text.Json;
using System.Text.Json.Serialization;
using RestaurantReservation.Db.Repositories;
using RestaurantReservation.Services;

namespace RestaurantReservation;

public static class Program
{
    private static readonly int CustomerId = 1;
    private static readonly int ReservationId = 1;
    public static async Task Main(string[] args)
    {  
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            ReferenceHandler = ReferenceHandler.IgnoreCycles 
        };
        
       Console.WriteLine("List of all Managers:");
       await EmployeeService.ListAllManagers(options);
       Console.WriteLine("------------------------------------");
       
       Console.WriteLine($"Get Reservations By CustomerId: {CustomerId}");
       await ReservationService.GetReservationsByCustomerId(CustomerId, options);
       Console.WriteLine("------------------------------------");
       
       Console.WriteLine($"Lists the orders placed on that specific reservation {ReservationId} along with the associated menu items.");
       await OrderService.ListOrdersAndMenuItems(ReservationId, options);
       Console.WriteLine("------------------------------------");
    }
}