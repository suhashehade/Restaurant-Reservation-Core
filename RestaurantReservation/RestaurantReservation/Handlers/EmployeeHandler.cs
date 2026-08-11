using System.Text.Json;
using RestaurantReservation.Services;

namespace RestaurantReservation.Handlers;

public static class EmployeeHandler
{
    public static async Task ListAllManagers(JsonSerializerOptions options)
    {
        Console.WriteLine("List of all Managers:");
        var managers = await EmployeeService.ListAllManagers();
        foreach (var manager in managers)
        {
            Console.WriteLine(JsonSerializer.Serialize(manager, options));
        }
        Console.WriteLine("------------------------------------");
    }
    
    public static async Task CalculateAverageOrderAmount(int employeeId, JsonSerializerOptions options)
    {
        Console.WriteLine($"Calculates the average order amount for that specific employee {employeeId} along with the associated menu items.");
        var average = await EmployeeService.CalculateAverageOrderAmount(employeeId);
        Console.WriteLine(average);
        Console.WriteLine("------------------------------------");
    }
    
    public static async Task ListEmployeesDetails(JsonSerializerOptions options)
    {
        Console.WriteLine($"View that lists all employees with their respective restaurant details from a database view");
        var employeeDetailsList = await EmployeeService.ListEmployeesDetails();
        foreach (var employee in employeeDetailsList)
        {
            Console.WriteLine(JsonSerializer.Serialize(employee, options));
        }
        Console.WriteLine("------------------------------------");
    }
}