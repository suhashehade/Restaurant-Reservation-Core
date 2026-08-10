using RestaurantReservation.Db.Repositories;
using RestaurantReservation.Services;

namespace RestaurantReservation;

public static class Program
{
    private static readonly int CustomerId = 1;
    public static async Task Main(string[] args)
    {  
      
       Console.WriteLine("List of all Managers:");
       await EmployeeService.ListAllManagers();
       Console.WriteLine("------------------------------------");
      
    }
}