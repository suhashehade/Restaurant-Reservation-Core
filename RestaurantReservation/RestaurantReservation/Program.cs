using System.Text.Json;
using System.Text.Json.Serialization;
using RestaurantReservation.Handlers;
using RestaurantReservation.Services;

namespace RestaurantReservation;

public static class Program
{
    private static readonly int CustomerId = 1;
    private static readonly int ReservationId = 1;
    private static readonly int EmployeeId = 1;
    private static readonly int RestaurantId = 1;
    private static readonly int PartySize = 1;
    public static async Task Main(string[] args)
    {  
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            ReferenceHandler = ReferenceHandler.IgnoreCycles 
        };
        
       await EmployeeHandler.ListAllManagers(options);
       
       await ReservationHandler.GetReservationsByCustomerId(CustomerId, options);
       
       await ReservationHandler.ListOrdersAndMenuItems(ReservationId, options);
       
       await ReservationHandler.ListOrderedAndMenuItems(ReservationId, options);
       
       await EmployeeHandler.CalculateAverageOrderAmount(EmployeeId, options);
       
       await ReservationHandler.GetReservationDetails();
       
       await EmployeeHandler.ListEmployeesDetails(options);
       
       await RestaurantHandler.GetRestaurantRevenue(RestaurantId, options);
       
       await CustomerHandler.FindCustomersByPartySize(PartySize, options);

    }
}